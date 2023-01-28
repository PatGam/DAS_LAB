namespace Command
{
    /// <summary>
    /// Command Design Pattern
    /// </summary>

    public class Program
    {
        //The Command design pattern encapsulates a request as an object,
        //thereby letting you parameterize clients with different requests,
        //queue or log requests, and support undoable operations.
        public static void Main(string[] args)
        {
            // Create receiver, command, and invoker
            Receiver receiver = new Receiver();
            Command command = new MoveNorth(receiver);
            Invoker invoker = new Invoker();

            invoker.SetCommand(command);
            invoker.ExecuteCommand();

            Command command2 = new MoveEast(receiver);
            invoker.SetCommand(command2);
            invoker.ExecuteCommand();

            Command command3 = new MoveNorth(receiver);
            invoker.SetCommand(command3);
            invoker.ExecuteCommand();

            invoker.Undo();

            Command command4 = new MoveEast(receiver);
            invoker.SetCommand(command4);
            invoker.ExecuteCommand();

            invoker.Redo();


            // Wait for user

            Console.ReadKey();
        }
    }

    /// <summary>
    /// The 'Command' abstract class
    /// </summary>
    public abstract class Command
    {
        protected Receiver receiver;

        public int directionToMove { get; set; }
        
        // Constructor
        public Command(Receiver receiver)
        {
            this.receiver = receiver;
        }

        public abstract void Execute();
        public abstract void UnExecute();

    }

    /// <summary>
    /// The 'ConcreteCommand' class
    /// </summary>
    public class MoveNorth : Command
    {
        // Constructor
        public MoveNorth(Receiver receiver) :
            base(receiver)
        {
            Console.WriteLine("Client: Creating new command (Move North)");
            this.directionToMove = 1;
        }
        public override void Execute()
        {
            Console.WriteLine("Command: Executing. Calling SetY() on 2d position");
            receiver.SetY(1);
        }

        public override void UnExecute()
        {
            receiver.SetY(-base.directionToMove);
        }
    }

    /// <summary>
    /// The 'ConcreteCommand' class
    /// </summary>
    public class MoveEast : Command
    {
        // Constructor
        public MoveEast(Receiver receiver) :
            base(receiver)
        {
            Console.WriteLine("Client: Creating new command (Move East)");
            this.directionToMove = 1;
        }
        public override void Execute()
        {
            Console.WriteLine("Command: Executing. Calling SetX() on 2d position");
            receiver.SetX(1);
        }

        public override void UnExecute()
        {
            Console.WriteLine("Command: Undoing. Calling SetY() on 2d position");
            receiver.SetY(-base.directionToMove);
        }
    }


    /// <summary>
    /// The 'Receiver' class
    /// </summary>

    public class Receiver
    {
        public Receiver()
        {
            Console.WriteLine("Client: Creating new 2d position@ 0,0");
        }
        public int x { get; set; }
        public int y { get; set; }
        public void SetY(int directionToMove)
        {
            this.y += directionToMove;
            Console.WriteLine("Point2D: Moving to {0},{1}.", this.x, this.y);        
        }
        public void SetX(int directionToMove)
        {
            this.x += directionToMove;
            Console.WriteLine("Point2D: Moving to {0},{1}.", this.x, this.y);
        }
    }

    /// <summary>
    /// The 'Invoker' class
    /// </summary>

    public class Invoker
    {
        Command command;

        public List<Command> _undoList;
        public List<Command> _redoList;

        public Invoker()
        {
            _undoList = new List<Command>();
            _redoList = new List<Command>();
        }

        public void SetCommand(Command command)
        {
            Console.WriteLine("Client: Sending command to invoker");
            Console.WriteLine("Invoker: Receiving new command");
            this.command = command;
            _undoList.Add(command);
            _redoList.Clear();
            Console.WriteLine("Invoker: Storing new command in undo list and clearing redo list (undo list: {0} commands, redo list: {1} commands)", this._undoList.Count(), this._redoList.Count());
        }

        public void ExecuteCommand()
        {
            Console.WriteLine("Invoker: executing command");
            command.Execute();
        }

        public void Undo()
        {
            Console.WriteLine("Client: Sending request to undo to invoker");
            Console.WriteLine("Invoker: Received undo request");
            var undoCommand = _undoList.Last();
            Console.WriteLine("Invoker: Undoing last command in undo list");
            undoCommand.UnExecute();
            _undoList.Remove(undoCommand);
            _redoList.Add(undoCommand);
            Console.WriteLine("Invoker: Removing last command from undo list and adding to redolist (undo list: {0} commands, redo list: {1})", this._undoList.Count(), this._redoList.Count());
        }

        public void Redo()
        {
            Console.WriteLine("Client: Sending request to redo to invoker");
            Console.WriteLine("Invoker: Received redo request");
            if (_redoList.Count > 0)
            {
                var redoCommand = _redoList.Last();
                redoCommand.Execute();
                _undoList.Remove(redoCommand);
                _redoList.Add(redoCommand);
            }
            else
            {
                Console.WriteLine("Invoker: Not possible, no previously undone command found");
            }
            
        }
    }
}
