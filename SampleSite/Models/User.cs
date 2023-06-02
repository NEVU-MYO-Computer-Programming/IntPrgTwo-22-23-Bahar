
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SampleSite.Models;


public partial class User
{
    public long Id { get; set; }

    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string CreateDate { get; set; } = null!;

    public long IsActive { get; set; }

    public string BirthDate { get; set; } = null!;
}
