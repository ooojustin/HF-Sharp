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
        public int fid;

        /// <summary>
        /// The name of the category.
        /// </summary>
        public string name;
        
        /// <summary>
        /// A description of the designation of the category.
        /// </summary>
        public string description;

        /// <summary>
        /// The type. 'f' = forum, 'c' = category.
        /// </summary>
        public string type;

        /// <summary>
        /// Parent forum/category id.
        /// </summary>
        public int parent;

        /// <summary>
        /// The icon of the category, I assume, but it seems to always be 'NULL' for some reason.
        /// </summary>
        public object ficon;

        /// <summary>
        /// Categories contained inside of the current category.
        /// </summary>
        public List<CategoryInformation> children;

    }

}
