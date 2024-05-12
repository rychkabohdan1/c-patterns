using System;

// Product
public class Product
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }

    public void DisplayInfo()
    {
        Console.WriteLine($"Product: {Name}, Price: {Price}, Description: {Description}");
    }
}

// Factory Method
public abstract class ProductFactory
{
    public abstract Product CreateProduct();
}

public class MilkFactory : ProductFactory
{
    public override Product CreateProduct()
    {
        return new Product { Name = "Milk", Price = 2.5m, Description = "Fresh cow milk" };
    }
}

public class BreadFactory : ProductFactory
{
    public override Product CreateProduct()
    {
        return new Product { Name = "Bread", Price = 1.0m, Description = "Whole wheat bread" };
    }
}

// Abstract Factory
public abstract class ProductCategoryFactory
{
    public abstract Product CreateProduct();
}

public class FoodProductFactory : ProductCategoryFactory
{
    public override Product CreateProduct()
    {
        return new Product { Name = "Apple", Price = 0.5m, Description = "Fresh red apple" };
    }
}

public class HouseholdProductFactory : ProductCategoryFactory
{
    public override Product CreateProduct()
    {
        return new Product { Name = "Soap", Price = 1.2m, Description = "Gentle skin soap" };
    }
}

// Builder
public class ProductBuilder
{
    private Product _product = new Product();

    public ProductBuilder SetName(string name)
    {
        _product.Name = name;
        return this;
    }

    public ProductBuilder SetPrice(decimal price)
    {
        _product.Price = price;
        return this;
    }

    public ProductBuilder SetDescription(string description)
    {
        _product.Description = description;
        return this;
    }

    public Product Build()
    {
        return _product;
    }
}

// Prototype
public abstract class ProductPrototype
{
    public abstract Product Clone();
}

public class CloneableProduct : ProductPrototype
{
    private Product _product;

    public CloneableProduct(Product product)
    {
        _product = product;
    }

    public override Product Clone()
    {
        return new Product
        {
            Name = _product.Name,
            Price = _product.Price,
            Description = _product.Description
        };
    }
}

// Singleton
public class InventoryManager
{
    private static InventoryManager _instance;
    private InventoryManager() { }

    public static InventoryManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new InventoryManager();
            }
            return _instance;
        }
    }

    public void AddProductToInventory(Product product)
    {
        // Add product to inventory logic
        Console.WriteLine($"Product {product.Name} added to inventory.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Factory Method
        ProductFactory milkFactory = new MilkFactory();
        Product milk = milkFactory.CreateProduct();
        milk.DisplayInfo();

        ProductFactory breadFactory = new BreadFactory();
        Product bread = breadFactory.CreateProduct();
        bread.DisplayInfo();

        // Abstract Factory
        ProductCategoryFactory foodFactory = new FoodProductFactory();
        Product apple = foodFactory.CreateProduct();
        apple.DisplayInfo();

        ProductCategoryFactory householdFactory = new HouseholdProductFactory();
        Product soap = householdFactory.CreateProduct();
        soap.DisplayInfo();

        // Builder
        ProductBuilder builder = new ProductBuilder();
        Product customProduct = builder.SetName("Custom Product").SetPrice(3.5m).SetDescription("Custom description").Build();
        customProduct.DisplayInfo();

        // Prototype
        ProductPrototype cloneableProduct = new CloneableProduct(apple);
        Product clonedProduct = cloneableProduct.Clone();
        clonedProduct.DisplayInfo();

        // Singleton
        InventoryManager inventoryManager = InventoryManager.Instance;
        inventoryManager.AddProductToInventory(milk);
    }
}
