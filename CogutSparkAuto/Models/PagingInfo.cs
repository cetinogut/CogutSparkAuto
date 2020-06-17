using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CogutSparkAuto.Models
{
    public class PagingInfo // bunu pagination için oluşturduk.. Veritabanında olmasına gerek yo...
    {
        public int TotalItems { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPage => (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage);
        public string UrlParam { get; set; }

    }
}
