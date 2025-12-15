using EntityLayer.Concreate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Valitadions
{
    public class HeadingValidation : AbstractValidator<Heading>
    {
        public HeadingValidation()
        {
            RuleFor(x => x.HeadingName).NotEmpty().WithMessage("Başlık alanı boş bırakılamaz.").
            MinimumLength(3).WithMessage("Başlık alanı minimum 3 karakterden oluşmalıdır.").
            MaximumLength(30).WithMessage("Başlık alanı maksimum 30 karakterden oluşmalıdır.").
            Matches("^[a-zA-ZçÇğĞıİöÖşŞüÜ ]+$").WithMessage("Başlık sadece harflerden oluşmalıdır !!!");

            RuleFor(x => x.HeadingDate).NotEmpty().WithMessage("Tarih boş bırakılamaz.").
            Must(d => d.Day > 0 && d.Month > 0 && d.Year > 0).WithMessage("Gün, ay ve yıl eksiksiz girilmelidir.");
        }
    }
}
