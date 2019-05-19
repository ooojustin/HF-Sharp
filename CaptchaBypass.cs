using HF_Sharp.Networking;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace HF_Sharp {

    /// <summary>
    /// Contains functions related to bypassing the HackForums captcha system.
    /// Implements the 2Captcha API for token generation.z
    /// </summary>
    public static class CaptchaBypass {

        private const string HACKFORUMS = "https://hackforums.net";

        /// <summary>
        /// Automatically bypasses HackForums captcha/cloudflare system.
        /// This should called immediately after initializing, if your program is running on a server.
        /// </summary>
        public static bool BypassCaptchaSystem(this HttpClient client, string _2captchApiKey) {

            // send a request to the API
            string response = client.ApiGet("?version");

            // check if we actually *need* to bypass the captcha
            if (!response.Contains("HackForums.net wants to verify that you're a human."))
                return true;

            // get the url we'll be submitting our bypass to
            string submitURL = GetActionURL(response);
            if (string.IsNullOrEmpty(submitURL)) return false;

            // get the value of 's'
            string s = GetValueS(response);
            if (string.IsNullOrEmpty(s)) return false;

            // get script data (data-raw and data-sitekey)
            Tuple<string, string> scriptData = GetScriptData(response);
            if (scriptData == null) return false;

            string ray = scriptData.Item1;
            string siteKey = scriptData.Item2;

            // use the _2Captcha class to get a valid token to bypass the captcha
            _2Captcha captcha = new _2Captcha(HACKFORUMS, siteKey, _2captchApiKey);
            string token = captcha.GetToken();
            if (token == null) return false;

            NameValueCollection queryString = HttpUtility.ParseQueryString(string.Empty);
            queryString["s"] = s;
            queryString["id"] = ray;
            queryString["g-recaptcha-response"] = token;

            string requestString = submitURL + "?" + queryString.ToString();

            _ = client.GetAsync(requestString).Result;

            return true;

        }

        private static string GetValueS(string response) {

            // use regular expressions to find the hidden field 's'
            Regex expressionS = new Regex("<input type=\"hidden\" name=\"s\" value=\".*?\">");
            Match matchS = expressionS.Match(response);
            if (!matchS.Success) return null;

            // expected count = 7
            string[] splitS = matchS.Value.Split('"');
            if (splitS.Count() != 7) return null;

            // index of 's' = 5
            return splitS[5];

        }

        private static Tuple<string, string> GetScriptData(string response) {

            // use regular expressions to find cf.challenge.js script tag
            Regex expressionScript = new Regex("<script type=\"text\\/javascript\" src=\"\\/cdn-cgi\\/scripts\\/cf.challenge.js\" data-type=\"normal\"  data-ray=\".*\" async data-sitekey=\".*\"><\\/script>");
            Match matchScript = expressionScript.Match(response);
            if (!matchScript.Success) return null;

            // expected count = 11
            string[] splitScript = matchScript.Value.Split('"');
            if (splitScript.Count() != 11) return null;

            // index of 'data-ray' = 7, 'data-sitekey' = 9
            return new Tuple<string, string>(splitScript[7], splitScript[9]);

        }

        private static string GetActionURL(string response) {

            // use regular expressions to find the 'form' tag
            Regex expressionPath = new Regex("<form class=\"challenge-form\" id=\"challenge-form\" action=\".*?\" method=\"get\">");
            Match matchPath = expressionPath.Match(response);
            if (!matchPath.Success) return null;

            // expected count = 5
            string[] splitPath = matchPath.Value.Split('"');
            if (splitPath.Count() != 9) return null;

            // index of 'action' (path) = 5
            return HACKFORUMS + splitPath[5];

        }

        class _2Captcha {

            private readonly HttpClient Client = new HttpClient() {
                BaseAddress = new Uri("http://2captcha.com/")
            };

            private string URL { get; set; }
            private string SiteKey { get; set; }
            private string ApiKey { get; set; }

            public _2Captcha(string url, string siteKey, string apiKey) {
                URL = url;
                SiteKey = siteKey;
                ApiKey = apiKey;
            }

            public string GetToken() {

                // create request to get a captcha token from the api
                string id = CreateRequest();
                if (string.IsNullOrEmpty(id)) return null;

                // wait 15 seconds before checking it for the first time
                Thread.Sleep(15000);

                // how many times to check again before timing out.
                // will wait 5 seconds between each check.
                int extraChecks = 10;

                for (int i = 0; i < extraChecks; i++) {

                    _2CaptchaResponse response = CheckRequest(id);

                    // if it's completed, return the 'Message', which will be the token
                    if (response.GetStatus()) return response.Message;

                    // if there was an error OR the request timed out (this was the last check) return null
                    if (response.Message.StartsWith("ERROR") || i == extraChecks - 1) return null;

                    // wait 5 seconds before checking again
                    Thread.Sleep(5000);

                }

                return null;

            }

            // response example: {"status":1,"request":"123"}
            private string CreateRequest() {

                List<KeyValuePair<string, string>> data = GetDefaultData();
                data.Add(new KeyValuePair<string, string>("method", "userrecaptcha"));
                data.Add(new KeyValuePair<string, string>("googlekey", SiteKey));
                data.Add(new KeyValuePair<string, string>("pageurl", URL));

                FormUrlEncodedContent content = new FormUrlEncodedContent(data);
                using (HttpResponseMessage responseMessage = Client.PostAsync("in.php", content).Result) {

                    string raw = responseMessage.Content.ReadAsStringAsync().Result;
                    _2CaptchaResponse response = _2CaptchaResponse.Create(raw);

                    if (!response.GetStatus()) return null;
                    else return response.Message;

                }

            }

            // response example: {"status":0,"request":"CAPCHA_NOT_READY"}
            private _2CaptchaResponse CheckRequest(string id) {

                List<KeyValuePair<string, string>> data = GetDefaultData();
                data.Add(new KeyValuePair<string, string>("action", "get"));
                data.Add(new KeyValuePair<string, string>("id", id));

                FormUrlEncodedContent content = new FormUrlEncodedContent(data);
                using (HttpResponseMessage responseMessage = Client.PostAsync("res.php", content).Result) {
                    string raw = responseMessage.Content.ReadAsStringAsync().Result;
                    return _2CaptchaResponse.Create(raw);
                }

            }

            private List<KeyValuePair<string, string>> GetDefaultData() {
                var data = new List<KeyValuePair<string, string>> {
                    new KeyValuePair<string, string>("json", "1"),
                    new KeyValuePair<string, string>("key", ApiKey),
                };
                return data;
            }

            class _2CaptchaResponse {

                [JsonProperty("status")]
                private string Status { get; set; }

                [JsonProperty("request")]
                public string Message { get; set; }

                public static _2CaptchaResponse Create(string data) {
                    return JsonConvert.DeserializeObject<_2CaptchaResponse>(data);
                }

                public bool GetStatus() {
                    return Status == "1";
                }

            }

        }

    }

}
