using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ZeusApp.Application.Features.SalesInvoiceCategories.Queries.GetById;
using ZeusApp.Application.Features.SalesInvoices.Commands.Create;
using ZeusApp.Application.Features.SalesInvoices.Queries.GetAllPaged;
using ZeusApp.Domain.Entities.Catalog;

namespace ZeusApp.Application.Mappings;
internal class SalesInvoiceProfile : Profile
{
    public SalesInvoiceProfile()
    {
        CreateMap<CreateSalesInvoiceCommand, SalesInvoice>().ReverseMap();
        CreateMap<GetSalesInvoiceByIdResponse, SalesInvoice>().ReverseMap();
        CreateMap<GetAllSalesInvoicesResponse, SalesInvoice>().ReverseMap();
    }
}
