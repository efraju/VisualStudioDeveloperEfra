using FluentValidation;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApII.Validations
{
    public class CustomerValidator:AbstractValidator<Customer>
            {
        public CustomerValidator()
        {
            RuleFor(x => x.FirstName)
            .NotEmpty()
            .WithMessage("Debes Enviar Firstname");

            RuleFor(x => x.LastName)
           .NotEmpty()
           .WithMessage("Debes Enviar LastName");

            RuleFor(x => x.Email)
           .NotEmpty()
           .WithMessage("Debes Enviar Email")
           .Must(BeBetween10And20)
           .WithMessage("La longitud del email no esta en el rango") ;

        }

        private bool BeBetween10And20(string email)
        {
            return email.Length > 10 && email.Length < 20;
        }
    }
    
}