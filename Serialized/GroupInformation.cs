using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HF_Sharp.Serialized {

    /// <summary>
    /// Serialized data returned by GET group/:id
    /// </summary>
    public struct GroupInformation {

        /// <summary>
        /// The name of a group.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// An integer representing the type of group.
        /// I'm not really sure what the types are, and I couldn't find any documentation about it anywhere.
        /// </summary>
        [JsonProperty("type")]
        public int Type { get; set; }

        /// <summary>
        /// A description of the group and it's purpose.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// Path to the group icon on HF server. (Image URL)
        /// </summary>
        [JsonProperty("userbar")]
        public string UserBarPath { get; set; }

        /// <summary>
        /// The owner of the group.
        /// </summary>
        [JsonProperty("owner")]
        public GroupMember Owner { get; set; }

        /// <summary>
        /// Leaders of the group.
        /// </summary>
        [JsonProperty("leaders")]
        public List<GroupMember> Leaders { get; set; }

    }

    /// <summary>
    /// Represents an owner/leader in a group.
    /// </summary>
    public struct GroupMember {

        /// <summary>
        /// Users unique ID on HackForums.
        /// </summary>
        [JsonProperty("uid")]
        public int UserID { get; set; }

        /// <summary>
        /// Users username on HackForums.
        /// </summary>
        [JsonProperty("username")]
        public string Username { get; set; }

    }

}
