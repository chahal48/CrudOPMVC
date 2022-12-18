using System;
using System.ComponentModel.DataAnnotations;

namespace CrudOPMVC.Models
{
    public class ValidDateCheckAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime date;
            if (DateTime.TryParse(Convert.ToString(value), out date))
            {
                return true;
            }
            return false;
        }
    }
}