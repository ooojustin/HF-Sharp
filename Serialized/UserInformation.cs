using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HF_Sharp.Serialized {

    /// <summary>
    /// Serialed data returned by GET user/:id
    /// </summary>
    public struct UserInformation {

        /// <summary>
        /// Users usernme on HackForums.
        /// </summary>
        public string username;

        /// <summary>
        /// Number of posts a user has on HackForums.
        /// </summary>
        public int postnum;

        /// <summary>
        /// Path to the users profile picture on hackforums.org.
        /// </summary>
        public string avatar;

        /// <summary>?</summary>
        public string avatartype;

        /// <summary>?</summary>
        public int usergroup;

        /// <summary>?</summary>
        public int displaygroup;

        /// <summary>?</summary>
        public int[] additionalgroups;

    }

}
