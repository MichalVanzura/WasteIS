using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WasteIS.Models
{
    public class Plant
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Povinná položka.")]
        [Display(Name = "Identifikační číslo provozovny")]
        [Range(0, 999999999999, ErrorMessage = "Zadejte platný formát IČP (0 - 999999999999).")]
        [RegularExpression(@"[0-9]*$", ErrorMessage = "Vložte číslo.")]
        public int ICP { get; set; }

        [Required(ErrorMessage = "Povinná položka.")]
        [Display(Name = "Hlásí za")]
        [MaxLength(50, ErrorMessage = "Překročena maximální délka 50 znaků.")]
        public string WherePlaced { get; set; }

        [Required(ErrorMessage = "Povinná položka.")]
        [Display(Name = "Název")]
        [MaxLength(100, ErrorMessage = "Překročena maximální délka 100 znaků.")]
        public string Name { get; set; }

        [Display(Name = "Zastoupení obyvatel od kterých je odpad svážen [%]")]
        [Range(0, 100, ErrorMessage = "Zadejte číslo v rozsahu 0 - 100.")]
        [RegularExpression(@"[0-9]*$", ErrorMessage = "Vložte číslo.")]
        public int? PeoplePercentage { get; set; }

        [Display(Name = "Zapojena do sběru odpadu obce")]
        public bool IntegratedInColl { get; set; }

        [Display(Name = "Telefon")]
        [StringLength(13, MinimumLength = 13, ErrorMessage = "Telefonní číslo musí mít délku přesně 13 znaků (včetně předvolby).")]
        public string Phone { get; set; }

        [Display(Name = "Firma")]
        [Required(ErrorMessage = "Povinná položka.")]
        public int CompanyID { get; set; }
        public virtual Company Company { get; set; }

        public int AddressID { get; set; }
        public virtual Address Address { get; set; }
    }
}