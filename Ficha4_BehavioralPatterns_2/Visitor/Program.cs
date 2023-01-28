
namespace Visitor
{
    /// <summary>
    /// Visitor Design Pattern
    /// </summary>

    public class Program
    {
        public static void Main(string[] args)
        {
            //The Visitor design pattern represents an operation to be performed on the elements
            //of an object structure. This pattern lets you define a new operation without changing
            //the classes of the elements on which it operates.

            // Setup structure
            Console.WriteLine("Testing the IncrementorVisitor now.");
            IntegerProcessor intProc = new IntegerProcessor();
            intProc.AcceptVisitor(new IncrementVisitor());
            intProc.GetNumber();
            Console.WriteLine("Testing the DoubleMakerVisitor now.");
            IntegerProcessor intProc2 = new IntegerProcessor();
            intProc2.AcceptVisitor(new DoubleMakerVisitor());
            intProc2.GetNumber();           
        }
    }

    /// <summary>
    /// The 'Visitor' abstract class
    /// </summary>

    public abstract class Visitor
    {
        public abstract void VisitNumber(
            IntegerProcessor integerProcessor);
    }

    /// <summary>
    /// A 'ConcreteVisitor' class
    /// </summary>

    public class IncrementVisitor : Visitor
    {
        public override void VisitNumber(
            IntegerProcessor integerProcessor)
        {
            Console.WriteLine("Incrementing it by 10.");
            integerProcessor.number += 10;
        }
    }

    /// <summary>
    /// A 'ConcreteVisitor' class
    /// </summary>

    public class DoubleMakerVisitor : Visitor
    {
        public override void VisitNumber(
            IntegerProcessor integerProcessor)
        {
            Console.WriteLine("Multiplying it by 2.");
            integerProcessor.number *= 2;
        }
    }

    /// <summary>
    /// The 'Element' abstract class
    /// </summary>

    public abstract class NumberProcessor
    {
        public abstract void AcceptVisitor(Visitor visitor);
    }

    /// <summary>
    /// A 'ConcreteElement' class
    /// </summary>

    public class IntegerProcessor : NumberProcessor
    {
        public int number { get; set; }

        public IntegerProcessor()
        {
            Console.WriteLine("The flag value is:5");
            this.number = 5;
        }

        public override void AcceptVisitor(Visitor visitor)
        {
            visitor.VisitNumber(this);
        }

        public void GetNumber()
        {
            Console.WriteLine("The new value is:{0}", number);
        }
    }

    /// <summary>
    /// The 'ObjectStructure' class
    /// </summary>

    public class ObjectStructure
    {
        List<NumberProcessor> elements = new List<NumberProcessor>();

        public void Attach(NumberProcessor element)
        {
            elements.Add(element);
        }

        public void Detach(NumberProcessor element)
        {
            elements.Remove(element);
        }

        public void Accept(Visitor visitor)
        {
            foreach (NumberProcessor element in elements)
            {
                element.AcceptVisitor(visitor);
            }
        }
    }
}
