using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CardPro.UI.Models
{
    public class EnquiryViewModel
    {
        /// <summary>
        /// First Name
        /// </summary>
        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        /// <summary>
        /// Last Name
        /// </summary>
        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        /// <summary>
        /// Date Of Birth
        /// </summary>
        [Required]
        [DisplayName("Date Of Birth")]
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Annual Income
        /// </summary>
        [Required]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Annual Income must be numeric")]
        [DisplayName("Annual Income")]
        public int AnnualIncome { get; set; }
    }
}