using System;

namespace Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            //The Factory Method design pattern defines an interface for creating an object,
            //but let subclasses decide which class to instantiate. This pattern lets a class defer instantiation to subclasses.
            IAnimalFactory dogFactory = new DogFactory();
            IAnimalFactory tigerFactory = new TigerFactory();

            IAnimal a = dogFactory.CreateAnimal();
            a.DisplayBehavior();
            IAnimal b = tigerFactory.CreateAnimal();
            b.DisplayBehavior();
        }

        public interface IAnimalFactory
        {
            public IAnimal CreateAnimal();
        }

        public interface IAnimal
        {
            public void DisplayBehavior();
        }

        public class DogFactory : IAnimalFactory
        {
            public IAnimal CreateAnimal()
            {
                return new Dog();
            }
        }

        class TigerFactory : IAnimalFactory
        {
            public IAnimal CreateAnimal()
            {
                return new Tiger();
            }
        }

        class Dog : IAnimal
        {
            public Dog()
            {
                Console.WriteLine("A dog is created.");
            }
            public void DisplayBehavior()
            {
                Console.WriteLine("It says: Bow - Wow.\nIt prefers barking.");
            }
        }

        class Tiger : IAnimal
        {
            public Tiger()
            {
                Console.WriteLine("A tiger is created.");
            }
            public void DisplayBehavior()
            {
                Console.WriteLine("It says: Roar!\nIt loves to roam in a jungle.");
            }
        }


    }
}
