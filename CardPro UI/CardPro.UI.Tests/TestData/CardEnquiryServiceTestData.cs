﻿using CardPro.UI.Business.Commands;
using CardPro.UI.Models;
using System;
using Xunit;

namespace CardPro.UI.Tests.TestData
{
    public static class CardEnquiryServiceTestData
    {
        public static TheoryData<EnquiryCommand> CreateValidEnquiryCommands()
        {
            return new TheoryData<EnquiryCommand>()
            {
                new EnquiryCommand()
                {
                    AnnualIncome=34000,
                    DateOfBirth=DateTime.Today.AddYears(-20),
                    FirstName="James",
                    LastName="Anderson"
                },
                new EnquiryCommand()
                {
                    AnnualIncome=14000,
                    DateOfBirth=DateTime.Today.AddYears(-20),
                    FirstName="John",
                    LastName="Luis"
                }
            };
        }

        public static TheoryData<EnquiryCommand> CreateInvalidEnquiryCommands()
        {
            return new TheoryData<EnquiryCommand>()
            {
                new EnquiryCommand()
                {
                    AnnualIncome=0,
                    DateOfBirth=DateTime.Today.AddYears(-20),
                    FirstName="James",
                    LastName="Anderson"
                },
                new EnquiryCommand()
                {
                    AnnualIncome=14000,
                    DateOfBirth=DateTime.Today.AddYears(-2),
                    FirstName="John",
                    LastName="Luis"
                }
            };
        }

        public static TheoryData<UserDetailsViewModel> CreateValidUserDetailsViewModel()
        {
            return new TheoryData<UserDetailsViewModel>()
            {
                new UserDetailsViewModel()
                {
                    AnnualIncome=0,
                    DateOfBirth=DateTime.Today.AddYears(-20),
                    FirstName="James",
                    LastName="Anderson"
                }
            };
        }
    }
}