using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using Microsoft.AspNetCore.Http;

namespace Login.Controllers
{
    public class AccountController : Controller
    {
        private readonly DataContext _context;
        public AccountController(DataContext context)
        {
            _context = context;

        }

        public IActionResult Index()
        {
            if(HttpContext.Session.GetInt32("Id").HasValue)
            {
                return Redirect("/Home/Index");
            }


            return View();
        }
        public IActionResult SignUp()
        {
            if (HttpContext.Session.GetInt32("Id").HasValue)
            {
                return Redirect("/Home/Index");
            }
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            return Redirect("Index");
        }
        public IActionResult Login(string Email,string Password)
        {
            var user = _context.User.FirstOrDefault(w=> w.Email.Equals(Email) && w.Password.Equals(Password));
            if (user != null)
            {
                HttpContext.Session.SetInt32("Id",user.Id);
                HttpContext.Session.SetString("fullname", user.Name + "" + user.Surname);
                HttpContext.Session.SetString("email", user.Email);

                return Redirect("/Home/Index");


            }


            return View();
        }
        public async Task<IActionResult> Register(User model)
        {

            await _context.AddAsync(model);
            await _context.SaveChangesAsync();

            return Redirect("/Account/Index");

        }

    }

}
