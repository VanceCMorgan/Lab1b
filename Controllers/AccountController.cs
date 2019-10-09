// I, Vance Morgan, student number 000384251, certify that this material is my
// original work. No other person's work has been used without due
// acknowledgement and I have not made my work available to anyone else.


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab1B.Data;
using Lab1B.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Lab1B.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;


        public AccountController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task<IActionResult> Seed()
        {
            //Create users
            ApplicationUser user1 = new ApplicationUser
            {
                FirstName = "Jack",
                LastName = "Doe",
                Email = "Jack2@Doe.com",
                UserName = "Jack2@Doe.com",
                Company = "Mohawk",
                Position = "Teacher",
                BirthDate = DateTime.Now,
            };
            ApplicationUser user2 = new ApplicationUser
            {
                FirstName = "Jessica",
                LastName = "Doe",
                UserName = "Jane2@Doe.com",
                Email = "Jane2@Doe.com",
                Company = "Mohawk",
                Position = "Dean",
                BirthDate = DateTime.Now,
            };
            ApplicationUser user3 = new ApplicationUser
            {
                FirstName = "average",
                LastName = "joe",
                UserName = "average@joe.com",
                Email = "average@joe.com",
                Company = "Mohawk",
                Position = "Dean",
                BirthDate = DateTime.Now,
            };

            //Add users
            IdentityResult result = await _userManager.CreateAsync(user1, "Mohawk1!");
            if (!result.Succeeded)
            {
                return View("Error", new ErrorViewModel { RequestId = "Failed to create user!" });
            }

            result = await _userManager.CreateAsync(user3, "Mohawk1!");
            if (!result.Succeeded)
            {
                return View("Error", new ErrorViewModel { RequestId = "Failed to create user!" });
            }

            result = await _userManager.CreateAsync(user2, "Mohawk1!");
            if (!result.Succeeded)
            {
                return View("Error", new ErrorViewModel { RequestId = "Failed to create user!" });
            }
            /**
            //add roles
            result = await _roleManager.CreateAsync(new IdentityRole("Employee"));
            if (!result.Succeeded)
            {
                return View("Error", new ErrorViewModel { RequestId = "Failed to create role!" });
            }

            result = await _roleManager.CreateAsync(new IdentityRole("Supervisor"));
            if (!result.Succeeded)
            {
                return View("Error", new ErrorViewModel { RequestId = "Failed to create role!" });
            }
    */
            //Assign roles
            result = await _userManager.AddToRoleAsync(user1, "Employee");
            if (!result.Succeeded)
            {
                return View("Error", new ErrorViewModel { RequestId = "Failed to assign role!" });
            }

            result = await _userManager.AddToRoleAsync(user2, "Supervisor");
            if (!result.Succeeded)
            {
                return View("Error", new ErrorViewModel { RequestId = "Failed to assign role!" });
            }


            return RedirectToAction("Index","Home");
        }
    }
}