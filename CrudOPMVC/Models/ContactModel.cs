using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CrudOPMVC.Models
{
    public class ContactModel
    {
        [DisplayName("Contact ID")]
        [Required(ErrorMessage = "Id is mandatory")]
        public int ContactID { get; set; }

        [DisplayName("Profession")]
        [Required(ErrorMessage ="Profession is mandatory!!")]
        public int ProfessionID { get; set; }

        [DisplayName("First Name")]
        [Required(ErrorMessage = "First name is mandatory!!")]
        [StringLength(30,MinimumLength =3,ErrorMessage ="First name character length should be in between 3 to 30.")]
        [RegularExpression("^[A-Za-z -]*$", ErrorMessage = "Sorry, only letters (a-z) are allowed.")]
        public string fName { get; set; }

        [DisplayName("Last Name")]
        [StringLength(30,MinimumLength =3,ErrorMessage ="Last name character length should be in between 3 to 30.")]
        [RegularExpression("^[A-Za-z -]*$", ErrorMessage = "Sorry, only letters (a-z) are allowed.")]
        public string lName { get; set; }

        [DisplayName("Email")]
        [Required(ErrorMessage = "Email is mandatory!!")]
        [RegularExpression("^([\\w-\\.]+)@((\\[[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\.)|(([\\w-]+\\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\\]?)$", ErrorMessage = "Sorry, email is invalid.")]
        public string emailAddr { get; set; }

        [DisplayName("Company")]
        [Required(ErrorMessage = "Company is mandatory!!")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "First name character length should be in between 3 to 100.")]
        [RegularExpression("^[A-Za-z -]*$", ErrorMessage = "Sorry, only letters (a-z) are allowed.")]
        public string Company { get; set; }

        [DisplayName("Category")]
        [Required(ErrorMessage = "Category is mandatory!!")]
        public byte Category { get; set; }

    }
}