namespace MathClass
{
    public class Calculation
    {
       public static decimal CalSalary(decimal amount, decimal da) {
        amount =  amount + amount * da;
            return amount;
        }
    }
}