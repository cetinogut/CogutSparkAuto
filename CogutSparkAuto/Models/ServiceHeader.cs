using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CogutSparkAuto.Models
{
    public class ServiceHeader
    {
        public int Id { get; set; }
        [Display(Name = "Araç km.")]
        public double Miles { get; set; }
        [Required]
        [Display(Name = "Toplam Fiyat")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:n} TL")]
        public double TotalPrice { get; set; }

        [Display(Name = "Detaylar")]
        public string Details { get; set; }

        [Required]
        [Display(Name = "Tarih")]
        [DisplayFormat(DataFormatString = "{0: dd MMM yyyy}")]
        public DateTime DateAdded { get; set; }

        public int CarId { get; set; }

        [ForeignKey("CarId")]
        public virtual Car Car { get; set; }
    }
}
