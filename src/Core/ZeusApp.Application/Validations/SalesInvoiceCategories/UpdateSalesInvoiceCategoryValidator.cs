using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using ZeusApp.Application.Features.SalesInvoiceCategories.Commands.Update;

namespace ZeusApp.Application.Validations.SalesInvoiceCategories;
public class UpdateSalesInvoiceCategoryValidator : AbstractValidator<UpdateSalesInvoiceCategoryCommand>
{
    public UpdateSalesInvoiceCategoryValidator()
    {
        
    }
}
