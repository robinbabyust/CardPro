using Moq;
using Moq.Protected;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace CardPro.UI.Tests.Helpers
{
    public static class HttpClientHelper
    {
        public static Mock<IHttpClientFactory> SetHttpClientFactory(HttpStatusCode httpStatusCode,HttpContent content)
        {
            Mock<IHttpClientFactory> mockFactory = new Mock<IHttpClientFactory>();
            Mock<HttpMessageHandler> mockHttpMessageHandler = new Mock<HttpMessageHandler>();

            mockHttpMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage()
                {
                    StatusCode = httpStatusCode,
                    Content = content
                });

            HttpClient client = new HttpClient(mockHttpMessageHandler.Object);
            mockFactory.Setup(_ => _.CreateClient(It.IsAny<string>())).Returns(client);

            return mockFactory;
        }

        public static HttpContent CreateHttpContentFromObject(object obj)
        {
            string contentString = JsonConvert.SerializeObject(obj);
            HttpContent content = new StringContent(contentString);

            return content;
        }
    }
}
