using System.ComponentModel.DataAnnotations;

namespace ZeusApp.Domain.Enums;

//Stok çıkış harektet durumu
public enum StockOutMovementType
{
    [Display(Name = "Fire Çıkış")]
    FireExit,

    [Display(Name = "Sarf Çıkış")]
    ConsumableOutput,

    [Display(Name = "Sayım Çıkış")]
    CountOut
}

