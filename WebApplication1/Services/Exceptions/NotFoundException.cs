namespace WebApplication1.Services.Exeptions
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string message): base (message) { }
    }
}
