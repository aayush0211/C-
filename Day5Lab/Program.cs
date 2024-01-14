using System.Runtime.Serialization;

namespace Day5Lab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            using (Employee employee = new Employee())
            {
                try
                {
                    
                    employee.Name = "a1";
                    employee.Basic = 1700;
                    employee.DeptNo = 1;
                    Console.WriteLine(" Employee salary : "+employee.GetEmployeeSalary(2.5M));
                    Func<Employee,string> f1 = emp => emp.Name;
                    Console.WriteLine("emp name : "+f1(employee));
                    employee.Perks = "GM";
                    Console.WriteLine("perks : "+employee.Perks);
                    Action<Employee> a1 = e =>   //lambda expression
                    {
                        Console.WriteLine("Dept No : " + e.DeptNo);
                    };
                    a1(employee);

                }
                catch(Exception ex) {
                    Console.WriteLine(ex.Message);
                }
                finally { Console.WriteLine("in finally "); }
                Console.WriteLine("in last after final");
            }
          
        }

     
    }
    public delegate void Del1(string s);

    public partial class Employee : IDisposable
    {
        public event Del1? invalidDeptNo;
        public static int id=0;
        public int EmpId { get;  }//read only
        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                if (value != default)
                    name = value;
                else
                {
                    throw new InvalidValueException("Invalid Name");
                }
            }
        }
        public Employee()
        {
            EmpId = ++id;
        }

        private decimal basic;

        public decimal Basic
        {
            get { return basic; }
            set
            {
                if (value < 1000)
                    throw new Exception("Invalid Basic pay !!!");
                basic = value;
            }
        }
        private short deptNo;

        public short DeptNo
        {
            get { return deptNo; }
            set
            {
                if (value <= 0 )
                {
                    this.invalidDeptNo += Employee_invalidDeptNo;
                    invalidDeptNo("Invalid dept No!!");
                    return;
                }
                deptNo = value;
            }
        }

        private void Employee_invalidDeptNo(string s)
        {
            Console.WriteLine("in event handler : "+s);
        }

        public void Dispose()
        {
            Console.WriteLine("in Despose method");
        }
    }

    public static class MyExtension
    {
        public static decimal GetEmployeeSalary(this Employee emp, decimal da)
        {
            return emp.Basic * da;
        }
    }

    public  partial class Employee
    {
        private string perks;
        public string Perks
        {
            get { return perks; }
            set { perks = value; }
        }

    }
    
}