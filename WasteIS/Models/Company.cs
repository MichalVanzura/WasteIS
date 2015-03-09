using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WasteIS.Models
{
    public class Company
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "IČ")]
        public int ID { get; set; }

        [Required(ErrorMessage = "Povinná položka.")]
        [Display(Name = "Typ")]
        [MaxLength(50, ErrorMessage = "Překročena maximální délka 50 znaků.")]
        public string Type { get; set; }

        [Required(ErrorMessage = "Povinná položka.")]
        [Display(Name = "Název")]
        [MaxLength(100, ErrorMessage = "Překročena maximální délka 100 znaků.")]
        public string Name { get; set; }

        [Display(Name = "Telefon")]
        [StringLength(13, MinimumLength = 13, ErrorMessage = "Telefonní číslo musí mít délku přesně 13 znaků (včetně předvolby).")]
        public string Phone { get; set; }

        public virtual ICollection<Plant> Plants { get; set; }

        public int AddressID { get; set; }

        public virtual Address Address { get; set; }
    }
}