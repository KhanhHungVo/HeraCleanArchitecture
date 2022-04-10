using FluentValidation;

namespace Hera.Application.Users.Commands.CreateUser
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(v => v.UserName).NotEmpty();
            RuleFor(v => v.Password).NotEmpty();
        }
    }
}