namespace StudentsAndWorkers
{
    using System;

    using StudentsAndWorkers.Interfaces;

    public class Worker : Human, IWorker, IHuman
    {
        private decimal weekSalary;
        private int workHoursPerDay;

        public Worker(string initialFirstName, string initialLastName, decimal initialWeekSalary, int hourPerDay)
            : base(initialFirstName, initialLastName)
        {
            this.WeekSalary = initialWeekSalary;
            this.WorkHoursPerDay = hourPerDay;
        }

        public decimal WeekSalary
        {
            get
            {
                return this.weekSalary;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Week salary cannot be less or equal to 0.");
                }

                this.weekSalary = value;
            }
        }

        public int WorkHoursPerDay
        {
            get
            {
                return this.workHoursPerDay;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Work hourse per day cannot be less or equal to 0.");
                }

                this.workHoursPerDay = value;
            }
        }

        public decimal MoneyPerHour()
        {
            return this.WeekSalary / (5m * this.WorkHoursPerDay);
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
