using OrderTrackingSystem.Models;

namespace OrderTrackingSystem.Services;

public static class OrderService{
    private static readonly List<Order> _orders = new();
    private static int _nextId = 1;

    public static Order CreateOrder(Order order){
        order.OrderId = _nextId++;
        _orders.Add(order);
        return order;
    }

    public static List<Order> GetOrderByUser(int userId) => 
        _orders.Where(o => o.UserId == userId).ToList();

    public static Order? GetOrderById(int id, int userId) =>
        _orders.FirstOrDefault(o => o.OrderId == id && o.UserId == userId);
}