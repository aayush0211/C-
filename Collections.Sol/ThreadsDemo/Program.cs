namespace ThreadsDemo
{
    internal class Program
    {
        static AutoResetEvent wOdd = new AutoResetEvent(false);
        static AutoResetEvent wEven = new AutoResetEvent(false);

        static void Main(string[] args)
        {
            Thread t1 = new Thread(ShowOdds);
            Thread t2 = new Thread(ShowEvens);
           
            //t1.IsBackground = true;
            //t2.IsBackground = true;

            if (t1.ThreadState == ThreadState.StopRequested) { 
                t1.Start();
                t2.Start();

                for(int i = 0; i< 100; i++) {
                    Console.WriteLine("Main : " + i);
                }
            }


            wEven.Set();
            t1.Start();
            t2.Start();

        //    t1.Join();
        //  t2.Join();

        }

        static void ShowOdds()
        {
            for (int i = 1; i < 100; i=i+2)
            {
                wEven.WaitOne();
                Thread.Sleep(100);
                Console.WriteLine($"From Odd therad: {i}");
                wOdd.Set();
            }
        }

        static void ShowEvens()
        {
            for (int i = 2; i < 100; i = i + 2)
            {
                wOdd.WaitOne();
                Thread.Sleep(1000);
                Console.WriteLine($"From Even therad: {i}");
                wEven.Set();
            }
        }
    }
}