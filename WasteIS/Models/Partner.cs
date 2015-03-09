using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WasteIS.Models
{
    public class Partner 
    {
        public int ID { get; set; }

        [Display(Name = "Číslo provozovny")]
        [Range(0, 999999999999, ErrorMessage = "Zadejte platný formát ČP (0 - 99999999).")]
        [RegularExpression(@"[0-9]*$", ErrorMessage = "Vložte číslo.")]
        public int? ICP { get; set; }

        [Display(Name = "Sídlo")]
        public bool inHeadquarters { get; set; }

        [Display(Name = "Název")]
        [MaxLength(100, ErrorMessage = "Překročena maximální délka 100 znaků.")]
        public string Name { get; set; }

        [Display(Name = "Telefon")]
        [StringLength(13, MinimumLength = 13, ErrorMessage = "Telefonní číslo musí mít délku přesně 13 znaků (včetně předvolby).")]
        public string Phone { get; set; }

        [Display(Name = "Subjekt")]
        [Required(ErrorMessage = "Povinná položka.")]
        public int SubjectID { get; set; }

        public virtual Subject Subject { get; set; }

        public int? AddressID { get; set; }

        public virtual Address Address { get; set; }
    }
}