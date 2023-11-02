using System.ComponentModel.DataAnnotations;

namespace ZeusApp.Domain.Entities.Catalog;

/// <summary>
/// Sadece bireysel müşteriye ait alanlar
/// </summary>
public class IndividualCustomerSupplier : CustomerSupplier
{
    /// <summary>
    /// T.C. Kimlik No
    /// </summary>
    public string TcIdNumber { get; set; }

    /// <summary>
    /// Ad *
    /// </summary>
    public string FirstName { get; set; } = null!;

    /// <summary>
    /// Soyad *
    /// </summary>
    public string LastName { get; set; } = null!;
}

