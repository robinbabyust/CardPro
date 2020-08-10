using System;

namespace CardPro.Data.Entities
{
    public class Card
    {
        /// <summary>
        /// Card Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Bank Id
        /// </summary>
        public int BankId { get; set; }

        /// <summary>
        /// Card Type Id
        /// </summary>
        public int CardTypeId { get; set; }

        /// <summary>
        /// Name On Card
        /// </summary>
        public string NameOnCard { get; set; }

        /// <summary>
        /// Cash Limit
        /// </summary>
        public int CashLimit { get; set; }

        /// <summary>
        /// Credit Limit
        /// </summary>
        public int CreditLimit { get; set; }

        /// <summary>
        /// Issued Date
        /// </summary>
        public DateTime IssuedDate { get; set; }

        /// <summary>
        /// Expiry Date
        /// </summary>
        public DateTime ExpiryDate { get; set; }

        /// <summary>
        /// CVV
        /// </summary>
        public string cvv { get; set; }

        /// <summary>
        /// PIN
        /// </summary>
        public string PIN { get; set; }

        /// <summary>
        /// Card Number
        /// </summary>
        public string CardNumber { get; set; }
    }
}