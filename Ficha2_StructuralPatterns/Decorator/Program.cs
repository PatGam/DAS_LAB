using System.ComponentModel;

namespace Decorator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //The Decorator design pattern attaches additional responsibilities to an object dynamically.
            //This pattern provide a flexible alternative to subclassing for extending functionality.

            PlaygroundDecorator playground = new PlaygroundDecorator();
            SwimmingPoolDecorator swimmingPool = new SwimmingPoolDecorator();

            Console.WriteLine("Scenario 1:");
            Console.WriteLine("Making a basic home with standard facilities.");
            BasicHome home1 = new BasicHome();
            home1.getTotalCost();

            Console.WriteLine();

            Console.WriteLine("Scenario 2:");
            Console.WriteLine("Making a basic home. Then adding a playground.");
            BasicHome home2 = new BasicHome();
            playground.DecorateHouse(home2);
            playground.addPart();
            home2.getTotalCost();
            
            Console.WriteLine();

            Console.WriteLine("Scenario 3:");
            Console.WriteLine("Making a basic home. Then adding two playgrounds one by one.");
            BasicHome home3 = new BasicHome();
            playground.DecorateHouse(home3);
            playground.addPart();
            playground.addPart(); 
            home3.getTotalCost();

            Console.WriteLine();

            Console.WriteLine("Scenario 4:");
            Console.WriteLine("Making a basic home. Then adding one additional playground and swimming pool.");
            BasicHome home4 = new BasicHome();
            playground.DecorateHouse(home4);
            swimmingPool.DecorateHouse(home4);
            playground.addPart();
            swimmingPool.addPart();
            home4.getTotalCost();
            
            Console.WriteLine();

            Console.WriteLine("Scenario 5:");
            Console.WriteLine("Making an advanced home.");
            AdvancedHome home5 = new AdvancedHome();
            home5.getTotalCost();
                        
            Console.WriteLine();

            Console.WriteLine("Scenario 6:");
            Console.WriteLine("Making an advanced home. Then adding one additional playground to it.");
            AdvancedHome home6 = new AdvancedHome();
            playground.DecorateHouse(home6);
            playground.addPart();
            home6.getTotalCost();
        }
    }

    //defines the interface for objects that can have responsibilities added to them dynamically.
    public abstract class Component
    {
        public double basePrice;
        public double additionalCost;
        public void getPrice()
        {
            Console.WriteLine("You need to pay ${0} for this.", this.basePrice);
        }
        public void getTotalCost()
        {
            Console.WriteLine("Total cost: ${0}", basePrice+additionalCost);
        }
    }

    //defines an object to which additional responsibilities can be attached.
    public class BasicHome : Component
    {
        public BasicHome()
        {
            base.basePrice = 100000.0;
            Console.WriteLine("The basic home with some standard facilities is ready.");
            base.getPrice();
        }
    }

    public class AdvancedHome : Component
    {
        public AdvancedHome()
        {
            base.basePrice = 125000.0;
            Console.WriteLine("The advanced home with more facilities is ready.");
            base.getPrice();
        }
    }

    //maintains a reference to a Component object and defines an interface that conforms to Component's interface.
    public abstract class Decorator : Component
    {
        protected Component component;

        public void DecorateHouse(Component component)
        {
            this.component = component;
        }

        public abstract void addPart();

    }

    //adds responsibilities to the component.
    public class PlaygroundDecorator : Decorator
    {

        public override void addPart()
        {
            Console.WriteLine("For a playground, you pay an extra $20000.0");
            base.component.additionalCost += 20000.0;
        }
    }

    public class SwimmingPoolDecorator : Decorator
    {
        public override void addPart()
        {
            Console.WriteLine("For a swimming pool, you pay an extra $55000.0");
            this.component.additionalCost += 55000.0;
        }
    }
}