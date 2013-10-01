using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EnlaceNoivas.Models;

namespace EnlaceNoivas.ViewModels
{
    public class CoupleUser
    {
        public User User { get; set; }
        public Couple Couple { get; set; }
    }
}