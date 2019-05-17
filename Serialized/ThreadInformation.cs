using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HF_Sharp.Serialized {

    /// <summary>
    /// Serialized data returned by GET thread/:id
    /// </summary>
    public struct ThreadInformation {

        /// <summary>
        /// Unique identifier representing the thread on HackForums.
        /// </summary>
        [JsonProperty("tid")]
        public int ID { get; set; }

        /// <summary>
        /// Indicates whether on not the thread is sticky/pinned.
        /// </summary>
        [JsonProperty("sticky")]
        public bool IsStickied { get; set; }

        /// <summary>
        /// Subject/title of the thread.
        /// </summary>
        [JsonProperty("subject")]
        public string Subject { get; set; }

        /// <summary>
        /// Prefix to the thread subject/title.
        /// </summary>
        [JsonProperty("threadprefix")]
        public string Prefix { get; set; }

        /// <summary>
        /// User ID of the creator of the thread.
        /// </summary>
        [JsonProperty("user")]
        public int UserID { get; set; }

        /// <summary>
        /// Username of the creator of the thread.
        /// </summary>
        [JsonProperty("username")]
        public string Username { get; set; }

        /// <summary>
        /// Indicates whether or not the thread has been closed.
        /// </summary>
        [JsonProperty("closed")]
        public bool IsClosed { get; set; }

        /// <summary>
        /// The number of replies to the thread.
        /// </summary>
        [JsonProperty("numreplies")]
        public int ReplyCount { get; set; }

        /// <summary>
        /// The time the thread was created at.
        /// </summary>
        [JsonProperty("dateline")]
        public DateTime DateTime { get; set; }

        /// <summary>
        /// The time somebody last responded to the thread.
        /// </summary>
        [JsonProperty("lastpost")]
        public DateTime LastPost { get; set; }

        /// <summary>
        /// The username of the last user to respond to the thread.
        /// </summary>
        [JsonProperty("lastposter")]
        public string LastPosterUsername { get; set; }

        /// <summary>
        /// The user ID of the last user to respond to the thread.
        /// </summary>
        [JsonProperty("lastposteruid")]
        public int LastPosterID { get; set; }

        /// <summary>
        /// The post ID number of the first post in the thread.
        /// </summary>
        [JsonProperty("firstpost")]
        public int FirstPostID { get; set; }

        /// <summary>
        /// A list of PostInformation objects up to 10 posts in the thread. Paginated.
        /// </summary>
        [JsonProperty("postdata")]
        public List<PostInformation> Posts { get; set; }

    }

}
