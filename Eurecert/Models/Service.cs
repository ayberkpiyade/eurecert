using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Eurecert.Models
{
    public class Service
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Hizmet Adı")]
        [StringLength(200)]
        public string ServiceName { get; set; }
        
    }
}
