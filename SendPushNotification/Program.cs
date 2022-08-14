using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendPushNotification
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> tokenList = new List<string>();
            tokenList.Add("ciFd9gPISxik43kWm3CsjZ:APA91bFrz0NxewKVIdOa5rodWNjtYiwjfk4pGHnOk0HzHzPPX1fqt10vorKhWox-alDR7RaaJ4Pc57GS3EkG9uUzVvwVMT6yqNI34cNw5MRs9z4mUCp7puuFmzOGd8Xoy8ZDst-1ANjo"); // Android Device Token
            tokenList.Add("fGfz9oZGJ00shSaORcT2Ui:APA91bFy7ixlR5s_aHAEE4PG0nduhtkehXC0XYsxmdR9h4DandqNzMYOkdQkzxKIKU_G7uJZnuybYNCRTVBPH0ySJTh4ZJ31V0u_QJlkP54sMFxpKM1Ne1I4rOQcL5ofw2eXycCyhLrU"); // IOS Device Token

            var dynamic = new PushNotifier(PushNotifier.Keys.FIREBASE_PUSHNOTIFICATION_KEY).SendNotification(tokenList, "Hello from kamran :) ", "This is notification message", "general");
            Console.WriteLine(dynamic);

        }
    }
}
