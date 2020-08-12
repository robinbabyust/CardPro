using CardPro.Business.Commands;
using CardPro.Business.Interfaces;
using CardPro.Business.Responses;
using CardPro.Business.Services;
using CardPro.Data.Entities;
using CardPro.Data.Interfaces;
using CardPro.Tests.Helpers;
using CardPro.Tests.TestData;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace CardPro.Tests.Services
{
    public class EnquiryServiceTests
    {
        private readonly Mock<IUserRepository> _userRepository;
        private readonly Mock<IBankRepository> _bankRepository;
        private readonly Mock<ICardTypeRepository> _cardTypeRepository;
        private readonly Mock<ICriteriaRepository> _criteriaRepository;
        private readonly IEnquiryService _enquiryService;

        public EnquiryServiceTests()
        {
            _bankRepository = new Mock<IBankRepository>();
            _cardTypeRepository = new Mock<ICardTypeRepository>();
            _criteriaRepository = new Mock<ICriteriaRepository>();
            _userRepository = new Mock<IUserRepository>();
            _enquiryService = new EnquiryService(_userRepository.Object, _cardTypeRepository.Object, _criteriaRepository.Object, _bankRepository.Object);
        }

        [Theory]
        [Trait("Category", "Positive Test")]
        [MemberData(nameof(EnquiryServiceTestData.GetMockEnQuiryCommand), MemberType = typeof(EnquiryServiceTestData))]
        public async Task RegisterEnquiry_ValidRequest_Test(EnquiryCommand enquiryCommand)
        {
            // Arrange
            IEnumerable<Bank> banks = EnquiryServiceHelper.GetBanks();
            IEnumerable<Criteria> criterias = EnquiryServiceHelper.GetValidCritireas();
            List<CardType> cardTypes = EnquiryServiceHelper.GetCardTypes();
            _criteriaRepository.Setup(x => x.GetCriterias(It.IsAny<User>())).Returns(Task.FromResult(criterias));
            _cardTypeRepository.Setup(x => x.GetCardTypes(It.IsAny<Criteria>())).Returns(Task.FromResult(cardTypes));
            _userRepository.Setup(x => x.SaveUser(It.IsAny<User>())).Returns(Task.FromResult(true));
            _bankRepository.Setup(x => x.GetBanks()).Returns(Task.FromResult(banks));

            // Act
            List<CardTypeResponse> sut = await _enquiryService.RegisterEnquiry(enquiryCommand);

            // Assert
            Assert.Equal(cardTypes.FirstOrDefault().Name, sut.FirstOrDefault().CardTypeName);
            Assert.Equal(cardTypes.FirstOrDefault().CreditLimit, sut.FirstOrDefault().CreditLimit);
            Assert.Equal(cardTypes.FirstOrDefault().CashLimit, sut.FirstOrDefault().CashLimit);
            Assert.Equal(cardTypes.FirstOrDefault().Category, sut.FirstOrDefault().CardCategory);
            Assert.Equal(cardTypes.FirstOrDefault().Image, sut.FirstOrDefault().Image);
        }

        [Theory]
        [Trait("Category", "Negative Test")]
        [MemberData(nameof(EnquiryServiceTestData.GetMockEnQuiryCommand), MemberType = typeof(EnquiryServiceTestData))]
        public async Task RegisterEnquiry_ValidRequest_NegativeResult_Test(EnquiryCommand enquiryCommand)
        {
            // Arrange
            IEnumerable<Bank> banks = EnquiryServiceHelper.GetBanks();
            IEnumerable<Criteria> criterias = EnquiryServiceHelper.GetInvalidCritireas();
            List<CardType> cardTypes = new List<CardType>();
            _criteriaRepository.Setup(x => x.GetCriterias()).Returns(Task.FromResult(criterias));
            _cardTypeRepository.Setup(x => x.GetCardTypes(It.IsAny<Criteria>())).Returns(Task.FromResult(cardTypes));
            _userRepository.Setup(x => x.SaveUser(It.IsAny<User>())).Returns(Task.FromResult(true));
            _bankRepository.Setup(x => x.GetBanks()).Returns(Task.FromResult(banks));

            // Act
            List<CardTypeResponse> sut = await _enquiryService.RegisterEnquiry(enquiryCommand);

            // Assert
            Assert.Equal(0, sut.Count);
        }
    }
}