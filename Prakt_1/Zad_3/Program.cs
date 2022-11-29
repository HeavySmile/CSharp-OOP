using Microsoft.VisualBasic;
using System;
using System.Net.Security;

namespace Zad_3
{
    public class Program
    {
        static public int Encrypt(int number)
        {
            int[] digitList = new int[4];
            digitList[0] = number / 1000;
            digitList[1] = (number % 1000) / 100;
            digitList[2] = (number % 100) / 10;
            digitList[3] = number % 10;

            for (int i = 0; i < 4; i++)
            {
                digitList[i] = (digitList[i] + 7) % 10;
            }

            (digitList[0], digitList[2]) = (digitList[2], digitList[0]);
            (digitList[1], digitList[3]) = (digitList[3], digitList[1]);

            return digitList[0] * 1000 + digitList[1] * 100 + digitList[2] * 10 + digitList[3];
        }

        static public int Decrypt(int number)
        {
            int[] digitList = new int[4];
            
            digitList[0] = number / 1000;
            digitList[1] = (number % 1000) / 100;
            digitList[2] = (number % 100) / 10;
            digitList[3] = number % 10;

            (digitList[0], digitList[2]) = (digitList[2], digitList[0]);
            (digitList[1], digitList[3]) = (digitList[3], digitList[1]);

            for (int i = 0; i < 4; i++)
            {
                if (digitList[i] >= 7 && digitList[i] <= 9) digitList[i] = digitList[i] - 7;
                else digitList[i] = digitList[i] + 3;
            }
            
            return digitList[0] * 1000 + digitList[1] * 100 + digitList[2] * 10 + digitList[3];
        }

        static public int Main(string[] args)
        {
            int input; 
            Int32.TryParse(Console.ReadLine(), out input);

            Console.WriteLine(Encrypt(input));
            Console.WriteLine(Decrypt(Encrypt(input)));
            return 0;
        }
    }
}




