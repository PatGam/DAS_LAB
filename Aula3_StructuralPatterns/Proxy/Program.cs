namespace Proxy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //The Proxy design pattern provides a surrogate or placeholder for another object to control access to it.
            Proxy proxy = new Proxy();
            proxy.doSomeWork();
        }
    }

    //Defines the common interface for RealSubject and Proxy so that a Proxy can be used anywhere a RealSubject is expected.
    public abstract class Subject
    {
        public abstract void doSomeWork();
    }

    //defines the real object that the proxy represents.
    public class ConcreteSubject : Subject
    {
        public override void doSomeWork()
        {
            Console.WriteLine("The doSomeWork() method is executed.");
        }
    }

    //maintains a reference that lets the proxy access the real subject. 
    public class Proxy : Subject
    {
        private ConcreteSubject concreteSubject;

        public override void doSomeWork()
        {
            if (concreteSubject == null)
            {
                concreteSubject = new ConcreteSubject();

                Console.WriteLine("The proxy call is happening now.");
            }

            concreteSubject.doSomeWork();
        }

    }

}