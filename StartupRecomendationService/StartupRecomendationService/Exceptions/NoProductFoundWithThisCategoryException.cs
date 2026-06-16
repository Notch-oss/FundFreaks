using System.Runtime.Serialization;

namespace StartupRecomendationService.Exceptions
{
    [Serializable]
    internal class NoProductFoundWithThisCategoryException : Exception
    {
        public NoProductFoundWithThisCategoryException()
        {
        }

        public NoProductFoundWithThisCategoryException(string message) : base(message)
        {
        }

        public NoProductFoundWithThisCategoryException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NoProductFoundWithThisCategoryException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}