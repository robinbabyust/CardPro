using CardPro.UI.Business.Interfaces;
using CardPro.UI.Business.Responses;
using CardPro.UI.Controllers;
using CardPro.UI.Models;
using CardPro.UI.Tests.Fake;
using CardPro.UI.Tests.TestData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using Moq;
using System.Collections.Generic;
using System.Reflection;
using Xunit;

namespace CardPro.UI.Tests.Controllers
{
    public class EnquiryControllerTests
    {
        private readonly ICardEnquiryService _enquiryService;
        private readonly EnquiryController _enquiryController;
        private readonly Mock<ILogger<EnquiryController>> _logger;

        public EnquiryControllerTests()
        {
            _logger = new Mock<ILogger<EnquiryController>>();
            _enquiryService = new CardEnquiryServiceFake();
            _enquiryController = new EnquiryController(_enquiryService, _logger.Object);

        }

        [Theory]
        [Trait("Category", "Positive Test")]
        [MemberData(nameof(CardEnquiryServiceTestData.CreateValidUserDetailsViewModel), MemberType = typeof(CardEnquiryServiceTestData))]
        public void Post_OKResult(UserDetailsViewModel userDetails)
        {
            // Act
            var sut = _enquiryController.UserDetails(userDetails);

            // Assert
            Assert.IsType<RedirectToActionResult>(sut.Result);
        }

        [Theory]
        [Trait("Category", "Positive Test")]
        [MemberData(nameof(CardEnquiryServiceTestData.CreateValidUserDetailsViewModel), MemberType = typeof(CardEnquiryServiceTestData))]
        public void Post_ReturnAllItems(UserDetailsViewModel userDetails)
        {
            // Act
            RedirectToActionResult sut = _enquiryController.UserDetails(userDetails).Result as RedirectToActionResult;

            // Assert
            RouteValueDictionary routeValues = Assert.IsType<RouteValueDictionary>(sut.RouteValues);
            Assert.Equal(5, routeValues.Count);
        }
    }
}
