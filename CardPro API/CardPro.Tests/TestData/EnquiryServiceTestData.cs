using CardPro.Business.Commands;
using System;
using Xunit;

namespace CardPro.Tests.TestData
{
    public static class EnquiryServiceTestData
    {
        public static TheoryData<EnquiryCommand> GetMockEnQuiryCommand()
        {
            return new TheoryData<EnquiryCommand>()
            {
                new EnquiryCommand()
                {
                    AnnualIncome=30001,
                    DateOfBirth=DateTime.Today.AddYears(-22),
                    FirstName="John",
                    LastName="Smith"
                }
            };
        }
    }
}