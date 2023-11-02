using System.ComponentModel.DataAnnotations;

namespace ZeusApp.Domain.Entities.Catalog;


/// <summary>
/// Kurumsal tedarikçi,müşteriye ait propertyler.
/// </summary>
public class CorporateCustomerSupplier : CustomerSupplier
{
    /// <summary>
    /// Vergi No
    /// </summary>
    public string TaxNumber { get; set; }
}
