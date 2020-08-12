using CardPro.UI.Business.Commands;
using CardPro.UI.Business.Interfaces;
using CardPro.UI.Business.Responses;
using CardPro.UI.Tests.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CardPro.UI.Tests.Fake
{
    public class CardEnquiryServiceFake : ICardEnquiryService
    {
        private List<CardTypeResponse> _cardTypeResponses;
        public CardEnquiryServiceFake()
        {
            _cardTypeResponses = CardEnquiryServiceHelper.GetCardTypeResponse();
        }

        public Task<List<CardTypeResponse>> RegisterEnquiry(EnquiryCommand enquiryCommand)
        {
            return Task.FromResult(_cardTypeResponses);
        }
    }
}
