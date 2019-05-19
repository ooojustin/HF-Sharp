using HF_Sharp;
using HF_Sharp.Serialized;
using System;
using System.Collections.Generic;

namespace Testing {

    class Program {

        static void Main(string[] args) {

            Console.WriteLine("Initializing API...");
            HF_API api = new HF_API("", "HF-Sharp");

            // Use this if you're running your program on a server or VPN.
            // The parameter passed to 'BypassCaptchaSystem' should be a 2Captcha API Key.
            /*Console.WriteLine("Bypassing captcha system...");
            api.BypassCaptchaSystem("");*/

            Console.WriteLine("\nTesting GetVersion...");
            Console.WriteLine("Completed. Version #" + api.GetVersion());

            Console.WriteLine("\nTesting GetUserInformation...");
            UserInformation user = api.GetUserInformation(3241222);
            Console.WriteLine("username: " + user.Username);

            Console.WriteLine("\nTesting GetCategoryInformation...");
            CategoryInformation category = api.GetCategoryInformation(151);
            Console.WriteLine("category name: " + category.Name);

            Console.WriteLine("\nTesting GetForumInformation...");
            ForumInformation forum = api.GetForumInformation(208);
            Console.WriteLine("forum name: " + forum.Name);

            Console.WriteLine("\nTesting GetThreadInformation...");
            ThreadInformation thread = api.GetThreadInformation(5665556);
            Console.WriteLine("thread name: " + thread.Subject);

            Console.WriteLine("\nTesting GetPostInformation...");
            PostInformation post = api.GetPostInformation(58564495);
            Console.WriteLine("post message: " + post.Message);

            Console.WriteLine("\nTesting GetPrivateMessageContainer...");
            PrivateMessageContainer privateMessageContainer = api.GetPrivateMessageContainer();
            Console.WriteLine("box information: " + privateMessageContainer.ContainerName + ", " + privateMessageContainer.PageInfo.TotalMessages + " messages");

            Console.WriteLine("\nTesting GetPrivateMessages...");
            List<PrivateMessageInformation> messages = api.GetPrivateMessages();
            Console.WriteLine("got messages: " + messages.Count + " total, first id: " + messages[0].ID);

            Console.WriteLine("\nTesting GetPrivateMessage...");
            PrivateMessage message = api.GetPrivateMessage(messages[0].ID);
            Console.WriteLine("got message: from " + message.FromUsername + ", to " + message.ToUsername + ", subject = " + message.Subject);

            Console.WriteLine("\nTesting GetGroupInformation...");
            GroupInformation group = api.GetGroupInformation(52);
            Console.WriteLine("group: " + group.Name + ", owner: " + group.Owner.Username);

            Console.ReadKey();

        }

    }

}
