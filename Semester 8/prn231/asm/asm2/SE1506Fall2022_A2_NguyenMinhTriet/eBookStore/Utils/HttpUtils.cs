using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace eBookStore.Utils
{
    public static class HttpUtils
    {
        static async Task<string> CheckResponseIsSuccess (HttpResponseMessage response, string strData)
        {
            if (!response.IsSuccessStatusCode)
            {
                dynamic json = (strData == "") ? "{}" : JValue.Parse(strData);
                string msg = json.message ?? json.detail ?? "Something went wrong!";
                throw new Exception(msg);
            }
            return "OK";
        }
        public static async Task<string> SendGetRequestAsync(string url)
        {
            HttpClient client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            HttpResponseMessage response = await client.GetAsync(url);
            string strData = await response.Content.ReadAsStringAsync();
            string check = await CheckResponseIsSuccess(response, strData);
            if (check == "Call request again!")
            {
                response = await client.GetAsync(url);
                strData = await response.Content.ReadAsStringAsync();
                check = await CheckResponseIsSuccess(response, strData);
            }
            return strData;
        }

        public static async Task<string> SendDeleteRequestAsync(string url)
        {
            HttpClient client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            HttpResponseMessage response = await client.DeleteAsync(url);
            string strData = await response.Content.ReadAsStringAsync();
            string check = await CheckResponseIsSuccess(response, strData);
            if (check == "Call request again!")
            {
                response = await client.GetAsync(url);
                strData = await response.Content.ReadAsStringAsync();
                check = await CheckResponseIsSuccess(response, strData);
            }
            return strData;
        }

        public static async Task<string> SendPostRequestAsync<T>(string url, T payload) where T : class
        {
            HttpClient client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            HttpResponseMessage response = await client.PostAsJsonAsync(url, payload);
            string strData = await response.Content.ReadAsStringAsync();
            string check = await CheckResponseIsSuccess(response, strData);
            if (check == "Call request again!")
            {
                response = await client.PostAsJsonAsync(url, payload);
                strData = await response.Content.ReadAsStringAsync();
                check = await CheckResponseIsSuccess(response, strData);
            }
            return strData;
        }

        public static async Task<string> SendPutRequestAsync<T>(string url, T payload) where T : class
        {
            HttpClient client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            HttpResponseMessage response = await client.PutAsJsonAsync(url, payload);
            string strData = await response.Content.ReadAsStringAsync();
            string check = await CheckResponseIsSuccess(response, strData);
            if (check == "Call request again!")
            {
                response = await client.PutAsJsonAsync(url, payload);
                strData = await response.Content.ReadAsStringAsync();
                check = await CheckResponseIsSuccess(response, strData);
            }
            return strData;
        }

        public static T DeserializeResponse<T>(string responseStringData) where T : class
        {
            T objectData = JsonSerializer.Deserialize<T>(responseStringData, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            });
            return objectData;
        }
    }
}
