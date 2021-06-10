using System;
using System.Collections.Generic;
using System.Text;

namespace MediatR_Exemplo.Core.Models.Entities
{
    public class UserEntity: BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public UserEntity(string name, string email)
        {
            Name = name;
            Email = email;
        }
    }
}
