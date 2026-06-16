namespace EmailService.Exception
{
    public class EmailNotSentExceptiom : ApplicationException
    {
        public EmailNotSentExceptiom(string message) : base(message)
        {

        }
    }
}
