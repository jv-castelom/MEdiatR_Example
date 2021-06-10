using MediatR;
using MediatR_Exemplo.Core.Models.Entities;
using MediatR_Exemplo.Core.Repositories;
using MediatR_Exemplo.Shared;
using MediatR_Exemplo.Shared.Requests;
using MediatR_Exemplo.Shared.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MediatR_Exemplo.Core.RequestHandlers
{
    public sealed class CreateUserRequestHandler : IRequestHandler<CreateUserRequest, OperationResult<UserViewModel>>
    {
        private IUserRepository _repository;

        public CreateUserRequestHandler(IUserRepository repository)
        {
            _repository = repository;
        }
        public async Task<OperationResult<UserViewModel>> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var newUser = await _repository.InsertAsync(new UserEntity(request.Name, request.Email));
                return OperationResult<UserViewModel>.Success(new UserViewModel(newUser.Id, newUser.Name, newUser.Email));
            }
            catch(Exception ex)
            {
                return OperationResult<UserViewModel>.Error(ex);
            }
        }
    }
}
