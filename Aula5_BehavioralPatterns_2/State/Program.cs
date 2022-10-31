
namespace State
{
    /// <summary>
    /// State Design Pattern
    /// </summary>

    public class Program
    {
        //The State design pattern allows an object to alter its behavior
        //when its internal state changes. The object will appear to change its class.
        public static void Main(string[] args)
        {
            // Setup context in a state
            var context = new TCPConnection();
            // Issue requests, which toggles state

            context.Open();
            context.Acknowledge();
            context.Close();
            context.Open();
            context.Close();
            context.Acknowledge();
        }
    }

    /// <summary>
    /// The 'State' abstract class
    /// </summary>

    public abstract class TCPState
    {
        public abstract void Open(TCPConnection context);
        public abstract void Close(TCPConnection context);
        public abstract void Acknowledge(TCPConnection context);
    }

    /// <summary>
    /// A 'ConcreteState' class
    /// </summary>

    public class TCPEstablished : TCPState
    {
        public override void Acknowledge(TCPConnection context)
        {
            throw new NotImplementedException();
        }

        public override void Close(TCPConnection context)
        {
            Console.WriteLine("Closing. State is now Listen.");
            context.State = new TCPListen();
        }

        public override void Open(TCPConnection context)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// A 'ConcreteState' class
    /// </summary>

    public class TCPListen : TCPState
    {
        public override void Acknowledge(TCPConnection context)
        {
            Console.WriteLine("Acknowledging. State is now Established.");
            context.State = new TCPEstablished();
        }

        public override void Close(TCPConnection context)
        {
            Console.WriteLine("Closing. Unexpected message. State is now Listen.");
            context.State = new TCPListen();
        }

        public override void Open(TCPConnection context)
        {
            Console.WriteLine("Active opening. Unexpected message. State is now Listen.");
            context.State = new TCPListen();
        }
    }

    /// <summary>
    /// A 'ConcreteState' class
    /// </summary>
    public class TCPClosed : TCPState
    {
        public override void Acknowledge(TCPConnection context)
        {
            throw new NotImplementedException();
        }

        public override void Close(TCPConnection context)
        {
            throw new NotImplementedException();
        }

        public override void Open(TCPConnection context)
        {
            Console.WriteLine("Passive opening. State is now Listen.");
            context.State = new TCPListen();
        }
    }

    /// <summary>
    /// The 'Context' class
    /// </summary>

    public class TCPConnection
    {
        // Constructor
        public TCPConnection()
        {
            Console.WriteLine("Creating new connection. Initial state is Closed.");
            this.State = new TCPClosed();
        }

        // Gets or sets the state

        public TCPState State { get; set; }

        public void Open()
        {
            State.Open(this);
        }
        public void Close()
        {
            State.Close(this);
        }
        public void Acknowledge()
        {
            State.Acknowledge(this);
        }
    }
}
