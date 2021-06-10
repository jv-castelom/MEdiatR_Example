using System;
using System.Collections.Generic;
using System.Text;

namespace MediatR_Exemplo.Shared.ViewModel
{
    public class UserViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public UserViewModel(long id, string name, string email)
        {
            Id = id;
            Name = name;
            Email = email;
        }
    }
}
