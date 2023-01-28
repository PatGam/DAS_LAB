namespace Adapter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //The Adapter design pattern converts the interface of a class into another interface clients expect.
            //This design pattern lets classes work together that couldn‘t otherwise because of incompatible interfaces.

            Figure rectangle = new Rectangle();
            rectangle.aboutMe();
            rectangle.CalculateArea();

            Figure triangle = new Adapter();
            triangle.aboutMe();
            triangle.CalculateArea();
        }

        //Target
        public abstract class Figure
        {
            public abstract void aboutMe();

            public abstract void CalculateArea();
        }

        //Adapter
        public class Adapter : Figure
        {
            //Adaptee
            private TriInterface triInterface;

            public Adapter()
            {
                this.triInterface = new Triangle();
            }

            public override void aboutMe()
            {
                triInterface.aboutTriangle();
            }

            public override void CalculateArea()
            {
                triInterface.calculateTriangleArea();
            }
        }

        public class Rectangle : Figure
        {
            public override void aboutMe()
            {
                Console.WriteLine("Shape type: Rectangle.");            
            }

            public override void CalculateArea()
            {
                Console.WriteLine("Area: 200.0 square units.");
            }
        }

        //Adaptee
        public class Triangle : TriInterface
        {
            public override void aboutTriangle()
            {
                Console.WriteLine("Shape type: Triangle.");
            }

            public override void calculateTriangleArea()
            {
                Console.WriteLine("Area: 100.0 square units.");
            }
        }

        public abstract class TriInterface
        {
            public abstract void aboutTriangle();

            public abstract void calculateTriangleArea();
        }


    }
}