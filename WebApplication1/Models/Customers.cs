using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
//using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Login.Models
{
    public class Customers 
    {
      
            
        public int Id { get; set; }
        
        public string Name { get; set; }
       
        public string Surname { get; set; }
     
        public string Adress { get; set; }
        


    }
}
