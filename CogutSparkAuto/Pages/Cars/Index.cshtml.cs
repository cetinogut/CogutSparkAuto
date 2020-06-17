using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CogutSparkAuto.Data;
using CogutSparkAuto.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CogutSparkAuto.Pages.Cars
{
    [Authorize]
    public class IndexModel : PageModel
    {
        public readonly ApplicationDbContext _db;

        [BindProperty]
        public CarAndCustomerViewModel CarAndCustVM { get; set; }
        [TempData]
        public string StatusMessage { get; set; }


        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> OnGet(string userId = null)
        {
            if (userId == null)
            {
                var claimsIdentity = (ClaimsIdentity)User.Identity; // eğer user buraya log in oluyorsa user ıd sini claimsten getirmeliyiz.. admin oluyorsa zaten gelecek
                var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
                userId = claim.Value;
            }

            CarAndCustVM = new CarAndCustomerViewModel()
            {
                Cars = await _db.Car.Where( x => x.UserId == userId).ToListAsync(), // birden fazla araba olabileceği için first and default kullanmadık..
                UserObj = await _db.ApplicationUser.FirstOrDefaultAsync( x=> x.Id == userId )
            };

            return Page();
        }
    }
}