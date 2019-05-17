using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HF_Sharp.Serialized {

    /// <summary>
    /// Serialized data returned by GET post/:id
    /// </summary>
    public struct PostInformation {

        /// <summary>
        /// The id of the thread that the post is inside of.
        /// </summary>
        [JsonProperty("tid")]
        public int ThreadID { get; set; }

        /// <summary>
        /// The specific post id.
        /// </summary>
        [JsonProperty("pid")]
        public int ID { get; set; }

        /// <summary>?</summary>
        [JsonProperty("parent")]
        public int Parent { get; set; }

        /// <summary>?</summary>
        [JsonProperty("fid")]
        public int ForumID { get; set; }

        /// <summary>?</summary>
        [JsonProperty("subject")]
        public string Subject { get; set; }

        /// <summary>
        /// UID of the user who made the post.
        /// </summary>
        [JsonProperty("uid")]
        public int UserID { get; set; }

        /// <summary>
        /// Username of the user who made the post.
        /// </summary>
        [JsonProperty("username")]
        public string Username { get; set; }

        /// <summary>
        /// Date/time the post was created at.
        /// </summary>
        [JsonProperty("dateline")]
        public DateTime DateTime { get; set; }

        /// <summary>
        /// The actual post message/contents.
        /// May be HTML depending on 'raw' variable in the function that retrieved it.
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; }

        /// <summary>
        /// UID of the last user to edit the post.
        /// </summary>
        [JsonProperty("edituid")]
        public int LastEditUserID { get; set; }

        /// <summary>
        /// The date/time the post was last edited.
        /// </summary>
        [JsonProperty("edittime")]
        public DateTime LastEditDateTime { get; set; }

    }

}
