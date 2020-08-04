using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Microsoft.Dynamics.CrmClient
{
    public class EntityService
    {
        private readonly ServiceConnector _connector;
        private readonly string _logicalCollectionName;

        public EntityService(ServiceConnector connector, string logicalCollectionName)
        {
            _connector = connector;
            _logicalCollectionName = logicalCollectionName;
        }

        public async Task<Guid> Create(EntityData entityData)
        {

            var resourceUrl = _connector.GetResourceUrl(_logicalCollectionName);

            var body = JsonConvert.SerializeObject(entityData, Formatting.Indented);

            var response = await _connector.SendRequestAsync(HttpMethod.Post, resourceUrl, body);

            if (!response.IsSuccessStatusCode)
            {
                var responseError = await response.Content.ReadAsStringAsync();

                throw new RemoteCallException(response.ReasonPhrase, resourceUrl, responseError, body);
            }
            
            var oDataEntityId = response.Headers.GetValues("OData-EntityId").FirstOrDefault();

            var entityId = Guid.Parse(oDataEntityId.Replace(resourceUrl, string.Empty));

            return entityId;

        }

        public async Task<SearchResult> Search(QueryOptions queryOptions)
        {
            var resourceUrl = _connector.GetResourceUrl($"{_logicalCollectionName}?{queryOptions}");

            var response = await _connector.SendRequestAsync(HttpMethod.Get, resourceUrl);

            if (!response.IsSuccessStatusCode)
            {
                var responseError = await response.Content.ReadAsStringAsync();

                throw new RemoteCallException(response.ReasonPhrase, resourceUrl, responseError);
            }

            var responseData = await response.Content.ReadAsStringAsync();

            dynamic responseObject = JsonConvert.DeserializeObject<SearchResult>(responseData);

            return responseObject;
        }

        public async Task Update(object entityId, EntityData entityData)
        {
            var resourceUrl = _connector.GetResourceUrl($"{_logicalCollectionName}({entityId})");

            var data = JsonConvert.SerializeObject(entityData, Formatting.Indented);

            var response = await _connector.SendRequestAsync(new HttpMethod("PATCH"), resourceUrl, data);

            if (!response.IsSuccessStatusCode)
            {
                var responseError = await response.Content.ReadAsStringAsync();

                throw new RemoteCallException(response.ReasonPhrase, resourceUrl, responseError, data);
            }
        }
    }
}