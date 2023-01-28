namespace Singleton
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //The Singleton design pattern ensures a class has only one instance and provide a global point of access to it.

            // Constructor is protected -- cannot use new

            Console.WriteLine("Trying to make a captain for your team.");
            Captain captain1 = Captain.GetCaptain();

            Console.WriteLine("Trying to make another captain for your team:");
            Captain captain2 = Captain.GetCaptain();
            
            Console.WriteLine("Send him for the toss.");
            // Test for same instance
            if (captain1 == captain2)
            {
                Console.WriteLine("Both captain1 and captain2 are the same.");
            }
            // Wait for user
            Console.ReadKey();
        }

        /// <summary>
        /// The 'Singleton' class
        /// </summary>
        public class Captain
        {
            static Captain captain;

            // Constructor is 'protected'
            protected Captain()
            {
            }
            public static Captain GetCaptain()
            {
                // Uses lazy initialization.
                if (captain == null)
                {
                    Console.WriteLine("A new captain is elected for your team.");
                    captain = new Captain();
                }
                else
                {
                    Console.WriteLine("You already have a captain for your team.");
                }

                return captain;
            }

        }
    }
}