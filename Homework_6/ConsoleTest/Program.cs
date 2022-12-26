using Task_1;

public class Program
{
    public class Book
    {
        public string title = "";

        public Book(string title)
        {
            this.title = title;
        }
    }
    private static void Main(string[] args)
    {
        Store store1 = new Store("123");
        store1.ListOfProducts = new List<Product>() { new Product("abcd"), new Product("efg") };
        
    }
}