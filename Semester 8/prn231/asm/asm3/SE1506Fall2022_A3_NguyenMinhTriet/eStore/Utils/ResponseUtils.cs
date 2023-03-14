using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;

namespace eStore.Utils
{
    public static class ResponseUtils
    {
        public static void CheckResponseIsSuccess (HttpResponseMessage response, string strData)
        {
            if (!response.IsSuccessStatusCode)
            {
                dynamic json = JValue.Parse(strData);
                string msg = json.detail;
                throw new Exception(msg);
            }
        }
    }
}
