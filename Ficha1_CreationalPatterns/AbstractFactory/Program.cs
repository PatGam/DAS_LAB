using System;

namespace AbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            //The Abstract Factory design pattern provides an interface for creating families
            //of related or dependent objects without specifying their concrete classes.

            IAnimalFactory wildAnimalFactory = new WildAnimalFactory();
            IAnimal wildDog = wildAnimalFactory.CreateDog();
            IAnimal wildTiger = wildAnimalFactory.CreateTiger();
            wildDog.DisplayBehavior();
            wildTiger.DisplayBehavior();

            IAnimalFactory petAnimalFactory = new PetAnimalFactory();
            IAnimal petDog = petAnimalFactory.CreateDog();
            IAnimal petTiger = petAnimalFactory.CreateTiger();

            petDog.DisplayBehavior();
            petTiger.DisplayBehavior();
        }

        public interface IAnimal
        {
            public void DisplayBehavior();
        }

        public interface IAnimalFactory
        {
            IAnimal CreateTiger();
            IAnimal CreateDog();
        }

        public class PetAnimalFactory : IAnimalFactory
        {
            public PetAnimalFactory()
            {
                Console.WriteLine("You opt for a pet animal factory.");
            }
            public IAnimal CreateDog()
            {
                return new PetDog();
            }

            public IAnimal CreateTiger()
            {
                return new PetTiger();
            }
        }

        class PetDog : IAnimal
        {
            public PetDog()
            {
                Console.WriteLine("A pet dog with black color is created.");
            }
            public void DisplayBehavior()
            {
                Console.WriteLine("The pet dog says: Bow-Wow. I prefer to stay at home.");
            }
        }

        class PetTiger : IAnimal
        {
            public PetTiger()
            {
                Console.WriteLine("A pet tiger with yellow color is created.");
            }
            public void DisplayBehavior()
            {
                Console.WriteLine("The pet tiger says: Halum. I play in an animal circus.\nThe pet tiger says: I saw a pet dog in my town.");
            }
        }

        class WildAnimalFactory : IAnimalFactory
        {
            public WildAnimalFactory()
            {
                Console.WriteLine("You opt for a wild animal factory.");
            }
            public IAnimal CreateDog()
            {
                return new WildDog();
            }

            public IAnimal CreateTiger()
            {
                return new WildTiger();
            }
        }

        class WildDog : IAnimal
        {
            public WildDog()
            {
                Console.WriteLine("A wild dog with white color is created.");
            }
            public void DisplayBehavior()
            {
                Console.WriteLine("The wild dog says: I prefer to roam freely in jungles.Bow - Wow.");
            }
        }

        class WildTiger : IAnimal
        {
            public WildTiger()
            {
                Console.WriteLine("A wild tiger with golden and cinnamon color is created.");
            }
            public void DisplayBehavior()
            {
                Console.WriteLine("The wild tiger says: I prefer hunting in jungles.Roar.\nThe wild tiger says: I saw a wild dog in the jungle.");
            }
        }
    }
}
