# Order Tracking System API

This API allows users to create and retrieve orders. The system restricts access to orders owned by the currently authenticated (or demo) user.
🛠️ Endpoints
## POST /api/orders

Creates a new order.

    Request Body (JSON):

    {
      "userId": 1,
      "OrderItems": [
        {
          "ProductId": 101,
          "ProductName": "Sample Item",
          "Quantity": 2,
          "Price": 15.5
        }
      ]
    }

    Success Response:
    201 Created
    Returns the created order with calculated total and generated order ID.

## GET /api/orders

Returns all orders associated with the demo user.

    Success Response:
    200 OK

    [
      {
        "orderId": 1,
        "userId": 1,
        "OrderItems": [...],
        "total": 31.0
      }
    ]

## GET /api/orders/{id}

Returns a specific order only if it belongs to the demo user.

    Path Parameter:

        id: Order ID to retrieve.

    Success Response:
    200 OK

{
  "orderId": 1,
  "userId": 1,
  "OrderItems": [...],
  "total": 31.0
}

Error Response:
404 Not Found – If the order does not exist or does not belong to the user.

-----------------------------------------------

# Ratings API

This API allows users to leave ratings and short feedback on the products they've ordered. Ratings are tied to individual products in specific orders, and users can retrieve their feedback history or look up ratings per product/order.

## POST /api/rating

Submit a rating for a product that was part of an order.
Request Body (JSON):

{
  "orderId": 1,
  "productId": 101,
  "productName": "Sample Item",
  "stars": 5,
  "feedback": "Great quality!"
}

Success Response:

200 OK
Returns the created rating with an assigned internal ID.
Error Response:

400 Bad Request – If stars is not between 1 and 5.

## GET /api/rating/user

Retrieve all ratings submitted by the current user.
Success Response:

200 OK

[
  {
    "ratingId": 1,
    "orderId": 1,
    "productId": 101,
    "productName": "Sample Item",
    "stars": 5,
    "feedback": "Great quality!",
    "userId": 1
  }
]

## GET /api/rating/order/{orderId}

Retrieve all ratings given for a specific order.
  Path Parameter:

    orderId: The ID of the order to retrieve ratings for.

  Success Response:

200 OK
Returns an array of ratings linked to that order.

## GET /api/rating/product/{productId}

Retrieve all ratings left for a specific product across all users and orders.
  Path Parameter:

    productId: The ID of the product.

  Success Response:

200 OK
Returns a list of all ratings for the product, useful for analytics or display.
