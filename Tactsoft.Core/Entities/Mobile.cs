using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tactsoft.Core.Base;

namespace Tactsoft.Core.Entities
{
    public class Mobile:BaseEntity
    {
        [Required]
        [DisplayName("Brand Name")]
        public string BrandName { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        [DisplayName("Ram & Rom")]
        public string RamRom { get; set; }

        public Boolean Black { get; set; }
        public Boolean Blue { get; set; }
        public Boolean Red { get; set; }
        public string Picture { get; set; }
    }
}
