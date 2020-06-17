using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CogutSparkAuto.Data;
using CogutSparkAuto.Models;
using CogutSparkAuto.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CogutSparkAuto.Pages.ServiceTypes
{
    [Authorize(Roles = StaticValues.AdminEndUser)]
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

         public IList<ServiceType> listServiceType { get; set; }
        public async Task<IActionResult> OnGet()
        {
            listServiceType = await _db.ServiceType.ToListAsync();
            return Page();
        }
    }
}