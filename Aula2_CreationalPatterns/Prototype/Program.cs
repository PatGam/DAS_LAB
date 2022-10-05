namespace Prototype
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //The Prototype design pattern specifies the kind of objects to create using a prototypical instance,
            //and create new objects by copying this prototype.

            // Create two instances and clone each
            Nano nano = new Nano("Nano XM624 cc", 5003);
            Console.WriteLine("Model: {0}", nano.Model);
            Console.WriteLine("Price: ${0}", nano.Price);
            Console.WriteLine("-------");

            Nano clone = (Nano)nano.Clone();
            clone.Price = 5103;
            Console.WriteLine("Model: {0}", clone.Model);
            Console.WriteLine("Price: ${0}", clone.Price);
            Console.WriteLine("-------");
        }

        /// <summary>
        /// The 'Prototype' abstract class
        /// </summary>
        public abstract class Prototype
        {
            public string Model;
            public int Price;
            // Constructor
            public Prototype(string model, int price)
            {
                this.Model = model;
                this.Price = price;
            }

            public abstract Prototype Clone();
        }
        /// <summary>
        /// A 'ConcretePrototype' class 
        /// </summary>
        public class Nano : Prototype
        {
            // Constructor
            public Nano(string model, int price)
                : base(model, price)
            {
            }
            // Returns a shallow copy
            public override Prototype Clone()
            {
                Console.WriteLine("Editing a cloned model:");
                return (Prototype)this.MemberwiseClone();
            }
        }

    }
}
