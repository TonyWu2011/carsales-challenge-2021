using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Example.Core.Enums;
using Example.Core.Models;
using Example.Core.Services;
using Example.Persistence.Services;

namespace Example.Infrastructure.Services
{
    public class FakeSalesPersonService : ISalesPersonService
    {
        private IStorageService StorageService { get; }
        private ISalesGroupService SalesGroupService { get; }

        public FakeSalesPersonService(IStorageService storageService, ISalesGroupService salesGroupService)
        {
            StorageService = storageService;
            SalesGroupService = salesGroupService;
        }

        public async Task<ICollection<SalesPerson>> GetSalesPeopleAsync()
        {
            return await StorageService.GetSalesPeopleAsync();
        }

        public async Task<SalesPerson> AssignBestSalePersonAsync(CarType carType, LanguageOption languageOption)
        {
            var salesPeople = await StorageService.GetSalesPeopleAsync();

            var carTypeSalesGroup = await SalesGroupService.GetSalesGroupForCarTypeAsync(carType);
            var languageSalesGroup = await SalesGroupService.GetSalesGroupForLanguageAsync(languageOption);

            var availableSalesPeople = salesPeople.Where(x => !x.IsBusy).ToList();

            // Early termination if all Sales People are occupied
            if (availableSalesPeople.Count <= 0)
            {
                return null;
            }
            // Early termination if only have one avaliable Sale Person
            else if (availableSalesPeople.Count == 1)
            {
                var salePerson = availableSalesPeople.First();
                salePerson.IsBusy = true;

                return salePerson;
            }
            else
            {
                var salePerson = GetBestSalesPerson(availableSalesPeople, carTypeSalesGroup, languageSalesGroup);

                if (salePerson != null)
                {
                    salePerson.IsBusy = true;

                    return salePerson;
                }
                else
                {
                    return null;
                }
            }
        }

        private SalesPerson GetBestSalesPerson(ICollection<SalesPerson> availableSalesPeople, SalesGroup carTypeSalesGroup, SalesGroup languageSalesGroup)
        {
            if (carTypeSalesGroup == null && languageSalesGroup == null)
            {
                var rand = new Random();
                return availableSalesPeople.ElementAt(rand.Next(availableSalesPeople.Count));
            }
            else
            {
                var bestSalePersonQuery = availableSalesPeople.AsQueryable();
                if (carTypeSalesGroup != null)
                {
                    bestSalePersonQuery = bestSalePersonQuery.Where(x => x.Groups.Contains(carTypeSalesGroup));
                }

                if (languageSalesGroup != null)
                {
                    bestSalePersonQuery = bestSalePersonQuery.Where(x => x.Groups.Contains(languageSalesGroup));
                }

                var bestSalePerson = bestSalePersonQuery.FirstOrDefault();

                if (bestSalePerson == null)
                {
                    if (carTypeSalesGroup != null && languageSalesGroup != null)
                    {
                        languageSalesGroup = null;
                    }
                    else if (carTypeSalesGroup != null || languageSalesGroup != null)
                    {
                        carTypeSalesGroup = null;
                        languageSalesGroup = null;
                    }

                    return GetBestSalesPerson(availableSalesPeople, carTypeSalesGroup, languageSalesGroup);
                }
                else
                {
                    return bestSalePerson;
                }
            }
        }
    }
}