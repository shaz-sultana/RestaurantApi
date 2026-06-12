# Restaurant Menu & Order Management API

This project is a beginner-friendly backend project based on the Presto Backend Engineer JD.

## Concepts Covered

- REST API
- Backend services
- Menu data synchronization
- Order processing
- Webhook simulation
- Kafka/RabbitMQ event simulation
- Redis caching concept
- Swagger API testing
- Git-ready project structure

## How to Run

```bash
dotnet restore
dotnet run
```

Open Swagger in browser:

```text
http://localhost:YOUR_PORT/swagger
```

## APIs

### Menu APIs

- GET `/api/menu` - Get all menu items
- POST `/api/menu` - Add menu item
- PUT `/api/menu/{id}` - Update menu item
- DELETE `/api/menu/{id}` - Delete menu item

### Order APIs

- GET `/api/orders` - Get all orders
- POST `/api/orders` - Create order

Sample order request:

```json
{
  "itemId": 1,
  "quantity": 2
}
```

## How to Explain in Interview

I built a Restaurant Menu and Order Management API using ASP.NET Core Web API. It supports menu CRUD operations and order creation through REST APIs. When an order is created, the system simulates an event that could be sent to Kafka or RabbitMQ and also simulates a webhook notification to a kitchen or POS system. This project helped me understand backend APIs, data synchronization, webhooks, reliability, and scalable backend design.

## Future Improvements

- Add PostgreSQL or SQL Server database
- Add Redis caching for menu data
- Add Kafka or RabbitMQ for real event-driven communication
- Add authentication
- Deploy to AWS/Azure
