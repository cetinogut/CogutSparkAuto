using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CogutSparkAuto.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Display(Name = "Adı")]
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        [Display(Name = "Posta Kodu")]
        public string PostalCode { get; set; }
    }
}
