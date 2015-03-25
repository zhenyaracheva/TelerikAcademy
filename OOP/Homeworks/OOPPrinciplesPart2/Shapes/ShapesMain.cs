namespace Shapes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Shapes.Interfaces;

    public class ShapesMain
    {
        public static void Main()
        {
            Square square = new Square(4);
            Triangle triangle = new Triangle(5, 6);
            Rectangle rectangle = new Rectangle(2, 6);

            Console.WriteLine("Square area: " + square.CalculateSurface());
            Console.WriteLine("Triangle area: " + triangle.CalculateSurface());
            Console.WriteLine("Rectangle: " + rectangle.CalculateSurface());
            Console.WriteLine();

            Console.WriteLine("Sorted shapes by area:");
            var listOfShapes = new List<IShape>();
            listOfShapes.Add(square);
            listOfShapes.Add(triangle);
            listOfShapes.Add(rectangle);
            listOfShapes.Add(new Triangle(4.5m, 7));
            listOfShapes.Add(new Triangle(5, 2.6m));
            listOfShapes.Add(new Triangle(1, 3));
            listOfShapes.Add(new Triangle(8.1m, 15));

            var sorted = listOfShapes.OrderBy(x => x.CalculateSurface());

            foreach (var item in sorted)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
