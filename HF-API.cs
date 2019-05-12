using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using HF_Sharp.Serialized;
using System.Dynamic;

namespace HF_Sharp {

    public class HF_API {

        private const string API_URL = "https://hackforums.net/api/v1/";

        private float Version = 0;
        private string ApiKey = string.Empty;
        private string UserAgent = string.Empty;

        public HF_API(string apiKey, string userAgent) {

            ApiKey = apiKey;
            UserAgent = userAgent;

            string versionRaw = GET("?version");
            dynamic versionData = JsonConvert.DeserializeObject(versionRaw);
            Version = versionData.apiVersion;

        }

        /// <summary>
        /// Gets the API version, stored upon instantiation.
        /// </summary>
        public float GetVersion() {
            return Version;
        }

        /// <summary>
        /// Returns information about a user, given the UID.
        /// </summary>
        public UserInformation GetUserInformation(int uid) {
            string path = "user/" + uid;
            return GET<UserInformation>(path);
        }

        /// <summary>
        /// Returns information about a category, given the CID.
        /// NOTE: type "c" = category, type "f" = forum
        /// </summary>
        public CategoryInformation GetCategoryInformation(int cid) {
            string path = "category/" + cid;
            return GET<CategoryInformation>(path);
        }

        /// <summary>
        /// Returns information about a forum, given the FID.
        /// Includes all threads inside the forum, to be used for navigation.
        /// NOTE: type "c" = category, type "f" = forum
        /// </summary>
        public ForumInformation GetForumInformation(int fid) {
            string path = "forum/" + fid;
            return GET<ForumInformation>(path);
        }

        /// <summary>
        /// Returns information about a thread, given the TID.
        /// Includes 10 posts on the specified page number. Default page = 1.
        /// </summary>
        public ThreadInformation GetThreadInformation(int tid, int page = 1, bool raw = true) {
            string path = "thread/" + tid + "?page=" + page;
            if (raw) path = path.Replace("?page=", "?raw&page=");
            return GET<ThreadInformation>(path);
        }

        /// <summary>
        /// Returns information about a post, given the PID;
        /// </summary>
        public PostInformation GetPostInformation(int pid, bool raw = true) {
            string path = "post/" + pid + (raw ? "?raw" : string.Empty);
            return GET<PostInformation>(path);
        }

        /// <summary>
        /// Returns a struct containing information about the specified InboxType alongside a list of messages.
        /// </summary>
        public PrivateMessageContainer GetPrivateMessageContainer(InboxType box = InboxType.Inbox, int page = 1) {
            string path = "pmbox/" + box + "?page=" + page;
            return GET<PrivateMessageContainer>(path);
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
        /// Returns a PrivateMessage object, containg actual 'message' content from a specified PMID.
        /// </summary>
        public PrivateMessage GetPrivateMessage(int pmid) {
            string path = "pm/" + pmid;
            return GET<PrivateMessage>(path);
        }

        /// <summary>
        /// Returns information about a HackForums group given the GID.
        /// </summary>
        public GroupInformation GetGroupInformation(int gid) {
            string path = "group/" + gid;
            return GET<GroupInformation>(path);
        }

        /// <summary>
        /// Standard GET request, returns a response string.
        /// </summary>
        private string GET(string path) {
            using (WebClient web = GetClient()) {
                return web.DownloadString(API_URL + path);
            }
        }

        /// <summary>
        /// API GET request which automatically converts 'result' property of a normal API response to provided type T.
        /// </summary>
        private T GET<T>(string path) {
            string raw = GET(path);
            HF_API_Response response = JsonConvert.DeserializeObject<HF_API_Response>(raw);
            if (response.success) {
                string resultString = JsonConvert.SerializeObject(response.result);
                return JsonConvert.DeserializeObject<T>(resultString);
            } else {
                throw new Exception("HF-API Request Failed: " + response.message);
            }
        }

        /// <summary>
        /// Initializes and returns an authorized WebClient object.
        /// </summary>
        private WebClient GetClient() {
            WebClient web = new WebClient();
            string auth = "Basic " + Utils.Base64Encode(ApiKey + ":");
            web.Headers.Add(HttpRequestHeader.Authorization, auth);
            web.Headers.Add(HttpRequestHeader.UserAgent, UserAgent);
            return web;
        }

    }

}
