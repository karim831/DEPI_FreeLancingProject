namespace OrderTrackingSystemTests.Models;

public class Order{
    public int OrderId {get; set;}
    public DateTime TimeStamp {get; set;} = DateTime.UtcNow;
    public string Status {get; set;} = "Pending";
    public int UserId {get; set;}
    public List<OrderItem> OrderItems {get; set;} = new();
    public decimal Total => OrderItems.Sum(o => o.Price * o.Quantity);
}