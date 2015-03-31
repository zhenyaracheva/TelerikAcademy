namespace BitArray
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;

    public class BitArray64 : IEnumerable<int>
    {
        private string bits;
        private ulong number;

        public BitArray64(ulong currentNumber)
        {
            this.number = currentNumber;
            this.bits = ConvertToBinary(currentNumber);
        }

        public string Bits
        {
            get
            {
                return this.bits;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Bits cannot be null or empty.");
                }

                this.bits = value;
            }
        }

        public char this[int index]
        {
            get
            {
                if (index < 0 || index >= 64)
                {
                    throw new IndexOutOfRangeException("Index is out of range.");
                }

                return this.Bits[index];
            }
        }

        public override bool Equals(object obj)
        {
            var otherBits = obj as BitArray64;

            if (otherBits == null)
            {
                return false;
            }

            return this.Bits == otherBits.Bits;
        }

        public override int GetHashCode()
        {
            return this.number.GetHashCode();
        }

        public override string ToString()
        {
            return this.Bits;
        }

        public static bool operator ==(BitArray64 first, BitArray64 second)
        {
            return first.Bits.Equals(second);
        }

        public static bool operator !=(BitArray64 first, BitArray64 second)
        {
            return !first.Bits.Equals(second);
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < this.bits.Length; i++)
            {
                yield return int.Parse(this.Bits[i].ToString());
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private string ConvertToBinary(ulong value)
        {
            if (value == 0) return "0";
            var b = new StringBuilder();

            while (value != 0)
            {
                b.Insert(0, ((value & 1) == 1) ? '1' : '0');
                value >>= 1;
            }
            return b.ToString().PadLeft(64, '0');
        }
    }
}
