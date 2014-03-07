namespace HttpHandlerInjection
{
    using System.Threading;
    using System.Web;

    public class MyHttpHandler : InjectableHttpHandler
    {
        private readonly ThreadLocal<IMessageProvider> messageProvider = new ThreadLocal<IMessageProvider>();
        public IMessageProvider MessageProvider
        {
            get
            {
                return messageProvider.Value;
            }
            set
            {
                messageProvider.Value = value;
            }
        }

        public override void ProcessRequest(HttpContextBase context)
        {
            base.ProcessRequest(context);

            context.Response.StatusCode = 200;
            context.Response.Write(MessageProvider.GetMessage());
        }
    }
}
