namespace Aula7_8_WebServices.Resources
{
    public class Department
    {
        public Department(int id, string name, int size)
        {
            this.id = id;
            this.name = name;
            this.size = size;
            this.employees = new List<Person>();
        }

        public int id { get; set; }
        public string name { get; set; }
        public int size { get; set; }

        public Person manager { get; set; }
        public List<Person> employees { get; set; }

        public void SetManager(int id, string name, string address)
        {
            this.manager = new Person(id, name, address);
        }

        public void AddEmployee(int id, string name, string address)
        {
            this.employees.Add(new Person(id, name, address));
        }

    }
}
