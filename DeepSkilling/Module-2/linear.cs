using System;

class Product
{
    public int ProductId;
    public string ProductName;
    public string Category;

    public Product(int id, string name, string category)
    {
        ProductId = id;
        ProductName = name;
        Category = category;
    }
}

class Program
{
    static Product LinearSearch(Product[] products, int targetId)
    {
        foreach (Product p in products)
        {
            if (p.ProductId == targetId)
            {
                return p;
            }
        }
        return null;
    }

    static Product BinarySearch(Product[] products, int targetId)
    {
        int left = 0;
        int right = products.Length - 1;

        while (left <= right)
        {
            int mid = (left + right) / 2;

            if (products[mid].ProductId == targetId)
                return products[mid];

            if (products[mid].ProductId < targetId)
                left = mid + 1;
            else
                right = mid - 1;
        }

        return null;
    }

    static void Main()
    {
        Product[] products =
        {
            new Product(101,"Laptop","Electronics"),
            new Product(102,"Phone","Electronics"),
            new Product(103,"Shoes","Fashion"),
            new Product(104,"Watch","Accessories"),
            new Product(105,"Bag","Fashion")
        };

        Product result1 = LinearSearch(products,103);

        Console.WriteLine(
            "Linear Search Result: "
            + result1.ProductName);

        Product result2 = BinarySearch(products,103);

        Console.WriteLine(
            "Binary Search Result: "
            + result2.ProductName);
    }
}