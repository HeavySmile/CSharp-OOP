
namespace Task_2
{
    public class Program
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int ComputateFactorial(int value)
        {
            int result = 1; 
            for (int i = value; i > 1; i--) result *= i;
           
            return result;
        }
        public static double CosX(double value, int power)
        {
            return (Math.Pow(value, power) / ComputateFactorial(power)) - 
                   (Math.Pow(value, power + 2) / ComputateFactorial(power + 2));
        }
        private static void Main(string[] args)
        {
            double x;
            Console.Write("Insert x value for computation of cos(x) : ");
            x = Double.Parse(Console.ReadLine());
            x = (x * Math.PI) / 180;

            double epsilon;
            Console.Write("Insert epsilon for computation accuracy : ");
            epsilon = Double.Parse(Console.ReadLine());

            double result = 0;
            int power = 0;
            do
            {
                result += CosX(x, power);
                power += 2;
            }
            while (epsilon <= Math.Abs(Math.Cos(x) - result));

            Console.WriteLine($"\nMath.Cos(x) = {Math.Cos(x):N3}\tHandmade cos(x) = {result:N3}");
            Console.WriteLine($"\nAccurate value = {result}");
            Console.WriteLine($"Approximate value = {result:N3}");
            Console.WriteLine($"Accuracy value = {epsilon:N3}");
        }
    }
}