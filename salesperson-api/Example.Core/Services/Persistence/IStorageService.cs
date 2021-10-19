﻿using Example.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Example.Core.Services
{
    public interface IStorageService
    {
        public Task<ICollection<SalesPerson>> GetSalesPersonsFromStorage();
    }
}