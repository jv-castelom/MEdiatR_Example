using MediatR;
using MediatR_Exemplo.Shared.Pipeline;
using MediatR_Exemplo.Shared.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace MediatR_Exemplo.Shared.Requests
{
    public class CreateUserRequest: IRequest<OperationResult<UserViewModel>>, IValidatable
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
