namespace ClassAdapter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Class Adapter uses inheritance and can only wrap a class.
            //It cannot wrap an interface since by definition it must derive from some base class.

            //Object Adapter uses composition and can wrap classes or interfaces, or both.
            //It can do this since it contains, as a private, encapsulated member, the class or interface object instance it wraps.
            //Composition over inheritance
            IFigure rectangle = new Rectangle();
            rectangle.aboutMe();
            rectangle.CalculateArea();

            IFigure triangle = new Adapter();
            triangle.aboutMe();
            triangle.CalculateArea();
        }

        //Target
        public interface IFigure
        {
            public void aboutMe();

            public void CalculateArea();
        }

        //Adapter
        //In this approach, the Adapter calls the methods inherited from the Adaptee class.
        public class Adapter : Triangle, IFigure
        {
            public void aboutMe()
            {
                base.aboutTriangle();
            }

            public void CalculateArea()
            {
                base.calculateTriangleArea();
            }
        }

        public class Rectangle : IFigure
        {
            public  void aboutMe()
            {
                Console.WriteLine("Shape type: Rectangle.");
            }

            public  void CalculateArea()
            {
                Console.WriteLine("Area: 200.0 square units.");
            }
        }

        //Adaptee
        public class Triangle : ITriInterface
        {
            public  void aboutTriangle()
            {
                Console.WriteLine("Shape type: Triangle.");
            }

            public void calculateTriangleArea()
            {
                Console.WriteLine("Area: 100.0 square units.");
            }
        }

        public interface ITriInterface
        {
            public void aboutTriangle();

            public void calculateTriangleArea();
        }


    }
}