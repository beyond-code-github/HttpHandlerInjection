namespace HttpHandlerInjection
{
    public class MessageProvider : IMessageProvider
    {
        public string GetMessage()
        {
            return "Hello World";
        }
    }
}