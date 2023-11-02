using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AspNetCoreHero.Results;
using MediatR;
using ZeusApp.Application.Interfaces.Repositories;
using ZeusApp.Domain.Entities.Catalog;

namespace ZeusApp.Application.Features.CustomerSupplieries.Commands.Delete;
public class DeleteCustomerSupplierCommand : IRequest<Result<int>>
{
    public int Id { get; set; }

    public DeleteCustomerSupplierCommand(int id )
    {
        Id = id;
    }
    public class DeleteCustomerSupplierCommandHandler : IRequestHandler<DeleteCustomerSupplierCommand, Result<int>>
    {
        private readonly IRepositoryAsync<CustomerSupplier> _customerSupplierRepositoryAsync;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCustomerSupplierCommandHandler(IUnitOfWork unitOfWork, IRepositoryAsync<CustomerSupplier> repositoryAsync, IRepositoryAsync<CustomerSupplier> customerSupplierRepositoryAsync)
        {
            _unitOfWork = unitOfWork;
            _customerSupplierRepositoryAsync = customerSupplierRepositoryAsync;
        }

        public async Task<Result<int>> Handle(DeleteCustomerSupplierCommand command, CancellationToken cancellationToken)
        { 
            var customerSupplier = await _customerSupplierRepositoryAsync.GetByIdAsync(command.Id);
            
            if (customerSupplier == null)
                throw new KeyNotFoundException("Bu isimde bir Müşteri/Tedarikçi bulunamadı");

            await _customerSupplierRepositoryAsync.DeleteAsync(customerSupplier);
            await _unitOfWork.Commit(cancellationToken);
            return await Result<int>.SuccessAsync(customerSupplier.Id, 200);
        }
    }
}
