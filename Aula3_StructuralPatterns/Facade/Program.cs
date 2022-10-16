namespace Facade
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //he Facade design pattern provides a unified interface to a set of interfaces in a subsystem.
            //This pattern defines a higher-level interface that makes the subsystem easier to use.

            Person bob = new Person("Bob", 5000.0, true);
            Person jack = new Person("Jack", 70000.0, false);
            Person tony = new Person("Tony", 125000.0, true);

            Subsystem loanApproval = new Subsystem();

            loanApproval.CheckApplication(bob, 20000.0);
            loanApproval.CheckApplication(jack, 30000.0);
            loanApproval.CheckApplication(tony, 125000.0);

            
        }

        public class Person
        {
            public string name;
            public double assetValue;
            public bool hasPreviousLoan;

            public Person(string name, double assetValue, bool hasPreviousLoan)
            {
                this.name = name;
                this.assetValue = assetValue;
                this.hasPreviousLoan = hasPreviousLoan;
            }
            
        }

        public class Subsystem
        {
            public Asset asset;

            public LoanStatus loanStatus;

            public Subsystem()
            {
                asset = new Asset();
                loanStatus = new LoanStatus();
            }

            public void CheckApplication(Person person, double claimAmount)
            {
                Console.WriteLine("Checking the loan approval status of {0}", person.name);
                Console.WriteLine("[The current asset value: {0}", person.assetValue);
                Console.WriteLine("claim amount: {0}", claimAmount);
                Console.WriteLine("existing loan?: {0}", person.hasPreviousLoan);

                bool hasSufficientAssetValue = asset.hasSufficientAssetValue(person, claimAmount);
                bool hasPreviousLoans = loanStatus.hasPreviousLoans(person);

                if (hasSufficientAssetValue && !hasPreviousLoans)
                {
                    Console.WriteLine("{0}'s application status: Approved", person.name);
                }
                else
                {
                    Console.WriteLine("{0}'s application status: Not approved", person.name);
                }

                Console.WriteLine("Remarks if any:");

                if (!hasSufficientAssetValue)
                {
                    Console.WriteLine("Insufficient balance.");
                }

                if (hasPreviousLoans)
                {
                    Console.WriteLine("An old loan exists.");
                }

                Console.WriteLine("---------");

            }
        }

        public class Asset
        {
            public Asset()
            {
            }

            public bool hasSufficientAssetValue(Person person, double claimAmount)
            {
                Console.WriteLine("Verifying {0}'s asset value.", person.name);
                if (person.assetValue < claimAmount)
                {
                    return false;
                }

                return true;
            }
        }

        public class LoanStatus
        {
            public LoanStatus()
            {

            }

            public bool hasPreviousLoans(Person person)
            {
                Console.WriteLine("Verifying {0}'s previous loan(s) status.", person.name);
                return person.hasPreviousLoan;                    
            }
        }
    }
}