namespace HttpHandlerInjection
{
    using System;

    using Autofac;

    public static class Container
    {
        private static IContainer container;

        public static Func<IContainer> Instance = () =>
            {
                if (container == null)
                {
                    var builder = new ContainerBuilder();
                    builder.RegisterType<MessageProvider>().As<IMessageProvider>();
                    container = builder.Build();
                }

                return container;
            };
    }
}