using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using ZeusApp.Application.Features.SalesInvoices.Commands.Create;

namespace ZeusApp.Application.Validations.SalesInvoices;
public class CreateSalesInvoiceValidator : AbstractValidator<CreateSalesInvoiceCommand>
{
    public CreateSalesInvoiceValidator()
    {
        
    }
}
