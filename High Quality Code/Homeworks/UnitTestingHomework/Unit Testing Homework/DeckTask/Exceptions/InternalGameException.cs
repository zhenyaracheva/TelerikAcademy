﻿namespace SantaseGameEngine.Exceptions
{
    using System;

    public class InternalGameException : Exception
    {
        public InternalGameException(string message)
            : base(message)
        {
        }
    }
}
