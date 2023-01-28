namespace TemplateMethod
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //The Template Method design pattern defines the skeleton of an algorithm in an operation,
            //deferring some steps to subclasses. This pattern lets subclasses redefine certain steps
            //of an algorithm without changing the algorithm‘s structure.
            SpreadsheetApplication app = new SpreadsheetApplication();
            app.OpenDocument();
        }
    }

    public abstract class Application
    {
        List<MyDocument> _docs;
        public Application()
        {
            _docs = new List<MyDocument>();
        }
        //Template
        public void OpenDocument()
        {
            if (!CanOpenDocument())
            {
                Console.WriteLine("Chapéu");
                return;
            }

            MyDocument doc = DoCreateDocument();
            if (doc != null)
            {
                this.AddDocument(doc);
                Console.WriteLine("Application: Notifying about to open document");
                AboutToOpenDocument();
                doc.Open();
                doc.DoRead();
            }
        }

        public virtual void AddDocument(MyDocument doc)
        {
            _docs.Add(doc);
            Console.WriteLine("Application: Adding new document to document list");
        }

        public abstract MyDocument DoCreateDocument();

        public virtual void AboutToOpenDocument()
        {

        }

        public abstract bool CanOpenDocument();
    }

    public class SpreadsheetApplication : Application
    {
        public SpreadsheetApplication():base()
        {
            Console.WriteLine("Creating new spreadsheet application.");
        }
        public override void AboutToOpenDocument()
        {
            Console.WriteLine("SpreadsheetApplication: Doc about to be opened, how exciting!");
        }

        //public override void AddDocument()
        //{
        //    throw new NotImplementedException();
        //}

        public override bool CanOpenDocument()
        {
            Console.WriteLine("SpreadsheetApplication: Attempting to open file “file 1”.");
            Console.WriteLine("SpreadsheetApplication: Can open “file 1”.");

            return true;
        }

        public override MyDocument DoCreateDocument()
        {
            Console.WriteLine("SpreadsheetApplication: Creating spreadsheet document object");
            return new MyDocument();   
        }

    }

    public abstract class Document
    {
        public abstract void Save();
        public abstract void Open();
        public abstract void Close();
        public abstract void DoRead();
    }

    public class MyDocument : Document
    {
        public override void Close()
        {
            throw new NotImplementedException();
        }

        public override void DoRead()
        {
            Console.WriteLine("SpreadsheetDocument: Reading contents of “file1” spreadsheet file");
        }

        public override void Open()
        {
            Console.WriteLine("SpreadsheetDocument: Opening “file1” spreadsheet file");        
        }

        public override void Save()
        {
            throw new NotImplementedException();
        }
    }
}