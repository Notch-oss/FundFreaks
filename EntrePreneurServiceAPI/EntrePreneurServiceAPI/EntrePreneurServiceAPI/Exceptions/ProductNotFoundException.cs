namespace EntrePreneurServiceAPI.Exceptions
{  
        public class ProductNotFoundException : ApplicationException
        {
            public ProductNotFoundException() { }
            public ProductNotFoundException(string message) : base(message) { }
        }   
}
