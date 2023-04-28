using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SampleSite.Models;

public partial class User
{
    public long Id { get; set; }
    [Required(ErrorMessage ="Kullanıcı adı boş geçilemez.")]
    [MaxLength(5,ErrorMessage ="Kullanıcı adı en fazla 5 karakter olabilir."),MinLength(2,ErrorMessage ="Kullanıcı adı minimum 2 karakter olabilir.")]    
    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;

    [NotMapped]
    [Display(Name ="Confirm Password",Prompt =" Type password again.")]
    [Compare("Password",ErrorMessage ="Şifreler uyuşmuyor")]
    public string ConfirmPassword { get; set; }

    [DataType(DataType.Date)]
    public string CreateDate { get; set; } = null!;

    public long IsActive { get; set; }
}
