namespace HttpHandlerInjection
{
    using System.Web;

    using Autofac;

    public abstract class InjectableHttpHandler : IHttpHandler
    {
        public virtual void ProcessRequest(HttpContext context)
        {
            this.ProcessRequest(new HttpContextWrapper(context));
        }

        public virtual void ProcessRequest(HttpContextBase context)
        {
            Container.Instance().InjectProperties(this);
        }

        public bool IsReusable { get; private set; }
    }
}