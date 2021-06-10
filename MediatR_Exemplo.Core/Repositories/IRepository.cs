using MediatR_Exemplo.Core.Models.Entities;
using MediatR_Exemplo.Shared.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MediatR_Exemplo.Core.Repositories
{
    public interface IRepository<T>
        where T:BaseEntity
    {
        public Task<T> InsertAsync(T entity);
        public T GetEntityAsync(long id);
    }
}
