using Onkruid.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Onkruid.Core.Repositories
{
    public class OnkruidRepo
    {

        private readonly ApplicationDbContext _context;

        public OnkruidRepo(ApplicationDbContext context)
        {
            this._context = context;
        }
    }
}
