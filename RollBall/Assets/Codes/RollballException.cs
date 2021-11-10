using System;

namespace Kravchuk
{
    public sealed class RollballException : Exception
    {
        public RollballException(string message) : base(message) { }
    }
}