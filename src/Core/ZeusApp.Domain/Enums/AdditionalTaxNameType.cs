using System.ComponentModel.DataAnnotations;

namespace ZeusApp.Domain.Enums;
public enum AdditionalTaxNameType
{
    [Display(Name = "Uygulanmaz")]
    V1,

    [Display(Name = "4961 Banka Sigorta Muameleleri Vergisi")]
    V2,

    [Display(Name = "Elektrik Tüketim Vergisi")]
    V3,
    [Display(Name = "Konaklama Vergisi")]
    V4,

    [Display(Name = "ÖTV - Alkollu İçeceklere İlişkin Özel Tüketim Vergisi")]
    V5,

    [Display(Name = "ÖTV - Dayanikli Tüketim Ve Diğer Mallara İlişkin Özel Tüketim Vergisi")]
    V6,

    [Display(Name = "ÖTV - Kolali Gazoz, Alkollü İçeçekler Ve Tütün Mamüllerine İlişkin Özel Tüketim Vergisi")]
    V7,

    [Display(Name = "ÖTV - Kolali Gazozlara İlişkin Özel Tüketim Vergisi")]
    V8,
    [Display(Name = "ÖTV- Motorlu Taşıtla")]
    V9,

    [Display(Name = "ÖTV - petrol ve Doğalgaz Ürünlerine İlişkin Özel Tüketim Vergisi")]
    V10,

    [Display(Name = "ÖTV - Tütün Mamüllerine İlişkin Özel Tüketim Vergisi")]
    V11,

    [Display(Name = "Özel İletişim Vergisi")]
    V12,
}
