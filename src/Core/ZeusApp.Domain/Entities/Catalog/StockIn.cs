using ZeusApp.Domain.Enums;

namespace ZeusApp.Domain.Entities.Catalog;

public class StockIn : Stock
{
    /// <summary>
    /// Stok Harektet Türü
    /// </summary>
    public StockInMovementType StockInMovementType { get; set; }

    /// <summary>
    /// Döviz
    /// </summary>
    public CurrencyType? Currency { get; set; }

    /// <summary>
    /// Döviz Kuru
    /// </summary>
    public decimal ExchangeRate { get; set; }

    /// <summary>
    /// Genel Toplam
    /// </summary>
    public decimal GrandTotal { get; set; }
}
