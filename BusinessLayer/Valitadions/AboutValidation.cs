using EntityLayer.Concreate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Valitadions
{
    public class AboutValidation : AbstractValidator<About>
    {
        public AboutValidation()
        {
            RuleFor(x => x.AboutDetails1).NotEmpty().WithMessage("Detay 1 Alanı boş bırakılamaz").
            MinimumLength(10).WithMessage("Detay 1 Alanı minumum 10 karakter olmalıdır");
            RuleFor(x => x.AboutDetails2).NotEmpty().WithMessage("Detay 2 Alanı boş bırakılamaz").
            MinimumLength(10).WithMessage("Detay 2 Alanı minumum 10 karakter olmalıdır");
        }
    }
}
