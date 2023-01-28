namespace Memento
{
    /// <summary>
    /// Memento Design Pattern
    /// </summary>

    public class Program
    {
        //The Memento design pattern without violating encapsulation, captures and
        //externalizes an object‘s internal state so that the object can be restored to this state later.
        public static void Main(string[] args)
        {
            Originator o = new Originator();
            o.state = "Snapshot #0";

            // Store internal state
            Caretaker c = new Caretaker();
            c.Save(o.CreateMemento());

            // Continue changing originator
            o.state = "Snapshot #1";
            c.Save(o.CreateMemento());            
            
            o.state = "Snapshot #2";
            c.Save(o.CreateMemento());
                        
            o.state = "Snapshot #3";
            c.Save(o.CreateMemento());

            o.state = "Snapshot #4";

            o.SetMemento(c.Mementos.First(x => x.state == "Snapshot #3"));
            o.SetMemento(c.Mementos.First(x => x.state == "Snapshot #2"));
            o.SetMemento(c.Mementos.First(x => x.state == "Snapshot #1"));
            o.SetMemento(c.Mementos.First(x => x.state == "Snapshot #0"));
            o.SetMemento(c.Mementos.First(x => x.state == "Snapshot #3"));
        }
    }

    /// <summary>
    /// The 'Originator' class
    /// </summary>

    public class Originator
    {
        public string state { get; set; }
        public Originator()
        {
        }

        // Creates memento 
        public Memento CreateMemento()
        {
            return (new Memento(state));
        }

        // Restores original state

        public void SetMemento(Memento memento)
        {
            this.state = memento.state;
            Console.WriteLine("Restored to state: {0}", this.state);
        }
    }

    /// <summary>
    /// The 'Memento' class
    /// </summary>

    public class Memento
    {
        public string state { get; set; }

        // Constructor

        public Memento(string state)
        {
            Console.WriteLine("The current state is {0}. Saving this checkpoint.", state);
            this.state = state;
        }
    }

    /// <summary>
    /// The 'Caretaker' class
    /// </summary>

    public class Caretaker
    {
        public List<Memento> Mementos { get; set; }

        public Caretaker()
        {
            Mementos = new List<Memento>();
        }

        public void Save(Memento memento)
        {
            Mementos.Add(memento);
        }
    }
}
