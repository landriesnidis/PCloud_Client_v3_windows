using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCloud_Client_v3
{
    class ActionJson
    {
        public string action{set;get;}
        public Boolean flag { set; get; }
        public string content { set; get; }
        public string message { set; get; }

        public ActionJson(string strJson)
        {
            JObject json = JObject.Parse(strJson);

            action = (string)json["action"];
            flag = (Boolean)json["flag"];
            content = (string)json["content"];
            message = (string)json["message"];
        }


    }
}
