using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using ZeusApp.Application.Features.StockIns.Commands.Create;

namespace ZeusApp.Application.Validations.StockIns;
public class CreateStockInValidator : AbstractValidator<CreateStockInCommand>
{
    public CreateStockInValidator()
    {
        
    }
}
