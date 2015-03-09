using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WasteIS.Models
{
    //inherited on Company, Plant, Transporter
    public class Address
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Povinná položka.")]
        [Display(Name = "Ulice")]
        [MaxLength(100, ErrorMessage = "Překročena maximální délka 100 znaků.")]
        public string Street { get; set; }

        [Display(Name = "Číslo popisné")]
        [RegularExpression(@"[0-9]*$", ErrorMessage = "Vložte číslo.")]
        public int? StreetNumber { get; set; }

        [Required(ErrorMessage = "Povinná položka.")]
        [Display(Name = "PSČ")]
        [Range(10000, 99999, ErrorMessage = "Zadejte platný formát PSČ (10000 - 99999).")]
        [RegularExpression(@"[0-9]*$", ErrorMessage = "Vložte číslo.")]
        public int PSC { get; set; }
        
        //Obec
        [Required(ErrorMessage = "Povinná položka.")]
        [Display(Name = "ZÚJ")]
        public int ZujID { get; set; }
        public virtual Zuj Zuj { get; set; }
    }
}