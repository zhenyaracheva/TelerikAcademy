namespace GSMTaskMain
{
    using System;
    using System.Text;

    public class Battery
    {
        private string model;
        private BatteryType batteryType;
        private double? idleHours;
        private double? talkHours;

        public Battery(string model, BatteryType batteryType, double idleHours, double talkHours)
            : this(model, batteryType)
        {
            this.IdleHours = idleHours;
            this.TalkHours = talkHours;
        }

        public Battery(string model, BatteryType batteryType)
        {
            this.Model = model;
            this.BatteryType = batteryType;
        }

        public BatteryType BatteryType
        {
            get
            {
                return this.batteryType;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Battery type cannot be null!");
                }

                this.batteryType = value;
            }
        }

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
                    throw new ArgumentNullException("Battery model cannot be null or empty!");
                }

                this.model = value;
            }
        }

        public double? IdleHours
        {
            get
            {
                return this.idleHours;
            }

            set
            {
                if (value <= 0.0)
                {
                    throw new ArgumentException("Battery idle hours cannot be smaller than 0!");
                }

                this.idleHours = value;
            }
        }

        public double? TalkHours
        {
            get
            {
                return this.talkHours;
            }

            set
            {
                if (value <= 0.0)
                {
                    throw new ArgumentException("Battery talk hours cannot be smaller than 0");
                }

                this.talkHours = value;
            }
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.AppendLine(string.Format("- Battery model: {0}", this.Model));
            result.AppendLine(string.Format("- Battery type: {0}", this.BatteryType));

            if (this.IdleHours != null)
            {
                result.AppendLine(string.Format("- Bttery idle hours: {0}", this.IdleHours));
            }

            if (this.TalkHours != null)
            {
                result.AppendLine(string.Format("- Battery talk hors: {0}", this.TalkHours));
            }

            return result.ToString().Trim();
        }
    }
}
