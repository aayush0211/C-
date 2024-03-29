﻿namespace Day2_ASSGN1

/*
 * Create a Class Employee with the following specifications

Properties
----------
string Name -> no blank names should be allowed
int EmpNo ->  must be readonly and autogenerated
decimal Basic -> must be between some range
short DeptNo -> must be > 0

Methods
-------
decimal GetNetSalary() -> returns calculated net salary (Use any formula to get net salary based on Basic salary)


Create constructors to accept initial values for Employee obj
Employee o1 = new Employee("Amol",123465, 10);
Employee o2 = new Employee("Amol",123465);
Employee o3 = new Employee("Amol");
Employee o4 = new Employee();

EmpNo must be autogenerated ... i.e.
first object should automatically get EmpNo 1
second object should automatically get EmpNo 2
third object should automatically get EmpNo 3
...and so on...

Test Cases
Employee o1 = new Employee()
Employee o2 = new Employee()
Employee o3 = new Employee()
cw(o1.EmpNo)
cw(o2.EmpNo)
cw(o3.EmpNo)

cw(o3.EmpNo)
cw(o2.EmpNo)
cw(o1.EmpNo)



 *
 */
{
    public class TestEmployee
    {
        static void Main()
        {
            Console.WriteLine("Hello, World!");
            Employee o1 = new Employee("Amol", 123465, 10);
            Employee o2 = new Employee("Amol", 123465);
            Employee o3 = new Employee("Amol");
            Employee o4 = new Employee();
            Console.WriteLine(o1.EmpNo);
            Console.WriteLine(o2.EmpNo);
            Console.WriteLine(o3.EmpNo);
            Console.WriteLine(o4.EmpNo);
            Console.WriteLine(o1.GetNetSalary());
            Console.WriteLine(o2.GetNetSalary());
            Console.WriteLine(o3.GetNetSalary());
            Console.WriteLine(o4.GetNetSalary());
            Console.WriteLine(o1.display());
            Console.WriteLine(o2.display());
            Console.WriteLine(o3.display());
            Console.WriteLine(o4.display());
            /*
             * 2. Create an array of Employee class objects
                    Accept details for all Employees
                    Display the Employee with highest Salary
                    Accept EmpNo to be searched. Display all details for that employee.*/
            Employee[] empl
                = new Employee[3];

            for (int i = 0; i < empl.Length; i++)
            {
                Console.WriteLine($"Enter emp {i+1} details : name, basic pay, dept no");
                empl[i] = new Employee(Console.ReadLine(), Convert.ToDecimal(Console.ReadLine()), Convert.ToInt16(Console.ReadLine()));
            }
            Employee highestSalaryEmp = null;
            decimal highestSalary = empl[0].GetNetSalary();
            for (int i = 0; i < empl.Length; i++)
            {
                if (highestSalary < empl[i].GetNetSalary())
                {
                    highestSalaryEmp = empl[i];
                    highestSalary = empl[i].GetNetSalary();
                }
            }
            Console.WriteLine("highest salary is of: Emp Name = " + highestSalaryEmp!.Name + "Emp id: " + highestSalaryEmp.EmpNo + " Salary: " + highestSalary);
            Console.WriteLine("Enter emp no");
            int empNoByUser = Convert.ToInt32(Console.ReadLine());
            bool flag= false;
            foreach (Employee emp in empl)
            {
                if (emp.EmpNo == empNoByUser)
                {
                    flag = true;
                    Console.WriteLine(emp.Name + " id : " + emp.EmpNo + " salary : " + emp.GetNetSalary()); break;
                }
            }
            Console.WriteLine(flag==true?"Found":"Not Found");
        }

        public class Employee
        {
            private static int id;
            private string name;

            public string Name
            {
                set
                {
                    string name2 = value.Trim();
                    if ((name2.Equals(null)))
                    {
                        Console.WriteLine("Invalid Name");
                    }
                    else
                    {
                        name = name2;
                    }
                }
                get
                {
                    return name;
                }
            }

            private int empNo;
            public int EmpNo
            {
                set { empNo = value; }
                get { return empNo; }
            }
            private decimal basic;

            //property of bASIC 
            public decimal Basic
            {
                set
                {
                    if (value < 5000 && value > 1000)//1000 - 5000
                    {
                        basic = value;
                    }
                    else
                    {
                        Console.WriteLine("invalid basic pay!!!");
                    }
                }
                get { return basic; }
            }

            private short deptNo;
            public short DeptNo
            {
                set
                {
                    if (value > 0)//1000 - 5000
                    {
                        deptNo = value;
                    }
                    else
                    {
                        Console.WriteLine("invalid Dept no!!!");
                    }
                }
                get { return deptNo; }
            }


            static Employee()//parameter less must, no access specifier 
            {
                id = 0;
            }
            public Employee(string name = null, decimal basicpay = 0, short deptNo = 0)
            {
                this.name = name;
                this.basic = basicpay;
                this.deptNo = deptNo;
                EmpNo = ++id;

            }

            public decimal GetNetSalary()
            {
                MathClass1.CalculateSalary s1 = new MathClass1.CalculateSalary();
                return MathClass1.CalculateSalary.CalSalary(basic, 12.50M); //decimal written with suffix M 

            }
            public String display()
            {
                return "Employee details are : " + " " + this.empNo + " " + this.Name + " " + this.basic + " " + this.deptNo;
            }

        }
    }
}
