using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CrudOPMVC.Models
{
    public enum Category
    {
        [Display(Name ="")]
        All,
        [Display(Name ="Client")]
        Client,
        [Display(Name = "Vendor")]
        Vendor
    }
    public class ContactModel
    {
        [DisplayName("Contact ID")]
        [Required(ErrorMessage = "Id is mandatory")]
        public int ContactID { get; set; }

        public int ProfessionID { get; set; }

        [DisplayName("Profession")]
        [Required(ErrorMessage ="Profession is mandatory!!")]
        [ForeignKey("ProfessionModel")]
        public ProfessionModel Profession { get; set; }

        [DisplayName("First Name")]
        [Required(ErrorMessage = "First name is mandatory!!")]
        [StringLength(30,MinimumLength =3,ErrorMessage ="First name character length should be in between 3 to 30.")]
        [RegularExpression("^[A-Za-z -]*$", ErrorMessage = "Sorry, only letters (a-z) are allowed.")]
        public string fName { get; set; }

        [DisplayName("Last Name")]
        [StringLength(30,ErrorMessage ="Last name character length should be less than 30.")]
        [RegularExpression("^[A-Za-z -]*$", ErrorMessage = "Sorry, only letters (a-z) are allowed.")]
        public string lName { get; set; }

        [DisplayName("Email")]
        [Required(ErrorMessage = "Email is mandatory!!")]
        [EmailAddress(ErrorMessage = "Sorry, email is invalid.")]
        //[RegularExpression("^([\\w-\\.]+)@((\\[[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\.)|(([\\w-]+\\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\\]?)$", ErrorMessage = "Sorry, email is invalid.")]
        public string emailAddr { get; set; }

        [DisplayName("Company")]
        [Required(ErrorMessage = "Company is mandatory!!")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "First name character length should be in between 3 to 100.")]
        [RegularExpression("^[A-Za-z -]*$", ErrorMessage = "Sorry, only letters (a-z) are allowed.")]
        public string Company { get; set; }

        [DisplayName("Category")]
        [Required(ErrorMessage = "Category is mandatory!!")]
        public Category Category { get; set; }

        [DisplayName("Full Name")]
        public string FullName
        {
            get
            {
               return string.Concat(fName," ", lName);
            }
        }

        [DisplayName("S.No.")]
        public int SerialNo { get; set; }

    }
}