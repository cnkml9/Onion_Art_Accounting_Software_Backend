using ZeusApp.Domain.Enums;

namespace ZeusApp.Domain.Entities.Catalog;
public class StockOut : Stock
{
    /// <summary>
    /// Stok Harektet Türü
    /// </summary>
    public StockOutMovementType StockOutMovementType { get; set; }

}
