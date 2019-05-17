using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HF_Sharp.Serialized {

    /// <summary>
    /// Serialized data returned by GET forum/:id
    /// </summary>
    public struct ForumInformation {

        /// <summary>
        /// The name of the forum.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// A description of the designation of the forum.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// The type. 'f' = forum, 'c' = category.
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// Parent forum/category id.
        /// </summary>
        [JsonProperty("parent")]
        public int Parent { get; set; }

        /// <summary>
        /// The number of threads inside of the current forum.
        /// </summary>
        [JsonProperty("numthreads")]
        public string ThreadCount { get; set; }

        /// <summary>
        /// A list of ThreadInformation objects, containing some basic information used for navigation.
        /// </summary>
        [JsonProperty("threaddata")]
        public List<ThreadInformation> Threads { get; set; }

    }

}
