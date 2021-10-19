using Example.Core.Models;
using Example.Persistence.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Example.Persistence.Services
{
    public class JsonStorageService : IPersistenceStorageService
    {
        private static readonly string StorageString = @"[{""Name"":""Cierra Vega"",""Groups"":[""A""]},{""Name"":""Alden Cantrell"",""Groups"":[""B"",""D""]},{""Name"":""Kierra Gentry"",""Groups"":[""A"",""C""]},{""Name"":""Pierre Cox"",""Groups"":[""D""]},{""Name"":""Thomas Crane"",""Groups"":[""A"",""B""]},{""Name"":""Miranda Shaffer"",""Groups"":[""B""]},{""Name"":""Bradyn Kramer"",""Groups"":[""D""]},{""Name"":""Alvaro Mcgee"",""Groups"":[""A"",""D"",""C""]}]";

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task<MemoryStorage> GetDataFromPersistenceAsync()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            var jsonSalesPeople = JsonConvert.DeserializeObject<ICollection<JsonSalesPerson>>(StorageString);

            var salesPersonMap = new Dictionary<string, SalesPerson>();
            var salesGroupMap = new Dictionary<string, SalesGroup>();

            foreach (var jsonSalePerson in jsonSalesPeople)
            {
                SalesPerson currentSalesPerson;

                if (!salesPersonMap.TryGetValue(jsonSalePerson.Name, out currentSalesPerson))
                {
                    currentSalesPerson = new SalesPerson(jsonSalePerson.Name);

                    salesPersonMap.Add(
                        jsonSalePerson.Name,
                        currentSalesPerson
                    );
                }

                foreach(var groupName in jsonSalePerson.Groups)
                {
                    SalesGroup currentSalesGroup;

                    if (!salesGroupMap.TryGetValue(groupName, out currentSalesGroup))
                    {
                        currentSalesGroup = new SalesGroup(groupName);

                        salesGroupMap.Add(
                            groupName,
                            currentSalesGroup
                        );
                    }

                    currentSalesPerson.Groups.Add(currentSalesGroup);
                    currentSalesGroup.Members.Add(currentSalesPerson);
                }
            }

            return new MemoryStorage(salesPersonMap.Values, salesGroupMap.Values);
        }
    }
}
