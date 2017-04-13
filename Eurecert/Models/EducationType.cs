using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Eurecert.Models
{
    public class EducationType
    {
        public int Id { get; set; }
        [Required]
        [StringLength(200)]
        [Display(Name = "Eğitim Tipi")]
        public string Name { get; set; }
    }
}
