using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AspNetCoreHero.Results;
using MediatR;
using ZeusApp.Application.Features.Ayarlar.Commands.Delete;
using ZeusApp.Application.Interfaces.Repositories;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ZeusApp.Application.Features.StockIns.Commands.Delete;
public class DeleteStockInCommand : IRequest<Result<int>>
{
    public int Id { get; set; }
    public class DeleteStockInCommandHandler : IRequestHandler<DeleteStockInCommand, Result<int>>
    {
        private readonly IStockInRepository _stockInRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteStockInCommandHandler(IStockInRepository stockInRepository, IUnitOfWork unitOfWork)
        {
            _stockInRepository = stockInRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<int>> Handle(DeleteStockInCommand request, CancellationToken cancellationToken)
        {
            var stockIn = await _stockInRepository.GetByIdAsync(request.Id);
            await _stockInRepository.DeleteAsync(stockIn);
            await _unitOfWork.Commit(cancellationToken);
            return await Result<int>.SuccessAsync(stockIn.Id);
        }
    }
}
