using FluentValidation;
using HealthBlog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthBlog.Bussiness.FluentValidation
{
    public class MessageValidator  : AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(x => x.ReceiverMail).NotEmpty().WithMessage("Alıcı adresi boş geçilemez!!!");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu boş geçilemez!!!");
            RuleFor(x => x.Subject).MinimumLength(3).MaximumLength(40).WithMessage("Konu alanı 3-40 karakter arası olmalı!");
            RuleFor(x => x.SenderMail).EmailAddress().WithMessage("Mail adresi boş geçilemez");

        }
    }
}
