using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace SCFWeb2.Models
{
    public class ContributionViewModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Credit Union must be selected")]
        public int creditUnionId { get; set; }

        [Required(ErrorMessage = "Contribution Category is required")]
        public int categoryId { get; set; }
        
        [Required(ErrorMessage = "Charity/Organization Name is required")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "Charity/Organization must be at least 4 characters long")]
        public string charityName { get; set; }

        [Required(ErrorMessage = "Address is required")]
        public string address1 { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string address2 { get; set; }

        [Required(ErrorMessage = "City is required")]
        public string city { get; set; }

        [Required(ErrorMessage = "State/Province is required")]
        public string provState { get; set; }

        [Required(ErrorMessage = "Zip/Postal Code is required")]
        public string postalZip { get; set; }

        [Required(ErrorMessage = "Country is required")]
        public string country { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "If Volunteer Hours are provided, it must be a valid integer")]
        public string volunteerHours { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "If Amount is provided, it must be a valid integer")]
        public string amount { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "If Contributed Dollar Value is provided, it must be a valid integer")]
        public string contributedDollarValue { get; set; }

        public string otherContributions { get; set; }
        
        [Required(ErrorMessage = "Charity/Organization Description is required")]
        [StringLength(500, MinimumLength = 4, ErrorMessage = "Charity/Organization must be at least 4 characters long")]
        public string description { get; set; }
        
        
    }
}