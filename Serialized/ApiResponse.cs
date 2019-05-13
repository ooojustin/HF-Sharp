using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HF_Sharp.Serialized {

    /// <summary>
    /// Standard response format when an API query is completed.
    /// </summary>
    public struct HF_API_Response {

        /// <summary>
        /// Whether or not the API request was completed successfully.
        /// </summary>
        public bool success;

        /// <summary>
        /// A message from the API, only set when 'success' is false. Serves as an error message.
        /// </summary>
        public string message;

        /// <summary>
        /// The actual response/data we asked for.
        /// </summary>
        public dynamic result;

    }

}
