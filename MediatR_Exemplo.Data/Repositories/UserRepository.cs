using MediatR_Exemplo.Core.Models.Entities;
using MediatR_Exemplo.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MediatR_Exemplo.Data.Repositories
{
    public class UserRepository : Repository<UserEntity>, IUserRepository
    {
        public bool ContainsAnoherUserWithSameEmail(string email)
        => _database.Any(user => user.Email == email);
    }
}
