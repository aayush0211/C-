namespace MathClass1
{
    public class CalculateSalary
    {
        public static decimal CalSalary(decimal amount, decimal da)
        {
            amount = amount + amount * da;
            return amount;
        }

    }
}