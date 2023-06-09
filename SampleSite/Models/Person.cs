﻿using System;
using System.Collections.Generic;

namespace SampleSite.Models;

public partial class Person
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string IdentityNo { get; set; } = null!;

    public string? RecordNo { get; set; }

    public string NickName { get; set; } = null!;

    public string? YeniAlan { get; set; }

    public virtual ICollection<PersonWare> PersonWares { get; set; } = new List<PersonWare>();
}
