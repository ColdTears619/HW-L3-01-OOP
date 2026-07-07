namespace HW_L3;

// Discount behavior interface
interface IDiscountable
{
    decimal ApplyDiscount(decimal percent);
}

// Base product class
class Product
{
    // Common product properties
    public string Name { get; set; }
    public decimal Price { get; set; }

    // Create product object
    public Product(string name, decimal price)
    {
        Name = name;
        Price = price;
    }

    // Show product details
    public virtual string GetProductDetails()
    {
        return $"Name: {Name}, Price: {Price:C}";
    }
}

// Electronic product class
class Electronic : Product, IDiscountable
{
    // Electronic specific property
    public int WarrantyPeriod { get; set; }

    // Create electronic object
    public Electronic(string name, decimal price, int warrantyPeriod)
        : base(name, price)
    {
        WarrantyPeriod = warrantyPeriod;
    }

    // Apply discount to price
    public decimal ApplyDiscount(decimal percent)
    {
        Price -= Price * percent / 100;
        return Price;
    }

    // Show electronic details
    public override string GetProductDetails()
    {
        return base.GetProductDetails() +
               $", Warranty: {WarrantyPeriod} months";
    }
}

// Clothing product class
class Clothing : Product
{
    // Clothing specific properties
    public string Size { get; set; }
    public string Material { get; set; }

    // Create clothing object
    public Clothing(string name, decimal price, string size, string material)
        : base(name, price)
    {
        Size = size;
        Material = material;
    }

    // Show clothing details
    public override string GetProductDetails()
    {
        return base.GetProductDetails() +
               $", Size: {Size}, Material: {Material}";
    }
}

class Question3
{
    public static void Q3()
    {
        // Store different products
        List<Product> products = new List<Product>();

        // Add electronic product
        products.Add(new Electronic("Laptop", 1200, 24));

        // Add clothing product
        products.Add(new Clothing("T-Shirt", 50, "L", "Cotton"));

        // Apply discount if possible
        foreach (Product product in products)
        {
            if (product is IDiscountable discountable)
            {
                discountable.ApplyDiscount(10);
            }

            // Display product details
            WriteLine(product.GetProductDetails());
        }
    }
}