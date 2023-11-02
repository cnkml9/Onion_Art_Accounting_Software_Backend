using AutoMapper;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ZeusApp.WebApi.Controllers.v2;


public class ProductControllers : BaseApiController<ProductControllers>
{
    //public ProductControllers(IMapper mapper, AppDbContext context) : base(mapper, context)
    //{
    //}


    //[HttpPost]
    //public async Task<IActionResult> Create(ProductCreateDto createDto)
    //{
    //    if (ModelState.IsValid)
    //    {
    //        var product = _mapper.Map<Product>(createDto);
    //        await _context.Products.AddAsync(product);
    //        await _context.SaveChangesAsync();
    //        return Ok();
    //    }
    //    return BadRequest(ModelState.AddModelStateErrorResult());
    //}

    //[HttpPut]
    //public async Task<IActionResult> Update(ProductUpdateDto updateDto)
    //{
    //    if (ModelState.IsValid)
    //    {
    //        var product = await _context.Products.FindAsync(updateDto.Id);

    //        if (product == null)
    //        {
    //            return NotFound(new ErrorResponseDto
    //            {
    //                PropertyName = string.Empty,
    //                ErrorMessage = "Bu isimde bir ürün bulunamadı!"
    //            });
    //        }
    //        var updateProduct = _mapper.Map<ProductUpdateDto, Product>(updateDto, product);
    //        _context.Products.Update(updateProduct);
    //        await _context.SaveChangesAsync();
    //        return Ok();
    //    }
    //    return BadRequest(ModelState.AddModelStateErrorResult());
    //}

    //[HttpDelete("{id}")]
    //public async Task<IActionResult> Delete(Guid id)
    //{
    //    var product = await _context.Products.FindAsync(id);
    //    if (product == null)
    //    {
    //        return NotFound(new ErrorResponseDto
    //        {
    //            PropertyName = string.Empty,
    //            ErrorMessage = "Bu isimde bir ürün bulunamadı!"
    //        });
    //    }
    //    _context.Products.Remove(product);
    //    await _context.SaveChangesAsync();
    //    return Ok();
    //}

    //[HttpGet("{id}")]
    //public async Task<IActionResult> GetProduct(Guid id)
    //{
    //    var product = await _context.Products
    //        .Include(x => x.ProductBrand)
    //        .Include(x => x.ProductCategory)
    //        .SingleOrDefaultAsync(x => x.Id == id);

    //    var getProductDto = _mapper.Map<GetProductDto>(product);

    //    if (getProductDto != null)
    //    {
    //        return Ok(getProductDto);
    //    }

    //    return NotFound(new ErrorResponseDto
    //    {
    //        PropertyName = string.Empty,
    //        ErrorMessage = "Bu isimde bir ürün bulunamadı!"
    //    });
    //}


    //[HttpGet("[action]")]
    //public async Task<IActionResult> GetDataTableAllProduct()
    //{
    //    var customers = await _context.Products.AsNoTracking().OrderByDescending(x => x.CreatedDate)

    //           .Select(x => new GetDataTableProductDto
    //           {
    //               Id = x.Id,
    //               Code = x.Code,
    //               Name = x.Name,
    //               PurchasePriceIncludingVAT = x.PurchasePriceIncludingVAT,
    //               SalesPriceIncludingVAT = x.SalesPriceIncludingVAT,
    //               UnitType = x.UnitType,
    //               VATRate = x.VATRate,
    //               TotalStockAmount = x.TotalStockAmount
    //           }).ToListAsync();
    //    return Ok(customers);
    //}


    //[HttpPost("[action]")]
    //public async Task<IActionResult> CreateProductCategory(CreateCategoryDto createDto)
    //{
    //    if (ModelState.IsValid)
    //    {
    //        ProductCategory productCategory = new ProductCategory()
    //        {
    //            Name = createDto.Name,
    //        };
    //        await _context.ProductCategories.AddAsync(productCategory);

    //        await _context.SaveChangesAsync();
    //        return Ok();
    //    }
    //    return BadRequest(ModelState.AddModelStateErrorResult());
    //}

    //[HttpPut("[action]")]
    //public async Task<IActionResult> UpdateProductCategory(UpdateCategoryDto updateDto)
    //{

    //    if (ModelState.IsValid)
    //    {
    //        var productCategory = await _context.ProductCategories.FindAsync(updateDto.Id);
    //        productCategory!.Name = updateDto.Name;

    //        _context.ProductCategories.Update(productCategory);
    //        await _context.SaveChangesAsync();
    //        return Ok();
    //    }
    //    return BadRequest(ModelState.AddModelStateErrorResult());
    //}

    //[HttpDelete("[action]/{id}")]
    //public async Task<IActionResult> DeleteProductCategory(Guid id)
    //{
    //    var category = await _context.ProductCategories.FindAsync(id);
    //    if (category != null)
    //    {
    //        _context.ProductCategories.Remove(category);

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
    //                ErrorMessage = $"Kategori alanı, bir ya da daha fazla ürün ile ilişkili olduğundan dolayı silme işlemi tamamlanamıyor!"
    //            });
    //        }

    //    }
    //    return BadRequest(ModelState.AddModelStateErrorResult());
    //}


    //[HttpGet("[action]")]
    //public async Task<IActionResult> GetAllProductCategories()
    //{
    //    var productCategories = await _context.ProductCategories
    //        .OrderByDescending(x => x.CreatedDate)
    //        .Select(x => new { x.Name, x.Id })
    //        .ToListAsync();

    //    return Ok(productCategories);
    //}




    //[HttpPost("[action]")]
    //public async Task<IActionResult> CreateProductBrand(CreateCategoryDto createDto)
    //{
    //    if (ModelState.IsValid)
    //    {
    //        ProductBrand productBrand = new ProductBrand()
    //        {
    //            Name = createDto.Name,
    //        };
    //        await _context.ProductBrands.AddAsync(productBrand);
    //        await _context.SaveChangesAsync();
    //        return Ok();
    //    }
    //    return BadRequest(ModelState.AddModelStateErrorResult());
    //}


    //[HttpPut("[action]")]
    //public async Task<IActionResult> UpdateProductBrand(UpdateCategoryDto updateDto)
    //{
    //    if (ModelState.IsValid)
    //    {
    //        var productBrand = await _context.ProductBrands.FindAsync(updateDto.Id);
    //        productBrand!.Name = updateDto.Name;

    //        _context.ProductBrands.Update(productBrand);
    //        await _context.SaveChangesAsync();
    //        return Ok();
    //    }
    //    return BadRequest(ModelState.AddModelStateErrorResult());
    //}

    //[HttpDelete("[action]/{id}")]
    //public async Task<IActionResult> DeleteProductBrand(Guid id)
    //{
    //    var brand = await _context.ProductBrands.FindAsync(id);
    //    if (brand != null)
    //    {
    //        _context.ProductBrands.Remove(brand);
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
    //                ErrorMessage = $"Kategori alanı, bir ya da daha fazla ürün ile ilişkili olduğundan dolayı silme işlemi tamamlanamıyor!"
    //            });
    //        }
    //    }
    //    return BadRequest(ModelState.AddModelStateErrorResult());
    //}


    //[HttpGet("[action]")]
    //public async Task<IActionResult> GetAllProductBrands()
    //{
    //    var productBrands = await _context.ProductBrands
    //        .OrderByDescending(x => x.CreatedDate)
    //        .Select(x => new { x.Name, x.Id })
    //        .ToListAsync();

    //    return Ok(productBrands);
    //}
}
