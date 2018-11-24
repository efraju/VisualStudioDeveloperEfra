using FluentValidation;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApII.Validations
{ 
        public class StudentValidator : AbstractValidator<Student>
        {
            public StudentValidator()
            {
                RuleFor(x => x.FirstName)
                .NotEmpty()
                .WithMessage("Debes Enviar Firstname");

                RuleFor(x => x.LastName)
               .NotEmpty()
               .WithMessage("Debes Enviar LastName");

                RuleFor(x => x.Address)
               .NotEmpty()
               .WithMessage("Debes Enviar Address");

            } 
    }
}