using MediatR_Exemplo.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MediatR_Exemplo.Core.Repositories
{
    public interface IUserRepository : IRepository<UserEntity>
    {
        bool ContainsAnoherUserWithSameEmail(string email);
        
    }
}
