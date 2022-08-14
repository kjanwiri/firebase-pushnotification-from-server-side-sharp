# firebase-pushnotification-from-server-side-sharp
This project is to send the push notification on android or ios mobile app from server side.

Please follow below steps

- [X] Step#1  : Get the Firebase pushnotification server key.<br>
  Hint > Check with mobile app developr they know how to get it.<br>
  <strong>Go to firebase console > select project > settings > cloud messaging > Cloud Messaging API > Now copy the token id</strong>
  
- [X] Step#2 : Get the android or ios device token <br>
Hint > It should be stored in the database or mobile app developer will share it with you.


Run the application <br>

````
```
using System; 
using System.Collections.Generic; 

namespace SendPushNotification 
{
    class Program 
    {
        static void Main(string[] args) 
        {
            List<string> tokenList = new List<string>();
            tokenList.Add("Device token"); // Android Device Token 
            tokenList.Add("Device Token"); // IOS Device Token
            var dynamic = new PushNotifier(PushNotifier.Keys.FIREBASE_PUSHNOTIFICATION_KEY).SendNotification(tokenList, "Title:) ", "notification message", "general"); 
            Console.WriteLine(dynamic); 

        } 
    } 
} 
```
````
