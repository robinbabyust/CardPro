using CardPro.UI.Business.Commands;
using CardPro.UI.Business.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CardPro.UI.Business.Interfaces
{
    public interface ICardEnquiryService
    {
        /// <summary>
        /// To check for eligible cards and to save user input
        /// </summary>
        /// <param name="enquiryCommand"></param>
        /// <returns></returns>
        Task<List<CardTypeResponse>> RegisterEnquiry(EnquiryCommand enquiryCommand);
    }
}