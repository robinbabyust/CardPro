namespace CardPro.Data.Entities
{
    public class Criteria
    {
        /// <summary>
        /// Criteria Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Card Type Id
        /// </summary>
        public int CardTypeId { get; set; }

        /// <summary>
        /// Minimum Income
        /// </summary>
        public int MinimumIncome { get; set; }

        /// <summary>
        /// Minimum Age
        /// </summary>
        public int MinimumAge { get; set; }
    }
}