using System;
using System.Collections.Generic;

namespace SampleSite.Models;

public partial class User
{
    public long Id { get; set; }

    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string CreateDate { get; set; } = null!;

    public long IsActive { get; set; }
}
