using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CogutSparkAuto.Models.ViewModel
{
    public class UserListsViewModel // pagination kullanacağımızsafya users modelindeydi. ancak orada pagination ile ilgili bir şey yok. Şimdi pagination kullanmak istiyorsak öyle bir model olmalı ki içinde hem userlist hem de pagination olsun..elimizde böyle bir model  olmadığından burada bunu oluşturduk...
    {
        public List<ApplicationUser> listAppUser { get; set; }
        public  PagingInfo PagingInfo { get; set; }

    }
}
