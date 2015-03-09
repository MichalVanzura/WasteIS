using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WasteIS.Models
{
    public class News
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Povinná položka.")]
        [Display(Name = "Typ")]
        public string Type { get; set; }

        [Display(Name = "Nadpis")]
        [Required(ErrorMessage = "Povinná položka.")]
        [MaxLength(40, ErrorMessage = "Překročena maximální délka 40 znaků.")]
        public string Headline { get; set; }

        [Display(Name = "Text")]
        [Required(ErrorMessage = "Povinná položka.")]
        [MaxLength(4000, ErrorMessage = "Překročena maximální délka 4000 znaků.")]
        [DataType(DataType.MultilineText)]
        public string Text { get; set; }

        [Required(ErrorMessage = "Povinná položka.")]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        [Display(Name = "Datum")]
        public DateTime EnterDate
        {
            get
            {
                return (this.dateCreated == default(DateTime))
                   ? DateTime.Now
                   : this.dateCreated;
            }

            set { this.dateCreated = value; }
        }
        private DateTime dateCreated = default(DateTime);

        //USER
        [Display(Name = "Zadal")]
        public int UserID { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}