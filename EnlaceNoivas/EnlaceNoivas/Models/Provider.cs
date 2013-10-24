using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EnlaceNoivas.Models
{
    public class Provider
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Type { get; set; }
        public string Site { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }


        public User User { get; set; }

        [NotMapped]
        public string ImagePath
        {
            get
            {
                if (Image == "default.png")
                    return "../Content/Images/" + Image;
                else
                    return "../Content/Images/" + User.Username + "/" + Image;
            }
        }

        public IEnumerable<PhotoOfProvider> Galary { get; set; }
    
    }
}