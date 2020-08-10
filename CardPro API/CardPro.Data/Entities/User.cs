using System;

namespace CardPro.Data.Entities
{
    public class User
    {
        /// <summary>
        /// User Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// First Name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Last Name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Date Of Birth
        /// </summary>
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Annual Income
        /// </summary>
        public int AnnualIncome { get; set; }

        /// <summary>
        /// Card Type Id
        /// </summary>
        public int CardTypeId { get; set; }
    }
}