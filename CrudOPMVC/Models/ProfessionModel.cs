using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CrudOPMVC.Models
{
    public class ProfessionModel
    {
        [DisplayName("S.No.")]
        public int SerialNo { get; set; }

        [DisplayName("Profession ID")]
        [Required(ErrorMessage = "Id is mandatory!!")]
        public int ProfessionID { get; set; }

        [DisplayName("Profession Name")]
        [Required(ErrorMessage = "Profession name is mandatory!!")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Profession name character length should be in between 3 to 30.")]
        [RegularExpression("^[A-Za-z -]*$", ErrorMessage = "Sorry, only letters (a-z) are allowed.")]
        public string Profession { get; set; }

        [DisplayName("Description")]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "Description character length should be in between 3 to 200.")]
        [RegularExpression("^[A-Za-z -]*$", ErrorMessage = "Sorry, only letters (a-z) are allowed.")]
        public string Description { get; set; }
    }
}