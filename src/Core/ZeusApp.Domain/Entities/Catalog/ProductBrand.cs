using System.Collections.Generic;
using AspNetCoreHero.Abstractions.Domain;

namespace ZeusApp.Domain.Entities.Catalog;

public class ProductBrand : AuditableEntity
{
    /// <summary>
    /// Ürün Marka Adı
    /// </summary>
    public string Name { get; set; }
    public ICollection<Product> Products { get; set; } = new HashSet<Product>();
}
