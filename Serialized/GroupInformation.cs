using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HF_Sharp.Serialized {

    public struct GroupInformation {

        /// <summary>
        /// The name of a group.
        /// </summary>
        public string name;

        /// <summary>
        /// An integer representing the type of group.
        /// I'm not really sure what the types are, and I couldn't find any documentation about it anywhere.
        /// </summary>
        public int type;
        
        /// <summary>
        /// A description of the group & it's purpose.
        /// </summary>
        public string description;

        /// <summary>
        /// Path to the group icon on HF server. (Image URL)
        /// </summary>
        public string userbar;

        /// <summary>
        /// The owner of the group.
        /// </summary>
        public GroupMember owner;

        /// <summary>
        /// Leaders of the group.
        /// </summary>
        public List<GroupMember> leaders;

    }

    public struct GroupMember {

        public int uid;

        public string username;

    }

}
