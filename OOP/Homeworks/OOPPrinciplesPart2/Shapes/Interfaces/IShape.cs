namespace Shapes.Interfaces
{
    public interface IShape
    {
        decimal Width { get; set; }

        decimal Height { get; set; }

        decimal CalculateSurface();
    }
}
