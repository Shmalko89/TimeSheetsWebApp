using FluentValidation;
using System.Runtime.InteropServices;
using TimeSheetsWebApp.Models;

namespace TimeSheetsWebApp
{
    public class UserValidationService : AbstractValidator<Users>
    {

        public UserValidationService()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("Имя не может быть пустым").WithErrorCode("BRL-100.1");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Фамилия не должна быть пустой").WithErrorCode("BRL-100.2");
        }
    }
}
