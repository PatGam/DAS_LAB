namespace ChainOfCommand
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //The Chain of Responsibility design pattern avoids coupling the sender of a request to its receiver
            //by giving more than one object a chance to handle the request.
            //This pattern chains the receiving objects and passes the request along the chain until an object handles it.
            Application app = new Application();
            Dialog printDialog = new Dialog("PrintDialog", false);
            Dialog drawDialog = new Dialog("DrawDialog", true);
            app.AddWidget(printDialog);
            app.AddWidget(drawDialog);
            Button button1 = new Button("Button1", false);
            Button button2 = new Button("Button2", true);
            Button button3 = new Button("Button3", false);
            drawDialog.AddWidget(button1);
            drawDialog.AddWidget(button2);
            printDialog.AddWidget(button3);
            button1.HandleHelp();
            button2.HandleHelp();
            button3.HandleHelp();
        }
    }

    public abstract class HelpHandler
    {
        protected HelpHandler successor;

        public void SetSuccessor(HelpHandler successor)
        {
            this.successor = successor;
        }

        public abstract void HandleHelp();

    }

    public class Application : HelpHandler
    {
        public Application()
        {
            Console.WriteLine("Creating new Application providing default help.");
            this._widgets = new List<Widget>();
        }

        public List<Widget> _widgets { get; set; }

        public void AddWidget(Widget widget)
        {
            _widgets.Add(widget);
            widget.SetSuccessor(this);
        }

        public override void HandleHelp()
        {
            Console.WriteLine("Application:: Help request received, will handle");
            this.ShowHelp();
        }

        public void ShowHelp()
        {
            Console.WriteLine("Application:: Showing help for application");
        }
    }

    public class Widget : HelpHandler
    {
        public Widget(string name, bool canHandle)
        {
            this.canHandle = canHandle;
            this.name = name;
            this._widgets = new List<Widget>();

            Console.Write("Creating new {0}. ", this.name);
            if (this.canHandle)
                Console.WriteLine("It handles help");
            else
                Console.WriteLine("It does not handle help");
        }

        public bool canHandle { get; set; }
        public string name { get; set; }
        public List<Widget> _widgets {get;set;}

        public void AddWidget(Widget widget)
        {
            Console.WriteLine("Adding {0} to {1}", widget.name, this.name);
            _widgets.Add(widget);
            widget.SetSuccessor(this);
        }

        public override void HandleHelp()
        {
            if (this.canHandle)
            {
                Console.WriteLine("{0}:: Help request received, will handle.", this.name);
                ShowHelp();
            }
            else
            {
                Console.WriteLine("{0}:: request for help, pass it along the chain.", this.name);
                if (successor != null)
                {
                    successor.HandleHelp();
                }
            }
        }

        public void ShowHelp()
        {
            Console.WriteLine("{0}:: Showing help for {0}", this.name);
        }
    }

    public class Dialog : Widget
    {
        public Dialog(string name, bool canHandle) : base(name, canHandle)
        {
        }
    }

    public class Button : Widget
    {
        public Button(string name, bool canHandle) : base(name, canHandle)
        {
        }

    }
}