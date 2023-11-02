using System.ComponentModel.DataAnnotations;

namespace AspNetCoreHero.Abstractions.Domain;

/// <summary>
/// Temel varlık sınıfı
/// </summary>
public abstract class BaseEntity
{
    /// <summary>
    /// Varlık numarası
    /// </summary>
    [Key]
    public int Id { get; set; }

    /// <summary>
    /// Varlık durumu
    /// </summary>
    [Required]
    public int Status { get; set; } = 1;

    /// <summary>
    /// Gösterim için sıra numarası
    /// </summary>
    [Required]
    public int? DisplayOrder { get; set; } = 0;
}
