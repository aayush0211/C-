using System.Reflection.Metadata.Ecma335;

namespace AsyncAwait
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
           Task t = Method1();
            Method2();
            
            Console.WriteLine("Enter some msg");
            string m = Console.ReadLine();
            Console.WriteLine($"Msg: {m}");

            Task.Factory.StartNew(() => { });
            Task.Factory.StartNew(() => { });
            Task.Factory.StartNew(() => { });


            Task.WaitAll();

            Console.ReadKey();
        }

        public static async Task Method1()
        {
            await Task.Run(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    Console.WriteLine(" Method 1");
                    // Do something
                    Task.Delay(1000).Wait();
                }
                
            });
        }


        public static void Method2()
        {
            for (int i = 0; i < 25; i++)
            {
                Console.WriteLine(" Method 2");
                // Do something
                Task.Delay(1000).Wait();
            }
        }


    }
}