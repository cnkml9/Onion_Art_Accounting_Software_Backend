using System.ComponentModel.DataAnnotations;

namespace ZeusApp.Domain.Enums;

//Stok giriş harektet durumu
public enum StockInMovementType
{
    [Display(Name = "Devir Giriş")]
    CycleOut,

    [Display(Name = "Giriş Fişi")]
    InputeReceipt,

    [Display(Name = "Sayım Giriş")]
    CountOut

}
