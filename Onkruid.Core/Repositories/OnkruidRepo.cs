using Microsoft.EntityFrameworkCore;
using Onkruid.Core.Data;
using Onkruid.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onkruid.Core.Repositories
{
    public class OnkruidRepo : IOnkruidRepo
    {
        //fields
        private readonly ApplicationDbContext _context;

        //constructor injection (dependency injection)
        public OnkruidRepo(ApplicationDbContext context)
        {
            this._context = context;
        }

        //methods
        public async Task<IEnumerable<Familie>> GetFamiliesAsync()
        {
            //haal onkruid families op
            return await _context.Familie.ToListAsync();
        }
        public async Task<IEnumerable<Onkruid_Naam>> GetOnkruidNamenAsync(string OnkruidFamilie)
        {
            //haal onkruid families op
            return await _context
                .Onkruid_Naam
                .Where( o => o.Familie_Naam == OnkruidFamilie)
                .ToListAsync();
        }
    }
}
