using OrderTrackingSystemTests.Models;
using OrderTrackingSystemTests.Services;
using Xunit;

namespace OrderTrackingSystemTests;

public class OrderServiceTests
{
    [Fact]
    public void CreateOrder_ShouldSucceed()
    {
        var order = new Order
        {
            UserId = 10,
            OrderItems = new List<OrderItem>
            {
                new() { ProductId = 1, ProductName = "Test Product", Quantity = 2, Price = 10 }
            }
        };

        var created = OrderService.CreateOrder(order);

        Assert.NotNull(created);
        Assert.True(created.OrderId > 0);
        Assert.Equal(20, created.Total);
    }

    [Fact]
    public void GetOrderById_ShouldReturnCorrectOrder()
    {
        var user = new User(){UserId = 2, Username = "Test User"};
        var order = new Order
        {
            UserId = user.UserId,
            OrderItems = new List<OrderItem> { new() { ProductId = 2, ProductName = "Item", Quantity = 1, Price = 5 } }
        };

        var created = OrderService.CreateOrder(order);
        var fetched = OrderService.GetOrderById(created.OrderId, user.UserId);

        Assert.Equal(created.OrderId, fetched?.OrderId);
    }

    [Fact]
    public void GetOrderById_InvalidUser_ReturnsNull()
    {
        var order = new Order
        {
            UserId = 3,
            OrderItems = new List<OrderItem> { new() { ProductId = 1, ProductName = "X", Quantity = 1, Price = 1 } }
        };

        var created = OrderService.CreateOrder(order);
        var result = OrderService.GetOrderById(created.OrderId, 10);

        Assert.Null(result);
    }
}
