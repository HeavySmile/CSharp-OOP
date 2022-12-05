using Task_2;
using Task_3;

public class Program
{
    private static void Main(string[] args)
    {
        #region Task_2a test code

        Task_2.a.CountDown countDown1 = new Task_2.a.CountDown();

        do
        {
            Console.Write(countDown1.Current);
        }
        while (countDown1.MoveNext());

        countDown1.Reset();
        Console.WriteLine();

        #endregion

        #region Task_2b test code

        Task_2.b.IEnumerator countDown2 = new Task_2.b.IEnumerator.CountDown();

        do
        {
            Console.Write(countDown2.Current);
        }
        while (countDown2.MoveNext());

        countDown2.Reset();
        Console.WriteLine();

        #endregion

        #region Task_2c test code

        Task_2.c.IEnumerator countDown3 = new Task_2.c.CountDownWithOverride();

        do
        {
            Console.Write(countDown3.Current);
        }
        while (countDown3.MoveNext());

        countDown3.Reset();
        Console.WriteLine();

        #endregion

        #region Task_2d test code

        Task_2.d.IEnumerator countDown4 = new Task_2.d.IEnumerator.CountDown();

        do
        {
            Console.Write(countDown4.Current);
        }
        while (countDown4.MoveNext());

        countDown4.Reset();
        Console.WriteLine();

        #endregion

        #region Task_3 test code

        MultilineRichTextBox textBox = new MultilineRichTextBox();
        textBox.PolyTest();

        #endregion
    }
}
