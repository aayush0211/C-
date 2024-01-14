using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace InheritanceAndInterfaces
{

    public interface Fruit
    {
        abstract String Taste();
        //abstract keyword is explicitly prepended to the method's name
        String Color();

        //We can not give a default implementation of a method in an interface as it was an problem earlier , if there was change made in an interface
        //so all the implementing classes wont work until they dont implement the method
        //So a solution was discoverd by giving the default implementation of a method so that it was not made compulsory to implement the method
        String Weight()
        {
            return "Default Implementation";
        }
    }

    public class Base
    {
        public virtual void AddToBasket()
        {
            Console.WriteLine("Added to Basket!");
        }
    }

    public class Mango : Base,Fruit
    {
        public string Color()
        {
            return "Mango is Yellow in color";
        }

        public string Taste()
        {
            return "Mango is Sweet in Taste";
        }
        public override void AddToBasket()
        {
            base.AddToBasket();
        }
    }

    public class Orange : Base,Fruit
    {
        public string Color()
        {
            return "Orange is Green in color";
        }

        public string Taste()
        {
            return "Orance is Sour in Taste";
        }
        public override void AddToBasket()
        {
            base.AddToBasket();
        }
    }

    internal class Tester
    {
        static void Main1(string[] args)
        {
            Console.WriteLine("Hello, World!");

            //We can use interface as a refernce type pointing to the object of Implementing Class

            Fruit fruit = new Mango();
            Console.WriteLine(fruit.Color());
            Console.WriteLine(fruit.Taste());
            Console.WriteLine(fruit.Weight());

            fruit = new Orange();
            Console.WriteLine(fruit.Color());
            Console.WriteLine(fruit.Taste());
            Console.WriteLine(fruit.Weight());


            Mango mangoObj = new Mango();
            //This calls the method of Object Type being pointed to the reference
            mangoObj.AddToBasket();

            //The way of Upcasting Mango to BaseFruit
            (mangoObj as Base).AddToBasket();
            //Other traditional way to upcast
            ((Base)mangoObj).AddToBasket();


            Base baseObj = new Base();
            //This cannot be done as we cannot do Downcasting directly without Upcasting
            (baseObj as Mango).AddToBasket();

        }
    }
}

namespace ExplicitInterfaces
{

    public interface Interface1
    {
        void Insert();
        void Delete();
    }

    public interface Interface2
    {
        void Save();
        void Delete();
    }

    public class ImplementingClass : Interface1, Interface2
    {

        public void Insert()
        {
            Console.WriteLine("In Insert by Interface 1");
        }
        public void Delete()
        {
            Console.WriteLine("In Delete by Interface 1");
        }

        public void Save()
        {
            Console.WriteLine("In Save by Interface 2");
        }

        //This is the Explicit Implementation of the Delete method of Interface 2, this is done because Interface1 and Interface2, have same method Delete
        //and cannot be implemented directly so we use InterfaceName.MethodName()
        //This method is private explicitly so hence cannot be accessed by Reference type of this class, rather we will access
        //it by having Reference of Interface 2 pointing to the Object of ImplementingClass

        void Interface2.Delete()
        {
            Console.WriteLine("In Delete by Interface 2");
        }
    }
    class Tester
    {
        public static void Main()
        {
            ImplementingClass implementingClass = new ImplementingClass();
            implementingClass.Insert();
            implementingClass.Delete();
            implementingClass.Save();
            
            //The delete method of Interface method will be only accessed by Reference of Interface2 pointing to the object of ImplementingClass
            Interface2 interface2 = new ImplementingClass();
            interface2.Delete();

        }
    }

}