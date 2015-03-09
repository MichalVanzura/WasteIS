using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WasteIS.Models
{
    public class Zuj
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Povinná položka.")]
        [Display(Name = "ZÚJ název")]
        [MaxLength(50, ErrorMessage = "Překročena maximální délka 50 znaků.")]
        public string City { get; set; }

        [Required(ErrorMessage = "Povinná položka.")]
        [Display(Name = "ZÚJ kód")]
        [Range(100000, 999999, ErrorMessage = "Zadejte platný formát ZÚJ (100000 - 999999).")]
        [RegularExpression(@"[0-9]*$", ErrorMessage = "Vložte číslo.")]
        public int ZUJ { get; set; }

        //ORP - not required, we are doing check when adding plant/company (the only ones which need it)
        [Display(Name = "ORP/SOP")]
        public int? OrpID { get; set; }
        public virtual Orp Orp { get; set; }
    }
}