using CardPro.Business.Commands;
using CardPro.Business.Interfaces;
using CardPro.Business.Responses;
using CardPro.Controllers;
using CardPro.Tests.Fake;
using CardPro.Tests.TestData;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Xunit;

namespace CardPro.Tests.Controllers
{
    public class EnquiryControllerTests
    {
        private readonly IEnquiryService _enquiryService;
        private readonly EnquiryController _enquiryController;

        public EnquiryControllerTests()
        {
            _enquiryService = new EnquiryServiceFake();
            _enquiryController = new EnquiryController(_enquiryService);
        }

        [Theory]
        [Trait("Category", "Positive Test")]
        [MemberData(nameof(EnquiryServiceTestData.GetMockEnQuiryCommand), MemberType = typeof(EnquiryServiceTestData))]
        public void Post_OKResult(EnquiryCommand enquiryCommand)
        {
            // Act
            var sut = _enquiryController.Post(enquiryCommand);

            // Assert
            Assert.IsType<OkObjectResult>(sut.Result);
        }

        [Theory]
        [Trait("Category", "Positive Test")]
        [MemberData(nameof(EnquiryServiceTestData.GetMockEnQuiryCommand), MemberType = typeof(EnquiryServiceTestData))]
        public void Post_ReturnAllItems(EnquiryCommand enquiryCommand)
        {
            // Act
            OkObjectResult sut = _enquiryController.Post(enquiryCommand).Result as OkObjectResult;

            // Assert
            List<CardTypeResponse> cardTypeResponses = Assert.IsType<List<CardTypeResponse>>(sut.Value);
            Assert.Equal(2, cardTypeResponses.Count);
        }
    }
}