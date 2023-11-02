using System.Collections.Generic;
using AspNetCoreHero.Abstractions.Domain;

namespace ZeusApp.Domain.Entities.Catalog;

public class ProductCategory : AuditableEntity
{
    /// <summary>
    /// Ürün Kategori Adı
    /// </summary>
    public string Name { get; set; } = null!;
    public ICollection<Product> Products { get; set; } = new HashSet<Product>();
}
