using OrderTrackingSystem.Models;

namespace OrderTrackingSystem.Services;

public static class RatingService
{
    private static readonly List<Rating> _ratings = new();
    private static int _nextId = 1;

    public static Rating AddRating(Rating rating)
    {
        rating.RatingId = _nextId++;
        _ratings.Add(rating);
        return rating;
    }

    public static List<Rating> GetRatingsByUser(int userId) =>
        _ratings.Where(r => r.UserId == userId).ToList();

    public static List<Rating> GetRatingsByProduct(int productId) =>
        _ratings.Where(r => r.ProductId == productId).ToList();

    public static List<Rating> GetRatingsByOrder(int orderId) =>
        _ratings.Where(r => r.OrderId == orderId).ToList();
}
