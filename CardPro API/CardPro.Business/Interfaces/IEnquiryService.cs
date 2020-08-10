using CardPro.Business.Commands;
using CardPro.Business.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CardPro.Business.Interfaces
{
    public interface IEnquiryService
    {
        /// <summary>
        /// Check for available card types for the user details and save the user details
        /// </summary>
        /// <param name="enquiryCommand"></param>
        /// <returns> List of Card Types</returns>
        Task<List<CardTypeResponse>> RegisterEnquiry(EnquiryCommand enquiryCommand);
    }
}