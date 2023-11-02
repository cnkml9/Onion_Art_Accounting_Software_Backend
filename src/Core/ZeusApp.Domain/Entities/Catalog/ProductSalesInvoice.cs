using AspNetCoreHero.Abstractions.Domain;
using System;
using ZeusApp.Domain.Enums;

namespace ZeusApp.Domain.Entities.Catalog;

/// <summary>
/// Satış faturlarında ürün eklemek için çoka çok tablosu
/// Base tablodan miras almadım.
/// satış tablosunda bununla ilgili BaseAuditableEntity değerleri tutulmaktadır. 
/// </summary>

public class ProductSalesInvoice:AuditableEntity
{
    public int ProductdId { get; set; }

    /// <summary>
    /// Vergi Tutarı
    /// </summary>
    public int SalesInvoiceId { get; set; }

    /// <summary>
    /// Vergi Tutarı
    /// </summary>
    public decimal TaxAmount { get; set; }

    /// <summary>
    /// Ürün Miktarı
    /// </summary>
    public decimal ProductQuantity { get; set; }

    /// <summary>
    /// Birim dinamik eklenecek tablo oluşturulacak.
    /// </summary>
    //public UnitType UnitType { get; set; }

    /// <summary>
    /// Birim Fiyat
    /// </summary>
    public decimal UnitPrice { get; set; }

    /// <summary>
    /// Vergi Oranı
    /// </summary>
    public decimal TaxRate { get; set; }

    /// <summary>
    /// İndirim
    /// </summary>
    public decimal Discount { get; set; }

    /// <summary>
    /// İndirim Tipi
    /// </summary>
    public DiscountType DiscountType { get; set; }

    /// <summary>
    /// Toplam Satış Tutarı
    /// Ürün Miktarı X  Birim Fiyat=Toplam Satış Tutarı
    /// </summary>
    public decimal TotalSalesAmountForProduct { get; set; }

    /// <summary>
    /// KDV Oranı
    /// </summary>
    public decimal VATRate { get; set; }

    public Product Product { get; set; }
    public SalesInvoice SalesInvoice { get; set; }
}

//public class ProductSalesInvoiceConfiguration : IEntityTypeConfiguration<ProductSalesInvoice>
//{
//    public void Configure(EntityTypeBuilder<ProductSalesInvoice> builder)
//    {
//        builder.HasKey(x => x.Id);

//        builder.HasOne(x => x.Product)
//             .WithMany(x => x.ProductSalesInvoices)
//             .HasForeignKey(x => x.ProductdId);

//        builder.HasOne(pc => pc.SalesInvoice)
//            .WithMany(c => c.ProductSalesInvoices)
//            .HasForeignKey(pc => pc.SalesInvoiceId);
//    }
//}
