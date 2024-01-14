namespace Task2
{
    internal class Employee
    {
        static int empNoGenerator = 0;
        int empNo;
        public int EmpNo { get; }
        string? name;
        public string? Name
        {
            set
            {
                if (value!.Length == 0) throw new ArgumentException("Name should not be Empty");
                else name = value;
            }
            get
            { return name; }
        }
        decimal basic;
        public decimal Basic
        {
            set
            {
                if (value <= 2000 || value >= 50000) throw new ArgumentException("Salary must be between 2000 and 50000");
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

        public Employee(string name, decimal basic = 2000, short deptNo = 1)
        {
            EmpNo = ++empNoGenerator;
            Name = name;
            Basic = basic;
            DeptNo = deptNo;
        }

        public decimal GetNetSalary()
        {
            return Basic + 5000;
        }

    }


    internal class Tester
    {
        static void Main(string[] args)
        {

            Employee[] arr = new Employee[3];
            for (int i = 0; i < arr.Length; i++)
            {
                try
                {
                    Console.WriteLine("Enter Name, Salary, Dept No");
                    Employee emp = new Employee(Console.ReadLine()!, Convert.ToDecimal(Console.ReadLine()), Convert.ToInt16(Console.ReadLine()));
                    arr[i] = emp;
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            Employee? highestSalaryEmployee = null;

            decimal highestSalary = -100000;

            for (int i = 0; i < arr.Length; i++)
            {
                if (highestSalary < arr[i].Basic)
                {
                    highestSalaryEmployee = arr[i];
                    highestSalary = arr[i].Basic;
                }
            }

            Console.Write("\nHighest Salary : ");
            Console.WriteLine((highestSalaryEmployee!.Name));

            Console.WriteLine("Enter Employee No: ");
            int empNoByUser = Convert.ToInt32(Console.ReadLine());
            bool flag = false;

            for (int i = 0; i < arr.Length; i++)
            {
                if (empNoByUser == arr[i].EmpNo)
                {
                    flag = true;
                    Console.WriteLine(arr[i].Name);
                }
            }

            Console.WriteLine(flag == true ? "Found" : "Not Found");

        }
    }

}
