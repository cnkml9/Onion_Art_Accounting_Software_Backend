﻿namespace ZeusApp.Application.DTOs.RelatedPerson;

public class RelatedPersonResponse
{
    public int Id { get; set; }
    
    /// <summary>
    /// Adi soyadi
    /// </summary>
    public string FullName { get; set; }

    /// <summary>
    /// Telefon
    /// </summary>
    public string PhoneNumber { get; set; }

    /// <summary>
    /// E-posta
    /// </summary>
    public string Email { get; set; }

    public int CustomerSupplierId { get; set; }
}
