using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SampleSite.MetaData;

public partial class WareMetaData
{
    [Key]
    public long Id { get; set; }

    [Display(Name ="Malzeme Adı")]
    public string Name { get; set; } = null!;

    [Display(Name="Malzeme Detayı")]
    [MaxLength(150,ErrorMessage ="Malzeme detayı 150 karakterden fazla olamaz.")]
    public string? Detail { get; set; }

   
}
