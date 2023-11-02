using AutoMapper;
using System.Net.Http;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace ZeusApp.WebApi.Controllers.v2;

public class StockControllers : BaseApiController<StockControllers>
{
//    public StockControllers(IMapper mapper, AppDbContext context) : base(mapper, context)
//    {
//    }


//    //Toplam Tutar(TotalAmount)= Miktar x  Birim Fiyat |  Amount* PurchasePriceExcludingVAT;
//    //İlgili hesaplamalar FrontEnd tarafta otomatik doldurulup gönderilecek 

//    private readonly IHttpClientFactory _httpClientFactory;
//    [HttpPost("[action]")]
//    public async Task<IActionResult> CreateStockIn(StockInCreateDto stockInCreateDto)
//    {
//        if (stockInCreateDto.StockInProductCreateDtos.Count == 0)
//        {
//            ModelState.AddModelError("", "En az bir ürün girilmelidir.");
//            return BadRequest(ModelState.AddModelStateErrorResult());
//        }

//        StockIn stockIn = new StockIn()
//        {
//            Currency = stockInCreateDto.Currency,
//            Description = stockInCreateDto.Description,
//            DocumentNo = stockInCreateDto.DocumentNo,
//            StockCategoryId = stockInCreateDto.StockCategoryId,
//            ExchangeRate = stockInCreateDto.ExchangeRate,
//            StockInMovementType = stockInCreateDto.StockInMovementType,
//            GrandTotal = stockInCreateDto.GrandTotal,
//        };


//        stockInCreateDto.StockInProductCreateDtos.ForEach(p =>
//        {
//            var product = _context.Products.SingleOrDefault(x => x.Id == p.ProductId);


//            product!.TotalStockAmount += p.StockAmount;

//            stockIn.ProductStocks.Add(new ProductStock
//            {
//                ProductId = p.ProductId,
//                StockAmount = p.StockAmount,
//                TotalAmount = p.TotalAmount,
//                PurchasePriceExcludingVAT = p.PurchasePriceExcludingVAT,
//                UnitType = p.UnitType,
//                StockType = StockType.stockIn,
//            });
//            _context.Products.Update(product);
//        });

//        await _context.StockIns.AddAsync(stockIn);
//        await _context.SaveChangesAsync();
//        return Ok();
//    }

//    [HttpGet("[action]/{id}")]
//    public async Task<IActionResult> GetStock(Guid id)
//    {

//        var stock = await _context.Stocks.FindAsync(id);

//        if (stock == null)
//        {
//            return NotFound(new ErrorResponseDto
//            {
//                PropertyName = string.Empty,
//                ErrorMessage = "Stok bulunamadı!"
//            });
//        }

//        if (stock.Discriminator == "StockIn")
//        {
//            var stockIn = await _context.StockIns.Include(x => x.ProductStocks).SingleOrDefaultAsync(x => x.Id == id);

//            StockInUpdateDto stockInUpdateDto = new StockInUpdateDto()
//            {
//                Id = id,
//                Currency = stockIn!.Currency,
//                Date = stockIn.Date,
//                DocumentNo = stockIn.DocumentNo,
//                Description = stockIn.Description,
//                ExchangeRate = stockIn.ExchangeRate,
//                GrandTotal = stockIn.GrandTotal,
//                StockCategoryId = stockIn.StockCategoryId,
//                StockInMovementType = stockIn.StockInMovementType,
//                UpdateDate = stockIn.UpdateDate,
//                StockType = StockType.stockIn

//            };


//            stockIn.ProductStocks.ToList().ForEach(x =>
//            {
//                stockInUpdateDto.StockInProductCreateDtos.Add(new StockInProductCreateDto
//                {
//                    ProductId = x.ProductId,
//                    PurchasePriceExcludingVAT = x.PurchasePriceExcludingVAT,
//                    StockAmount = x.StockAmount,
//                    TotalAmount = x.TotalAmount,
//                    UnitType = x.UnitType
//                });
//            });
//            return Ok(stockInUpdateDto);
//        }
//        else
//        {
//            var stockOut = await _context.StockOuts.Include(x => x.ProductStocks).SingleOrDefaultAsync(x => x.Id == id);
//            StockOutUpdateDto stockOutUpdateDto = new StockOutUpdateDto()
//            {
//                Id = id,
//                Date = stockOut!.Date,
//                Description = stockOut.Description,
//                DocumentNo = stockOut.DocumentNo,
//                StockCategoryId = stockOut.StockCategoryId,
//                StockOutMovementType = stockOut.StockOutMovementType,
//                UpdateDate = stockOut.UpdateDate,
//                StockType = StockType.stockOut
//            };

//            stockOut.ProductStocks.ToList().ForEach(x =>
//            {
//                stockOutUpdateDto.StockOutProductCreateDtos.Add(new StockOutProductCreateDto
//                {
//                    ProductId = x.ProductId,
//                    StockAmount = x.StockAmount,
//                    UnitType = x.UnitType
//                });
//            });
//            return Ok(stockOutUpdateDto);
//        }
//    }

//    [HttpPost("[action]")]
//    public async Task<IActionResult> CreateStockOut(StockOutCreateDto stockOutCreateDto)
//    {
//        if (stockOutCreateDto.StockOutProductCreateDtos.Count == 0)
//        {
//            ModelState.AddModelError("", "En az bir ürün girilmelidir.");
//            return BadRequest(ModelState.AddModelStateErrorResult());
//        }

//        StockOut stockOut = new StockOut()
//        {
//            Description = stockOutCreateDto.Description,
//            DocumentNo = stockOutCreateDto.DocumentNo,
//            StockCategoryId = stockOutCreateDto.StockCategoryId,
//            StockOutMovementType = stockOutCreateDto.StockOutMovementType,
//        };

//        stockOutCreateDto.StockOutProductCreateDtos.ForEach(p =>
//        {
//            var product = _context.Products.SingleOrDefault(x => x.Id == p.ProductId);
//            product!.TotalStockAmount -= p.StockAmount;
//            product!.UnitType = p.UnitType;

//            stockOut.ProductStocks.Add(new ProductStock
//            {
//                ProductId = p.ProductId,
//                UnitType = p.UnitType,
//                StockAmount = p.StockAmount,
//                StockType = StockType.stockOut
//            });
//            _context.Products.Update(product);
//        });
//        await _context.StockOuts.AddAsync(stockOut);
//        await _context.SaveChangesAsync();
//        return Ok();
//    }



//    [HttpPut("[action]")]
//    public async Task<IActionResult> UpdateStockInOrOut(StockUpdateDto updateDto)
//    {

//        var stockInUpdateDto = updateDto.StockInUpdateDto;

//        if (stockInUpdateDto.StockType == StockType.stockIn)
//        {
//            if (stockInUpdateDto.StockInProductCreateDtos.Count == 0)
//            {
//                ModelState.AddModelError("", "En az bir ürün girilmelidir.");
//                return BadRequest(ModelState.AddModelStateErrorResult());
//            }

//            var stockIn = await _context.StockIns.Include(x => x.ProductStocks).ThenInclude(x => x.Product).SingleOrDefaultAsync(x => x.Id == stockInUpdateDto.Id);

//            stockIn!.DocumentNo = stockInUpdateDto.DocumentNo;
//            stockIn.ExchangeRate = stockInUpdateDto.ExchangeRate;
//            stockIn.UpdateDate = stockInUpdateDto.UpdateDate;
//            stockIn.Currency = stockInUpdateDto.Currency;
//            stockIn.Date = stockInUpdateDto.Date;
//            stockIn.Description = stockInUpdateDto.Description;
//            stockIn.Date = stockInUpdateDto.Date;
//            stockIn.GrandTotal = stockInUpdateDto.GrandTotal;
//            stockIn.StockCategoryId = stockInUpdateDto.StockCategoryId;
//            stockIn.StockInMovementType = stockInUpdateDto.StockInMovementType;

//            stockIn.ProductStocks.ToList().ForEach(x =>
//            {
//                x.Product.TotalStockAmount = x.Product.TotalStockAmount - x.StockAmount;

//                _context.ProductStocks.Remove(x);
//            });

//            stockInUpdateDto.StockInProductCreateDtos.ForEach(p =>
//            {
//                var product = _context.Products.SingleOrDefault(x => x.Id == p.ProductId);

//                product!.TotalStockAmount += p.StockAmount;

//                stockIn.ProductStocks.Add(new ProductStock
//                {
//                    ProductId = p.ProductId,
//                    StockAmount = p.StockAmount,
//                    TotalAmount = p.TotalAmount,
//                    PurchasePriceExcludingVAT = p.PurchasePriceExcludingVAT,
//                    UnitType = p.UnitType,
//                    StockType = StockType.stockIn,
//                });
//                _context.Products.Update(product);
//            });

//            _context.StockIns.Update(stockIn);

//            await _context.SaveChangesAsync();
//        }
//        else
//        {
//            var stockOutUpdateDto = updateDto.StockOutUpdateDto;

//            if (stockOutUpdateDto.StockOutProductCreateDtos.Count == 0)
//            {
//                ModelState.AddModelError("", "En az bir ürün girilmelidir.");
//                return BadRequest(ModelState.AddModelStateErrorResult());
//            }

//            var stockOut = await _context.StockOuts.Include(x => x.ProductStocks).ThenInclude(x => x.Product).SingleOrDefaultAsync(x => x.Id == stockInUpdateDto.Id);

//            stockOut!.DocumentNo = stockOutUpdateDto.DocumentNo;
//            stockOut.UpdateDate = stockOutUpdateDto.UpdateDate;
//            stockOut.Date = stockOutUpdateDto.Date;
//            stockOut.Description = stockOutUpdateDto.Description;
//            stockOut.Date = stockOutUpdateDto.Date;
//            stockOut.StockCategoryId = stockOutUpdateDto.StockCategoryId;
//            stockOut.StockOutMovementType = stockOutUpdateDto.StockOutMovementType;

//            stockOut.ProductStocks.ToList().ForEach(x =>
//            {
//                x.Product.TotalStockAmount = x.Product.TotalStockAmount + x.StockAmount;
//                _context.ProductStocks.Remove(x);
//            });


//            stockOutUpdateDto.StockOutProductCreateDtos.ForEach(p =>
//            {
//                var product = _context.Products.SingleOrDefault(x => x.Id == p.ProductId);

//                product!.TotalStockAmount -= p.StockAmount;

//                stockOut.ProductStocks.Add(new ProductStock
//                {
//                    ProductId = p.ProductId,
//                    StockAmount = p.StockAmount,
//                    UnitType = p.UnitType,
//                    StockType = StockType.stockIn,
//                });
//                _context.Products.Update(product);
//            });

//            _context.StockOuts.Update(stockOut);
//            await _context.SaveChangesAsync();
//        }
//        return Ok();
//    }


//    [HttpDelete("{id}/{stockType}")]
//    public async Task<IActionResult> DeleteStock(Guid id, StockType stockType)
//    {

//        if (stockType == StockType.stockIn)
//        {
//            var stockIn = await _context.StockIns.Include(x => x.ProductStocks).ThenInclude(x => x.Product).SingleOrDefaultAsync(x => x.Id == id);

//            if (stockIn == null)
//            {
//                return NotFound(new ErrorResponseDto
//                {
//                    PropertyName = string.Empty,
//                    ErrorMessage = "Stok bulunamadı!"
//                });
//            }

//            stockIn!.ProductStocks.ToList().ForEach(x =>
//            {
//                x.Product.TotalStockAmount -= x.StockAmount;
//            });


//            _context.StockIns.Remove(stockIn);
//            await _context.SaveChangesAsync();
//        }
//        else
//        {
//            var stockOut = await _context.StockOuts.Include(x => x.ProductStocks).ThenInclude(x => x.Product).SingleOrDefaultAsync(x => x.Id == id);

//            if (stockOut == null)
//            {
//                return NotFound(new ErrorResponseDto
//                {
//                    PropertyName = string.Empty,
//                    ErrorMessage = "Stok bulunamadı!"
//                });
//            }


//            stockOut!.ProductStocks.ToList().ForEach(x =>
//            {
//                x.Product.TotalStockAmount += x.StockAmount;
//            });


//            _context.StockOuts.Remove(stockOut);
//            await _context.SaveChangesAsync();
//        }
//        return Ok();
//    }






//    //Stock giriş  formunda ürünler kısmındaki, ürünler dropdown ve Birim alanlarını doldurmak için
//    [HttpGet("[action]")]
//    public async Task<IActionResult> StockInCreateProductData()
//    {
//        var product = await _context.Products.Include(x => x.ProductStocks).OrderByDescending(x => x.CreatedDate).Select(x => new StockProductDto
//        {
//            ProductId = x.Id,
//            ProductName = x.Name,
//            UnitType = x.UnitType,
//            PurchasePriceExcludingVAT = x.PurchasePriceExcludingVAT,
//            TotalStockAmount = x.TotalStockAmount
//        }).ToListAsync();

//        return Ok(product);
//    }


//    //Stock Çıkış  formunda ürünler kısmındaki, ürünler dropdown ve Birim alanlarını doldurmak için

//    [HttpGet("[action]")]
//    public async Task<IActionResult> StockOutCreateProductData()
//    {
//        var product = await _context.Products.Include(x => x.ProductStocks).OrderByDescending(x => x.CreatedDate).Select(x => new
//        {
//            ProductId = x.Id,
//            TotalStockAmount = x.TotalStockAmount,
//            ProductName = x.Name,
//            UnitType = x.UnitType,
//        }).ToListAsync();
//        return Ok(product);
//    }

}
