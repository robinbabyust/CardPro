using CardPro.UI.Business.Commands;
using CardPro.UI.Business.Interfaces;
using CardPro.UI.Business.Responses;
using CardPro.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardPro.UI.Controllers
{
    public class EnquiryController : Controller
    {
        private readonly ICardEnquiryService _cardEnquiryService;
        private readonly ILogger<EnquiryController> _logger;

        public EnquiryController(ICardEnquiryService cardEnquiryService, ILogger<EnquiryController> logger)
        {
            _cardEnquiryService = cardEnquiryService;
            _logger = logger;
        }

        /// <summary>
        /// GET: EnquiryController/UserDetails
        /// </summary>
        /// <returns></returns>
        public ActionResult UserDetails()
        {
            try
            {
                _logger.Log(LogLevel.Trace, "Loading User Details View", null);

                return View();
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Trace, ex.Message, ex);

                return RedirectToAction("Error", "Home");
            }
        }

        /// <summary>
        /// POST: EnquiryController/UserDetails
        /// </summary>
        /// <param name="enquiryViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> UserDetails(UserDetailsViewModel enquiryViewModel)
        {
            try
            {
                _logger.Log(LogLevel.Trace, "Attempting to process user input", enquiryViewModel);

                EnquiryCommand enquiryCommand = new EnquiryCommand()
                {
                    AnnualIncome = enquiryViewModel.AnnualIncome,
                    DateOfBirth = enquiryViewModel.DateOfBirth,
                    FirstName = enquiryViewModel.FirstName,
                    LastName = enquiryViewModel.LastName
                };

                List<CardTypeResponse> cardTypes = await _cardEnquiryService.RegisterEnquiry(enquiryCommand);
                CardTypeViewModel cardType = new CardTypeViewModel();

                if (cardTypes != null && cardTypes.Count > 0)
                {
                    CardTypeResponse bestAvailableCard = cardTypes.OrderByDescending(x => x.CreditLimit).FirstOrDefault();
                    cardType.CardCategory = bestAvailableCard.CardCategory;
                    cardType.CashLimit = bestAvailableCard.CashLimit;
                    cardType.CardTypeName = bestAvailableCard.CardTypeName;
                    cardType.CreditLimit = bestAvailableCard.CreditLimit;
                    cardType.Image = bestAvailableCard.Image;
                }

                _logger.Log(LogLevel.Trace, "Successfully processed request", null);
                return RedirectToAction(nameof(CardType), cardType);

            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Trace, ex.Message, ex);

                return RedirectToAction("Error", "Home");
            }
        }

        /// <summary>
        /// GET: EnquiryController/CardType
        /// </summary>
        /// <param name="cardType"></param>
        /// <returns></returns>
        public ActionResult CardType(CardTypeViewModel cardType)
        {
            try
            {
                _logger.Log(LogLevel.Trace, "Attempting to load Card Type View", cardType);

                return View(cardType);
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Trace, ex.Message, ex);

                return RedirectToAction("Error", "Home");
            }
        }
    }
}