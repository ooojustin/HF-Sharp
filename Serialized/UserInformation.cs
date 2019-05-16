using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HF_Sharp.Serialized {

    /// <summary>
    /// Serialized data returned by GET user/:id
    /// </summary>
    public struct UserInformation {

        /// <summary>
        /// Users usernme on HackForums.
        /// </summary>
        [JsonProperty("username")]
        public string Username { get; set; }

        /// <summary>
        /// Number of posts a user has on HackForums.
        /// </summary>
        [JsonProperty("postnum")]
        public int PostCount { get; set; }

        /// <summary>
        /// Path to the users profile picture on hackforums.org.
        /// </summary>
        [JsonProperty("avatar")]
        public string AvatarPath { get; set; }

        /// <summary>?</summary>
        [JsonProperty("avatartype")]
        public string AvatarType { get; set; }

        /// <summary>?</summary>
        [JsonProperty("usergroup")]
        public int UserGroup { get; set; }

        /// <summary>?</summary>
        [JsonProperty("displaygroup")]
        public int DisplayGroup { get; set; }

        /// <summary>?</summary>
        [JsonProperty("additionalgroups")]
        public int[] AdditionalGroups { get; set; }

    }

}
