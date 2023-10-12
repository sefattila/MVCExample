using Microsoft.AspNetCore.Identity;
using MVCExample.CORE.Abstarct;
using MVCExample.CORE.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCExample.CORE.Entities
{
    public class AppUser : IdentityUser, IBaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public DateTime CreateDate { get; set; }= DateTime.Now;
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public Status Status { get; set; } = Status.Active;
    }
}
