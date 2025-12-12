using EntityLayer.Concreate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Valitadions
{
    public class MessageValidation : AbstractValidator<Message>
    {
        public MessageValidation()
        {
            RuleFor(x => x.ReceiverMail).NotEmpty().WithMessage("Mail alanı boş bırakılamaz.").
            MinimumLength(9).WithMessage("Mail alanı minimum 9 karakterden oluşmalıdır.").
            MaximumLength(50).WithMessage("Mail alanı maksimum 50 karakterden oluşmalıdır.").
            Matches(@"^[\w\.\-\/]+@([\w\-]+\.)+[\w\-]{2,}$").WithMessage("Geçerli bir e-posta adresi giriniz!");

            RuleFor(x => x.MessageSubject).NotEmpty().WithMessage("Konu alanı boş bırakılamaz.").
            MinimumLength(5).WithMessage("Konu alanı minimum 5 karakterden oluşmalıdır.").
            MaximumLength(20).WithMessage("Konu alanı maksimum 20 karakterden oluşmalıdır.");

            RuleFor(x => x.MessageContent).NotEmpty().WithMessage("İçerik alanı boş bırakılamaz.").
            MinimumLength(20).WithMessage("İçerik alanı minimum 20 karakterden oluşmalıdır.").
            MaximumLength(100).WithMessage("İçerik alanı maksimum 100 karakterden oluşmalıdır.");
        }
    }
}
