using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ZeusApp.Application.Features.StockOuts.Commands.Create;
using ZeusApp.Application.Features.StockOuts.Queries.GetAllPaged;
using ZeusApp.Application.Features.StockOuts.Queries.GetById;
using ZeusApp.Domain.Entities.Catalog;

namespace ZeusApp.Application.Mappings;
internal class StockOutProfile : Profile
{
    public StockOutProfile()
    {
        CreateMap<CreateStockOutCommand, StockOut>().ReverseMap();
        CreateMap<GetStockOutByIdResponse, StockOut>().ReverseMap();
        CreateMap<GetAllStockOutsResponse, StockOut>().ReverseMap();
    }
}
