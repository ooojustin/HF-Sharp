using HF_Sharp.Serialized;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HF_Sharp.Networking {

    /// <summary>
    /// Class containing extension functions accessible via the HF_Sharp.Networking namespace.
    /// Used for sending/parsing web requests to HF API. It is assumed that provided HttpClient is authorized.
    /// </summary>
    public static class NetworkingExtensions {

        private const string API_URL = "https://hackforums.net/api/v1/";

        /// <summary>
        /// Standard GET request, returns a response string.
        /// </summary>
        public static string ApiGet(this HttpClient client, string path) {
            string url = API_URL + path;
            using (HttpResponseMessage responseMessage = client.GetAsync(url).Result) {
                string response = responseMessage.Content.ReadAsStringAsync().Result;
                return response;
            }
        }

        /// <summary>
        /// Asynchronous GET request, returns a task of return type string.
        /// </summary>
        public static async Task<string> ApiGetAsync(this HttpClient client, string path) {
            string url = API_URL + path;
            using (HttpResponseMessage responseMessage = await client.GetAsync(url)) {
                string response = await responseMessage.Content.ReadAsStringAsync();
                return response;
            }
        }

        /// <summary>
        /// API GET request which automatically converts 'result' property of a normal API response to provided type T.
        /// </summary>
        public static T ApiGet<T>(this HttpClient client, string path) {
            string raw = client.ApiGet(path);
            return GetApiResult<T>(raw);
        }

        /// <summary>
        /// API GET request which automatically converts 'result' property of a normal API response to provided type T.
        /// This variant executes the GET request asynchronously.
        /// </summary>
        public static async Task<T> ApiGetAsync<T>(this HttpClient client, string path) {
            string raw = await client.ApiGetAsync(path);
            return GetApiResult<T>(raw);
        }

        /// <summary>
        /// Parses raw API response data and deserializes 'result' property into provided type.
        /// </summary>
        private static T GetApiResult<T>(string data) {
            HF_API_Response response = JsonConvert.DeserializeObject<HF_API_Response>(data);
            if (response.success) {
                string resultString = JsonConvert.SerializeObject(response.result);
                return JsonConvert.DeserializeObject<T>(resultString);
            } else {
                throw new Exception("HF-API Request Failed: " + response.message);
            }
        }

    }

}
