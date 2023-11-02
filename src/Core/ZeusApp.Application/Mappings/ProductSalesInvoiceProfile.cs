using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ZeusApp.Application.Features.ProductSalesInvoices.Commands.Create;
using ZeusApp.Application.Features.ProductSalesInvoices.Queries.GetAllPaged;
using ZeusApp.Application.Features.ProductSalesInvoices.Queries.GetById;
using ZeusApp.Domain.Entities.Catalog;

namespace ZeusApp.Application.Mappings;
internal class ProductSalesInvoiceProfile : Profile
{
    public ProductSalesInvoiceProfile()
    {
        CreateMap<CreateProductSalesInvoiceCommand, ProductSalesInvoice>().ReverseMap();
        CreateMap<GetProductSalesInvoiceByIdResponse, ProductSalesInvoice>().ReverseMap();
        CreateMap<GetAllProductSalesInvoicesResponse, ProductSalesInvoice>().ReverseMap();
    }
}
