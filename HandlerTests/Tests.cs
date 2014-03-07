using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HandlerTests
{
    using System;
    using System.Web;

    using Autofac;

    using HttpHandlerInjection;

    using Moq;

    [TestClass]
    public class Tests
    {
        private Mock<IMessageProvider> mockMessageProvider;

        private Mock<HttpContextBase> context;

        [TestInitialize]
        public void Init()
        {
            this.SetupContext();

            mockMessageProvider = new Mock<IMessageProvider>();

            Container.Instance = () =>
                {
                    var builder = new ContainerBuilder();
                    builder.RegisterInstance(mockMessageProvider.Object);
                    return builder.Build();
                };
        }

        [TestMethod]
        public void Should_get_the_message()
        {
            var handler = new MyHttpHandler();
            handler.ProcessRequest(this.context.Object);

            mockMessageProvider.Verify(o => o.GetMessage());
        }

        private void SetupContext()
        {
            this.context = new Mock<HttpContextBase>();
            var response = new Mock<HttpResponseBase>();
            response.SetupProperty(x => x.ContentType);
            
            this.context.Setup(x => x.Request.Url).Returns(new Uri("http://localhost/"));
            this.context.Setup(x => x.Response).Returns(response.Object);

        }
    }
}
