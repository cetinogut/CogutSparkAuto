using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CogutSparkAuto.Data;
using CogutSparkAuto.Models;
using CogutSparkAuto.Models.ViewModel;
using CogutSparkAuto.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CogutSparkAuto.Pages.Users
{
    [Authorize(Roles = StaticValues.AdminEndUser)]
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        //public List<ApplicationUser> listAppUser { get; set; } // pagination kullanmadan yaptığımız listede bunu kullandık.. Pagination için yeni bir viewmodel oluşturduk ve aşağıdaki satırda onun listesini kullanıyoruz...
        public UserListsViewModel UserlistsVM { get; set; } 
        public async Task<IActionResult> OnGet(int productPage = 1, string searchEmail=null, string searchName = null, string searchPhone = null)
        {
            UserlistsVM = new UserListsViewModel()
            {
                listAppUser = await _db.ApplicationUser.ToListAsync()
            };

            StringBuilder param = new StringBuilder();
            param.Append("/Users?productPage=:");

            param.Append("&searchName=");
            if (searchName != null)
            {
                param.Append(searchName);
            }

            param.Append("&searchEmail=");
            if (searchEmail != null)
            {
                param.Append(searchEmail);
            }

            param.Append("&searchPhone=");
            if (searchPhone != null)
            {
                param.Append(searchPhone);
            }

            if (searchEmail != null)
            {
                UserlistsVM.listAppUser = await _db.ApplicationUser.Where(u => u.Email.ToLower().Contains(searchEmail.ToLower())).ToListAsync();
            }
            else
            {
                if (searchName != null)
                {
                    UserlistsVM.listAppUser = await _db.ApplicationUser.Where(u => u.Name.ToLower().Contains(searchName.ToLower())).ToListAsync();
                }
                else
                {
                    if (searchPhone != null)
                    {
                        UserlistsVM.listAppUser = await _db.ApplicationUser.Where(u => u.PhoneNumber.ToLower().Contains(searchPhone.ToLower())).ToListAsync();
                    }
                }
            }

            var count = UserlistsVM.listAppUser.Count;

            UserlistsVM.PagingInfo = new PagingInfo
            {
                CurrentPage = productPage,
                ItemsPerPage = StaticValues.PaginationUsersPageSize,
                TotalItems = count,
                UrlParam = param.ToString()
            };

            UserlistsVM.listAppUser = UserlistsVM.listAppUser.OrderBy(p => p.Email)
                .Skip((productPage-1)*2)
                .Take(StaticValues.PaginationUsersPageSize).ToList();

            return Page();
        }
    }
}