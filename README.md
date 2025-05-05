# Order Tracking System API

This API allows users to create and retrieve orders. The system restricts access to orders owned by the currently authenticated (or demo) user.
🛠️ Endpoints
POST /api/orders

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

# GET /api/orders

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

# GET /api/orders/{id}

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