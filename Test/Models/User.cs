﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Test.Models
{
    public class User
    {
        public int Id { get; set; }
        
        public string FullName { get; set; }
        
        public int Age { get; set; }
       
        public string RegionalCenter { get; set; }
        
        public string Email { get; set; }
        public string Phone { get; set; }
        
        public string Password { get; set; }
    }
}