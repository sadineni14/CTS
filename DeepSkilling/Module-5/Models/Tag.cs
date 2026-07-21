// Demonstrates a many-to-many relationship: Products <-> Tags
public class Tag
{
    public int TagId { get; set; }
    public string Name { get; set; } = string.Empty;
    public List<Product> Products { get; set; } = new();
}

// Add this to Product.cs (or extend it) to complete the many-to-many side:
//   public List<Tag> Tags { get; set; } = new();
