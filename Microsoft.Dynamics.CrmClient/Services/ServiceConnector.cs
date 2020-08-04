using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Dynamics.CrmClient
{

    public class ServiceConnector : IServiceConnector
    {
        const string ApiVersion = "v9.0";

        private readonly IServiceConnection _connection;

        private static AuthenticationResult _accessToken;

        public ServiceConnector(IServiceConnection connection)
        {
            _connection = connection;
        }

        public string GetResourceUrl(string resource)
        {
            var requestUri = $"{_connection.Url}/api/data/{ApiVersion}/{resource}";

            return requestUri;
        }

        private async Task<string> AccessTokenGenerator()
        {
            if (_accessToken != null && _accessToken.ExpiresOn > DateTime.Now.AddMinutes(1))
            {
                return _accessToken.AccessToken;
            }

            string clientId = _connection.ClientId;
            string clientSecret = _connection.ClientSecret;
            string authority = _connection.Authority;
            string resourceUrl = _connection.Url;

            var credentials = new ClientCredential(clientId, clientSecret);
            var authContext = new Microsoft.IdentityModel.Clients.ActiveDirectory.AuthenticationContext(authority);
            _accessToken = await authContext.AcquireTokenAsync(resourceUrl, credentials);

            return _accessToken.AccessToken;
        }

        public async Task<HttpResponseMessage> SendRequestAsync(HttpMethod httpMethod, string requestUri, string body = null)
        {
            var accessToken = await AccessTokenGenerator();
            var client = new HttpClient();
            var msg = new HttpRequestMessage(httpMethod, requestUri);
            msg.Headers.Add("OData-MaxVersion", "4.0");
            msg.Headers.Add("OData-Version", "4.0");
            msg.Headers.Add("Prefer", "odata.include-annotations=\"*\"");

            // Passing AccessToken in Authentication header  
            msg.Headers.Add("Authorization", $"Bearer {accessToken}");

            if (body != null)
                msg.Content = new StringContent(body, UnicodeEncoding.UTF8, "application/json");

            return await client.SendAsync(msg);
        }
    }


}
