using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using ZeusApp.Application.Features.ProductBrands.Commands.Create;

namespace ZeusApp.Application.Validations.ProductBrands;
public class CreateProductBrandValidator : AbstractValidator<CreateProductBrandCommand>
{
    public CreateProductBrandValidator()
    {
        
    }
}
