namespace StudentsAndWorkers.Interfaces
{
    public interface IWorker : IHuman
    {
        decimal WeekSalary { get; set; }

        int WorkHoursPerDay { get; set; }

        decimal MoneyPerHour();
    }
}
