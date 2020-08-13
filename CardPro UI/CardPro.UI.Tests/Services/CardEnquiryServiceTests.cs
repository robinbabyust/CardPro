using CardPro.UI.Business.Commands;
using CardPro.UI.Business.Configurations;
using CardPro.UI.Business.Interfaces;
using CardPro.UI.Business.Responses;
using CardPro.UI.Business.Services;
using CardPro.UI.Tests.Helpers;
using CardPro.UI.Tests.TestData;
using Microsoft.Extensions.Options;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace CardPro.UI.Tests.Services
{
    public class CardEnquiryServiceTests
    {
        private Mock<IHttpClientFactory> _httpClientFactory;
        private readonly Mock<IOptions<CardProAPIConfiguration>> _cardProAPIConfiguration;
        private ICardEnquiryService _cardEnquiryService;

        public CardEnquiryServiceTests()
        {
            _httpClientFactory = new Mock<IHttpClientFactory>();
            _cardProAPIConfiguration = new Mock<IOptions<CardProAPIConfiguration>>();
            _cardProAPIConfiguration.Setup(x => x.Value).Returns(new CardProAPIConfiguration() { APIUrl = "http://localhost/" });
        }

        [Theory]
        [Trait("Category", "Positive Test")]
        [MemberData(nameof(CardEnquiryServiceTestData.CreateValidEnquiryCommands), MemberType = typeof(CardEnquiryServiceTestData))]
        public async Task RegisterEnquiry_ValidResponse(EnquiryCommand enquiryCommand)
        {
            // Arrange
            List<CardTypeResponse> cardTypeResponse = CardEnquiryServiceHelper.GetCardTypeResponse();

            HttpContent mockContent = HttpClientHelper.CreateHttpContentFromObject(cardTypeResponse);
            _httpClientFactory = HttpClientHelper.SetHttpClientFactory(HttpStatusCode.OK, mockContent);

            _cardEnquiryService = new CardEnquiryService(_httpClientFactory.Object, _cardProAPIConfiguration.Object);

            // Act
            List<CardTypeResponse> sut = await _cardEnquiryService.RegisterEnquiry(enquiryCommand);

            // Assert
            Assert.Equal(cardTypeResponse.FirstOrDefault().BankName, sut.FirstOrDefault().BankName);
            Assert.Equal(cardTypeResponse.FirstOrDefault().CardCategory, sut.FirstOrDefault().CardCategory);
            Assert.Equal(cardTypeResponse.FirstOrDefault().CashLimit, sut.FirstOrDefault().CashLimit);
            Assert.Equal(cardTypeResponse.FirstOrDefault().CreditLimit, sut.FirstOrDefault().CreditLimit);
            Assert.Equal(cardTypeResponse.FirstOrDefault().Image, sut.FirstOrDefault().Image);
        }

        [Theory]
        [Trait("Category", "Negative Test")]
        [MemberData(nameof(CardEnquiryServiceTestData.CreateInvalidEnquiryCommands), MemberType = typeof(CardEnquiryServiceTestData))]
        public async Task RegisterEnquiry_InvalidResponse(EnquiryCommand enquiryCommand)
        {
            // Arrange
            List<CardTypeResponse> cardTypeResponse = new List<CardTypeResponse>();

            HttpContent mockContent = HttpClientHelper.CreateHttpContentFromObject(cardTypeResponse);
            _httpClientFactory = HttpClientHelper.SetHttpClientFactory(HttpStatusCode.OK, mockContent);

            _cardEnquiryService = new CardEnquiryService(_httpClientFactory.Object, _cardProAPIConfiguration.Object);

            // Act
            List<CardTypeResponse> sut = await _cardEnquiryService.RegisterEnquiry(enquiryCommand);

            // Assert
            Assert.Equal(0, sut.Count);
        }
    }
}