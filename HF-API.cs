using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using System.Reflection;
using HF_Sharp.Serialized;

namespace HF_Sharp {

    /// <summary>
    /// HackForums API wrapper class.
    /// </summary>
    public class HF_API {

        private const string API_URL = "https://hackforums.net/api/v1/";

        private readonly HttpClient Client = new HttpClient(); 

        /// <summary>
        /// Creates an instance of the HackForums API wrapper.
        /// </summary>
        /// <param name="apiKey">Your API key, provided by HackForums.</param>
        /// <param name="userAgent">Application name, to be used in user-agent.</param>
        /// <param name="version">Optional version number. If not provided, version will be derived from assembly.</param>
        public HF_API(string apiKey, string userAgent, string version = "") {

            // if version application isn't specified, use refelection to get assembly version
            if (version == string.Empty)
                version = Assembly.GetExecutingAssembly().GetName().Version.ToString();

            // initialize authorization/user-agent haeders for future requests
            Client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Utils.Base64Encode(apiKey + ":"));
            Client.DefaultRequestHeaders.UserAgent.Add(new System.Net.Http.Headers.ProductInfoHeaderValue(userAgent, Assembly.GetExecutingAssembly().GetName().Version.ToString()));

        }

        /// <summary>
        /// Gets the API version, stored upon instantiation.
        /// </summary>
        public float GetVersion() {
            string versionRaw = GET("?version");
            dynamic versionData = JsonConvert.DeserializeObject(versionRaw);
            return versionData.apiVersion;
        }

        /// <summary>
        /// Returns information about a user, given the UID.
        /// </summary>
        public UserInformation GetUserInformation(int uid) {
            string path = "user/" + uid;
            return GET<UserInformation>(path);
        }

        /// <summary>
        /// Returns information about a user, given the UID.
        /// This variant runs asychronously.
        /// </summary>
        public async Task<UserInformation> GetUserInformationAsync(int uid) {
            string path = "user/" + uid;
            return await GETAsync<UserInformation>(path);
        }

        /// <summary>
        /// Returns information about a category, given the CID.
        /// </summary>
        public CategoryInformation GetCategoryInformation(int cid) {
            string path = "category/" + cid;
            return GET<CategoryInformation>(path);
        }

        /// <summary>
        /// Returns information about a category, given the CID.
        /// This variant runs asychronously.
        /// </summary>
        public async Task<CategoryInformation> GetCategoryInformationAsync(int cid) {
            string path = "category/" + cid;
            return await GETAsync<CategoryInformation>(path);
        }

        /// <summary>
        /// Returns information about a forum, given the FID.
        /// </summary>
        public ForumInformation GetForumInformation(int fid) {
            string path = "forum/" + fid;
            return GET<ForumInformation>(path);
        }

        /// <summary>
        /// Returns information about a forum, given the FID.
        /// This variant runs asychronously.
        /// </summary>
        public async Task<ForumInformation> GetForumInformationAsync(int fid) {
            string path = "forum/" + fid;
            return await GETAsync<ForumInformation>(path);
        }

        /// <summary>
        /// Returns information about a thread, given the TID.
        /// </summary>
        public ThreadInformation GetThreadInformation(int tid, int page = 1, bool raw = true) {
            string path = "thread/" + tid + "?page=" + page;
            if (raw) path = path.Replace("?page=", "?raw&page=");
            return GET<ThreadInformation>(path);
        }

        /// <summary>
        /// Returns information about a thread, given the TID.
        /// This variant runs asychronously.
        /// </summary>
        public async Task<ThreadInformation> GetThreadInformationAsync(int tid, int page = 1, bool raw = true) {
            string path = "thread/" + tid + "?page=" + page;
            if (raw) path = path.Replace("?page=", "?raw&page=");
            return await GETAsync<ThreadInformation>(path);
        }

        /// <summary>
        /// Returns information about a post, given the PID;
        /// </summary>
        public PostInformation GetPostInformation(int pid, bool raw = true) {
            string path = "post/" + pid + (raw ? "?raw" : string.Empty);
            return GET<PostInformation>(path);
        }

