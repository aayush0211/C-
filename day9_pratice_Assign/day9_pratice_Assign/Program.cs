using Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.Text;

namespace day9_pratice_Assign
{
    internal class Program
    {
        static void Main1(string[] args)//file handling
        {
            Console.WriteLine(saveInText());//save in unformatted way
            readFromTextFile();//read in unformatted way
            saveInTextInFormat();//text written in formatted way
          
            readFromTextFileInFormat(); //read in formatted way
        }
        static void Main(string[] args)//serialization
        {
            Employee employee = new Employee("shruti", 80000, 5);
            Console.WriteLine(employee);
            writeObjectBinaryFormat(employee);//binaryformat
            Console.WriteLine(readObjectBinaryFormat());//binarformat
            Console.WriteLine("from jsson way ");
            writeObjectJssonFormat(employee);//write jsson object
            Console.WriteLine(readObjectJssonFormat());//read jsson object
        }
        static string saveInText()//in unformated way 
        {  //first convert text data into byte and store into byte array
            Employee e1 = new Employee("Amol",15000,2);//create emp object by const'r
            byte[] name=Encoding.Default.GetBytes(e1.Name);
            byte[] empNo = Encoding.Default.GetBytes(Convert.ToString(e1.EmpNo));
            byte[] deptNo = Encoding.Default.GetBytes(Convert.ToString(e1.DeptNo));
            byte[] basic = Encoding.Default.GetBytes(Convert.ToString(e1.Basic));
            //store data in byte format so we use FileStream, here filestream is autocloseable so open in using block
            using (FileStream str = File.Open(@"C:\Users\dac\Day9_Practice_data", FileMode.OpenOrCreate))
            {  
                str.Write(name, 0, name.Length);//name is array of byte
                str.Write(empNo, 0, empNo.Length);
                str.Write(deptNo, 0, deptNo.Length);
                str.Write(basic, 0, basic.Length);
            }
            return "done !!";
        }
        static void readFromTextFile()//unformated way
        {   
            using (FileStream str = File.Open(@"C:\Users\dac\Day9_Practice_data", FileMode.OpenOrCreate))
            {
                byte[] arr=new byte[str.Length];
                
               str.Read(arr, 0, arr.Length);
                String result=Encoding.Default.GetString(arr);//convert byte -->string
                Console.WriteLine(result);
            }
        }
        static void saveInTextInFormat()//in formatted way + text 
        {
            Employee e2 = new Employee("Amol", 15000, 2);
         
            using (StreamWriter str = File.CreateText(@"C:\Users\dac\Day9_Practice_data"))
            {
              str.WriteLine(e2.Name);
                str.WriteLine(e2.EmpNo);
                str.WriteLine(e2.DeptNo);
                str.WriteLine(e2.Basic);
            }
        }
        static void readFromTextFileInFormat()
        {

            using (StreamReader str = File.OpenText(@"C:\Users\dac\Day9_Practice_data"))
            {
                string str2=str.ReadLine();//name
                string str3 = str.ReadLine();//empno
                string str4 = str.ReadLine();//deptno
                string str5 = str.ReadLine();//salary


                //  Console.WriteLine("in while : ");
                //  Console.WriteLine(str2); }
                Employee e3 = new Employee(str2, Convert.ToInt32(str3), Convert.ToInt16(str4), Convert.ToDecimal(str5));
                Console.WriteLine(e3);

            }
        }
        static void writeObjectBinaryFormat(Employee e)//4 ways to serialize object . one of is binaryformat
        {

            using (Stream s = new FileStream(@"C:\Users\dac\Day9_Practice_data", FileMode.OpenOrCreate))  
            {
                BinaryFormatter bf = new BinaryFormatter();
#pragma warning disable SYSLIB0011 // Type or member is obsolete
                bf.Serialize(s, e);
#pragma warning restore SYSLIB0011 // Type or member is obsolete
            }
        }
        static Employee readObjectBinaryFormat()
        {
            Employee emp = new Employee();
            using (Stream s = new FileStream(@"C:\Users\dac\Day9_Practice_data", FileMode.OpenOrCreate))
            {
                BinaryFormatter bf = new BinaryFormatter();
#pragma warning disable SYSLIB0011 // Type or member is obsolete
                emp=(Employee)bf.Deserialize(s);//if custom deserialize than custom constructor will call
#pragma warning restore SYSLIB0011 // Type or member is obsolete
            }
            return emp;
        }
        static void writeObjectJssonFormat(Employee e)//2nd way of serialization
        {
            using (Stream s = new FileStream(@"C:\Users\dac\Day9_Practice_data1", FileMode.OpenOrCreate))
            {
                DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(Employee));
                js.WriteObject(s, e);
            }
        }
        static Employee readObjectJssonFormat()//2nd way of Deserialization
        {
            Employee e=null;
            using (Stream s = new FileStream(@"C:\Users\dac\Day9_Practice_data1", FileMode.OpenOrCreate))
            {
                DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(Employee));
                 e = (Employee)js.ReadObject(s);//if custom deserialize than custom constructor will call
            }
            return e;
        }
    }
}