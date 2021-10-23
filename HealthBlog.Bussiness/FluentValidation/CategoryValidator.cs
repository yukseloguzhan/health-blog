using FluentValidation;
using HealthBlog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthBlog.Bussiness.FluentValidation
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Kategori ismi boş geçilemez!!!");
            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("Açıklama alanı boş geçilemez!!!");
            RuleFor(x => x.CategoryName).MinimumLength(3).MaximumLength(20).WithMessage("Kategori ismi 3-20 karakter arası olmalı!");

            /*RuleFor(c => c.CategoryName).Must(StartWithA).WithMessage("Urun adı A ile baslamali!!");

        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }*/
        }
    }
}