        /// <summary>
        /// Returns information about a post, given the PID;
        /// This variant runs asychronously.
        /// </summary>
        public async Task<PostInformation> GetPostInformationAsync(int pid, bool raw = true) {
            string path = "post/" + pid + (raw ? "?raw" : string.Empty);
            return await GETAsync<PostInformation>(path);
        }

        /// <summary>
        /// Returns a struct containing information about the specified InboxType alongside a list of messages.
        /// </summary>
        public PrivateMessageContainer GetPrivateMessageContainer(InboxType box = InboxType.Inbox, int page = 1) {
            string path = "pmbox/" + box + "?page=" + page;
            return GET<PrivateMessageContainer>(path);
        }

        /// <summary>
        /// Returns a struct containing information about the specified InboxType alongside a list of messages.
        /// This variant runs asychronously.
        /// </summary>
        public async Task<PrivateMessageContainer> GetPrivateMessageContainerAsync(InboxType box = InboxType.Inbox, int page = 1) {
            string path = "pmbox/" + box + "?page=" + page;
            return await GETAsync<PrivateMessageContainer>(path);
        }

        /// <summary>
        /// Returns a list of private messages from the specified inbox type.
        /// Note that it will return up to 25 messages, depending on the specified page.
        /// </summary>
        public List<PrivateMessageInformation> GetPrivateMessages(InboxType box = InboxType.Inbox, int page = 1) {
            PrivateMessageContainer container = GetPrivateMessageContainer(box, page);
            return container.pms;
        }

        /// <summary>
        /// Returns a list of private messages from the specified inbox type.
        /// Note that it will return up to 25 messages, depending on the specified page.
        /// This variant runs asychronously.
        /// </summary>
        public async Task<List<PrivateMessageInformation>> GetPrivateMessagesAsync(InboxType box = InboxType.Inbox, int page = 1) {
            PrivateMessageContainer container = await GetPrivateMessageContainerAsync(box, page);
            return container.pms;
        }

        /// <summary>
        /// Returns a PrivateMessage object, containg actual 'message' content from a specified PMID.
        /// </summary>
        public PrivateMessage GetPrivateMessage(int pmid) {
            string path = "pm/" + pmid;
            return GET<PrivateMessage>(path);
        }

        /// <summary>
        /// Returns a PrivateMessage object, containg actual 'message' content from a specified PMID.
        /// This variant runs asychronously.
        /// </summary>
        public async Task<PrivateMessage> GetPrivateMessageAsync(int pmid) {
            string path = "pm/" + pmid;
            return await GETAsync<PrivateMessage>(path);
        }

        /// <summary>
        /// Returns information about a HackForums group given the GID.
        /// </summary>
        public GroupInformation GetGroupInformation(int gid) {
            string path = "group/" + gid;
            return GET<GroupInformation>(path);
        }

        /// <summary>
        /// Returns information about a HackForums group given the GID.
        /// This variant runs asychronously.
        /// </summary>
        public async Task<GroupInformation> GetGroupInformationAsync(int gid) {
            string path = "group/" + gid;
            return await GETAsync<GroupInformation>(path);
        }

        /// <summary>
        /// Standard GET request, returns a response string.
        /// </summary>
        private string GET(string path) {
            string url = API_URL + path;
            using (HttpResponseMessage responseMessage = Client.GetAsync(url).Result) {
                string response = responseMessage.Content.ReadAsStringAsync().Result;
                return response;
            }
        }

        /// <summary>
        /// Asynchronous GET request, returns a task of return type string.
        /// </summary>
        private async Task<string> GETAsync(string path) {
            string url = API_URL + path;
            using (HttpResponseMessage responseMessage = await Client.GetAsync(url)) {
                string response = await responseMessage.Content.ReadAsStringAsync();
                return response;
            }
        }

        /// <summary>
        /// API GET request which automatically converts 'result' property of a normal API response to provided type T.
        /// </summary>
        private T GET<T>(string path) {
            string raw = GET(path);
            return GetApiResult<T>(raw);
        }

        /// <summary>
        /// API GET request which automatically converts 'result' property of a normal API response to provided type T.
        /// This variant executes the GET request asynchronously.
        /// </summary>
        private async Task<T> GETAsync<T>(string path) {
            string raw = await GETAsync(path);
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
