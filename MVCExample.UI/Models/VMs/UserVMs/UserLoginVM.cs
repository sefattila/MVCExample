using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MVCExample.UI.Models.VMs.UserVMs
{
    public class UserLoginVM
    {
        [DisplayName("Kullanıcı Adı")]
        [Required(ErrorMessage = "Kullanıcı Adı Girmek Zorunlu")]
        public string UserName { get; set; }
        [DisplayName("Şifre")]
        [Required]
        public string Password { get; set; }
    }
}
