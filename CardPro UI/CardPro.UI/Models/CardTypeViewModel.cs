using System.ComponentModel;

namespace CardPro.UI.Models
{
    public class CardTypeViewModel
    {
        /// <summary>
        /// Card Type Name
        /// </summary>
        [DisplayName("Card Type")]
        public string CardTypeName { get; set; }

        /// <summary>
        /// Card Category Name
        /// </summary>
        [DisplayName("Card Category")]
        public string CardCategory { get; set; }

        /// <summary>
        /// Credit Limit
        /// </summary>
        [DisplayName("Credit Limit")]
        public int CreditLimit { get; set; }

        /// <summary>
        /// Cash Limit
        /// </summary>
        [DisplayName("Cash Limit")]
        public int CashLimit { get; set; }

        /// <summary>
        /// Card Image
        /// </summary>
        public string Image { get; set; }
    }
}