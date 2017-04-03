using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace WebDemoXPlatform.Clients
{
    public class Client
    {
        private readonly String _host;
        private readonly String _username;
        private readonly String _password;

        private const String MEDIA_TYPE = "application/json";

        public Client(String node, String username, String password)
        {
            _username = username;
            _password = password;

            if (!String.IsNullOrEmpty(node))
            {
                _host = node;
            }
            else
            {
                throw new ArgumentNullException("Node cannot be null");
            }
        }

        public async Task<Models.GetInfo.Response> GetInfo(String chain)
        {
            //TODO:  String isnull or empty
            using (HttpClient client = new HttpClient())
            {
                Models.Request request = new Models.GetInfo.Request()
                {
                    ChainName = chain
                };

                String json = JsonConvert.SerializeObject(request);
                StringContent requestContent = new StringContent(json, Encoding.UTF8, MEDIA_TYPE);
                String url = String.Format("{0}", _host);

                String content = await Post(requestContent, url);
                return JsonConvert.DeserializeObject<Models.GetInfo.Response>(content);
            }
        }

        private async Task<String> Post(StringContent requestContent, String url)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                if (!String.IsNullOrEmpty(_username) && !String.IsNullOrEmpty(_password))
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes(string.Format("{0}:{1}", _username, _password))));
                }

                using (HttpResponseMessage responseMessage = await httpClient.PostAsync(url, requestContent))
                {
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        String responseContent = await responseMessage.Content.ReadAsStringAsync();
                        return responseContent;
                    }
                    else
                    {
                        //maybe here?
                        throw new InvalidOperationException();
                    }
                }
            }
        }

        //private static void SetBasicAuthHeader(WebRequest webRequest, string username, string password)
        //{
        //    var authInfo = username + ":" + password;
        //    authInfo = Convert.ToBase64String(Encoding.Default.GetBytes(authInfo));
        //    webRequest.Headers["Authorization"] = "Basic " + authInfo;
        //}
    }
}