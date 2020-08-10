using CardPro.Business.Commands;
using CardPro.Business.Interfaces;
using CardPro.Business.Responses;
using CardPro.Data.Entities;
using CardPro.Data.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardPro.Business.Services
{
    public class EnquiryService : IEnquiryService
    {
        private readonly IUserRepository _userRepository;
        private readonly ICardTypeRepository _cardTypeRepository;
        private readonly ICriteriaRepository _criteriaRepository;
        private readonly IBankRepository _bankRepository;

        public EnquiryService(IUserRepository userRepository, ICardTypeRepository cardTypeRepository,
            ICriteriaRepository criteriaRepository, IBankRepository bankRepository)
        {
            _userRepository = userRepository;
            _cardTypeRepository = cardTypeRepository;
            _criteriaRepository = criteriaRepository;
            _bankRepository = bankRepository;
        }

        /// <summary>
        /// Check for available card types for the user details and save the user details
        /// </summary>
        /// <param name="enquiryCommand"></param>
        /// <returns> List of Card Types</returns>
        public async Task<List<CardTypeResponse>> RegisterEnquiry(EnquiryCommand enquiryCommand)
        {
            User user = new User()
            {
                AnnualIncome = enquiryCommand.AnnualIncome,
                DateOfBirth = enquiryCommand.DateOfBirth,
                FirstName = enquiryCommand.FirstName,
                LastName = enquiryCommand.LastName
            };

            IEnumerable<Bank> banks = await _bankRepository.GetBanks();
            IEnumerable<Criteria> criterias = await _criteriaRepository.GetCriterias(user);
            List<CardTypeResponse> cardTypes = new List<CardTypeResponse>();

            foreach (Criteria criteria in criterias)
            {
                var eligibleCardTypes = await _cardTypeRepository.GetCardTypes(criteria);

                foreach (CardType cardType in eligibleCardTypes)
                {
                    string bankName = banks.FirstOrDefault(x => x.Id == cardType.BankId).Name;

                    CardTypeResponse cardTypeResponse = new CardTypeResponse()
                    {
                        CardCategory = cardType.Category,
                        CashLimit = cardType.CashLimit,
                        CardTypeName = cardType.Name,
                        CreditLimit = cardType.CreditLimit,
                        Image = cardType.Image,
                        BankName = bankName
                    };

                    cardTypes.Add(cardTypeResponse);
                }
            }

            await _userRepository.SaveUser(user);

            return cardTypes;
        }
    }
}