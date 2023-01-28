using System.IO;

namespace Builder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //The Builder design pattern separates the construction of a complex object from its representation
            //so that the same construction process can create different representations.

            VehicleBuilder builder;
            // Create shop with vehicle builders
            Shop shop = new Shop();
            // Construct and display vehicles
            builder = new CarBuilder();
            shop.Construct(builder);
            builder.Vehicle.Show();
            builder = new MotorCycleBuilder();
            shop.Construct(builder);
            builder.Vehicle.Show();
        }

        /// <summary>
        /// The 'Director' class
        /// </summary>
        class Shop
        {
            // Builder uses a complex series of steps
            public void Construct(VehicleBuilder vehicleBuilder)
            {
                vehicleBuilder.BuildBody();
                vehicleBuilder.InsertWheels();
                vehicleBuilder.AddBrand();
            }
        }
        /// <summary>
        /// The 'Builder' abstract class
        /// </summary>
        abstract class VehicleBuilder
        {
            protected Vehicle vehicle;
            // Gets vehicle instance
            public Vehicle Vehicle
            {
                get { return vehicle; }
            }
            // Abstract build methods
            public abstract void BuildBody();
            public abstract void InsertWheels();
            public abstract void AddBrand();
        }
        /// <summary>
        /// The 'ConcreteBuilder1' class
        /// </summary>
        class MotorCycleBuilder : VehicleBuilder
        {
            public MotorCycleBuilder()
            {
                vehicle = new Vehicle("Honda motorcycle");
            }
            public override void BuildBody()
            {
                vehicle["body"] = "Making the body of the motorcycle.";
            }
            public override void InsertWheels()
            {
                vehicle["wheels"] = "2 wheels are added to the motorcycle.";
            }
            public override void AddBrand()
            {
                vehicle["brand"] = "Adding the brand name: Honda";
            }
        }
        /// <summary>
        /// The 'ConcreteBuilder2' class
        /// </summary>
        class CarBuilder : VehicleBuilder
        {
            public CarBuilder()
            {
                vehicle = new Vehicle("Ford car");
            }
            public override void BuildBody()
            {
                vehicle["body"] = "Making the car body.";
            }
            public override void InsertWheels()
            {
                vehicle["wheels"] = "4 wheels are added to the car.";
            }
            public override void AddBrand()
            {
                vehicle["brand"] = "Adding the car brand: Ford";
            }
        }
        /// <summary>
        /// The 'Product' class
        /// </summary>
        class Vehicle
        {
            private string _vehicleType;
            private Dictionary<string, string> _parts = new Dictionary<string, string>();
            // Constructor
            public Vehicle(string vehicleType)
            {
                this._vehicleType = vehicleType;
            }
            // Indexer
            public string this[string key]
            {
                get { return _parts[key]; }
                set { _parts[key] = value; }
            }
            public void Show()
            {
                Console.WriteLine("We are about to make a {0}", _vehicleType);
                Console.WriteLine(_parts["body"]);
                Console.WriteLine(_parts["wheels"]);
                Console.WriteLine(_parts["brand"]);
            }
        }
    }
}