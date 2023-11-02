using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using ZeusApp.Application.Interfaces.Repositories;
using ZeusApp.Domain.Entities.Catalog;
using ZeusApp.Domain.Enums;

namespace ZeusApp.Application.Features.StockIns.Commands.Create;
public class CreateStockInCommand : IRequest<Result<int>>
{
    

}

public class CreateStockInCommandHandler : IRequestHandler<CreateStockInCommand, Result<int>>
{
    private readonly IStockInRepository _stockInRepository; 
    private readonly IMapper _mapper;
    private IUnitOfWork _unitOfWork { get; set; }

    public CreateStockInCommandHandler(IStockInRepository stockInRepository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _stockInRepository = stockInRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateStockInCommand request, CancellationToken cancellationToken)
    {
        var stockIn = _mapper.Map<StockIn>(request);

        await _stockInRepository.InsertAsync(stockIn);
        await _unitOfWork.Commit(cancellationToken);
        return await Result<int>.SuccessAsync(stockIn.Id);
    }
}
