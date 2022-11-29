using Task_1;
using Task_2a;
public class Program
{
    private static void Main(string[] args)
    {
        CountDown countDown = new CountDown(16);
        
        do
        {
            Console.Write(countDown.Current);
        }
        while (countDown.MoveNext()) ;
        
        countDown.Reset();


    }
}