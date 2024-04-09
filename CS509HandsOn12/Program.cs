namespace CS509HandsOn12
{
    // <summary>Entry point for simple console program</summary>
    public class Program
    {
        public static int Multiply(int a, int b)
        {
            return a * b;
        }

        // <summary>Entry point for simple console program</summary>
        // <param name="args">command line arguments</param>
        public static void Main()
        {
            int number1 = 2;
            int number2 = 3;
            int product = Multiply(number1, number2);
            Console.WriteLine(product);
        }
    }
}
