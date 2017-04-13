using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Eurecert.Models
{
    public class SalesRepresentative
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Ad Soyad alanı zorunludur.")]
        [StringLength(200)]
        [Display(Name ="Ad Soyad")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Telefon alanı zorunludur.")]
        [StringLength(200)]
        [Display(Name = "Telefon")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Email alanı zorunludur.")]
        [StringLength(200)]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
