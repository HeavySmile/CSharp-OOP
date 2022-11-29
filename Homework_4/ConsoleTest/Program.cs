using ConsoleTest;
using System.Net.Sockets;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace ConsoleTest
{
    public static class Program
    {
        private static List<Product> products = new List<Product>()
        {
            new Product("Electric sander", Type.M, new List<int>() { 99, 82, 81, 79 }, 157.98m),
            new Product("Power saw",       Type.M, new List<int>() { 99, 86, 90, 94 }, 99.99m),
            new Product("Sledge hammer",   Type.F, new List<int>() { 93, 92, 80, 87 }, 21.50m),
            new Product("Hammer",          Type.M, new List<int>() { 97, 89, 85, 82 }, 11.99m),
            new Product("Lawn mower",      Type.F, new List<int>() { 35, 72, 91, 70 }, 139.50m),
            new Product("Screwdriver",     Type.F, new List<int>() { 88, 94, 65, 91 }, 56.99m),
            new Product("Jig saw",         Type.M, new List<int>() { 75, 84, 91, 39 }, 11.00m),
            new Product("Wrench",          Type.F, new List<int>() { 97, 92, 81, 60 }, 17.50m),
            new Product("Sledge hammer",   Type.M, new List<int>() { 75, 84, 91, 39 }, 21.50m),
            new Product("Hammer",          Type.F, new List<int>() { 94, 92, 91, 91 }, 11.99m),
            new Product("Lawn mower",      Type.M, new List<int>() { 96, 85, 91, 60 }, 179.50m),
            new Product("Screwdriver",     Type.M, new List<int>() { 96, 85, 51, 30 }, 66.99m)
        };
        public static void GroupByCategoryCountDescending()
        {
            var groups =
                from product in products
                orderby product.Category descending
                group product by product.Category into productGroup
                select productGroup;

            foreach (var element in groups)
            {
                Console.WriteLine($"Category group: {element.Key}");
                Console.WriteLine($"\t\tNumber of products of Type {element.Key} in this group: {element.Count()}\n");
            }
        }
        public static void GroupByQtrAndProductPriceAvg()
        {
            var groups =
                from product in products
                orderby product.Quarter
                group product by product.Quarter into productGroup
                select productGroup;

            foreach (var element in groups)
            {
                Console.WriteLine($"Quarter group: {element.Key}");
                Console.WriteLine($"\tAverage price per Quarter: {element.Average(element => element.Price):C}\n");
            }
        }
        public static void GroupByQtrCategoryWeeklySum()
        {
            var _products =
                from product in products
                orderby product.Quarter
                group product by product.Quarter into groups
                from categoryGroup in
                (
                    from product in groups
                    group product by product.Category
                )
                group categoryGroup by groups.Key;

            int maxLength = products.Max(product => product.Description.Length);
            foreach (var innerGroup in _products)
            {
                Console.WriteLine($"Quarter group: {innerGroup.Key}");
                foreach (var outterGroup in innerGroup)
                {
                    Console.WriteLine($"\tCategory group: {outterGroup.Key}");
                    foreach (var product in outterGroup)
                    {
                        Console.WriteLine("\t\t(" + product.Description.PadRight(maxLength) + ", " + product.WeeklyPurchases.Sum(x => (int)x) + ")");
                    }
                }
                Console.WriteLine();
            }
        }
        public static void GroupByQtrCategoryAndProducts()
        {
            var _products =
                from product in products
                orderby product.Quarter
                group product by product.Quarter into groups
                from categoryGroup in
                (
                    from product in groups
                    group product by product.Category
                )
                group categoryGroup by groups.Key;

            foreach (var innerGroup in _products)
            {
                Console.WriteLine($"Quarter group: {innerGroup.Key}");
                foreach (var outterGroup in innerGroup)
                {
                    Console.WriteLine($"\tCategory group: {outterGroup.Key}");
                    foreach (var product in outterGroup)
                    {
                        Console.WriteLine("\t\t" + product);
                    }
                }
                Console.WriteLine();
            }
        }
        public static void GroupByQtrMinMaxPrice()
        {

            var _products =
                from product in products
                orderby product.Quarter
                group product by product.Quarter into groups
                select groups;

            foreach (var innerGroup in _products)
            {
                Console.WriteLine($"Quarter group: {innerGroup.Key}");
                Console.WriteLine($"\t\tMin price per Quarter: {innerGroup.Min(el => el.Price):C}");
                Console.WriteLine($"\t\tMax price per Quarter: {innerGroup.Max(el => el.Price):C}");
                Console.WriteLine();
            }
        }
        private static void Main(string[] args)
        {
            GroupByCategoryCountDescending();
            GroupByQtrAndProductPriceAvg();
            GroupByQtrCategoryWeeklySum();
            GroupByQtrCategoryAndProducts();
            GroupByQtrMinMaxPrice();
        }
    }
}