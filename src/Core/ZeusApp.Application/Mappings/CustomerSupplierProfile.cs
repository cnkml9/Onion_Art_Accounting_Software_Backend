using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ZeusApp.Application.Features.CorporateCustomerSupplieries.Queries.GetById;
using ZeusApp.Application.Features.CustomerSupplieries.Commands.Create;
using ZeusApp.Application.Features.CustomerSupplieries.Commands.Update;
using ZeusApp.Domain.Entities.Catalog;

namespace ZeusApp.Application.Mappings;
public class CustomerSupplierProfile:Profile
{
    public CustomerSupplierProfile()
    {
        CreateMap<CreateCustomerSupplierCommand, IndividualCustomerSupplier>();
        CreateMap<CreateCustomerSupplierCommand, CorporateCustomerSupplier>();

        CreateMap<UpdateCustomerSupplierCommand, CorporateCustomerSupplier>().ReverseMap();
        CreateMap<UpdateCustomerSupplierCommand, IndividualCustomerSupplier>().ReverseMap();
      
        
        CreateMap<IndividualCustomerSupplier,GetCustomerSupplierByIdResponse>().ReverseMap();
        CreateMap<CorporateCustomerSupplier,GetCustomerSupplierByIdResponse>().ReverseMap();

        CreateMap<CustomerSupplier, IndividualCustomerSupplier>().ReverseMap();

        CreateMap<CustomerSupplier, CorporateCustomerSupplier>().ReverseMap();
    }
}
