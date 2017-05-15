using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace WebDemoXPlatform.Clients
{
    [Obsolete]
    public class Client : IDisposable
    {
        private readonly String _host;
        private readonly String _username;
        private readonly String _password;
        private readonly Int16 _port;

        private const String MEDIA_TYPE = "application/json";

        public Client(String node, String username, String password, Int16 port = 8364)
        {
            _username = username;
            _password = password;
            _port = port;

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
            if (!String.IsNullOrEmpty(chain))
            {
                using (HttpClient client = new HttpClient())
                {
                    try
                    {
                        Models.Request request = new Models.GetInfo.Request()
                        {
                            ChainName = chain
                        };

                        String json = JsonConvert.SerializeObject(request);
                        StringContent requestContent = new StringContent(json, Encoding.UTF8, MEDIA_TYPE);
                        String url = String.Format("{0}:{1}", _host, _port);

                        String content = await Post(requestContent, url);
                        return JsonConvert.DeserializeObject<Models.GetInfo.Response>(content);
                    }
                    catch (Exception ex)
                    {
                        //
                        throw ex;
                    }
                }
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        public async Task<Models.ListStreams.Response> GetStreams(String chain)
        {
            if (!String.IsNullOrEmpty(chain))
            {
                using (HttpClient client = new HttpClient())
                {
                    Models.ListStreams.Request request = new Models.ListStreams.Request()
                    {
                        ChainName = chain
                    };

                    String json = JsonConvert.SerializeObject(request);
                    StringContent requestContent = new StringContent(json, Encoding.UTF8, MEDIA_TYPE);
                    String url = String.Format("{0}:{1}", _host, _port);

                    String content = await Post(requestContent, url);
                    return JsonConvert.DeserializeObject<Models.ListStreams.Response>(content);
                }
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        public async Task<Models.ListStreamsItems.Response> GetStreamItems(String chain, String stream)
        {
            if (!String.IsNullOrEmpty(chain) && !String.IsNullOrEmpty(stream))
            {
                using (HttpClient client = new HttpClient())
                {
                    Models.ListStreamsItems.Request request = new Models.ListStreamsItems.Request()
                    {
                        ChainName = chain
                    };

                    request.Params = new Object[1];
                    request.Params[0] = stream;

                    String json = JsonConvert.SerializeObject(request);
                    StringContent requestContent = new StringContent(json, Encoding.UTF8, MEDIA_TYPE);
                    String url = String.Format("{0}:{1}", _host, _port);

                    String content = await Post(requestContent, url);
                    return JsonConvert.DeserializeObject<Models.ListStreamsItems.Response>(content);
                }
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        public async Task<Models.ListStreamsItems.Response> PublishStreamItem(String chain, String stream, String id, String data)
        {
            if (!String.IsNullOrEmpty(chain) && !String.IsNullOrEmpty(stream))
            {
                using (HttpClient client = new HttpClient())
                {
                    try
                    {
                        Models.PublishStreamItem.Request request = new Models.PublishStreamItem.Request(chain, stream);
                        request.Params = new Object[3];
                        request.Params[0] = stream;
                        request.Params[1] = id;
                        request.Params[2] = data;

                        String json = JsonConvert.SerializeObject(request);
                        StringContent requestContent = new StringContent(json, Encoding.UTF8, MEDIA_TYPE);
                        String url = String.Format("{0}:{1}", _host, _port);

                        String content = await Post(requestContent, url);
                        return JsonConvert.DeserializeObject<Models.ListStreamsItems.Response>(content);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
            else
            {
                throw new ArgumentNullException();
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
                        throw new InvalidOperationException();
                    }
                }
            }
        }

        public void Dispose()
        {
        }
    }
}