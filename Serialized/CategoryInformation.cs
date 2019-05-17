using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HF_Sharp.Serialized {

    /// <summary>
    /// Serialized data returned by GET category/:id
    /// </summary>
    public struct CategoryInformation {

        /// <summary>
        /// The forum that the category is inside of.
        /// </summary>
        [JsonProperty("fid")]
        public int ID { get; set; }

        /// <summary>
        /// The name of the category.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// A description of the designation of the category.
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
        /// The icon of the category, I assume, but it seems to always be 'NULL' for some reason.
        /// </summary>
        [JsonProperty("ficon")]
        public object Icon { get; set; }

        /// <summary>
        /// Categories contained inside of the current category.
        /// </summary>
        [JsonProperty("children")]
        public List<CategoryInformation> Children { get; set; }

    }

}
