using System.Text.Json.Serialization;

namespace CardPro.UI.Business.Responses
{
    public class CardTypeResponse
    {
        /// <summary>
        /// Card Type Name
        /// </summary>
        [JsonPropertyName("cardTypeName")]
        public string CardTypeName { get; set; }

        /// <summary>
        /// Card Category
        /// </summary>
        [JsonPropertyName("cardCategory")]
        public string CardCategory { get; set; }

        /// <summary>
        /// Credit Limit
        /// </summary>
        [JsonPropertyName("creditLimit")]
        public int CreditLimit { get; set; }

        /// <summary>
        /// Cash Limit
        /// </summary>
        [JsonPropertyName("cashLimit")]
        public int CashLimit { get; set; }

        /// <summary>
        /// Card Image
        /// </summary>
        [JsonPropertyName("image")]
        public string Image { get; set; }

        /// <summary>
        /// Bank Name
        /// </summary>
        [JsonPropertyName("bankName")]
        public string BankName { get; set; }
    }
}