using CardPro.UI.Business.Responses;
using System.Collections.Generic;

namespace CardPro.UI.Tests.Helpers
{
    public static class CardEnquiryServiceHelper
    {
        public static List<CardTypeResponse> GetCardTypeResponse()
        {
            return new List<CardTypeResponse>()
            {
                new CardTypeResponse()
                {
                    BankName = "Barclays",
                    CardCategory = "Barclayscard",
                    CashLimit = 7000,
                    CreditLimit = 10000,
                    CardTypeName = "Barclays plus",
                    Image = "http://ss.img"
                },
                new CardTypeResponse()
                {
                    BankName = "Vanquis",
                    CardCategory = "Vanquiscard",
                    CashLimit = 7000,
                    CreditLimit = 10000,
                    CardTypeName = "Vanquis luma",
                    Image = "http://van.img"
                }
            };
        }
    }
}