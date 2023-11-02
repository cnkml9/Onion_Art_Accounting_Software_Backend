using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZeusApp.Application.Features.Ayarlar.Commands.Update;
using ZeusApp.Application.Features.Ayarlar.Queries.GetById;
using ZeusApp.Application.Features.CorporateCustomerSupplieries.Queries.GetById;
using ZeusApp.Application.Features.CustomerSupplieries.Commands.Create;
using ZeusApp.Application.Features.CustomerSupplieries.Commands.Delete;
using ZeusApp.Application.Features.CustomerSupplieries.Commands.Update;
using ZeusApp.Domain.Entities.Catalog;
using ZeusApp.Infrastructure.DbContexts;

namespace ZeusApp.WebApi.Controllers.v2;

[AllowAnonymous]
public class CustomerController : BaseApiController<CustomerController>
{
    private readonly ApplicationDbContext _context;

    public CustomerController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateCustomerSupplierCommand command)
    {
        var model = await _mediator.Send(command);
        return Ok(model);

    }



    [HttpPut]
    public async Task<IActionResult> Put(UpdateCustomerSupplierCommand command)
    {
        var updateResult = await _mediator.Send(command);
        return Ok(updateResult);
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleteResult = _mediator.Send(new DeleteCustomerSupplierCommand(id));
        return Ok(deleteResult);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
     
        var customerSupplier = await _mediator.Send(new GetCustomerSupplierByIdQuery(id));
        return Ok(customerSupplier);
    }



    //[HttpGet("{id}")]
    //public async Task<IActionResult> GetCustomer(Guid id)
    //{
    //    var customer = await _context.Customer_Suppliers
    //        .Include(x => x.Contact)
    //        .Include(x => x.Banks)
    //        .Include(x => x.OtherAddresses)
    //        .Include(x => x.RelatedPersons)
    //        .SingleOrDefaultAsync(x => x.Id == id);

    //    if (customer != null)
    //    {
    //        return Ok(customer);
    //    }

    //    return NotFound(new ErrorResponseDto
    //    {
    //        PropertyName = string.Empty,
    //        ErrorMessage = "Bu isimde bir Müşteri/Tedarikçi bulunamadı"
    //    });
    //}

    //[HttpGet("[action]")]
    //public async Task<IActionResult> GetDataTableAllCustomer()
    //{
    //    var customers = await _context.Customer_Suppliers.AsNoTracking().OrderByDescending(x => x.CreatedDate)
    //           .Include(x => x.Contact)
    //           .Select(x => new GetDataTableCustomerDto
    //           {
    //               Id = x.Id,
    //               FirstName = _context.IndividualCustomer_Suppliers.SingleOrDefault(p => p.Id == x.Id)!.FirstName,
    //               LastName = _context.IndividualCustomer_Suppliers.SingleOrDefault(p => p.Id == x.Id)!.LastName,
    //               City = x.Contact.City,
    //               CustomerSupplierCode = x.CustomerSupplierCode,
    //               GeneralType = x.GeneralType,
    //               Status = x.Status,
    //               OpeningBalance = x.OpeningBalance,
    //               Title = x.Title,
    //               PhoneNumber1 = x.Contact.PhoneNumber1
    //           }).ToListAsync();
    //    return Ok(customers);
    //}






    //[HttpPost("[action]")]
    //public async Task<IActionResult> CreateCustomerCategory(CreateCategoryDto createDto)
    //{

    //    if (ModelState.IsValid)
    //    {
    //        CustomerCategory customerCategory = new CustomerCategory()
    //        {
    //            Name = createDto.Name,
    //        };
    //        await _context.CustomerCategories.AddAsync(customerCategory);
    //        await _context.SaveChangesAsync();
    //        return Ok();
    //    }
    //    return BadRequest(ModelState.AddModelStateErrorResult());
    //}

    //[HttpPut("[action]")]
    //public async Task<IActionResult> updateCustomerCategory(UpdateCategoryDto updateDto)
    //{

    //    if (ModelState.IsValid)
    //    {
    //        var customerCategory = await _context.CustomerCategories.FindAsync(updateDto.Id);
    //        customerCategory!.Name = updateDto.Name;

    //        _context.CustomerCategories.Update(customerCategory);
    //        await _context.SaveChangesAsync();
    //        return Ok();
    //    }
    //    return BadRequest(ModelState.AddModelStateErrorResult());
    //}

    //[HttpDelete("[action]/{id}")]
    //public async Task<IActionResult> DeleteCustomerCategory(Guid id)
    //{
    //    var category = await _context.CustomerCategories.FindAsync(id);
    //    if (category != null)
    //    {
    //        _context.CustomerCategories.Remove(category);

    //        try
    //        {
    //            await _context.SaveChangesAsync();
    //            return Ok();
    //        }
    //        catch (DbUpdateException)
    //        {
    //            return BadRequest(new ErrorResponseDto
    //            {
    //                PropertyName = string.Empty,
    //                ErrorMessage = $"Kategori alanı, bir ya da daha fazla Müşteri/Tedarikçi ile ilişkili olduğundan dolayı silme işlemi tamamlanamıyor!"
    //            });
    //        }

    //    }
    //    return BadRequest(ModelState.AddModelStateErrorResult());
    //}


    //[HttpGet("[action]")]
    //public async Task<IActionResult> GetAllCustomerCategory()
    //{
    //    var customerCategories = await _context.CustomerCategories
    //        .OrderByDescending(x => x.CreatedDate)
    //        .Select(x => new { x.Name, x.Id })
    //        .ToListAsync();

    //    return Ok(customerCategories);
    //}
}
