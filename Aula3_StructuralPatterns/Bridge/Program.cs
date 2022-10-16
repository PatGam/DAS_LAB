namespace Bridge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //The Bridge design pattern decouples an abstraction from its implementation so that the two can vary independently.

            Console.WriteLine("Creating a new IconWindow (icon window 1)");
            IconWindow iconWindow = new IconWindow();
            Console.WriteLine("Setting implementation to XWindowImpl (xwindowimpl)in icon window 1");
            iconWindow.windowImp = new XWindowImp();
            iconWindow.DrawBorder();

            Console.WriteLine();
            
            Console.WriteLine("Setting implementation to PMWindowImpl (pmwindowimpl)in icon window 1");
            iconWindow.windowImp = new PMWindowImp();
            iconWindow.DrawBorder();
        }

        /// <summary>
        /// The 'Abstraction' class
        /// </summary>
        public class Window
        {
            public WindowImp windowImp { get; set; }
            public void DrawText()
            {
                windowImp.DevDrawText();
            }
            public void DrawRect()
            {
                windowImp.DevDrawLine();
            }
        }

        /// <summary>
        /// The 'RefinedAbstraction' class
        /// </summary>
        public class IconWindow : Window
        {
            public void DrawBorder()
            {
                Console.WriteLine("Drawing border in icon window 1");

                Console.WriteLine("Drawing rect in icon window 1");
                base.DrawRect();

                Console.WriteLine("Drawing text in icon window 1");
                base.DrawText();

            }
        }

        /// <summary>
        /// The 'Implementor' abstract class
        /// </summary>
        public abstract class WindowImp
        {
            public abstract void DevDrawText();
            public abstract void DevDrawLine();
        }

        /// <summary>
        /// The 'ConcreteImplementorB' class
        /// </summary>
        public class XWindowImp : WindowImp
        {
            public override void DevDrawLine()
            {
                Console.WriteLine("devDrawLine in xwindowimpl");
                Console.WriteLine("devDrawLine in xwindowimpl");
                Console.WriteLine("devDrawLine in xwindowimpl");
                Console.WriteLine("devDrawLine in xwindowimpl");
            }

            public override void DevDrawText()
            {
                Console.WriteLine("devDrawText in xwindowimpl");            
            }
        }

        /// <summary>
        /// The 'ConcreteImplementorA' class
        /// </summary>

        public class PMWindowImp : WindowImp
        {
            public override void DevDrawLine()
            {
                Console.WriteLine("devDrawLine in pmwindowimpl");            
                Console.WriteLine("devDrawLine in pmwindowimpl");            
                Console.WriteLine("devDrawLine in pmwindowimpl");            
                Console.WriteLine("devDrawLine in pmwindowimpl");            
            }

            public override void DevDrawText()
            {
                Console.WriteLine("devDrawText in pmwindowimpl");
            }
        }
    }
}