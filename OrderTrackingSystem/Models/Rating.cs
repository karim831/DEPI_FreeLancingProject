namespace OrderTrackingSystem.Models;

public class Rating
{
    public int RatingId { get; set; }
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public int UserId { get; set; }
    public int Stars { get; set; } 
    public string Comment { get; set; } = string.Empty;
    public DateTime TimeStamp { get; set; } = DateTime.UtcNow;
}
