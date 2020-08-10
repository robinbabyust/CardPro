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
        [Range(1, 1000000000, ErrorMessage = "Value must be between 1 to 1000000000")]
        [DisplayName("Annual Income")]
        public int AnnualIncome { get; set; }
    }
}