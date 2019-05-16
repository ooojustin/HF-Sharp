using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HF_Sharp.Serialized {

    /// <summary>
    /// Serialized data returned by GET pm/:id
    /// </summary>
    public struct PrivateMessage {

        /// <summary>
        /// UID of the receiver of the message.
        /// </summary>
        [JsonProperty("to")]
        public int ToID { get; set; }

        /// <summary>
        /// Username of the receiver of the message.
        /// </summary>
        [JsonProperty("tousername")]
        public string ToUsername { get; set; }

        /// <summary>
        /// UID of the sender of the message.
        /// </summary>
        [JsonProperty("from")]
        public int FromID { get; set; }

        /// <summary>
        /// Username of the receiver of the message.
        /// </summary>
        [JsonProperty("fromusername")]
        public string FromUsername { get; set; }

        /// <summary>
        /// Subject of the message.
        /// </summary>
        [JsonProperty("subject")]
        public string Subject;

        /// <summary>
        /// Contents of the message.
        /// </summary>
        [JsonProperty("message")]
        public string Message;

        /// <summary>
        /// The date/time that the message was sent at.
        /// </summary>
        [JsonProperty("dateline")]
        public DateTime DateTime;

        /// <summary>
        /// The folder that the message is inside of.
        /// </summary>
        [JsonProperty("folder")]
        public int FolderID;

    }

    /// <summary>
    /// Serialized data returned by GET pmbox/:id
    /// </summary>
    public struct PrivateMessageContainer {

        /// <summary>
        /// The name of the current box.
        /// Something like 'inbox', 'sent', or 'trash'.
        /// </summary>
        [JsonProperty("pmbox")]
        public string ContainerName;

        /// <summary>
        /// Contains information regarding pagination.
        /// </summary>
        [JsonProperty("pageInfo")]
        public PrivateMessagePageInformation PageInfo;

        /// <summary>
        /// A list of pms, with their subjects and ids.
        /// </summary>
        [JsonProperty("pms")]
        public List<PrivateMessageInformation> PMs;

    }

    /// <summary>
    /// Serialized data returned in a list as 'pms' property from PrivateMessageContainer.
    /// </summary>
    public struct PrivateMessageInformation {

        /// <summary>
        /// Unique message id number.
        /// </summary>
        [JsonProperty("pmid")]
        public int ID { get; set; }

        /// <summary>
        /// Subject of the message.
        /// </summary>
        [JsonProperty("subject")]
        public string Subject { get; set; }

        /// <summary>
        /// Username of the sender of the message.
        /// </summary>
        [JsonProperty("senderusername")]
        public string FromUsername { get; set; }

        /// <summary>
        /// UID of the sender of the message.
        /// </summary>
        [JsonProperty("sender")]
        public int FromID { get; set; }

        /// <summary>
        /// Username of the receiver of the message.
        /// </summary>
        [JsonProperty("recipientusername")]
        public string ToUsername { get; set; }

        /// <summary>
        /// UID of the receiver of the message.
        /// </summary>
        [JsonProperty("recipient")]
        public int ToID { get; set; }

        /// <summary>
        /// Status of the message in the users inbox.
        /// </summary>
        [JsonProperty("status")]
        public MessageStatus Status { get; set; }

        /// <summary>
        /// The date/time the message was sent at.
        /// </summary>
        [JsonProperty("dateline")]
        public DateTime DateTime { get; set; }

        /// <summary>
        /// Returns the actual PrivateMessage information (with 'message' content) from the current message information.
        /// Provide an instance of the HF_API class to make the API call from.
        /// </summary>
        public PrivateMessage GetPrivateMessage(HF_API api) {
            return api.GetPrivateMessage(ID);
        }

    }

    /// <summary>
    /// Serialized data regarding the pagination of messages.
    /// </summary>
    public struct PrivateMessagePageInformation {

        /// <summary>
        /// The total number of private messages in the current box.
        /// </summary>
        [JsonProperty("total")]
        public int TotalMessages;

    }

    /// <summary>
    /// Known inbox type ids, used to retrieve PMs from different sections of a users private messages.
    /// </summary>
    public enum InboxType {

        /// <summary>Default message folder, containing received messages.</summary>
        Inbox = 1,

        /// <summary>Contains outgoing messages sent to other users/</summary>
        Sent = 2,

        /// <summary>Contains uncompleted messages.</summary>
        Drafts = 3,

        /// <summary>Contains deleted messages.</summary>
        Trash = 4

    }

    /// <summary>
    /// Status of the message in the users inbox.
    /// </summary>
    public enum MessageStatus {

        /// <summary>The message is in the users inbox and has not yet been opened.</summary>
        Unopened = 0,

        /// <summary>The message has been opened, but has not been replied to yet.</summary>
        Opened = 1,

        /// <summary>?</summary>
        Unknown = 2,

        /// <summary>A message that has already been replied to.</summary>
        RepliedTo = 3

    }

}

