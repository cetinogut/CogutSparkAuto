using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CogutSparkAuto.Data;
using CogutSparkAuto.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CogutSparkAuto.Pages.Cars
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        [BindProperty] // bu key word ü kullanarak methodlarda ServiceType objesinin birkez daha metod içine geçme zorunluluğunu kaldırdık.
        public Car Car{ get; set; }

        [TempData]
        public string StatusMessage { get; set; }
        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }


        public IActionResult OnGet(string userId = null) // user admin değilse bu null olacak...
        {
            Car = new Car();
            if (userId == null)
            {
                var claimsIdentity = (ClaimsIdentity)User.Identity; // eğer user buraya log in oluyorsa user ıd sini claimsten getirmeliyiz.. admin oluyorsa zaten gelecek
                var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
                userId = claim.Value;
            }
            Car.UserId = userId;
            return Page();
        }

        //public async Task<IActionResult> OnPostAsync(ServiceType ServiceType) yukarıda [bindProperty] yapınca aşağıdaki gibi değiştirdik.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _db.Car.Add(Car);
            await _db.SaveChangesAsync();
            StatusMessage = "Car has been added sucessfully.";
            return RedirectToPage("Index", new { userId = Car.UserId }); // index e giderken araba eklediğimiz user a dönebilmek için user id de gönderiyoruz..
        }
    }
}