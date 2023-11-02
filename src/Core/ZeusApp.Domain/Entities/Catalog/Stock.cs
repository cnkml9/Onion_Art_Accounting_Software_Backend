using System;
using System.Collections.Generic;
using AspNetCoreHero.Abstractions.Domain;

namespace ZeusApp.Domain.Entities.Catalog;


/// <summary>
/// Birim Fiyat= Product'ın ALIŞ FİYATI -> Birim Fiyat (KDV Hariç)
/// Toplam Tutar (TotalAmount)= Miktar x  Birim Fiyat |  Amount * PurchasePriceExcludingVAT;
/// Genel Toplam=Bu stokda seçilen tüm Productların TotalAmount'u olacak
/// </summary>

public abstract class Stock : AuditableEntity
{
    /// <summary>
    /// Tarih kullanıcı kendisi herhangi bir tarih girmek istiyor.
    /// </summary>
    public DateTime Date { get; set; }

    /// <summary>
    /// Belge No 
    /// </summary>
    public string DocumentNo { get; set; } = null!;

    /// <summary>
    ///Kategori
    /// </summary>
    public int? StockCategoryId { get; set; }
    public StockCategory StockCategory { get; set; }

    /// <summary>
    /// Açıklama
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Stok giriş mi? ,stok çıkış mı? 
    /// EF core ile otomatik gelen kolonu controller içinde kullanıldı.
    /// </summary>
    public string Discriminator { get; set; } = null!;

    /// <summary>
    ///  Stoğa ürün eklerken çoka çok ilişki.
    ///  Dikkat! aynı ürünü aynı stoğa bir daha ekleyebilir.
    /// </summary>
    public ICollection<ProductStock> ProductStocks { get; set; } = new HashSet<ProductStock>();
}

//public class StockConfiguration : IEntityTypeConfiguration<Stock>
//{
//    public void Configure(EntityTypeBuilder<Stock> builder)
//    {
//        builder.HasOne(x => x.StockCategory)
//            .WithMany(x => x.Stocks)
//            .HasForeignKey(x => x.StockCategoryId)
//            .OnDelete(DeleteBehavior.Restrict);
//    }
//}


