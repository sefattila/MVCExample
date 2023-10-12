using System.ComponentModel;

namespace MVCExample.UI.Models.VMs.UserVMs
{
    public class UserVM
    {
        [DisplayName("Id")]
        public string Id { get; set; }
        [DisplayName("Kullanıcı Adı")]
        public string UserName { get; set; }
        [DisplayName("Ad")]
        public string FirstName { get; set; }
        [DisplayName("Soyad")]
        public string LastName { get; set; }
        [DisplayName("Eposta")]
        public string Email { get; set; }
        [DisplayName("Telefon")]
        public string PhoneNumber { get; set; }
    }
}
