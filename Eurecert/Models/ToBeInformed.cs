using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Eurecert.Models
{
    public class ToBeInformed
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Haberdar olma şekli zorunlu alandır.")]
        [StringLength(200)]
        [Display(Name ="Haberdar Olma Şekli")]
        public string BeInformed { get; set; }
    }
}
