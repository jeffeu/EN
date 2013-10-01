using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnlaceNoivas.Models
{
    public class Couple
    {
        public int Id { get; set; }
        public string BrideName { get; set; }
        public string GroomName { get; set; }
        public DateTime MerriedDate { get; set; }
        public string CoupleUrl { get; set; }

        public User User { get; set; }

    }
}