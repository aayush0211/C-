using System.ComponentModel.DataAnnotations;

namespace ActionPreDele
{
    internal class Program
    {
        static void Main(string[] args)
        {
            class1 o = new class1();
            Action obj = o.Display;
            obj();
            Action<String> obj2 = o.Display; //action -> must return void
            obj2("Aayush");

            Func<int,int,int> obj3 = o.Add;//any return and any parameter
            Console.WriteLine(obj3(10,5));

            Predicate<int> obj4 = o.isEven; //must be bool return type
            Console.WriteLine(obj4(5));
    
            
            Console.WriteLine(o.ToAdd(o.Add, 10,5));

            decimal i = 100.1m;
            i=i.Multiply(10);
            Console.WriteLine(i);

            var o1 = new {a=1,b="vinay",c=true};
            Console.WriteLine(o1.a+" "+o1.b+" "+o1.c);
        }
    }
    public delegate int Del1(int a,int  b);
    public class class1
    {
        public int ToAdd(Del1 d1,int a, int b)//Del d1 = o.Add;
        {
            return d1(a,b);
        }
        
        public void Display()
        {
            Console.WriteLine("in Display");
        }

        public void Display(String s) {
        
        Console.WriteLine("in Display "+s);
        }

        public int Add(int a, int b)
        {
            return a + b;
        }

        public bool isEven(int a)
        {
            return a % 2 == 0;
        }

    }
    public static class MyExtension
    {
        public static decimal Multiply(this decimal i, int j)
        {
            return i*j;
        }
    }
}