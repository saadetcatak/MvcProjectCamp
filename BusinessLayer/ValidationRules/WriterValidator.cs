using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar adını boş geçemezsiniz");
            //RuleFor(x => x.WriterName).Must(a => a.ToLower().Contains("a")).WithMessage("Yazar adında a harfi olmalıdır");
            RuleFor(x=>x.WriterSurname).NotEmpty().WithMessage("Yazar soyadını boş geçemezsiniz");
            RuleFor(x => x.WriterTitle).NotEmpty().WithMessage("Yazar ünvanını boş geçemezsiniz");
            RuleFor(x=>x.WriterName).MinimumLength(2).WithMessage("En Az 2 karakter girmelisiniz");
            RuleFor(x => x.WriterName).MaximumLength(50).WithMessage("Lütfen 50 karakterden fazla veri girişi yapmayın");
        }
    }
}
