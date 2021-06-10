using FluentValidation;
using MediatR_Exemplo.Core.Repositories;
using MediatR_Exemplo.Shared.Requests;

namespace MediatR_Exemplo.Core.Validators
{
    public class CreateUserRequestValidator : AbstractValidator<CreateUserRequest>
    {
        public CreateUserRequestValidator(IUserRepository _userRepository)
        {
            RequiredProperties();
            UniqueProperties(_userRepository);
        }

        private void RequiredProperties()
        {
            RuleFor(user => user.Name)
                .Must(name => !string.IsNullOrWhiteSpace(name))
                .WithMessage("The property Name is Required");

            RuleFor(user => user.Email)
                .Must(email => !string.IsNullOrWhiteSpace(email))
                .WithMessage("The property Email is Required");
        }
        private void UniqueProperties(IUserRepository userRepository)
        {
            RuleFor(user => user.Email)
                .Must(email => !userRepository.ContainsAnoherUserWithSameEmail(email))
                .WithMessage("A User with the same email already exists.");
        }
    }
}
