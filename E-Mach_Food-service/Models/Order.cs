namespace E_Mach_Food_service.Models
{
    public class Order
    {
        public int Id { get; set; }// Auto-generated
        public string TableNumber { get; set; } = string.Empty;
        public decimal TotalPrice { get; set; }
        public List<OrderItem> Items { get; set; } = new(); 
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
