namespace Flyweight
{
    /// <summary>
    /// Flyweight Design Pattern
    /// </summary>

    public class Program
    {
        public static void Main(string[] args)
        {
            //The Flyweight design pattern uses sharing to support large numbers of fine-grained objects efficiently

            VehicleFactory factory = new VehicleFactory();

            Car car1 = factory.MakeCar("Audi", "A4");
            car1.AddColor("green");

            Console.WriteLine($"John owns a {car1.Color} {car1.Brand} {car1.Model}");

            Vehicle car2 = factory.MakeCar("Audi", "A4");
            car2.AddColor("blue");
            Console.WriteLine($"Marc owns a {car2.Color} {car2.Brand} {car2.Model}");


            Vehicle car3 = factory.MakeCar("Subaru", "Rex");
            car3.AddColor("pink");
            Console.WriteLine($"Marc owns a {car3.Color} {car3.Brand} {car3.Model}");

        }
    }
    /// <summary>
    /// The 'FlyweightFactory' class
    /// </summary>

    public class VehicleFactory
    {
        private Dictionary<string, Car> flyweights { get; set; } = new Dictionary<string, Car>();

        // Constructor

        public VehicleFactory()
        {
        }

        public Car MakeCar(string brand, string model)
        {
            // Uses "lazy initialization"
            if (flyweights.ContainsKey(brand+model))
            {
                Console.WriteLine("Reusing an existing car");
            }
            else
            {
                Console.WriteLine("Making a car {0} {1} for the first time.", brand, model);
                flyweights.Add(brand+model, new Car(brand, model));
            }

            return flyweights[brand + model];

        }
    }

    /// <summary>
    /// The 'Flyweight' abstract class
    /// </summary>

    public abstract class Vehicle
    {
        public Vehicle(string brand, string model)
        {
            Brand = brand;
            Model = model;
        }

        public string Brand { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public abstract void AddColor(string extrinsicstate);
    }

    /// <summary>
    /// The 'ConcreteFlyweight' class
    /// </summary>

    public class Car : Vehicle
    {
        public Car(string brand, string model):base(brand, model)
        {
            base.Brand = brand;
            base.Model = model;
        }
        public override void AddColor(string color)
        {
            base.Color = color;
        }
    }

}
