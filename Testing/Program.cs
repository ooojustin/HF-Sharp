using HF_Sharp;
using HF_Sharp.Serialized;
using System;
using System.Collections.Generic;

namespace Testing {

    class Program {

        static void Main(string[] args) {

            Console.WriteLine("Initializing API...");
            HF_API api = new HF_API("", "HF-Sharp");
            Console.WriteLine("Completed. Version #" + api.GetVersion());

            Console.WriteLine("\nTesting GetUserInformation...");
            UserInformation user = api.GetUserInformation(3241222);
            Console.WriteLine("username: " + user.username);

            Console.WriteLine("\nTesting GetCategoryInformation...");
            CategoryInformation category = api.GetCategoryInformation(151);
            Console.WriteLine("category name: " + category.name);

            Console.WriteLine("\nTesting GetForumInformation...");
            ForumInformation forum = api.GetForumInformation(208);
            Console.WriteLine("forum name: " + forum.name);

            Console.WriteLine("\nTesting GetThreadInformation...");
            ThreadInformation thread = api.GetThreadInformation(5665556);
            Console.WriteLine("thread name: " + thread.subject);

            Console.WriteLine("\nTesting GetPostInformation...");
            PostInformation post = api.GetPostInformation(58564495);
            Console.WriteLine("post message: " + post.message);

            Console.WriteLine("\nTesting GetPrivateMessageContainer...");
            PrivateMessageContainer privateMessageContainer = api.GetPrivateMessageContainer();
            Console.WriteLine("box information: " + privateMessageContainer.pmbox + ", " + privateMessageContainer.pageInfo.total + " messages");

            Console.WriteLine("\nTesting GetPrivateMessages...");
            List<PrivateMessageInformation> messages = api.GetPrivateMessages();
            Console.WriteLine("got messages: " + messages.Count + " total, first id: " + messages[0].pmid);

            Console.WriteLine("\nTesting GetPrivateMessage...");
            PrivateMessage message = api.GetPrivateMessage(messages[0].pmid);
            Console.WriteLine("got message: from " + message.fromusername + ", to " + message.tousername + ", subject = " + message.subject);

            Console.WriteLine("\nTesting GetGroupInformation...");
            GroupInformation group = api.GetGroupInformation(52);
            Console.WriteLine("group: " + group.name + ", owner: " + group.owner.username);

            Console.ReadKey();

        }

    }

}
