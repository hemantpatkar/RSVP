using System;
using System.ComponentModel.DataAnnotations;

namespace Registration.Web.Models
{
    public class RegistrationViewModel
    {

        public int ID { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Age")]
        [Required]
        [Range(1, 120)]
        public int Age { get; set; }

        [Display(Name = "Profession")]
        [Required]
        public Profession Profession { get; set; }
        [Required]
        [Display(Name = "DOB")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DOB { get; set; }
        [Required]
        [Display(Name = "Locality")]
        public string Locality { get; set; }

        [Display(Name = "NoOfGuest")]
        public int NoOfGuest { get; set; }

        [Display(Name = "Address")]
        public string Address { get; set; }

        [Display(Name = "Status")]
        public string Status { get; set; }

    }

    public enum Profession
    {
        Employed = 1,
        Student = 2
    }
}
