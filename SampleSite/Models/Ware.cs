using System;
using System.Collections.Generic;

namespace SampleSite.Models;

public partial class Ware
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Detail { get; set; }

    public virtual ICollection<PersonWare> PersonWares { get; set; } = new List<PersonWare>();
}
