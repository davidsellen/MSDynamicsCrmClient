using System.Net.Http;
using System.Threading.Tasks;

namespace Microsoft.Dynamics.CrmClient
{
    public interface IServiceConnector
    {
        string GetResourceUrl(string resource);
        Task<HttpResponseMessage> SendRequestAsync(HttpMethod httpMethod, string requestUri, string body = null);
    }
}