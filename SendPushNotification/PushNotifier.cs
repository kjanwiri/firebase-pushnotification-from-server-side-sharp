﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SendPushNotification
{
    public class PushNotifier
    {
        public class Keys
        {
            public static string FIREBASE_PUSHNOTIFICATION_KEY { get; set; } = string.Empty;
            // Go to firebase console > select project > settings > cloud messaging > Cloud Messaging API > Now copy the token id
        }

        private string FIREBASE_URL = "https://fcm.googleapis.com/fcm/send";
        private string KEY_SERVER;
        public PushNotifier(String key_server)
        {
            this.KEY_SERVER = key_server;
        }
        
        public dynamic SendNotification(List<string> tokenList, string title, string message, string category,string data="")
        {

            var response = new PushNotifier(this.KEY_SERVER).SendPush(new PushMessage()
            {

                // to = aDeviceTokens,
                registration_ids = tokenList,
                notification = new PushMessageData
                {
                    title = title,
                    body = message,
                    deeplink = category,
                    notificationData = data


                },
                data = new
                {
                    title = title,
                    body = message,
                    deeplink = category,
                    notificationData = data

                }
            });

            return response;
        }

        private dynamic SendPush(PushMessage message)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(FIREBASE_URL);
            request.Method = "POST";
            request.Headers.Add("Authorization", "key=" + this.KEY_SERVER);
            request.ContentType = "application/json";
            string json = JsonConvert.SerializeObject(message);
            byte[] byteArray = Encoding.UTF8.GetBytes(json);
            request.ContentLength = byteArray.Length;
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            if (response.StatusCode == HttpStatusCode.Accepted || response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.Created)
            {
                StreamReader read = new StreamReader(response.GetResponseStream());
                String result = read.ReadToEnd();
                read.Close();
                response.Close();
                dynamic stuff = JsonConvert.DeserializeObject(result);
                return stuff;
            }
            else
            {
                throw new Exception("An error has occurred when try to get server response: " + response.StatusCode);
            }
        }
    }

    public class PushMessage
    {
        private string _to;
        private List<string> _registration_ids;
        private PushMessageData _notification;

        private dynamic _data;
        private dynamic _click_action;
        public dynamic data
        {
            get { return _data; }
            set { _data = value; }
        }

        public string to
        {
            get { return _to; }
            set { _to = value; }
        }

        public List<string> registration_ids
        {
            get { return _registration_ids; }
            set { _registration_ids = value; }

        }
        public PushMessageData notification
        {
            get { return _notification; }
            set { _notification = value; }
        }

        public dynamic click_action
        {
            get
            {
                return _click_action;
            }

            set
            {
                _click_action = value;
            }
        }
    }

    public class PushMessageData
    {

        private string _deeplink;



        private string _notificationData;
        private string _title;
        private string _text;
        private string _sound = "default";
        private string _click_action;
        public string sound
        {
            get { return _sound; }
            set { _sound = value; }
        }

        public string title
        {
            get { return _title; }
            set { _title = value; }
        }
        public string notificationData
        {
            get { return _notificationData; }
            set { _notificationData = value; }
        }
        public string deeplink
        {
            get { return _deeplink; }
            set { _deeplink = value; }
        }
        public string body
        {
            get { return _text; }
            set { _text = value; }
        }

        public string click_action
        {
            get
            {
                return _click_action;
            }

            set
            {
                _click_action = value;
            }
        }
    }


}
