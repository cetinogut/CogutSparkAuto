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

namespace CogutSparkAuto.Pages.ServiceTypes
{
    [Authorize(Roles = StaticValues.AdminEndUser)]
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        [BindProperty] // bu key word ü kullanarak methodlarda ServiceType objesinin birkez daha metod içine geçme zorunluluğunu kaldırdık.
        public ServiceType ServiceType { get; set; }
        
        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }

        
        public IActionResult OnGet()
        {
            return Page();
        }

        //public async Task<IActionResult> OnPostAsync(ServiceType ServiceType) yukarıda [bindProperty] yapınca aşağıdaki gibi değiştirdik.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _db.ServiceType.Add(ServiceType);
            await _db.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}