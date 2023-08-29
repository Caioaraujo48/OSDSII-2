using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OsDsII.api.Repositories.UnitOfWork;

namespace OsDsII.api.Repositories.UnitOfWork : IUnitOfWork
{
    public interface IUnitOfWork
    {
        public Task SaveChangesAsync();
    }
}