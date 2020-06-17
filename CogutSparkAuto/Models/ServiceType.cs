using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CogutSparkAuto.Models
{
    public class ServiceType
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Servis Adı")]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:n} TL")]
        [Display(Name = "Fiyatı")]
        public double Price { get; set; }
    }
}
