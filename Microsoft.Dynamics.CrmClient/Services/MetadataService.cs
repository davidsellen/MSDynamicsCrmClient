using Microsoft.SqlServer.Server;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Microsoft.Dynamics.CrmClient
{
    public class MetadataService
    {
        private readonly IServiceConnector _service;
        public MetadataService(IServiceConnector service)
        {
            _service = service;
        }


        public async Task<Metadata> ListAllAsync()
        {
            var requestUri = _service.GetResourceUrl("EntityDefinitions?$select=LogicalName,LogicalCollectionName,DisplayName,PrimaryIdAttribute,PrimaryNameAttribute");

            var response = await _service.SendRequestAsync(HttpMethod.Get, requestUri);

            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException($"Remote call returned {response.StatusCode}");
            }

            var content = await response.Content.ReadAsStringAsync();

            var metadata = JsonConvert.DeserializeObject<Metadata>(content);

            return metadata;
        }

        public async Task<EntityAttributes> GetEntityAttributes(string entityLogicalName)
        {

            var requestUri = _service.GetResourceUrl($"EntityDefinitions(LogicalName='{entityLogicalName}')/Attributes");

            var response = await _service.SendRequestAsync(HttpMethod.Get, requestUri);

            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException($"Remote call returned {response.StatusCode}");
            }

            var content = await response.Content.ReadAsStringAsync();

            var data = JsonConvert.DeserializeObject<EntityAttributes>(content);

            return data;
        }

        public async Task<EntityMetadata> GetEntityDefinition(string entityLogicalName)
        {

            var requestUri = _service.GetResourceUrl($"EntityDefinitions(LogicalName='{entityLogicalName}')");

            var response = await _service.SendRequestAsync(HttpMethod.Get, requestUri);

            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException($"Remote call returned {response.StatusCode}");
            }

            var content = await response.Content.ReadAsStringAsync();

            var data = JsonConvert.DeserializeObject<EntityMetadata>(content);

            return data;
        }


        public async Task<PickListDefinition> GetPickListDefinition(string entityLogicalName, string logicalName = null)
        {

            var resource = $"EntityDefinitions(LogicalName='{entityLogicalName}')/Attributes/Microsoft.Dynamics.CRM.PicklistAttributeMetadata?$select=LogicalName&$expand=OptionSet";

            if (!string.IsNullOrWhiteSpace(logicalName))
            {
                resource = $"{resource}&$filter=LogicalName eq '{logicalName}'";
            }

            var requestUri = _service.GetResourceUrl(resource);

            var response = await _service.SendRequestAsync(HttpMethod.Get, requestUri);

            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException($"Remote call returned {response.StatusCode}");
            }

            var content = await response.Content.ReadAsStringAsync();

            var data = JsonConvert.DeserializeObject<PickListDefinition>(content);

            return data;
        }

        public async Task<OptionSet> GetStatusMetadata(string entityLogicalName, string fieldLogicalName)
        {

            var resource = $"EntityDefinitions(LogicalName='{entityLogicalName}')/Attributes(LogicalName='{fieldLogicalName}')/Microsoft.Dynamics.CRM.StatusAttributeMetadata/OptionSet?$select=Options";
            
            var requestUri = _service.GetResourceUrl(resource);

            var response = await _service.SendRequestAsync(HttpMethod.Get, requestUri);

            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException($"Remote call returned {response.StatusCode}");
            }

            var content = await response.Content.ReadAsStringAsync();

            var data = JsonConvert.DeserializeObject<OptionSet>(content);

            return data;
        }
    }


}
