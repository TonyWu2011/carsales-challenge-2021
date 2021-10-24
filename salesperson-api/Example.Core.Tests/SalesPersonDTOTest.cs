using Example.Core.Models;
using Example.Core.Models.DTOs;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Example.Core.Tests
{
    public class SalesPersonDTOTest
    {
        [Fact]
        public void SalesPersonDTO_constructor()
        {
            var salesPerson = new SalesPerson("Person 1")
            {
                IsBusy = false,
                Groups = new List<SalesGroup>
                {
                    new SalesGroup("Group 1"),
                    new SalesGroup("Group 2"),
                }
            };

            var result = new SalesPersonDTO(salesPerson);

            Assert.Equal(salesPerson.Name, result.Name);
            Assert.Equal(salesPerson.IsBusy, result.IsBusy);
            Assert.Equal(salesPerson.Groups.Select(x => x.Name), result.Groups);
        }
    }
}
