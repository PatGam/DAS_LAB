namespace Strategy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //The Strategy design pattern defines a family of algorithms, encapsulate each one, and make them interchangeable.
            //This pattern lets the algorithm vary independently from clients that use it.
            VehicleSupervisor context;

            // Three contexts following different strategies

            context = new VehicleSupervisor(new Vehicle("airplane"));
            context.DisplayDetail();

            context.SetVehicleBehavior(new FlyBehavior());
            context.DisplayDetail();

            context.SetVehicleBehavior(new FloatBehavior());
            context.DisplayDetail();
        }
    }

    /// <summary>
    /// The 'Strategy' abstract class
    /// </summary>

    public abstract class VehicleBehavior
    {
        public abstract void ShowDetail();
    }

    /// <summary>
    /// A 'ConcreteStrategy' class
    /// </summary>

    public class InitialBehavior : VehicleBehavior
    {
        public override void ShowDetail()
        {
            Console.WriteLine("The airplane is in born state.\r\nIt cannot do anything special.");
        }
    }

    /// <summary>
    /// A 'ConcreteStrategy' class
    /// </summary>

    public class FlyBehavior : VehicleBehavior
    {
        public override void ShowDetail()
        {
            Console.WriteLine("Setting flying capability to it.\r\nThe airplane can fly now.");
        }
    }

    /// <summary>
    /// A 'ConcreteStrategy' class
    /// </summary>

    public class FloatBehavior : VehicleBehavior
    {
        public override void ShowDetail()
        {
            Console.WriteLine("Changing the vehicle behavior again.\r\nThe airplane can float now.");
        }
    }

    /// <summary>
    /// The 'Context' class
    /// </summary>

    public class VehicleSupervisor
    {
        VehicleBehavior strategy;
        Vehicle vehicle;

        public VehicleSupervisor(Vehicle vehicle)
        {
            this.vehicle = vehicle;
            this.strategy = new InitialBehavior();
        }

        // Constructor

        public void SetVehicleBehavior(VehicleBehavior strategy)
        {
            this.strategy = strategy;
        }

        public void DisplayDetail()
        {
            strategy.ShowDetail();
        }
    }

    public class Vehicle
    {
        public Vehicle(string vehicleType)
        {
            VehicleType = vehicleType;
        }

        public string VehicleType { get; set; }
    }
}
