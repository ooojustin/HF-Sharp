using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HF_Sharp {

    public class Utils {

        /// <summary>
        /// Encodes a plain text string with Base64.
        /// </summary>
        public static string Base64Encode(string text) {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(text);
            return Convert.ToBase64String(plainTextBytes);
        }

    }

}
