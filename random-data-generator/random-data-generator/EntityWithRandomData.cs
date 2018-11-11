using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using System.Collections.Generic;
using System.Linq;

namespace random_data_generator
{
    public class EntityWithRandomData
    {
        private readonly IOrganizationService _service;
        private readonly List<Attribute> _attributes;
        private readonly string _logicalName;


        public EntityWithRandomData(IOrganizationService service, List<Attribute> attributes)
        {
            _service = service;
            _attributes = attributes;
            _logicalName = attributes.First().EntityName;
        }

        public CreateRequest GetCreateRequest()
        {

            var entity = new Entity(_logicalName);
            foreach (var attribute in _attributes)
            {
                entity[attribute.LogicalName] = attribute.GetRandomData(_service);
            }

            return new CreateRequest { Target = entity };
        }

    }
}
