using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using ZeusApp.Application.Features.ProductSalesInvoices.Commands.Update;

namespace ZeusApp.Application.Validations.ProductSalesInvoices;
public class UpdateProductSalesInvoiceValidator : AbstractValidator<UpdateProductSalesInvoiceCommand>
{
    public UpdateProductSalesInvoiceValidator()
    {
        
    }
}
