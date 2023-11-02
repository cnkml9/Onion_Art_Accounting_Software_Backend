using System;
using AspNetCoreHero.Abstractions.Domain;
using ZeusApp.Domain.Enums;

namespace ZeusApp.Domain.Entities.Catalog;

/// <summary>
/// Base tablodan miras almadım.
/// Stok tablosunda bununla ilgili AuditableEntity değerleri tutulmaktadır. 
/// </summary>
public class ProductStock : AuditableEntity
{
    public int ProductId { get; set; }
    public int StockId { get; set; }

    public Product Product { get; set; }
    public Stock Stock { get; set; }

    /// <summary>
    /// Birimi dinamik olarak eklenecek:
    /// To Do: Birim tablosu yapılacak
    /// </summary>
    //[Display(Name = "Birimi")]
    //public UnitType UnitType { get; set; }

    /// <summary>
    /// ALIŞ Birim Fiyat (KDV Hariç)
    /// </summary>
    public decimal PurchasePriceExcludingVAT { get; set; }


    /// <summary>
    ///Stok Tipi 
    /// </summary>
    public StockType StockType { get; set; }


    /// <summary>
    /// Stok Miktarı
    /// </summary>
    public decimal StockAmount { get; set; } = 1;


    /// <summary>
    /// Toplam Tutar
    /// </summary>
    public decimal TotalAmount { get; set; }
}

//public class ProductStockConfiguration : IEntityTypeConfiguration<ProductStock>
//{
//    public void Configure(EntityTypeBuilder<ProductStock> builder)
//    {
//        builder.HasKey(x => x.Id);

//        builder.HasOne(x => x.Stock)
//             .WithMany(x => x.ProductStocks)
//             .HasForeignKey(x => x.StockId);

//        builder.HasOne(pc => pc.Product)
//            .WithMany(c => c.ProductStocks)
//            .HasForeignKey(pc => pc.ProductId);
//    }
//}
