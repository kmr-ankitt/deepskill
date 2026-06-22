using System;

namespace SearchAlgorithmsExample
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }

        public Product(int productId, string productName, string category)
        {
            ProductId = productId;
            ProductName = productName;
            Category = category;
        }

        public override string ToString()
        {
            return $"ID: {ProductId}, Name: {ProductName}, Category: {Category}";
        }
    }

    public class SearchAlgorithms
    {
        public static Product? LinearSearch(Product[] products, int targetId)
        {
            for (int i = 0; i < products.Length; i++)
            {
                if (products[i].ProductId == targetId)
                {
                    return products[i];
                }
            }
            return null;
        }

        public static Product? BinarySearch(Product[] sortedProducts, int targetId)
        {
            int low = 0;
            int high = sortedProducts.Length - 1;

            while (low <= high)
            {
                int mid = low + (high - low) / 2;

                if (sortedProducts[mid].ProductId == targetId)
                {
                    return sortedProducts[mid];
                }
                else if (sortedProducts[mid].ProductId < targetId)
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }
            return null;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Product[] products = new Product[]
            {
                new Product(105, "Wireless Mouse", "Electronics"),
                new Product(102, "Yoga Mat", "Fitness"),
                new Product(108, "Bluetooth Speaker", "Electronics"),
                new Product(101, "Running Shoes", "Footwear"),
                new Product(110, "Office Chair", "Furniture")
            };

            Product[] sortedProducts = new Product[]
            {
                new Product(101, "Running Shoes", "Footwear"),
                new Product(102, "Yoga Mat", "Fitness"),
                new Product(105, "Wireless Mouse", "Electronics"),
                new Product(108, "Bluetooth Speaker", "Electronics"),
                new Product(110, "Office Chair", "Furniture")
            };

            int targetId = 108;

            Console.WriteLine("---- Linear Search ----");
            var linearResult = SearchAlgorithms.LinearSearch(products, targetId);
            Console.WriteLine(linearResult != null
                ? $"Product Found: {linearResult}"
                : "Product not found.");

            Console.WriteLine();

            Console.WriteLine("---- Binary Search ----");
            var binaryResult = SearchAlgorithms.BinarySearch(sortedProducts, targetId);
            Console.WriteLine(binaryResult != null
                ? $"Product Found: {binaryResult}"
                : "Product not found.");

            Console.WriteLine();

            Console.WriteLine("---- Searching for Non-Existent Product (ID: 999) ----");
            var notFoundLinear = SearchAlgorithms.LinearSearch(products, 999);
            Console.WriteLine("Linear Search Result: " + (notFoundLinear != null ? notFoundLinear.ToString() : "Not Found"));

            var notFoundBinary = SearchAlgorithms.BinarySearch(sortedProducts, 999);
            Console.WriteLine("Binary Search Result: " + (notFoundBinary != null ? notFoundBinary.ToString() : "Not Found"));
        }
    }
}
