using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MVCExample.UI.Models.VMs.UserVMs
{
    public class UserRegisterVM
    {
        [DisplayName("Kullanıcı Adı")]
        [Required(ErrorMessage = "Kullanıcı Adı Girmek Zorunlu")]
        public string UserName { get; set; }
        [DisplayName("İsim")]
        [Required(ErrorMessage = "İsim Yazmak Zorunlu")]
        [StringLength(10, ErrorMessage = "Max 20 Min 3", MinimumLength = 3)]
        public string FirstName { get; set; }
        [DisplayName("Soyisim")]
        [Required(ErrorMessage = "Soyisim Yazmak Zorunlu")]
        [StringLength(10, ErrorMessage = "Max 20 Min 3", MinimumLength = 3)]
        public string LastName { get; set; }
        [DisplayName("Email")]
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [DisplayName("Telefon")]
        [Required]
        [Phone]
        public string PhoneNumber { get; set; }
        [DisplayName("Şifre")]
        [Required]
        [DataType(DataType.Password)]
        [StringLength(10, ErrorMessage = "Max 10 Min 3", MinimumLength = 3)]
        public string Password { get; set; }
        [DisplayName("Tekrar Şifre")]
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Girilen Şifreler Uyumlu Olmalıdır")]
        [StringLength(10, ErrorMessage = "Max 10 Min 3", MinimumLength = 3)]
        public string PasswordControl { get; set; }
    }
}
