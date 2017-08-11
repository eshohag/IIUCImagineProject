using IIUCImagine.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace IIUCImagineProject.Models
{
    public class Member
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Enter Your Full Name")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Only String Full Name are allowed!")]
        [Display(Name = "Full Name")]

        public string Name { get; set; }
        [Display(Name = "Contact No ")]
        [Required(ErrorMessage = "Enter Your Contact No")]
        [StringLength(14, MinimumLength = 11, ErrorMessage = "Enter Your Valid Contact No")]
        public string ContactNo { get; set; }
        [Required(ErrorMessage = "Enter Your Student ID No")]
        [StringLength(9, MinimumLength = 7, ErrorMessage = "Enter Your Valid Student ID")]
        [Display(Name = "Student ID ")]
        public string StudentID { get; set; }
        [Required(ErrorMessage = "Enter Your Email")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Enter Your Department")]
        [Display(Name = "Department")]

        public int DepartmentID { get; set; }
        public virtual Department Department { get; set; }
        [Required]
        public int DoYouKnowID { get; set; }
        public virtual DoYouKnow DoYouKnow { get; set; }
        [Required]
        [Display(Name = "Participate")]

        public int ParticipateID { get; set; }
        public virtual Participate Participate { get; set; }
        public DateTime SubmitDate { get; set; }
    }
}