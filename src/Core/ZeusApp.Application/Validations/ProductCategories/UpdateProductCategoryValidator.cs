﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using ZeusApp.Application.Features.ProductCategories.Commands.Update;

namespace ZeusApp.Application.Validations.ProductCategories;
public class UpdateProductCategoryValidator : AbstractValidator<UpdateProductCategoryCommand>
{
    public UpdateProductCategoryValidator()
    {
        
    }
}
