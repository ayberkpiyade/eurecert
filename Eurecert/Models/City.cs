using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Eurecert.Models
{
    public class City
    {
        public int Id { get; set; }
        [Required]
        [Display(Name ="İl Adı")]
        [StringLength(200)]
        public string CityName { get; set; }
        [Required]
        [Display(Name = "Ülke Adı")]
        [StringLength(200)]
        public string CountryName { get; set; }
    }
}
