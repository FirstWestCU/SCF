using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace SCFWeb2.Models
{
    public class RegistrationViewModel
    {
        public int ID { get; set; }

        public string firstName { get; set; }
        public string lastName { get; set; }

        [Required(ErrorMessage = "Email Address is required")]
        [DataType(DataType.EmailAddress)]
        public string emailAddress { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is required")]
        public string password { get; set; }

        [DataType(DataType.Password)]
        [Compare("password", ErrorMessage = "The password and confirmation do not match.")]
        public string passwordConfirm { get; set; }


        public int creditUnionId { get; set; }

       [Required(ErrorMessage = "The Credit Union Name is required")]
        public string creditUnionName { get; set; }


        
    }
}