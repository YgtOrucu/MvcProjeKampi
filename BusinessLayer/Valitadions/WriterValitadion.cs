using EntityLayer.Concreate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Valitadions
{
    public class WriterValitadion : AbstractValidator<Writer>
    {
        public WriterValitadion()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Ad alanı boş bırakılamaz.").
            MinimumLength(3).WithMessage("Ad alanı minimum 3 karakterden oluşmalıdır.").
            MaximumLength(30).WithMessage("Ad alanı maksimum 30 karakterden oluşmalıdır.").
            Matches("^[a-zA-ZçÇğĞıİöÖşŞüÜ ]+$").WithMessage("Ad sadece harflerden oluşmalıdır !!!");

            RuleFor(x => x.WriterSurname).NotEmpty().WithMessage("Soyadı alanı boş bırakılamaz.").
            MinimumLength(3).WithMessage("Soyadı alanı minimum 3 karakterden oluşmalıdır.").
            MaximumLength(30).WithMessage("Soyadı alanı maksimum 30 karakterden oluşmalıdır.").
            Matches("^[a-zA-ZçÇğĞıİöÖşŞüÜ ]+$").WithMessage("Soyadı sadece harflerden oluşmalıdır !!!");

            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Hakkımda alanı boş bırakılamaz.").
            MinimumLength(5).WithMessage("Hakkımda alanı minimum 5 karakterden oluşmalıdır.").
            MaximumLength(100).WithMessage("Hakkımda alanı maksimum 100 karakterden oluşmalıdır.").
            Matches("^[a-zA-ZçÇğĞıİöÖşŞüÜ/\\- ]+$").WithMessage("Hakkımda sadece harf, / ve - karakterlerinden oluşabilir!");

            RuleFor(x => x.WriterMail).NotEmpty().WithMessage("Mail alanı boş bırakılamaz.").
            MinimumLength(9).WithMessage("Mail alanı minimum 9 karakterden oluşmalıdır.").
            MaximumLength(50).WithMessage("Mail alanı maksimum 50 karakterden oluşmalıdır.").
            Matches(@"^[\w\.\-\/]+@([\w\-]+\.)+[\w\-]{2,}$").WithMessage("Geçerli bir e-posta adresi giriniz!");
        }
    }
}
