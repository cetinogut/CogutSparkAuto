using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CogutSparkAuto.Models
{
    public class ServiceDetails
    {
        public int Id { get; set; }

        public int ServiceHeaderId { get; set; }
        [ForeignKey("ServiceHeaderId")]
        public virtual ServiceHeader ServiceHeader { get; set; }

        [Display(Name = "Servis")]
        public int ServiceTypeId { get; set; }
        [ForeignKey("ServiceTypeId")]
        public virtual ServiceType ServiceType { get; set; }

        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:n} TL")]
        [Display(Name = "Fiyatı")]
        public double ServicePrice { get; set; }

        [Display(Name = "Servis Adı")]
        public string ServiceName { get; set; }
    }
}
