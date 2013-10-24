using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnlaceNoivas.Models
{
    public class PhotoOfProvider
    {
        public int Id { get; set; }
        public string ImageName { get; set; }
        [NotMapped]
        public string ImagePath { get; set; }
        public DateTime PostedDate { get; set; }
        public string Description { get; set; }
        
        public Provider provider { get; set; }
    }
}
