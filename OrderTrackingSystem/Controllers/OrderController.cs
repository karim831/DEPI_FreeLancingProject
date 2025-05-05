using Microsoft.AspNetCore.Mvc;
using OrderTrackingSystem.Models;
using OrderTrackingSystem.Services;

namespace OrderTrackingSystem.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase{
    private readonly User mockUser = new User(){UserId = 1, Username = "Kareem Osama"};

    [HttpPost]
    public IActionResult CreateOrder([FromBody] Order order){
        if(order.OrderItems == null || !order.OrderItems.Any())
            return BadRequest(new { error = "Order must contain items." });
        if(order.OrderItems.Any(i => i.Quantity <= 0 || i.Price < 0))
            return BadRequest(new { error = "Invalid item quantity or price." });
        
        order.UserId = mockUser.UserId;
        var orderCreated = OrderService.CreateOrder(order);

        return CreatedAtAction(nameof(OrderService.GetOrderById), new {id = orderCreated.OrderId}, orderCreated);
    }

    [HttpGet]
    public IActionResult GetOrders(){
        var orders = OrderService.GetOrderByUser(mockUser.UserId);
        return Ok(orders);
    }

    [HttpGet("{id}")]
    public IActionResult GetOrderById(int id){
        var orders = OrderService.GetOrderById(id,mockUser.UserId);
        if(orders  == null)
            return NotFound(new {error = "Order not found"});
        
        return Ok(orders); 
    }
}