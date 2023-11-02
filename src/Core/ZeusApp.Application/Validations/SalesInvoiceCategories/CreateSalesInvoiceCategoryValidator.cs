using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using ZeusApp.Application.Features.SalesInvoiceCategories.Commands.Create;

namespace ZeusApp.Application.Validations.SalesInvoiceCategories;
public class CreateSalesInvoiceCategoryValidator : AbstractValidator<CreateSalesInvoiceCategoryCommand>
{
    public CreateSalesInvoiceCategoryValidator()
    {
        
    }
}
