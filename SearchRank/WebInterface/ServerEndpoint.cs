using Newtonsoft.Json;
using SearchRank.Models;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace SearchRank.Ui.WebInterface
{
    /// <summary>
    /// 
    /// </summary>
    public class ServerEndpoint
    {
        private HttpClient client;

        public ServerEndpoint()
        {
            client = new HttpClient()
            {
                BaseAddress = new Uri("http://localhost:31984/")
            };
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userSetting"></param>
        /// <returns></returns>
        public bool SaveUserSettings(UserSetting userSetting)
        {
            var serialized = JsonConvert.SerializeObject(userSetting);
            var content = new StringContent(serialized, Encoding.UTF8, "application/json");
            HttpResponseMessage responce = client.PostAsync("UserSettings/Save", content).Result;
            if(responce.StatusCode == HttpStatusCode.OK)
            {
                string reply = responce.Content.ReadAsStringAsync().Result;
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public UserSetting GetUserSettings(string user)
        {
            HttpResponseMessage responce = client.GetAsync("UserSettings/Get").Result;
            if (responce.StatusCode == HttpStatusCode.OK)
            {
                string reply = responce.Content.ReadAsStringAsync().Result;
                return (UserSetting)JsonConvert.DeserializeObject(reply, typeof(UserSetting));
            }
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int GetResults()
        {
            HttpResponseMessage responce = client.GetAsync("Results/Get").Result;
            if (responce.StatusCode == HttpStatusCode.OK)
            {
                string reply = responce.Content.ReadAsStringAsync().Result;
                return (int)JsonConvert.DeserializeObject(reply, typeof(int));
            }
            return 0;
        }
    }
}
