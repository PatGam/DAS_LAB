using System.Windows.Markup;

namespace VirtualProxy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //protection proxies check that the caller has the access permissions required to perform a request.
            ProtectionProxy protectionProxy = new ProtectionProxy();
            protectionProxy.Authenticate("ANN");
            protectionProxy.Authenticate("JOHN");


            //virtual proxies may cache additional information about the real subject so that they can postpone accessing it.
            Adder adder = new Adder();
            VirtualProxy proxy1 = new VirtualProxy(adder);
            proxy1.ArraySum();
            proxy1.ArraySum();

        }
    }

    public interface IAdder
    {
        public int ArraySum();
    }

    public class Adder : IAdder
    {
        public int[] arrayToSum = {1,2,3,4};
        public int ArraySum()
        {
            int sum = 0;

            for (int i = 0; i < arrayToSum.Length; i++)
            {
                sum += arrayToSum[i];
            }

            Console.WriteLine("Adder: Computing sum. {0}+{1}+{2}+{3} = {4}", arrayToSum[0], arrayToSum[1], arrayToSum[2], arrayToSum[3], sum);

            return sum;
        }
    }

    //O proxy só é responsável por gerir a cache, não faz os cálculos
    public class VirtualProxy : IAdder
    {
        private Adder adder;
        bool calculated = false;
        int value;

        public VirtualProxy(Adder adder)
        {
            this.adder = adder;

        }
        public int ArraySum()
        {   if (!calculated)
            {
                Console.WriteLine("CachingProxy: No cached result exists, calling original method");
                value = adder.ArraySum();
                calculated = true;
            }
            else
            {
                Console.WriteLine("CachingProxy: A cached result exists, returning stored result");
            }

            Console.WriteLine("The sum is {0}", value);
            return value;
        }
    }

    public class ProtectionProxy
    {
        public void Authenticate(string userId)
        {
            if (userId != "JOHN")
            {
                Console.WriteLine("ProtectionProxy: User {0} is not authorized", userId);
                Console.WriteLine("Unauthorized Operation Exception thrown");
            }
            else
            {
                Console.WriteLine("ProtectionProxy: User {0} is authorized", userId);
                Adder adder = new Adder();
                VirtualProxy proxy1 = new VirtualProxy(adder);
                proxy1.ArraySum();
                proxy1.ArraySum();
            }
        }
    }
}