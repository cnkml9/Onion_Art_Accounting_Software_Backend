using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using ZeusApp.Application.Features.StockIns.Commands.Update;

namespace ZeusApp.Application.Validations.StockIns;
public class UpdateStockInValidator : AbstractValidator<UpdateStockInCommand>
{
    public UpdateStockInValidator()
    {
        
    }
}
