using System.Net.WebSockets;
using System.Runtime.InteropServices;

namespace Collections
{
    internal class Program
    {
        static void Main(string[] args)
        {

            try
            {

                //String[] strings = { "abc", "xyz", "123" };
                //Console.WriteLine(String.Join(',',strings));


                List<Department> departmentList = new List<Department>();
                departmentList.Add(new Department {DeptId =1, DepartmentName="Comp" });
                departmentList.Add(new Department { DeptId = 2, DepartmentName = "Med" });
                departmentList.Add(new Department { DeptId = 3, DepartmentName = "Sci" });


                List<Employee> list = new List<Employee>();

                list.Add(Employee.createNewEmployee());
                list.Add(Employee.createNewEmployee());
                list.Add(Employee.createNewEmployee());


                Console.WriteLine("Enter DeptID to get its employees: ");
                int depid =  int.Parse(Console.ReadLine());




                foreach (var emp in list.Where(i=>i.DeptId == depid))
                {
                    Console.WriteLine(emp.ToString());
                 }

                Console.WriteLine();

                var emps = list.Join(departmentList, emp => emp.DeptId, dept => dept.DeptId, (emp, dept) => new { emp.Name, dept.DepartmentName });

                foreach(var item in emps)
                {
                    Console.WriteLine(item.DepartmentName);
                    Console.WriteLine(item.Name);
                }

                Console.WriteLine();

                foreach(var emp in list.Where(emp => emp.BasicPay > 10000))
                {
                    Console.WriteLine($"Employee Name: {emp.Name}");
                }
                Console.WriteLine();

                foreach (var emp in list.OrderByDescending(emp => emp.BasicPay))
                {
                    Console.WriteLine($"Employee Name: {emp.Name}");
                }
                Console.WriteLine();

                var emps2 = list.AsParallel().WithDegreeOfParallelism(2).Select(emp => emp.Name);
                foreach (var emp in emps2)
                {
                    Console.WriteLine($"Employee Name: {emp}"); 
                    Console.WriteLine();
                }



            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
        
        public class Department
    {
        public int DeptId
        {
            get; set;
        }
        public string? DepartmentName { get; set; }

        public Department(int deptId=0, string? departmentName=null)
        {
            DeptId = deptId;
            DepartmentName = departmentName;
        }


    }

        public class Employee 
        {
            private static int id = 0;
            public int DeptId
        {
            get; set;
        }
            public int EmpId
            {get; private set;
            }
            private string? name;
            public string? Name
            {
                get { return name; }
                set
                {
                    if (value!.Length == 0)
                    {
                        throw new Exception("Name should not be empty!!!");
                    }
                    else
                    {
                        name = value;
                    }
                }
            }

            private decimal basicPay;
            public decimal BasicPay
            {
                get { return basicPay; }
                set
                {
                    if (value < 1000)
                    {
                        throw new Exception("Basic Pay is entered less!!");
                    }
                    else
                    {
                        basicPay = value;
                    }
                }

            }
        
        public String[] Skills
        {
            get; set;
        }
            public Employee(String name =null!, decimal basicPay = 1000 , String Skills = null!)
            {
                EmpId = ++id;
                this.name = name;
                this.basicPay = basicPay;
            }

        public static Employee createNewEmployee()
        {
            Employee employee = new Employee();
            Console.WriteLine("Enter Name");
            employee.Name = Console.ReadLine()!;
            Console.WriteLine("Enter Basic Pay");
            employee.BasicPay = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Enter Skils");
            employee.Skills = Console.ReadLine()!.Split(',');

            Console.WriteLine("Enter DeptID");
            employee.DeptId = int.Parse(Console.ReadLine());

            return employee;
        }
        //public String SkillEmp(String[] skils)
        //{
        //    String s;
        //    s = " ";
        //    foreach(String skil in skils)
        //    {
        //        s=s + skil+",";
              
        //    }
        //    return s;
        //}
       
       
        public override String ToString()
            {
            //return "Employee[ empId = " + EmpId + " EmpName = " + Name + " Basic Pay = " + basicPay +" Skills = "+             Skills.Select+"]";

            return $"Employee[ EmpId : {EmpId},   EmpName= {Name} Basic Pay: {basicPay} Skills: {String.Join(',',Skills)}";  // use String.join for comma seperated arrays
            }
        }
    }
