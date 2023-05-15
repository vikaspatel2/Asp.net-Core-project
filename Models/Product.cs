using System.ComponentModel.DataAnnotations;

public class Product
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Product name is required")]
    [MaxLength(100, ErrorMessage = "Product name cannot exceed 100 characters")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Price is required")]
    [Range(0, 1000, ErrorMessage = "Price must be between 0 and 1000")]
    public decimal Price { get; set; }
}
