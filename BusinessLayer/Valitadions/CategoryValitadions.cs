using EntityLayer.Concreate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Valitadions
{
    public class CategoryValitadions : AbstractValidator<Category>
    {
        public CategoryValitadions()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("İsim alanı boş bırakılamaz.").
            MinimumLength(3).WithMessage("İsim alanı minimum 3 karakterden oluşmalıdır.").
            MaximumLength(15).WithMessage("İsim alanı maksimum 15 karakterden oluşmalıdır.").
            Matches("^[a-zA-ZçÇğĞıİöÖşŞüÜ ]+$").WithMessage("İsim sadece harflerden oluşmalıdır !!!");
        }
    }
}
