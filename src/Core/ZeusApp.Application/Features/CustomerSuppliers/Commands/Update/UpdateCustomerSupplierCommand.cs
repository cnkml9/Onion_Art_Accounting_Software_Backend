using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ZeusApp.Application.DTOs.Bank;
using ZeusApp.Application.DTOs.Contact;
using ZeusApp.Application.DTOs.OtherAddress;
using ZeusApp.Application.DTOs.RelatedPerson;
using ZeusApp.Application.Features.Banks.Commands.Create;
using ZeusApp.Application.Features.Contacts.Commands.Create;
using ZeusApp.Application.Features.OtherAddresses.Commands.Create;
using ZeusApp.Application.Features.RelatedPersons.Commands.Create;
using ZeusApp.Application.Interfaces.Repositories;
using ZeusApp.Domain.Entities.Catalog;
using ZeusApp.Domain.Enums;

namespace ZeusApp.Application.Features.CustomerSupplieries.Commands.Update;
public class UpdateCustomerSupplierCommand : IRequest<Result<int>>
{
    public int Id { get; set; }

    [Display(Name = "Ünvan")]
    public string? Title { get; set; }

    [Display(Name = "Müşteri / Tedarikçi Kodu:")]
    public string? CustomerSupplierCode { get; set; }

    [Display(Name = "Kısa Ünvan")]
    public string? ShortTitle { get; set; }

    [Display(Name = "Tipi *")]
    public CustomerSupplierType CustomerSupplierType { get; set; }
    public GeneralType GeneralType { get; set; }

    [Display(Name = "Vergi Dairesi")]
    public string? TaxOffice { get; set; }

    [Display(Name = "Açılış Bakiyesi")]
    [Precision(25, 2)]
    public decimal OpeningBalance { get; set; }

    [Display(Name = "Açılış Bakiyesi Tarihi")]
    public DateTime OpeningBalanceDate { get; set; }

    [Display(Name = "Döviz *")]
    public CurrencyType? Currency { get; set; }

    [Display(Name = "KDV Uygulanmaz")]
    public bool IsVATExempt { get; set; }

    [Display(Name = "Tevkifat Uygulanmaz")]
    public bool IsWithholdingTaxExempt { get; set; }

    [Display(Name = "Ek Vergi Uygulanmaz")]
    public bool IsAdditionalTaxExempt { get; set; }

    [Display(Name = "Açıklama")]
    public string? Description { get; set; }

    [Display(Name = "Kategori")]
    public int? CustomerCategoryId { get; set; }


    //İndividual Customer
    [Display(Name = "T.C. Kimlik No")]
    public string? TcIdNumber { get; set; }

    [Display(Name = "Ad *")]
    public string? FirstName { get; set; }

    [Display(Name = "Soyad *")]
    public string? LastName { get; set; }


    //CorporateCustomer
    [Display(Name = "Vergi No")]
    public string? TaxNumber { get; set; }

    public ContactResponse Contact { get; set; }
    public List<RelatedPersonResponse> RelatedPersons { get; set; }
    public List<OtherAddressResponse> OtherAddresses { get; set; }
    public List<BankResponse> Banks { get; set; }
}

public class UpdateCustomerSupplierCommandHandler : IRequestHandler<UpdateCustomerSupplierCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICorporateCustomerSupplierRepository _corporateCustomerSupplierRepository;
    private readonly IIndividualCustomerSupplierRepository _individualCustomerSupplierRepository;

    private readonly ICustomerSupplierRepository _customerSupplierRepository;
    private readonly IMapper _mapper;
    public UpdateCustomerSupplierCommandHandler(ICorporateCustomerSupplierRepository corporateCustomerSupplierRepository, IUnitOfWork unitOfWork, IMapper mapper, IIndividualCustomerSupplierRepository individualCustomerSupplierRepository, ICustomerSupplierRepository customerSupplierRepository)
    {
        _corporateCustomerSupplierRepository = corporateCustomerSupplierRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _individualCustomerSupplierRepository = individualCustomerSupplierRepository;
        _customerSupplierRepository = customerSupplierRepository;
    }

    public async Task<Result<int>> Handle(UpdateCustomerSupplierCommand command, CancellationToken cancellationToken)
    {

        if (command.GeneralType == GeneralType.Individual)
        {
            if (command.FirstName == null || command.LastName == null)
            {
                throw new Exception("Ad ve Soyad alanları zorunludur!");
            }

            var modelIndividual = await _customerSupplierRepository.GetByIdAsync(command.Id);

            if (modelIndividual == null)
            {
                throw new KeyNotFoundException("Bu isimde bir Müşteri/Tedarikçi bulunamadı");
            }

            var getIndividualModel = _mapper.Map<UpdateCustomerSupplierCommand, dynamic>(command, modelIndividual);
            IndividualCustomerSupplier individualModel = _mapper.Map<IndividualCustomerSupplier>(getIndividualModel);
            individualModel.Discriminator = "IndividualCustomerSupplier";
            await _individualCustomerSupplierRepository.UpdateAsync(individualModel);
            await _unitOfWork.Commit(cancellationToken);

            return await Result<int>.SuccessAsync(getIndividualModel.Id, 200);
        }

        if (command.Title == null || command.TaxOffice == null)
        {
            throw new Exception("Ünvan ve Vergi Dairesi alanları zorunludur!");
        }


        var model = await _customerSupplierRepository.GetByIdAsync(command.Id);

        if (model == null)
        {
            throw new KeyNotFoundException("Bu isimde bir Müşteri/Tedarikçi bulunamadı");
        }


        var getCorporateModel = _mapper.Map<UpdateCustomerSupplierCommand, dynamic>(command, model);
        CorporateCustomerSupplier corporateModel = _mapper.Map<CorporateCustomerSupplier>(getCorporateModel);
        corporateModel.Discriminator = "CorporateCustomerSupplier";

        await _corporateCustomerSupplierRepository.UpdateAsync(corporateModel);
        await _unitOfWork.Commit(cancellationToken);

        return await Result<int>.SuccessAsync(getCorporateModel.Id, 200);
    }
}