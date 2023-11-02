﻿namespace ZeusApp.Application.DTOs.OtherAddress;

public class OtherAddressResponse
{
    public int Id { get; set; }
    /// <summary>
    /// Adres Başlığı
    /// </summary>
    public string AddressTitle { get; set; }

    /// <summary>
    /// Ad Soyad
    /// </summary>
    public string FullName { get; set; }

    /// <summary>
    /// Telefon
    /// </summary>
    public string PhoneNumber { get; set; }

    /// <summary>
    /// Adres
    /// </summary>
    public string Address { get; set; }

    /// <summary>
    /// Ülke
    /// </summary>
    public string Country { get; set; }

    /// <summary>
    /// İl
    /// </summary>
    public string City { get; set; }

    /// <summary>
    /// İlçe
    /// </summary>
    public string District { get; set; }

    public int CustomerSupplierId { get; set; }
}
