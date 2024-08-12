using System;

namespace DSEU.Application.Common.Exceptions
{
    public class SecureException : Exception
    {
        public SecureException()
           : base()
        {
        }
        public SecureException(string message)
            : base(message)
        {
        }
        public SecureException(string message, Exception innerException)
           : base(message, innerException)
        {
        }
        public string EntityName { get; set; }
        public object Key { get; set; }
        public SecureException(string name, object key)
            : base($"Entity \"{name}\" ({key}) was not found.")
        {
            Key = key;
            EntityName = name;
        }
    }
}