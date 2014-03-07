namespace HttpHandlerInjection
{
    using System.Web;

    public class MyHttpHandler : InjectableHttpHandler {
       
        public IMessageProvider MessageProvider { get; set; }

        public override void ProcessRequest(HttpContextBase context)
        {
            base.ProcessRequest(context);

            context.Response.StatusCode = 200;
            context.Response.Write(MessageProvider.GetMessage());
        }
    }
}
