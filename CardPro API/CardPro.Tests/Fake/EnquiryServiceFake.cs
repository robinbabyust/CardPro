using CardPro.Business.Commands;
using CardPro.Business.Interfaces;
using CardPro.Business.Responses;
using CardPro.Tests.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CardPro.Tests.Fake
{
    public class EnquiryServiceFake : IEnquiryService
    {
        private List<CardTypeResponse> _cardTypeResponses;

        public EnquiryServiceFake()
        {
            _cardTypeResponses = EnquiryServiceHelper.GetCardTypeResponses();
        }

        public Task<List<CardTypeResponse>> RegisterEnquiry(EnquiryCommand enquiryCommand)
        {
            return Task.FromResult(_cardTypeResponses);
        }
    }
}