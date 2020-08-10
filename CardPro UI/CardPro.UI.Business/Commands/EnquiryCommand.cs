using System;
using System.Text.Json.Serialization;

namespace CardPro.UI.Business.Commands
{
    public class EnquiryCommand
    {
        /// <summary>
        /// First Name
        /// </summary>
        [JsonPropertyName("firstName")]
        public string FirstName { get; set; }

        /// <summary>
        /// Last Name
        /// </summary>
        [JsonPropertyName("lastName")]
        public string LastName { get; set; }

        /// <summary>
        /// Date Of Birth
        /// </summary>
        [JsonPropertyName("dateOfBirth")]
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Annual Income
        /// </summary>
        [JsonPropertyName("annualIncome")]
        public int AnnualIncome { get; set; }
    }
}