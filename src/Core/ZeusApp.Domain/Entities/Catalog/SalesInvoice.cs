using System;
using System.Collections.Generic;
using AspNetCoreHero.Abstractions.Domain;
using ZeusApp.Domain.Enums;

namespace ZeusApp.Domain.Entities.Catalog;

/// <summary>
/// Satış faturaları tablosu
///Her satışın 1 tane müşterisi vardır 
///Ürün ve müşteri alanları çoka çok ilişki
///Dikkat!!: Satış ve alış faturaları hemen hemen aynı bu 2 tablo birleştirilebilir.
/// </summary>
public class SalesInvoice : AuditableEntity
{
    /// <summary>
    /// Fatura Tarihi
    /// </summary>
    public DateTime InvoiceDate { get; set; }

    /// <summary>
    /// Sevk Tarihi
    /// </summary>
    public DateTime ShipmentDate { get; set; }

    /// <summary>
    /// Vade Tarihi
    /// </summary>
    public DateTime DueDate { get; set; }

    /// <summary>
    ///Fatura Numarası
    /// </summary>
    public string InvoiceNumber { get; set; }


    /// <summary>
    /// Döviz
    /// </summary>
    public CurrencyType CurrencyType { get; set; }


    /// <summary>
    /// Döviz Kuru
    /// </summary>
    public decimal ExchangeRate { get; set; }

    /// <summary>
    /// Açıklama
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Ara Toplam
    /// </summary>
    public decimal Subtotal { get; set; }

    /// <summary>
    /// İndirim Tipi
    /// </summary>
    public DiscountType DiscountType { get; set; }


    /// <summary>
    /// İndirim
    /// </summary>
    public decimal Discount { get; set; }


    /// <summary>
    /// Toplam İndirim
    /// </summary>
    public decimal TotalDiscount { get; set; }

    /// <summary>
    /// Genel Toplam
    /// </summary>
    public decimal TotalAmount { get; set; }

    /// <summary>
    /// Toplam KDV Tutarı
    /// </summary>
    public decimal TotalVATAmount { get; set; }

    /// <summary>
    ///Kalan Tutar
    /// </summary>
    public decimal RemainingAmount { get; set; }

    /// <summary>
    /// Sevkiyat No
    /// </summary>
    public string ShipmentNumber { get; set; }


    /// <summary>
    ///Satış Tipi-Toptan mı , Perakande mi?
    ///Toptansa Kvd hariç, Perakende ise kdv hariç
    /// </summary>
    public SalesInvoiceType SalesInvoiceType { get; set; }


    /// <summary>
    /// Teslimat adresi farklı mı?
    /// </summary>
    public bool IsAddressDifferent { get; set; }

    /// <summary>
    /// Teslimat adresi (Eğer farklıysa)
    /// </summary>
    public int? OtherAddressId { get; set; }

    /// <summary>
    /// Eklenme sebebi Datatable ile satışlar listelendiğinde ilgili müşterinin  kurumsal yada bireysel olduğu
    /// bilinmediği için db'ye 2 kez gitmesi veya her satışa ait müşteri için birdaha gitmesi.
    /// Farklı bir çözümde bulunabilir.
    /// </summary>
    public string FullNameOrUnvan { get; set; }

    /// <summary>
    /// Müşteri
    /// </summary>
    public int? CustomerId { get; set; }

    /// <summary>
    /// Satış Fatura kategorisi
    /// </summary>
    public int? SalesInvoiceCategoryId { get; set; }


    public CustomerSupplier CustomerSupplier { get; set; }
    public SalesInvoiceCategory SalesInvoiceCategory { get; set; }

    /// <summary>
    /// Ürünler ve satış faturası arasında çoka çok ilişki ve tutulması gereken değerle burada tutuluyor.
    /// </summary>
    public ICollection<ProductSalesInvoice> ProductSalesInvoices { get; set; } = new HashSet<ProductSalesInvoice>();
}

//public class SalesInvoiceConfiguration : IEntityTypeConfiguration<SalesInvoice>
//{
//    public void Configure(EntityTypeBuilder<SalesInvoice> builder)
//    {
//        builder
//          .HasOne(x => x.SalesInvoiceCategory)
//          .WithMany(x => x.SalesInvoices)
//          .HasForeignKey(x => x.SalesInvoiceCategoryId)
//          .OnDelete(DeleteBehavior.Restrict);
//    }
//}
