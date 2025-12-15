using EntityLayer.Concreate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Valitadions
{
    public class WriterLoginValidations: AbstractValidator<Writer>
    {
        public WriterLoginValidations()
        {
          
            RuleFor(x => x.WriterMail).NotEmpty().WithMessage("Mail alanı boş bırakılamaz.").
            MinimumLength(9).WithMessage("Mail alanı minimum 9 karakterden oluşmalıdır.").
            MaximumLength(50).WithMessage("Mail alanı maksimum 50 karakterden oluşmalıdır.").
            Matches(@"^[\w\.\-\/]+@([\w\-]+\.)+[\w\-]{2,}$").WithMessage("Geçerli bir e-posta adresi giriniz!");

            RuleFor(x => x.WriterPassword).NotEmpty().WithMessage("Şifre boş olmamalıdır !!").
            MinimumLength(5).WithMessage("Şifre alanı minimum 5 karakterden oluşmalıdır.").
            MaximumLength(15).WithMessage("Şifre alanı maksimum 15 karakterden oluşmalıdır.");
        }
    }
}
