using System;

namespace ZeusApp.Application.Features.Ayarlar.Queries.GetAllPaged;

public class GetAllAyarlarResponse
{
    public int Id { get; set; }
    public string Adi { get; set; }
    public string SistemAdi { get; set; }
    public string Degeri { get; set; }
    public byte[] Image { get; set; }
    public DateTime CreatedOn { get; set; }
    public int Status { get; set; }
    public int? DisplayOrder { get; set; }
}
