using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SampleSite.Models;

public partial class Person
{
    public long Id { get; set; }
    [Display(Name ="İsim",Prompt ="İsim yazınız.")]
    public string Name { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string IdentityNo { get; set; } = null!;

    public string? RecordNo { get; set; }

    public string NickName { get; set; } = null!;

    public string? YeniAlan { get; set; }

    public virtual ICollection<PersonWare> PersonWares { get; } = new List<PersonWare>();
}
