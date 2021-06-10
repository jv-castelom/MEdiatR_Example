using MediatR_Exemplo.Core.Models.Entities;
using MediatR_Exemplo.Core.Repositories;
using MediatR_Exemplo.Shared.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MediatR_Exemplo.Data.Repositories
{
    public class Repository<T> : IRepository<T>
        where T : BaseEntity
    {
        protected List<T> _database;

        public Repository()
        {
            _database = new List<T>();
        }
        public T GetEntityAsync(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<T> InsertAsync(T entity)
        {
            var id = _database.Count+1;
            entity.Id = id;
            _database.Add(entity);
            return entity;
        }
    }
}
