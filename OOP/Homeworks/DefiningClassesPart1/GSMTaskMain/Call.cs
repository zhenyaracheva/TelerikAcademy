namespace GSMTaskMain
{
    using System;
    using System.Text;

    public class Call
    {
        private DateTime dateTimeCall;
        private Contact dialedPhoneNumber;
        private double duration;

        public Call(DateTime currentDateTime, Contact currentContact, double currentDuration)
        {
            this.dateTimeCall = currentDateTime;
            this.dialedPhoneNumber = currentContact;
            this.duration = currentDuration;
        }

        public DateTime DateTimeCall
        {
            get
            {
                return this.dateTimeCall;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Date cannot be null!");
                }

                this.dateTimeCall = value;
            }
        }

        public Contact DialedPhoneNumber
        {
            get
            {
                return this.dialedPhoneNumber;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Dailded number cannot be null!");
                }

                this.dialedPhoneNumber = value;
            }
        }

        public double Duration
        {
            get
            {
                return this.duration;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Phone duration cannot be smaller than 0!");
                }

                this.duration = value;
            }
        }
        
        public override string ToString()
        {
            var result = new StringBuilder();

            result.AppendLine(this.DateTimeCall.ToString());
            result.AppendLine(string.Format("Name: {0}", this.DialedPhoneNumber.Name));
            result.AppendLine(string.Format("Phone number: {0}", this.DialedPhoneNumber.Number));
            result.Append(string.Format("Duration: {0}", this.Duration.ToString()));

            return result.ToString();
        }
    }
}
