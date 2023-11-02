using System.Collections.Generic;
using AspNetCoreHero.Abstractions.Domain;

namespace ZeusApp.Domain.Entities.Catalog;

public class SalesInvoiceCategory : AuditableEntity
{
    /// <summary>
    ///Satış Kategorisi Adı
    /// </summary>
    public string Name { get; set; } = null!;
    public ICollection<SalesInvoice> SalesInvoices { get; set; } = new HashSet<SalesInvoice>();
}
