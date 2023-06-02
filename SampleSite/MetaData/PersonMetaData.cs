using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SampleSite.MetaData;

public partial class PersonMetaData
{
    [Key]
    public long Id { get; set; }

    [Display(Name="Ad")]
    public string Name { get; set; } = null!;

    [Display(Name = "Soyad")]
    public string LastName { get; set; } = null!;

    [Display(Name = "Kimlik No")]
    public string IdentityNo { get; set; } = null!;

    [Display(Name = "Sicil No")]
    public string? RecordNo { get; set; }

    [Display(Name = "Takma Ad")]
    public string NickName { get; set; } = null!;

    [Display(Name = "Ek Bilgi")]
    public string? YeniAlan { get; set; }

    
}
