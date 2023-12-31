using OsDsII.api.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OsDsII.api.Repositories.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;

        public UnitOfWork(DataContext context)
        {
            _context = context;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}