namespace UserAuthenticationService.Exceptions
{
    public class PasswordDoesNotMatch:Exception
    {
        public PasswordDoesNotMatch()
        {

        }
        public PasswordDoesNotMatch(string message)
        : base(message)
        {
        }
    }
}
