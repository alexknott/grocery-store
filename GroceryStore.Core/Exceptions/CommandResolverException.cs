using System;

namespace GroceryStore.Core.Exceptions
{
    public class CommandResolverException : Exception
    {
        public CommandResolverException()
        {
        }

        public CommandResolverException(string message) : base(message)
        {
        }

        public CommandResolverException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
