using static System.Net.Mime.MediaTypeNames;

namespace Mediator
{
    /// <summary>
    /// Mediator Design Pattern
    /// </summary>

    public class Program
    {
        public static void Main(string[] args)
        {
            //The Mediator design pattern defines an object that encapsulates how a set of objects interact.
            //Mediator promotes loose coupling by keeping objects from referring to each other explicitly,
            //and it lets you vary their interaction independently.
            Console.WriteLine("Client::Creating Font Dialog Director.");
            FontDialogDirector fontDialogDirector = new FontDialogDirector();
            fontDialogDirector.CreateWidgets();
            Console.WriteLine("Client:: Acessing listbox to select new option");
            fontDialogDirector.ListBox.GetSelection("Op1");
            Console.WriteLine("Client:: Acessing listbox to select new option");
            fontDialogDirector.ListBox.GetSelection("Op2");
        }
    }

    /// <summary>
    /// The 'Mediator' abstract class
    /// </summary>

    public abstract class DialogDirector
    {
        public abstract void ShowDialog();
        public abstract void CreateWidgets();
        public abstract void WidgetChanged(Widget widget);
    }

    /// <summary>
    /// The 'ConcreteMediator' class
    /// </summary>

    public class FontDialogDirector : DialogDirector
    {
        public ListBox ListBox { get; set; }
        public EntryField EntryField { get; set; }

        public override void CreateWidgets()
        {
            Console.WriteLine("Director::Creating List Box with options Op1, Op2, Op3");
            this.ListBox = new ListBox(this);
            Console.WriteLine("Director::Creating Entry Field with empty text.");
            this.EntryField = new EntryField(this);
        }

        public override void ShowDialog()
        {
            throw new NotImplementedException();
        }

        public override void WidgetChanged(Widget widget)
        {
            if(widget.GetType() == ListBox.GetType())
            {
                ListBox lb = (ListBox)widget; 
                Console.WriteLine("Director:: Director knows Listbox changed. Retrieving selected option {0}.", lb.optionSelected);
                Console.WriteLine("Director::Director setting Entry Field text to {0}.", lb.optionSelected);
                this.EntryField.SetText(lb.optionSelected);
            }
        }
    }

    /// <summary>
    /// The 'Colleague' abstract class
    /// </summary>

    public abstract class Widget
    {
        protected DialogDirector mediator;

        // Constructor

        public Widget(DialogDirector mediator)
        {
            this.mediator = mediator;
        }
    }

    /// <summary>
    /// A 'ConcreteColleague' class
    /// </summary>

    public class ListBox : Widget
    {
        // Constructor
        public string optionSelected { get; set; }

        public ListBox(DialogDirector mediator)
            : base(mediator)
        {
        }

        public void GetSelection(string op)
        {
            optionSelected = op;
            Console.WriteLine("Listbox:: Listbox changed to {0}. Notifying director.", op);
            this.mediator.WidgetChanged(this);
        }
    }

    /// <summary>
    /// A 'ConcreteColleague' class
    /// </summary>

    public class EntryField : Widget
    {
        public string text { get; set; }
        // Constructor

        public EntryField(DialogDirector mediator)
            : base(mediator)
        {
        }
        public void SetText(string text)
        {
            this.text = text;
            Console.WriteLine("Entry Field::Entry Field text set to {0}.", text);
        }
    }
}
