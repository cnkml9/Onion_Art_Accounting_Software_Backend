using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ZeusApp.Application.Features.Products.Commands.Create;
using ZeusApp.Application.Features.Products.Queries.GetAllPaged;
using ZeusApp.Application.Features.Products.Queries.GetById;
using ZeusApp.Domain.Entities.Catalog;

namespace ZeusApp.Application.Mappings;
internal class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<CreateProductCommand, Product>().ReverseMap();
        CreateMap<GetProductByIdResponse, Product>().ReverseMap();
        CreateMap<GetAllProductsResponse, Product>().ReverseMap();
    }
}
