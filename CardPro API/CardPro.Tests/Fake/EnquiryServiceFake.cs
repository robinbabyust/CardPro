using CardPro.Business.Commands;
using CardPro.Business.Interfaces;
using CardPro.Business.Responses;
using CardPro.Tests.Helpers;
using CardPro.Tests.TestData;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
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
            return Task.FromResult( _cardTypeResponses);
        }
    }
}
