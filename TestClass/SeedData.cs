using LeaveManager.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveManagment.TestClass
{
    public class SeedData
    {
        public SeedData(UserManager<Employees> userManager) {
            SeedUsers(userManager);
        }
        public static void SeedUsers(UserManager<Employees> userManager)
        {
            if (userManager.FindByNameAsync("admin@localhost.com").Result == null)
            {
                var user = new Employees
                {
                    UserName = "admin@localhost.com",
                    Email = "admin@localhost.com",

                };
                var result = userManager.CreateAsync(user, "p@ssword1").Result;
                //ako je user uspjesno kreiran, potrebno je pridruziti pripadni role
                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Administrator").Wait();
                }
            }
        }
    }
}
