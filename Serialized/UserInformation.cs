using Newtonsoft.Json;
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

        private string _username;
        private int _postCount;
        private string _avatarPath;
        private string _avatarType;
        private int _userGroup;
        private int _displayGroup;
        private int[] _additionalGroups;

        /// <summary>
        /// Users usernme on HackForums.
        /// </summary>
        [JsonProperty("username")]
        public string Username {
            get { return _username; }
            set { _username = value; }
        }

        /// <summary>
        /// Number of posts a user has on HackForums.
        /// </summary>
        [JsonProperty("postnum")]
        public int PostCount {
            get { return _postCount; }
            set { _postCount = value; }
        }

        /// <summary>
        /// Path to the users profile picture on hackforums.org.
        /// </summary>
        [JsonProperty("avatar")]
        public string AvatarPath {
            get { return _avatarPath; }
            set { _avatarPath = value; }
        }

        /// <summary>?</summary>
        [JsonProperty("avatartype")]
        public string AvatarType {
            get { return _avatarType; }
            set { _avatarType = value; }
        }

        /// <summary>?</summary>
        [JsonProperty("usergroup")]
        public int UserGroup {
            get { return _userGroup; }
            set { _userGroup = value; }
        }

        /// <summary>?</summary>
        [JsonProperty("displaygroup")]
        public int DisplayGroup {
            get { return _displayGroup; }
            set { _displayGroup = value; }
        }

        /// <summary>?</summary>
        [JsonProperty("additionalgroups")]
        public int[] AdditionalGroups {
            get { return _additionalGroups; }
            set { _additionalGroups = value; }
        }

    }

}
