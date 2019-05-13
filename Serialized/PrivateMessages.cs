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
        public int to;

        /// <summary>
        /// Username of the receiver of the message.
        /// </summary>
        public string tousername;

        /// <summary>
        /// UID of the sender of the message.
        /// </summary>
        public int from;

        /// <summary>
        /// Username of the receiver of the message.
        /// </summary>
        public string fromusername;

        /// <summary>
        /// Subject of the message.
        /// </summary>
        public string subject;

        /// <summary>
        /// Contents of the message.
        /// </summary>
        public string message;

        /// <summary>
        /// The date/time that the message was sent at.
        /// </summary>
        public DateTime dateline;

        /// <summary>
        /// The folder that the message is inside of.
        /// </summary>
        public int folder;

    }

    /// <summary>
    /// Serialized data returned by GET pmbox/:id
    /// </summary>
    public struct PrivateMessageContainer {

        /// <summary>
        /// The name of the current box.
        /// Something like 'inbox', 'sent', or 'trash'.
        /// </summary>
        public string pmbox;

        /// <summary>
        /// Contains information regarding pagination.
        /// </summary>
        public PrivateMessagePageInformation pageInfo;

        /// <summary>
        /// A list of pms, with their subjects and ids.
        /// </summary>
        public List<PrivateMessageInformation> pms;

    }

    /// <summary>
    /// Serialized data returned in a list as 'pms' property from PrivateMessageContainer.
    /// </summary>
    public struct PrivateMessageInformation {

        /// <summary>
        /// Unique message id number.
        /// </summary>
        public int pmid;

        /// <summary>
        /// Subject of the message.
        /// </summary>
        public string subject;

        /// <summary>
        /// Username of the sender of the message.
        /// </summary>
        public string senderusername;

        /// <summary>
        /// UID of the sender of the message.
        /// </summary>
        public int sender;

        /// <summary>
        /// Username of the receiver of the message.
        /// </summary>
        public string recipientusername;

        /// <summary>
        /// UID of the receiver of the message.
        /// </summary>
        public int recipient;

        /// <summary>
        /// Status of the message in the users inbox.
        /// </summary>
        public MessageStatus status;

        /// <summary>
        /// The date/time the message was sent at.
        /// </summary>
        public DateTime dateline;

        /// <summary>
        /// Returns the actual PrivateMessage information (with 'message' content) from the current message information.
        /// Provide an instance of the HF_API class to make the API call from.
        /// </summary>
        public PrivateMessage GetPrivateMessage(HF_API api) {
            return api.GetPrivateMessage(pmid);
        }

    }

    /// <summary>
    /// Serialized data regarding the pagination of messages.
    /// </summary>
    public struct PrivateMessagePageInformation {

        /// <summary>
        /// The total number of private messages in the current box.
        /// </summary>
        public int total;

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

