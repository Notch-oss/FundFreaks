using System.Runtime.Serialization;

namespace StartupRecomendationService.Exceptions
{
    [Serializable]
    internal class NoProductFoundWithThisStageException : Exception
    {
        public NoProductFoundWithThisStageException()
        {
        }

        public NoProductFoundWithThisStageException(string message) : base(message)
        {
        }

        public NoProductFoundWithThisStageException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NoProductFoundWithThisStageException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}