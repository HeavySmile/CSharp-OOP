using System;

namespace Zad_3
{
    public static class Program
    {
        public static int Main(string[] args)
        {
            Invoice inv = new Invoice("Wheel", "1I3214", 12.5m, 2);
            
            Console.WriteLine(inv.PartDescription);
            Console.WriteLine(inv.PartNumber);
            Console.WriteLine(inv.PricePerItem);
            Console.WriteLine(inv.Quantity);
            Console.WriteLine(inv.GetInvoiceAmount());

            inv.PartDescription = "Door";
            inv.PartNumber = "1J2034";
            inv.PricePerItem = 30.5m;
            inv.Quantity = 3;

            Console.WriteLine();
            Console.WriteLine(inv.PartDescription);
            Console.WriteLine(inv.PartNumber);
            Console.WriteLine(inv.PricePerItem);
            Console.WriteLine(inv.Quantity);
            Console.WriteLine(inv.GetInvoiceAmount());

            return 0;
        }
    }
}