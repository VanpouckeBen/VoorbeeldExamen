﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Onkruid.Core.Models;

namespace Onkruid.Core.Repositories
{
    public interface IOnkruidRepo
    {
        Task<IEnumerable<Familie>> GetFamiliesAsync();
        Task<IEnumerable<Onkruid_Naam>> GetOnkruidNamenAsync(string onkruidFamilie);
    }
}