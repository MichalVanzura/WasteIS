using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WasteIS.Models
{
    public class Orp
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Povinná položka.")]
        [Display(Name = "ORP/SOP název")]
        [MaxLength(50, ErrorMessage = "Překročena maximální délka 50 znaků.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Povinná položka.")]
        [Display(Name = "ORP/SOP kód")]
        [Range(1000, 9999, ErrorMessage = "Zadejte platný formát ORP (1000 - 9999).")]
        [RegularExpression(@"[0-9]*$", ErrorMessage = "Vložte číslo.")]
        public int ORP { get; set; }

        public override bool Equals(System.Object obj)
        {
            // If parameter is null return false.
            if (obj == null)
            {
                return false;
            }

            // If parameter cannot be cast to Point return false.
            Orp orp = obj as Orp;
            if ((System.Object)orp == null)
            {
                return false;
            }

            // Return true if the fields match:
            return (ORP == orp.ORP);
        }

        public override int GetHashCode()
        {
            return ORP;
        }
    }
}