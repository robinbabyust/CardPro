using CardPro.Data.Entities;
using System.Collections.Generic;

namespace CardPro.Tests.Helpers
{
    public static class EnquiryServiceHelper
    {
        public static List<Criteria> GetValidCritireas()
        {
            return new List<Criteria>()
            {
                new Criteria()
                {
                    Id=1,
                    CardTypeId=1,
                    MinimumAge=22,
                    MinimumIncome=28000
                },
                new Criteria()
                {
                    Id=1,
                    CardTypeId=1,
                    MinimumAge=25,
                    MinimumIncome=34000
                }
            };
        }

        public static List<Criteria> GetInvalidCritireas()
        {
            return new List<Criteria>()
            {
                new Criteria()
                {
                    Id=1,
                    CardTypeId=1,
                    MinimumAge=16,
                    MinimumIncome=28000
                },
                new Criteria()
                {
                    Id=1,
                    CardTypeId=1,
                    MinimumAge=15,
                    MinimumIncome=34000
                }
            };
        }

        public static List<CardType> GetCardTypes()
        {
            return new List<CardType>()
            {
                new CardType()
                {
                    Id=1,
                    BankId=1,
                    CashLimit=1000,
                    CreditLimit=10000,
                    Category="Vanquis",
                    Image="www.google.com/img",
                    Name="Vanquis plus"
                },
                new CardType()
                {
                    Id=1,
                    BankId=1,
                    CashLimit=2000,
                    CreditLimit=20000,
                    Category="Barclay",
                    Image="www.google.com/img",
                    Name="Barclay plus"
                },
            };
        }

        public static List<Bank> GetBanks()
        {
            return new List<Bank>()
            {
                new Bank()
                {
                    Id=1,
                    Country="United Kingdom",
                    Name="Barclays"
                },
                new Bank()
                {
                    Id=2,
                    Country="United Kingdom",
                    Name="HSBC"
                }
            };
        }
    }
}