using EntityLayer.Concreate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Valitadions
{
    public class AdminValidation : AbstractValidator<Admin>
    {
        public AdminValidation()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı Adı boş olmamalıdır !!").
            MinimumLength(5).WithMessage("Kullanıcı Adı alanı minimum 5 karakterden oluşmalıdır.").
            MaximumLength(25).WithMessage("Kullanıcı Adı alanı maksimum 25 karakterden oluşmalıdır.");

            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre boş olmamalıdır !!").
            MinimumLength(5).WithMessage("Şifre alanı minimum 5 karakterden oluşmalıdır.").
            MaximumLength(15).WithMessage("Şifre alanı maksimum 15 karakterden oluşmalıdır.");
        }
    }
}
