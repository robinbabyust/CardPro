using CardPro.Business.Commands;
using CardPro.Business.Interfaces;
using CardPro.Business.Responses;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CardPro.Controllers
{
    [Route("api/enquiry")]
    [ApiController]
    public class EnquiryController : ControllerBase
    {
        private IEnquiryService _enquiryService;

        public EnquiryController(IEnquiryService enquiryService)
        {
            _enquiryService = enquiryService;
        }

        // POST api/<EnquiryController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EnquiryCommand enquiryCommand)
        {
            try
            {
                List<CardTypeResponse> cardTypes = await _enquiryService.RegisterEnquiry(enquiryCommand);

                return Ok(cardTypes);
            }
            catch(Exception ex)
            {
                // Log error details
                throw new Exception("Error processing request. Please try again.");
            }
        }
    }
}