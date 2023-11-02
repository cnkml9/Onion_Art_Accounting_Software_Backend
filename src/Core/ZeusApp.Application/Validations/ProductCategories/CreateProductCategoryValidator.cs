using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using ZeusApp.Application.Features.ProductCategories.Commands.Create;

namespace ZeusApp.Application.Validations.ProductCategories;
public class CreateProductCategoryValidator : AbstractValidator<CreateProductCategoryCommand>
{
    public CreateProductCategoryValidator()
    {
        
    }
}
