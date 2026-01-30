using E_Mach_Food_service.Models;
using System.Text.Json.Serialization;

public class OrderItem
{
    public int Id { get; set; }
    public int MenuItemId { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public string? Description { get; set; }

    public int OrderId { get; set; }

    [JsonIgnore]   // ✅ prevents validation errors
    public Order? Order { get; set; }
}
