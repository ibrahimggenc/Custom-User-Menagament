using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace Login.Controllers
{
    public class CustomersController : Controller
    {

        private DataContext _datacontext;

        public CustomersController(DataContext datacontext)
        {
            _datacontext = datacontext;
        
        
        }
        public IActionResult List()
        {
            
                return View(_datacontext.Customers.ToList());
           
        }
      /*  public IActionResult List()
        {
            if (HttpContext.Session.GetInt32("Customers.Id").HasValue)
            {
                return View(_datacontext.User.ToList());
            }


            return View();
        }
        */


    }
}
