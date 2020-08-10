using CardPro.UI.Business.Commands;
using CardPro.UI.Business.Configurations;
using CardPro.UI.Business.Interfaces;
using CardPro.UI.Business.Responses;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace CardPro.UI.Business.Services
{
    public class CardEnquiryService : ICardEnquiryService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly CardProAPIConfiguration _cardProAPIConfiguration;

        public CardEnquiryService(IHttpClientFactory httpClientFactory, IOptions<CardProAPIConfiguration> cardProAPIConfiguration)
        {
            _httpClientFactory = httpClientFactory;
            _cardProAPIConfiguration = cardProAPIConfiguration.Value;
        }

        /// <summary>
        /// To check user details for available cards and to save the the user input
        /// </summary>
        /// <param name="enquiryCommand"> Enquiry Command </param>
        /// <returns></returns>
        public async Task<List<CardTypeResponse>> RegisterEnquiry(EnquiryCommand enquiryCommand)
        {
            HttpClient client = _httpClientFactory.CreateClient();
            string url = $"{_cardProAPIConfiguration.APIUrl}enquiry";
            string token = "CarPro Validation Token";
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("Token", token);

            HttpContent content = new StringContent(JsonConvert.SerializeObject(enquiryCommand));
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            List<CardTypeResponse> cardTypeResponse = null;

            HttpResponseMessage responseMessage = await client.PostAsync(url, content);

            if (responseMessage.IsSuccessStatusCode)
            {
                cardTypeResponse = JsonConvert.DeserializeObject<List<CardTypeResponse>>(await responseMessage.Content.ReadAsStringAsync());
            }

            return cardTypeResponse;
        }
    }
}