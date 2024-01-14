namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Batch : ");
            int batch = Convert.ToInt32(Console.ReadLine());
            Console.Write("Students : ");
            int students = Convert.ToInt32(Console.ReadLine());

            int[,,] arr = new int[batch, students, 1];
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.WriteLine($"Marks of Student {j + 1} ");
                    arr[i, j, 0] = Convert.ToInt32(Console.ReadLine());
                }
            }
            Console.WriteLine();
            int count = 0;
            foreach (int i in arr)
            {
                Console.WriteLine($"Marks of Student {++count} : " + i);
            }

        }
    }
}
