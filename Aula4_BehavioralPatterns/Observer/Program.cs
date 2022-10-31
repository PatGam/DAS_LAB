using System.Security.Cryptography.X509Certificates;

namespace Observer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //The Observer design pattern defines a one-to-many dependency between objects so that when
            //one object changes state, all its dependents are notified and updated automatically.
            SpecificCompany company = new SpecificCompany("Abc Ltd.");
            Customer roy = new Customer("Roy");
            Customer kevin = new Customer("Kevin");
            Customer bose = new Customer("Bose");
            company.Register(roy);
            company.Register(kevin);
            company.Register(bose);
            company.SetStockPrice(5);

            Console.WriteLine("---------");

            company.Unregister(kevin);
            company.SetStockPrice(50);

            Console.WriteLine("---------");
            company.Register(kevin);
            company.SetStockPrice(100);

            Console.WriteLine("---------");
            Console.WriteLine("Working with another company: XYZ Co.");

            SpecificCompany company2 = new SpecificCompany("XYZ Co.");
            Customer jacklin = new Customer("Jacklin");
            company2.Register(roy);
            company2.Register(jacklin);
            company2.SetStockPrice(500);


        }


    }

    public abstract class Company {

        public List<Observer> observerList;
        public List<Observer> oldSubscribers;
        public string name;
        public int stockPrice;

        public Company(string name)
        {
            this.name = name;
            observerList = new List<Observer>();
            oldSubscribers = new List<Observer>();
        }

        public abstract void GetName();
        public abstract int GetStockPrice();
        public abstract void SetStockPrice(int newStockPrice);
        public abstract void Register(Observer observer);
        public abstract void Unregister(Observer observer);
        public abstract void NotifyRegisteredUsers();
    }

    public class SpecificCompany : Company
    {
        public SpecificCompany(string name):base(name)
        {
            Console.WriteLine("Working with the company: {0}", name);
            this.name=name;
        }
        public override void GetName()
        {
            throw new NotImplementedException();
        }

        public override int GetStockPrice()
        {
            return this.stockPrice;
                
        }

        public override void NotifyRegisteredUsers()
        {
            foreach (var user in observerList)
            {
                user.getNotification(this.stockPrice);
            }        
        }

        public override void Register(Observer observer)
        {
            if (oldSubscribers.Contains(observer))
            {
                Console.WriteLine("{0} registers again to get notifications from {1}", observer.name, this.name);
            }
            
            Console.WriteLine("{0} registers {1}", this.name, observer.name);
            
            this.observerList.Add(observer);
        }

        public override void SetStockPrice(int newStockPrice)
        {
            Console.WriteLine("{0} current stock price is ${1}.", this.name, newStockPrice);
            this.stockPrice = newStockPrice;
            this.NotifyRegisteredUsers();
        }

        public override void Unregister(Observer observer)
        {
            Console.WriteLine("{0} is removing {1} from the observer list now.", this.name, observer.name);
            observerList.Remove(observer);
            Console.WriteLine("{0} unregisters {1}", this.name, observer.name);
            oldSubscribers.Add(observer);
        }
    }

    public abstract class Observer
    {
        public string name;
        public Observer(string name)
        {
            this.name = name;
        }
        public void getNotification(int stockChange)
        {
            Console.WriteLine("{0} has received an alert from ABC Ltd. The current stock price is:${1}", this.name, stockChange);
        }

        public string getObserverName()
        {
            return this.name;
        }
    }

    public class Customer : Observer
    {
        public Customer(string name):base(name)
        {
            this.name = name;
        }
    }

}