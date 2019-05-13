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
        public int tid;

        /// <summary>
        /// Indicates whether on not the thread is sticky/pinned.
        /// </summary>
        public bool sticky;

        /// <summary>
        /// Subject/title of the thread.
        /// </summary>
        public string subject;

        /// <summary>
        /// Prefix to the thread subject/title.
        /// </summary>
        public string threadprefix;

        /// <summary>
        /// User ID of the creator of the thread.
        /// </summary>
        public int user;

        /// <summary>
        /// Username of the creator of the thread.
        /// </summary>
        public string username;

        /// <summary>
        /// Indicates whether or not the thread has been closed.
        /// </summary>
        public bool closed;

        /// <summary>
        /// The number of replies to the thread.
        /// </summary>
        public int numreplies;

        /// <summary>
        /// The time the thread was created at.
        /// </summary>
        public DateTime dateline;

        /// <summary>
        /// The time somebody last responded to the thread.
        /// </summary>
        public DateTime lastpost;

        /// <summary>
        /// The username of the last user to respond to the thread.
        /// </summary>
        public string lastposter;

        /// <summary>
        /// The user ID of the last user to respond to the thread.
        /// </summary>
        public int lastposteruid;

        /// <summary>
        /// The post ID number of the first post in the thread.
        /// </summary>
        public int firstpost;

        /// <summary>
        /// A list of PostInformation objects up to 10 posts in the thread. Paginated.
        /// </summary>
        public List<PostInformation> postdata;

    }

}
