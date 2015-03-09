using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WasteIS.Models
{
    public class Subject
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Povinná položka.")]
        [Display(Name = "Typ")]
        [MaxLength(50, ErrorMessage = "Překročena maximální délka 50 znaků.")]
        public string Type { get; set; }

        [Required(ErrorMessage = "Povinná položka.")]
        [Display(Name = "Identifikátor")]
        [MaxLength(30, ErrorMessage = "Překročena maximální délka 50 znaků.")]
        public string Identifier { get; set; }

        [Required(ErrorMessage = "Povinná položka.")]
        [Display(Name = "Název (interní)")]
        [MaxLength(50, ErrorMessage = "Překročena maximální délka 50 znaků.")]
        public string Name { get; set; }

        [Display(Name = "Telefon")]
        [StringLength(13, MinimumLength = 13, ErrorMessage = "Telefonní číslo musí mít délku přesně 13 znaků (včetně předvolby).")]
        public string Phone { get; set; }
    }
}