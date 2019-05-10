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
            //haal onkruid families 
            // --> gebruik van AsNoTracking voor caching probleem op te lossen. 
            // --> (aantal rijen data zijn correct, maar data is verkeerd opgevuld)
            var result = _context
                 .Onkruid_Naam
                 .Where(o => o.Familie_Naam == OnkruidFamilie)
                 .AsNoTracking();
                 ;
               

            return await result.ToListAsync();
        }
        //testje
        public IEnumerable<Onkruid_Naam> GetOnkruidNamen(string OnkruidFamilie)
        {
            return _context
                 .Onkruid_Naam.AsNoTracking();
        }

        public async Task<Onkruid_Naam> GetOnkruidNaamAsync(string wetenschappelijkeNaam)
        {
            //neem de laatste die toegevoegd is als er meerdere zijn.
            return await _context
                .Onkruid_Naam
                .Include(o => o.Gebruik)
                .LastOrDefaultAsync(o => o.Wetenschappelijke_Naam == wetenschappelijkeNaam);
        }
    }
}
