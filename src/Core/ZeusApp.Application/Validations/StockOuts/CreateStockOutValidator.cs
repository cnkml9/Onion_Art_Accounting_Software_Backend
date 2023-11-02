using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using ZeusApp.Application.Features.StockOuts.Commands.Create;

namespace ZeusApp.Application.Validations.StockOuts;
public class CreateStockOutValidator : AbstractValidator<CreateStockOutCommand>
{
    public CreateStockOutValidator()
    {
        
    }
}
