namespace Task1
{
    internal class Employee
    {
        static int empNoGenerator = 0;
        int empNo;
        public int EmpNo { get; }
        string name;
        public string Name
        {
            set
            {
                if (value.Length == 0) throw new ArgumentException("Name should not be Empty");
                else name = value;
            }
            get
            { return name; }
        }
        decimal basic;
        public decimal Basic
        {
            set {
                if (value <= 2000 && value >= 50000) throw new ArgumentException("Salary must be between 2000 and 50000");
                else basic = value; 
            }
            get { return basic; }
        }
        short deptNo;
        public short DeptNo
        {
            set
            {
                if (value < 0) throw new ArgumentException("Dept No must be above 0");
                else deptNo = value;
            }
            get { return deptNo; }
        }

        public Employee(string name,decimal basic=2000,short deptNo=1)
        {
            EmpNo = ++empNoGenerator;
            Name = name;
            Basic = basic;
            DeptNo = deptNo;
        }

        public decimal GetNetSalary()
        {
            return Basic+5000;
        }

    }

    internal class Tester
    {
        static void Main(string[] args)
        {
            try
            {
                //Console.WriteLine("Hello, World!");
                Employee o1 = new Employee("Jayesh", 123465, 10);
                Employee o2 = new Employee("Amol", 123465);
                Employee o3 = new Employee("Amol");
                //Employee o4 = new Employee();

                Console.WriteLine(o1.Name + " " + o1.EmpNo);
                Console.WriteLine(o2.Name + " " + o2.EmpNo);
                Console.WriteLine(o3.Name + " " + o3.EmpNo);
                //Console.WriteLine(o4.Name+" "+o4.
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }


}
