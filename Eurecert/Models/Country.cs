using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Eurecert.Models
{
    public class Country
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Ülke adı alanının girilmesi zorunludur.")]
        [StringLength(200)]
        [Display(Name ="Ülke Adı")]
        public string CountryName { get; set; }
    }
}
