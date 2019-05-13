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
        public string name;

        /// <summary>
        /// A description of the designation of the forum.
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
        /// The number of threads inside of the current forum.
        /// </summary>
        public string numthreads;

        /// <summary>
        /// A list of ThreadInformation objects, containing some basic information used for navigation.
        /// </summary>
        public List<ThreadInformation> threaddata;

    }

}
