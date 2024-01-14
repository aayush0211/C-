using System.Runtime.Serialization;

namespace Day5Lab
{
    [Serializable]
    internal class InvalidValueException : ApplicationException
    {
      

        public InvalidValueException(string? message) : base(message)
        {
        }

        
    }
}