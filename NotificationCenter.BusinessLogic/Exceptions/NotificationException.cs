using System;

namespace NotificationCenter.BusinessLogic.Exceptions
{
    public class NotificationException : Exception
    {
        public NotificationException(string message) : base(message) { }
    }
}