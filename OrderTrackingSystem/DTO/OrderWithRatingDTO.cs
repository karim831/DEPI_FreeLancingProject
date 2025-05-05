namespace OrderTrackingSystem.DTOs;

using OrderTrackingSystem.Models;

public class OrderWithRatingsDTO
{
    public int OrderId { get; set; }
    public DateTime TimeStamp { get; set; }
    public string Status { get; set; } = "Pending";
    public decimal Total { get; set; }
    public List<OrderItem> OrderItems { get; set; } = new();
    public List<Rating> Ratings { get; set; } = new();
}
