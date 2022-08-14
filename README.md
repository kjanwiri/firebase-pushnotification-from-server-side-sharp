# firebase-pushnotification-from-server-side-sharp
This project is to send the push notification on android or ios mobile app from server side.

Please follow below steps

Step#1  : Get the Firebase pushnotification server key.
  Hint > Check with mobile app developr they know how to get it.
  or Go to firebase console > select project > settings > cloud messaging > Cloud Messaging API > Now copy the token id
  
Step#2 : Get the android or ios device token
Hint > It should be stored in the database or mobile app developer will share it with you.


Run the application

using System;
using System.Collections.Generic;

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
