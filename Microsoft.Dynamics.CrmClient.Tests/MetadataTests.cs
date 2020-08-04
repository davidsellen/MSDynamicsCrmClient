using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Microsoft.Dynamics.CrmClient.Tests
{
    [TestClass]
    public class MetadataTests
    {
        [TestMethod]
        public async Task CanListAllEntities()
        {
            var connector = new ServiceConnector(new DemoConnection());

            var service = new MetadataService(connector);

            var metadata = await service.ListAllAsync();

            Assert.IsNotNull(metadata);

        }

        [TestMethod]
        public async Task CanListEntityFields()
        {
            var connector = new ServiceConnector(new DemoConnection());

            var entityLogicalName = "new_car";

            var service = new MetadataService(connector);

            var entityDefinition = await service.GetEntityDefinition(entityLogicalName);

            Assert.IsNotNull(entityDefinition);

        }

        [TestMethod]
        public async Task ExploreEntityAttributes()
        {
            var connector = new ServiceConnector(new DemoConnection());

            var service = new MetadataService(connector);

            var metadata = await service.ListAllAsync();

            var carMetadata = metadata.Entries.FirstOrDefault(m => m.LogicalName == "new_car");

            Assert.IsNotNull(carMetadata);

            var entityDefinition = await service.GetEntityAttributes(carMetadata.LogicalName);

            Assert.IsNotNull(entityDefinition);

            var ownerPropertyDefinition = entityDefinition.Entries.FirstOrDefault(v => v.LogicalName == "ownerid");
            Assert.IsNotNull(ownerPropertyDefinition);
            Assert.AreEqual(ownerPropertyDefinition.OdataType, "#Microsoft.Dynamics.CRM.LookupAttributeMetadata");
            CollectionAssert.AreEqual(ownerPropertyDefinition.Targets, new[] { "systemuser", "team" });

            var carTypePropertyDefinition = entityDefinition.Entries.FirstOrDefault(v => v.LogicalName == "new_cartype");
            Assert.IsNotNull(carTypePropertyDefinition);

            Assert.AreEqual(carTypePropertyDefinition.OdataType, "#Microsoft.Dynamics.CRM.PicklistAttributeMetadata");

            var optionSets = await service.GetPickListDefinition(carMetadata.LogicalName);
            Assert.IsNotNull(optionSets);

            var carTypeOptionSet = optionSets.Entries.FirstOrDefault(optionSet => optionSet.LogicalName == carTypePropertyDefinition.LogicalName);
            Assert.IsNotNull(carTypeOptionSet);

            var everyLookup = entityDefinition.Entries.Where(attr => attr.OdataType == "#Microsoft.Dynamics.CRM.LookupAttributeMetadata");

            Assert.IsNotNull(everyLookup);
        }


        [TestMethod]
        public async Task CanCreateOrUpdateCustomEntityInstance()
        {
            var entityLogicalName = "new_car";
            var logicalCollectionName = "new_cars";

            var connector = new ServiceConnector(new DemoConnection());

            var service = new MetadataService(connector);

            var metadata = await service.ListAllAsync();

            var carMetadata = metadata.Entries.FirstOrDefault(m => m.LogicalName == entityLogicalName);

            Assert.IsNotNull(carMetadata);

            var entityDefinition = await service.GetEntityAttributes(entityLogicalName);

            Assert.IsNotNull(entityDefinition);

            var cars = new EntityService(connector, logicalCollectionName);

            var name = "Civic";

            var cx3 = new QueryOptions()
                .Equal(carMetadata.PrimaryNameAttribute, name)
                .Top(1);

            var carMatches = await cars.Search(cx3);

            if (carMatches.Entries.Length > 0)
            {
                //update
                var carId = carMatches.Entries[0][carMetadata.PrimaryIdAttribute];

                var teamMetadata = metadata.Entries.FirstOrDefault(m => m.LogicalName == "team");
                Assert.IsNotNull(teamMetadata);

                var teams = new EntityService(connector, teamMetadata.LogicalCollectionName);

                var smtdemo = new QueryOptions().Equal("name", "Demo Team").Top(1);

                var matchingTeam = await teams.Search(smtdemo);

                var carUpdateData = new EntityData { { "new_engine", 3 }, { "new_carname", $"HONDA {name}" } };

                if (matchingTeam.Entries.Length > 0)
                {
                    carUpdateData.Add("ownerid@odata.bind", $"/{teamMetadata.LogicalCollectionName}({matchingTeam.Entries[0][teamMetadata.PrimaryIdAttribute]})");
                }

                await cars.Update(carId, carUpdateData);
            }
            else
            {

                var carTypePropertyDefinition = entityDefinition.Entries.FirstOrDefault(v => v.LogicalName == "new_cartype");
                
                Assert.IsNotNull(carTypePropertyDefinition);
                Assert.AreEqual(carTypePropertyDefinition.OdataType, "#Microsoft.Dynamics.CRM.PicklistAttributeMetadata");
                var optionSets = await service.GetPickListDefinition(entityLogicalName);
                Assert.IsNotNull(optionSets);
                var carTypeOptionSet = optionSets.Entries.FirstOrDefault(optionSet => optionSet.LogicalName == carTypePropertyDefinition.LogicalName);
                Assert.IsNotNull(carTypeOptionSet);

                var cartType = carTypeOptionSet.OptionSet.Options.FirstOrDefault(o => o.Label.LocalizedLabels.Any(l => l.Label == "SEDAN"));

                var entityData = new EntityData
                {
                    { carMetadata.PrimaryNameAttribute, name },
                    { "new_cartype", cartType.Value },
                    { "new_engine", 2 },
                    { "new_carname", $"HONDA {name}" },
                    { "ownerid@odata.bind","/systemusers(3d035ea1-36a7-ea11-a812-000d3a2537aa)" }
                };
                 

                //create
                var entityId = await cars.Create(entityData);
                Assert.IsNotNull(entityId);
                Assert.AreNotEqual(entityId, Guid.Empty);
            }


        }


        [TestMethod]
        public void CanCreateUpdateEntityInstance()
        {

            /*
            var ownerPropertyDefinition = entityDefinition.Value.FirstOrDefault(v => v.LogicalName == "ownerid");
            Assert.IsNotNull(ownerPropertyDefinition);
            Assert.AreEqual(ownerPropertyDefinition.OdataType, "#Microsoft.Dynamics.CRM.LookupAttributeMetadata");

            CollectionAssert.AreEqual(ownerPropertyDefinition.Targets, new[] { "systemuser", "team" });

            var systemUserMetadata = metadata.Value.FirstOrDefault(m => m.LogicalName == "systemuser");
            Assert.IsNotNull(systemUserMetadata);

            var carTypePropertyDefinition = entityDefinition.Value.FirstOrDefault(v => v.LogicalName == "new_cartype");
            Assert.IsNotNull(carTypePropertyDefinition);
            Assert.AreEqual(carTypePropertyDefinition.OdataType, "#Microsoft.Dynamics.CRM.PicklistAttributeMetadata");
            var optionSets = await service.GetPickListDefinition(entityLogicalName);
            Assert.IsNotNull(optionSets);
            var carTypeOptionSet = optionSets.Value.FirstOrDefault(optionSet => optionSet.LogicalName == carTypePropertyDefinition.LogicalName);
            Assert.IsNotNull(carTypeOptionSet);

            var users = new EntityService(connector, systemUserMetadata.LogicalCollectionName);

            var linus = new QueryOptions()
               .Equal("internalemailaddress", "linus.osterberg@releye.se")
               .Top(1);

            var matches = await users.Search(linus);

            if (matches.TotalRecordCount > 0)
            {

                var firstMatch = matches.Value[0];
                if (firstMatch.ContainsKey(systemUserMetadata.PrimaryIdAttribute))
                {
                    var systemUserId = firstMatch[systemUserMetadata.PrimaryIdAttribute];


                }

            }*/
        }

        [TestMethod]
        public void CanFindEntityByProvidedCondition()
        {
        }

    }
}
