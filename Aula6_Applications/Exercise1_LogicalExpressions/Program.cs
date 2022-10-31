namespace Exercise1_LogicalExpressions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Composite composite = new Composite();
            composite.Add(new AndExpr(new Variable("a"), new OrExpr(new Variable("b"), new Variable("c"))));
            composite.Display(1);
        }
    }

    public class Expr
    {    
        public string name { get; set; }
        public virtual void Display(int depth)
        {

        }
    }

    public class AndExpr : Composite
    {
        public AndExpr(Expr var1, Expr var2)
        {
            this.Add(var1);
            this.Add(new Leaf { name = "&&" });
            this.Add(var2);
        }
    }

    public class OrExpr : Composite
    {
        public OrExpr(Expr var1, Expr var2)
        {
            this.Add(var1);
            this.Add(new Leaf { name = "||" });
            this.Add(var2);
        }
    }

    public class NotExpr : Composite
    {
        public NotExpr(Expr var1)
        {
            this.Add(new Leaf { name = "!" });
            this.Add(var1);
        }
    }

    public class Variable : Leaf
    {
        public Variable(string name)
        {
            this.name = name;
        }
    }

    public class LogicValue : Leaf
    {
        public LogicValue(string name)
        {
            this.name = name;
        }
    }

    public class Composite : Expr
    {
        List<Expr> children = new List<Expr>();

        public void Add(Expr c)
        {
            children.Add(c);
        }
        public void Remove(Expr c)
        {
            children.Remove(c);
        }
        public override void Display(int depth)
        {
            Console.WriteLine(new String('-', depth) + name);

            // Recursively display child nodes
            foreach (Expr component in children)
            {
                component.Display(depth + 2);
            }
        }
    }
    public class Leaf : Expr
    {
        public override void Display(int depth)
        {
            Console.WriteLine(new String('-', depth) + name);
        }
    }
}