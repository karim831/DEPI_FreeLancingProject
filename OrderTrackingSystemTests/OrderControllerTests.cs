using Microsoft.AspNetCore.Mvc;
using OrderTrackingSystemTests.Controllers;
using OrderTrackingSystemTests.Models;
using Xunit;

public class OrderControllerTests
{
    [Fact]
    public void CreateOrder_ValidOrder_ReturnsCreated()
    {
        // Arrange
        var controller = new OrderController();
        var order = new Order
        {
            OrderItems = new List<OrderItem>
            {
                new() { ProductId = 1, ProductName = "Valid", Price = 10, Quantity = 2 }
            }
        };

        // Act
        var result = controller.CreateOrder(order);

        // Assert
        var createdResult = Assert.IsType<CreatedAtActionResult>(result);
        var createdOrder = Assert.IsType<Order>(createdResult.Value);
        Assert.Equal(20, createdOrder.Total);
    }

    [Fact]
    public void CreateOrder_InvalidOrder_NoItems_ReturnsBadRequest()
    {
        // Arrange
        var controller = new OrderController();
        var order = new Order
        {
            OrderItems = new List<OrderItem>() // no items
        };

        // Act
        var result = controller.CreateOrder(order);

        // Assert
        var badRequest = Assert.IsType<BadRequestObjectResult>(result);
        dynamic error = badRequest.Value;
        Assert.Equal("Order must contain items.", (string)error.error);
    }

    [Fact]
    public void CreateOrder_InvalidOrder_NegativePrice_ReturnsBadRequest()
    {
        // Arrange
        var controller = new OrderController();
        var order = new Order
        {
            OrderItems = new List<OrderItem>
            {
                new() { ProductId = 1, ProductName = "Invalid", Price = -10, Quantity = 2 }
            }
        };

        // Act
        var result = controller.CreateOrder(order);

        // Assert
        var badRequest = Assert.IsType<BadRequestObjectResult>(result);
        dynamic error = badRequest.Value;
        Assert.Equal("Invalid item quantity or price.", (string)error.error);
    }

    [Fact]
    public void GetOrder_ExistingOrder_ReturnsOrder()
    {
        // Arrange
        var controller = new OrderController();
        var newOrder = new Order
        {
            OrderItems = new List<OrderItem>
            {
                new() { ProductId = 1, ProductName = "Test", Price = 5, Quantity = 4 }
            }
        };

        var createResult = controller.CreateOrder(newOrder) as CreatedAtActionResult;
        var createdOrder = createResult!.Value as Order;

        // Act
        var result = controller.GetOrderById(createdOrder!.OrderId);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var fetchedOrder = Assert.IsType<Order>(okResult.Value);
        Assert.Equal(createdOrder.OrderId, fetchedOrder.OrderId);
    }

    [Fact]
    public void GetOrder_NonExistentOrder_ReturnsNotFound()
    {
        // Arrange
        var controller = new OrderController();

        // Act
        var result = controller.GetOrderById(999); // Non-existing ID

        // Assert
        var notFound = Assert.IsType<NotFoundObjectResult>(result);
        dynamic error = notFound.Value;
        Assert.Equal("Order not found", (string)error.error);
    }
}
