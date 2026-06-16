using System.Runtime.Serialization;

namespace StartupRecomendationService.Exceptions
{
    [Serializable]
    internal class NoProductFoundWithThisLocationException : Exception
    {
        public NoProductFoundWithThisLocationException()
        {
        }

        public NoProductFoundWithThisLocationException(string message) : base(message)
        {
        }

        public NoProductFoundWithThisLocationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NoProductFoundWithThisLocationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}