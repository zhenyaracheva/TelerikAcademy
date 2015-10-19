namespace CloneNorthwind
{
    using System.Data.Entity;

    public class NorthwindTwinEntities : DbContext
    {
        public NorthwindTwinEntities()
            : base("NorthwindTwin")
        {
        }
    }
}
