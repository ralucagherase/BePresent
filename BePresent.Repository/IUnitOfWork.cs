using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BePresent.Repository.Interface
{
    public interface IUnitOfWork
    {
        IRepository<T> GetRepository<T>() where T : class, IEntity;

        int SaveChanges();

        Task<int> SaveChangesAsync();

    }
}
