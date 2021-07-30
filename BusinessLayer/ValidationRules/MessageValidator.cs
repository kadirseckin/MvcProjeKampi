using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class MessageValidator : AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(x => x.ReceiverMail).NotEmpty().WithMessage("Alıcı adresi boş geçilemez").
                EmailAddress().WithMessage("Geçerli bir mail adresi giriniz");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu boş geçilemez");
            RuleFor(x => x.MessageContent).NotEmpty().WithMessage("Mesaj içeriği boş geçilemez");
            RuleFor(x => x.Subject).MinimumLength(3).
                 WithMessage("Lütfen en az 3 karakter giriniz");
            RuleFor(x => x.Subject).MaximumLength(100).
                 WithMessage("En fazla 100 karakter giriniz");

        }
    }
}
