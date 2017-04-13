using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Eurecert.Models
{
    public class InstitutionalFunction
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="İşlev Kodu alanının girilmesi zorunludur.")]
        [StringLength(200)]
        [Display(Name ="İşlev Kodu")]
        public string FunctionCode { get; set; }
        [Required(ErrorMessage ="İşlev Adı alanının girilmesi zorunludur.")]
        [StringLength(200)]
        [Display(Name ="İşlev Adı")]
        public string FunctionName { get; set; }
    }
}
