using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ZeusApp.Application.Features.SalesInvoiceCategories.Commands.Create;
using ZeusApp.Application.Features.SalesInvoiceCategories.Queries.GetAllPaged;
using ZeusApp.Application.Features.SalesInvoiceCategories.Queries.GetById;
using ZeusApp.Domain.Entities.Catalog;

namespace ZeusApp.Application.Mappings;
internal class SalesInvoiceCategoryProfile : Profile
{
    public SalesInvoiceCategoryProfile()
    {
        CreateMap<CreateSalesInvoiceCategoryCommand, SalesInvoiceCategory>().ReverseMap();
        CreateMap<GetSalesInvoiceCategoryByIdResponse, SalesInvoiceCategory>().ReverseMap();
        CreateMap<GetAllSalesInvoiceCategoriesResponse, SalesInvoiceCategory>().ReverseMap();
    }
}
