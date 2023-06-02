//using Microsoft.Build.Framework;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SampleSite.ViewModels
{
    public class LoginViewModel
    {

        [Required,Display(Name ="Kullanıcı Adı ")]
        public string Username { get; set; }
        [Required,PasswordPropertyText]
        public string Password { get; set; }

    }
}
