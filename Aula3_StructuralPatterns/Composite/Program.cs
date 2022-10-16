using System;
using System.Collections.Generic;

namespace Composite
{
    /// <summary>
    /// Composite Design Pattern
    /// </summary>

    public class Program
    {
        public static void Main(string[] args)
        {
            //The Composite design pattern composes objects into tree structures to represent part-whole hierarchies.
            //This pattern lets clients treat individual objects and compositions of objects uniformly.

            // Create a tree structure

            Composite picture1 = new Composite("picture 1", "Picture");
            Composite picture2 = new Composite("picture 2", "Picture");
            Leaf text1 = new Leaf("text 1", "text");
            picture2.Add(text1);

            Leaf line1 = new Leaf("line 1", "line");
            picture2.Add(line1);
            picture1.Add(picture2);

            Leaf line2 = new Leaf("line 2", "line");
            picture1.Add(line2);

            Leaf rectangle = new Leaf("rectangle 1", "rectangle");
            picture1.Add(rectangle);

            Console.WriteLine("--------");
            picture1.Draw();

            // Wait for user

            Console.ReadKey();
        }
    }

    /// <summary>
    /// The 'Component' abstract class
    /// </summary>

    public abstract class Graphic
    {
        public string name;
        public string type;

        // Constructor

        public Graphic(string name, string type)
        {
            this.name = name;
            this.type = type;
        }

        public abstract void Add(Graphic c);
        public abstract void Remove(Graphic c);
        public abstract void Draw();
    }

    /// <summary>
    /// The 'Composite' class
    /// </summary>

    public class Composite : Graphic
    {
        List<Graphic> children = new List<Graphic>();

        // Constructor

        public Composite(string name, string type)
            : base(name, type)
        {
            Console.WriteLine("Creating a {0} ({1})", type, name);
        }

        public override void Add(Graphic component)
        {
            Console.WriteLine("Adding {0} to {1}", component.name, this.name);
            children.Add(component);
        }

        public override void Remove(Graphic component)
        {
            children.Remove(component);
        }

        public override void Draw()
        {
            Console.WriteLine("Started drawing composite {0}", name);

            // Recursively display child nodes

            foreach (Graphic component in children)
            {
                component.Draw();
            }

            Console.WriteLine("Finished drawing composite {0}", name);
        }
    }

    /// <summary>
    /// The 'Leaf' class
    /// </summary>

    public class Leaf : Graphic
    {
        // Constructor

        public Leaf(string name, string type)
            : base(name, type)
        {
        }

        public override void Add(Graphic c)
        {
            Console.WriteLine("Cannot add to a leaf");
        }

        public override void Remove(Graphic c)
        {
            Console.WriteLine("Cannot remove from a leaf");
        }

        public override void Draw()
        {
            Console.WriteLine("Drawing {0}", name);
        }
    }
}
