namespace CardPro.Data.Entities
{
    public class CardType
    {
        /// <summary>
        /// Card Type Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Bank Id
        /// </summary>
        public int BankId { get; set; }

        /// <summary>
        /// Card Type Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Card Category
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// Credit Limit
        /// </summary>
        public int CreditLimit { get; set; }

        /// <summary>
        /// Cash Limit
        /// </summary>
        public int CashLimit { get; set; }

        /// <summary>
        /// Card Image
        /// </summary>
        public string Image { get; set; }
    }
}