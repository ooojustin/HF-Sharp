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
        public int tid;

        /// <summary>
        /// The specific post id.
        /// </summary>
        public int pid;

        /// <summary>?</summary>
        public int parent;

        /// <summary>?</summary>
        public int fid;

        /// <summary>?</summary>
        public string subject;

        /// <summary>
        /// UID of the user who made the post.
        /// </summary>
        public int uid;

        /// <summary>
        /// Username of the user who made the post.
        /// </summary>
        public string username;

        /// <summary>
        /// Date/time the post was created at.
        /// </summary>
        public DateTime dateline;

        /// <summary>
        /// The actual post message/contents.
        /// May be HTML depending on 'raw' variable in the function that retrieved it.
        /// </summary>
        public string message;

        /// <summary>
        /// UID of the last user to edit the post.
        /// </summary>
        public int edituid;

        /// <summary>
        /// The date/time the post was last edited.
        /// </summary>
        public DateTime edittime;

    }

}
