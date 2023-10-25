using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.UserMail).NotEmpty().WithMessage("Mail Adresini Boş geçemezsiniz");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu Adını boş beçemezsiniz");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı boş geçemezsiniz");
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("En Az 3 karakter girmelisiniz");
            RuleFor(x => x.UserName).MinimumLength(20).WithMessage("En Az 3 karakter girmelisiniz");
            RuleFor(x => x.Subject).MaximumLength(50).WithMessage("En Fazla 50 karakter girebilirsiniz");
        }
    }
}
