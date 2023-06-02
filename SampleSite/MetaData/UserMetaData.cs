using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SampleSite.MetaData

{
    public class UserMetaData
    {
        [Key]
        public long Id { get; set; }

        [Required(ErrorMessage = "Kullanıcı adı boş geçilemez.")]
        [MaxLength(5, ErrorMessage = "Kullanıcı adı en fazla 5 karakter olabilir."), MinLength(2, ErrorMessage = "Kullanıcı adı minimum 2 karakter olabilir.")]
        public string UserName { get; set; } = null!;

        [RegularExpression(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9]).{8,}$", ErrorMessage = "Şifre minumum 8 karekterden oluşmalı ve en az 1 büyük harf, 1 küçük harf ve 1 rakam içermelidir.")]
        public string Password { get; set; } = null!;

        [DataType(DataType.Date)]
        [Display(Name ="Kayıt Tarihi")]
        public string CreateDate { get; set; } = null!;

        [Display(Name = "Aktif Mi?")]
        [Range(0, 1)]
        public long IsActive { get; set; }

        [NotMapped]
        [Display(Name = "Confirm Password", Prompt = " Type password again.")]
        [Compare("Password", ErrorMessage = "Şifreler uyuşmuyor")]
        public string ConfirmPassword { get; set; }

        [NotMapped]
        public string NewProperty { get; set; }


        [Display(Name ="Doğum Tarihi")]
        [DataType(DataType.Date)]
        public string BirthDate { get; set; }
    }
}
