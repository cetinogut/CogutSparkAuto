using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CogutSparkAuto.Data;
using CogutSparkAuto.Models;
using Microsoft.AspNetCore.Authorization;
using CogutSparkAuto.Utility;

namespace CogutSparkAuto.Pages.ServiceTypes
{
    [Authorize(Roles = StaticValues.AdminEndUser)]
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public ServiceType ServiceType { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ServiceType = await _db.ServiceType.FirstOrDefaultAsync(m => m.Id == id);

            if (ServiceType == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var serviceFromDb = await _db.ServiceType.FirstOrDefaultAsync(s => s.Id == ServiceType.Id);
            serviceFromDb.Name = ServiceType.Name;
            serviceFromDb.Price = ServiceType.Price;
            await _db.SaveChangesAsync();

            //_db.Attach(ServiceType).State = EntityState.Modified; // otomatik olarak bütün prpperty leri değiştirecek.. Yukarıdaki daha etkindir çünkü satır satır istenenlerin güncellenmesine izin verir
            /*
            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceTypeExists(ServiceType.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }*/

            return RedirectToPage("./Index");
        }

        /*
        private bool ServiceTypeExists(int id)
        {
            return _db.ServiceType.Any(e => e.Id == id);
        }
        */
    }
}
