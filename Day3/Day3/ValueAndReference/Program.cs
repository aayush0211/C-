namespace ValueAndReference
{


    internal class Tester
    {

        /*
         *  Here we can observe that even if we swap the variables in this swap method
         *  It wont swap the original values as the Variables are sent as Value type in the method 
         *  Hence it is the copy of data of original vars
         *  To make it work, LOOK AT THE BELOW MEHTOD
         */

        public static void SwapWithoutRef(int num1, int num2)
        {
            num1 = num2+num1;
            num2 = num1 - num2;
            num1 = num1 - num2;

            Console.WriteLine("\nIn SwapWithoutRef Function");
            Console.WriteLine(num1+" "+num2);

        }

        /*
         * To Pass a Value type Data to a method using Reference Type
         * We just need to write a REF keyword before the Declaration of 
         * Variable in method argument and even at the caller we need to
         * write REF.
         */

        public static void SwapWithRef(ref int num1,ref int num2)
        {
            num1 = num2 + num1;
            num2 = num1 - num2;
            num1 = num1 - num2;

            Console.WriteLine("\nIn SwapWithoutRef Function");
            Console.WriteLine(num1 + " " + num2);
        }

        /*
         *      If we want to initialize any values in method without even initializing in the caller method
         *      We just use OUT keyword to intialize it
         *      But we need to make sure that the values are initialized in the method or else it will show
         *      compilation Error
         */

        public static void Init(out int connection)
        {
            //So this value will be retained even if the method returns and if we dont initialize the out variable
            //it will throw compilation error.
            connection = 8080;
            Console.WriteLine("\nGetting the connection in Init Method...");
        }


        /*
         *  If we wish to pass a parameter to a function and dont want it to be changed in the function
         *  We just use the IN keyword to send it to the method 
         */

        private static void checkPassword(in string password)
        {
            //password = "Jayesh";    //This will throw error
            Console.WriteLine("\nPassword Checked Successfully...");
        }


        static void Main(string[] args)
        {
            int num1 = 10;   
            int num2 = 20;

            SwapWithoutRef(num1, num2);

            Console.WriteLine("In Main");
            Console.WriteLine(num1 + " " + num2);

            int num3 = 10;
            int num4 = 20;

            SwapWithRef(ref num3,ref num4);

            Console.WriteLine("In Main");
            Console.WriteLine(num3 + " " + num4);

            //int connection;       //This shows compiler error as we have not initialized the variable, but what if we dont to initialize here
                                    //and want to initialize in the method ? USE OUT KEYWORD
            int connection;

            Init(out connection);
            Console.WriteLine("Establishing Connection....");
            Console.WriteLine("Connection established at Port : "+connection);


            string password = new string("password");
            Console.WriteLine("Checking Password....");
            checkPassword(in password);


        }

       
    }
}