using Microsoft.AspNetCore.Mvc;
using OrderTrackingSystem.Models;
using OrderTrackingSystem.Services;

namespace OrderTrackingSystem.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RatingController : ControllerBase
{
    private readonly User mockUser = new() { UserId = 1, Username = "Kareem Osama" };

    [HttpPost]
    public IActionResult SubmitRating([FromBody] Rating rating)
    {
        if (rating.Stars < 1 || rating.Stars > 5)
            return BadRequest(new { error = "Stars must be between 1 and 5." });

        rating.UserId = mockUser.UserId;
        var created = RatingService.AddRating(rating);
        return Ok(created);
    }

    [HttpGet("user")]
    public IActionResult GetUserRatings()
    {
        var ratings = RatingService.GetRatingsByUser(mockUser.UserId);
        return Ok(ratings);
    }

    [HttpGet("order/{orderId}")]
    public IActionResult GetRatingsByOrder(int orderId)
    {
        var ratings = RatingService.GetRatingsByOrder(orderId);
        return Ok(ratings);
    }

    [HttpGet("product/{productId}")]
    public IActionResult GetRatingsByProduct(int productId)
    {
        var ratings = RatingService.GetRatingsByProduct(productId);
        return Ok(ratings);
    }
}
