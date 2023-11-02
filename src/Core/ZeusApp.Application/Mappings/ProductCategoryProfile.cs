using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ZeusApp.Application.Features.ProductCategories.Commands.Create;
using ZeusApp.Application.Features.ProductCategories.Queries.GetAllPaged;
using ZeusApp.Application.Features.ProductCategories.Queries.GetById;
using ZeusApp.Domain.Entities.Catalog;

namespace ZeusApp.Application.Mappings;
internal class ProductCategoryProfile : Profile
{
    public ProductCategoryProfile()
    {
        CreateMap<CreateProductCategoryCommand, ProductCategory>().ReverseMap();
        CreateMap<GetProductCategoryByIdResponse, ProductCategory>().ReverseMap();
        CreateMap<GetAllProductCategoriesResponse, ProductCategory>().ReverseMap();
    }
}
