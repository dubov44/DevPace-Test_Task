using System.Net.Http.Formatting;
using DevPace.WebApi.Client.Config;
using Microsoft.Rest;
using Newtonsoft.Json;

namespace DevPace.WebApi.Client.HttpServices
{
    public abstract class HttpServiceBase
    {
        private static readonly MediaTypeFormatter JsonFormatter = new JsonMediaTypeFormatter
        {
            SerializerSettings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
                PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                NullValueHandling = NullValueHandling.Ignore,
                DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate
            }
        };

        private readonly IHttpClientFactory _clientFactory;

        protected HttpServiceBase(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        private HttpClient CreateClient()
        {
            return _clientFactory.CreateClient(ClientName);
        }

        protected virtual string ClientName => ClientNameConfig.CustomerClientName;

        protected Task<T> Send<T>(string path, HttpMethod method, CancellationToken token = default)
        {
            return Send<T>(path, method, default(KeyValuePair<string, string>), token);
        }

        protected Task<T> Send<T>(string path, HttpMethod method, KeyValuePair<string, string> header, CancellationToken token = default)
        {
            var request = new HttpRequestMessage(method, path);

            if (!string.IsNullOrWhiteSpace(header.Key) &&
                !string.IsNullOrWhiteSpace(header.Value))
            {
                request.Headers.Add(header.Key, header.Value);
            }

            return Send<T>(request, token);
        }

        protected async Task<T> Send<T>(HttpRequestMessage request, CancellationToken token = default)
        {
            var response = await Send(request, token);
            return await response.Content.ReadAsAsync<T>(token);
        }

        protected async Task<TResult> Send<T, TResult>(string path, HttpMethod method, T body, CancellationToken token = default)
        {
            var request = new HttpRequestMessage(method, path)
            {
                Content = GetContent(body)
            };
            var response = await Send(request, token);
            return await response.Content.ReadAsAsync<TResult>(token);
        }

        protected Task<HttpResponseMessage> Send(string path, HttpMethod method, CancellationToken token = default)
        {
            var request = new HttpRequestMessage(method, path);
            return Send(request, token);
        }

        protected Task<HttpResponseMessage> Send<T>(string path, HttpMethod method, T body, CancellationToken token = default)
        {
            var request = new HttpRequestMessage(method, path)
            {
                Content = GetContent(body)
            };
            return Send(request, token);
        }

        private ObjectContent<T> GetContent<T>(T body)
        {
            return new ObjectContent<T>(body, JsonFormatter);
        }

        protected async Task<HttpResponseMessage> Send(HttpRequestMessage request, CancellationToken token)
        {
            var client = CreateClient();
            var response = await client.SendAsync(request, token);

            if (response.IsSuccessStatusCode)
            {
                return response;
            }

            var responseContent = await response.Content.ReadAsStringAsync(token);

            throw new RestException();
        }
    }
}
