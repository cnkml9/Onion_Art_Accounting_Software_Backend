using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ZeusApp.Application.Features.StockIns.Commands.Create;
using ZeusApp.Application.Features.StockIns.Queries.GetAllPaged;
using ZeusApp.Application.Features.StockIns.Queries.GetById;
using ZeusApp.Domain.Entities.Catalog;

namespace ZeusApp.Application.Mappings;
internal class StockInProfile : Profile
{
    public StockInProfile()
    {
        CreateMap<CreateStockInCommand, StockIn>().ReverseMap();
        CreateMap<GetStockInByIdResponse, StockIn>().ReverseMap();
        CreateMap<GetAllStockInsResponse, StockIn>().ReverseMap();
    }
}
