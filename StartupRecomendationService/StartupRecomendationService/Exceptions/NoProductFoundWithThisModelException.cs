using System.Runtime.Serialization;

namespace StartupRecomendationService.Exceptions
{
    [Serializable]
    internal class NoProductFoundWithThisModelException : Exception
    {
        public NoProductFoundWithThisModelException()
        {
        }

        public NoProductFoundWithThisModelException(string message) : base(message)
        {
        }

        public NoProductFoundWithThisModelException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NoProductFoundWithThisModelException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}