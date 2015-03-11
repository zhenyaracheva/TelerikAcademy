namespace GSMTaskMain
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class GSM
    {
        private static IPhone4S iphone;
        private string model;
        private string manufacturer;
        private double? price;
        private Owner owner;
        private Battery battery;
        private Display display;
        private IList<Call> callHistory;

        public GSM(string model, string manufacturer, double price, Owner owner, Battery battery, Display display)
            : this(model, manufacturer, price, battery, display)
        {
            this.Owner = owner;
        }

        public GSM(string model, string manufacturer, double price, Battery battery, Display display)
            : this(model, manufacturer, price)
        {
            this.Battery = battery;
            this.Display = display;
        }

        public GSM(string model, string manufacturer, double? price)
            : this(model, manufacturer)
        {
            this.Price = price;
        }

        public GSM(string model, string manufacturer)
        {
            this.Model = model;
            this.Manufacturer = manufacturer;
            this.CallHistory = new List<Call>();
        }

        public IList<Call> CallHistory
        {
            get
            {
                return this.callHistory;
            }

            set
            {
                this.callHistory = new List<Call>();
            }
        }

        public IPhone4S IPhone { get; set; }

        public string Model
        {
            get
            {
                return this.model;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Model cannot be null or empty!");
                }

                this.model = value;
            }
        }

        public string Manufacturer
        {
            get
            {
                return this.manufacturer;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Manifacturer cannot be null or empty!");
                }

                this.manufacturer = value;
            }
        }

        public double? Price
        {
            get
            {
                return this.price;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Price cannot be smaller than 0!");
                }

                this.price = value;
            }
        }

        public Owner Owner
        {
            get
            {
                return this.owner;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Owner cannot be null!");
                }

                this.owner = value;
            }
        }

        public Battery Battery
        {
            get
            {
                return this.battery;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Phone cannot have null battery!");
                }

                this.battery = value;
            }
        }

        public Display Display
        {
            get
            {
                return this.display;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Phone cannot have null display!");
                }

                this.display = value;
            }
        }

        public void AddCall(Call currentCall)
        {
            this.CallHistory.Add(currentCall);
        }

        public void ClearHistory()
        {
            this.CallHistory.Clear();
        }

        public void DeleteCall(Call currentCall)
        {
            this.CallHistory.Remove(currentCall);
        }

        public decimal CalculateCallHistoryPrice(decimal price)
        {
            decimal allDurations = (decimal)this.CallHistory.Select(d => d.Duration).Sum();
            return price * allDurations;
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.AppendLine(string.Format("- Model: {0}", this.Model));
            result.AppendLine(string.Format("- Manufacturer: {0}", this.Manufacturer));

            if (this.Price != null)
            {
                result.AppendLine(string.Format("- Price: {0}", this.Price));
            }

            if (this.Battery != null)
            {
                result.AppendLine(this.Battery.ToString());
            }

            if (this.Display != null)
            {
                result.AppendLine(this.Display.ToString());
            }

            if (this.Owner != null)
            {
                result.AppendLine(this.Owner.ToString());
            }

            if (this.CallHistory != null)
            {
                result.AppendLine(string.Join(", ", this.CallHistory));
            }

            if (this.CallHistory != null)
            {
                var callHistoryAsString = new StringBuilder();
                callHistoryAsString.Append("Call history: ");

                if (this.CallHistory.Count != 0)
                {
                    for (int i = 0; i < this.CallHistory.Count; i++)
                    {
                        callHistoryAsString.Append(this.CallHistory[i]);

                        if (i != this.callHistory.Count)
                        {
                            callHistoryAsString.Append(", ");
                        }
                    }
                }
                else
                {
                    callHistoryAsString.Append("No call history!");
                }

                result.AppendLine(callHistoryAsString.ToString());
            }

            return result.ToString().Trim();
        }
    }
}
