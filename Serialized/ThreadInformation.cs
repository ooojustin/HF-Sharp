using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HF_Sharp.Serialized {

    public struct ThreadInformation {

        public int tid;

        public bool sticky;

        public string subject;

        public string threadprefix;

        public int user;

        public string username;

        public bool closed;

        public int numreplies;

        public DateTime dateline;

        public DateTime lastpost;

        public string lastposter;

        public int lastposteruid;

        public int firstpost;

        public List<PostInformation> postdata;

    }

}
