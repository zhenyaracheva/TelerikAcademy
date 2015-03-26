namespace RangeException
{
    using System;

    public class InvalidRangeException<T> : ApplicationException
        where T : struct
    {
        public InvalidRangeException(string msg, T startRange, T endRange, Exception innerEx)
            : base(msg, innerEx)
        {
            this.Start = startRange;
            this.End = endRange;
        }

        public InvalidRangeException(string msg, T startRange, T endRange)
            : this(msg, startRange, endRange, null)
        {
            this.Start = startRange;
            this.End = endRange;
        }

        public T Start { get;  set; }

        public T End { get;  set; }
    }
}
