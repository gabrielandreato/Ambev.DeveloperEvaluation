[Back to README](../README.md)
# Sale Management API Documentation

## Introduction

The `SaleController` provides a set of endpoints for managing sales and sale items within the system. This includes operations to create, update, retrieve, and delete sales and their associated items.

## Endpoints

### POST /sale

- **Description**: Creates a new sale.
- **Request Body**:
  ```json
  {
    "SaleNumber": "string",
    "SaleDate": "2022-03-15T00:00:00",
    "Customer": "Customer",
    "Branch": "Branch",
    "Items": [
      {
        "Product": "Product",
        "Quantity": 1,
        "UnitPrice": 100.0
      }
    ]
  }
  ```
- **Response**:
  - **201 Created**: Returns the details of the created sale.
  - **400 Bad Request**: Returns validation errors if request is invalid.

### PUT /sale/{id}

- **Description**: Update an existing sale.
- **Path Parameters**:
  - `id`: The unique identifier of the sale.
- **Request Body**:
  ```json
  {
    "SaleNumber": "string",
    "SaleDate": "2022-03-15T00:00:00",
    "Customer": "Customer",
    "Branch": "Branch",
    "IsCancelled": false
  }
  ```
- **Response**:
  - **200 OK**: Returns the updated sale details.
  - **400 Bad Request**: Validation errors.

### GET /sale/{id}

- **Description**: Retrieve a sale by its ID.
- **Path Parameters**:
  - `id`: The unique identifier of the sale.
- **Response**:
  - **200 OK**: Returns the sale details.
  - **400 Bad Request**: If the sale cannot be retrieved.

### GET /sale

- **Description**: Retrieve a list of sales with optional filters. Includes pagination and sorting.
- **Query Parameters**:
  - `SaleNumber`: Optional sale number to filter results.
  - `IsCanceled`: Optional flag to filter by canceled status.
  - `Branch`: Optional branch to filter results by.
  - `Customer`: Optional customer to filter results by.
  - `SaleDateFrom`: Optional starting date to filter sales from.
  - `SaleDateTo`: Optional end date to filter sales until.
  - `Page`: The page number for pagination (default is 0, which returns all results).
  - `PageSize`: The number of items per page (default is 0, which returns all results).
  - `SortBy`: Optional field name to sort results by. If null, no sorting is applied.
  - `IsDesc`: Indicates whether sorting should be descending (true) or ascending (false). Default is false.
- **Response**:
  - **200 OK**: Returns a paginated list of sales.
  - **400 Bad Request**: If the filters are invalid.

### DELETE /sale/{id}

- **Description**: Delete a sale by its ID.
- **Path Parameters**:
  - `id`: The unique identifier of the sale.
- **Response**:
  - **204 No Content**: If the sale is successfully deleted.
  - **400 Bad Request**: If the sale cannot be deleted.

### POST /sale/{saleId}/item

- **Description**: Add an item to an existing sale.
- **Path Parameters**:
  - `saleId`: The ID of the sale.
- **Request Body**:
  ```json
  {
    "Product": "Product",
    "Quantity": 1,
    "UnitPrice": 100.0
  }
  ```
- **Response**:
  - **201 Created**: Returns the details of the added item.
  - **400 Bad Request**: Validation errors.

### DELETE /sale/item/{id}

- **Description**: Delete a specific sale item.
- **Path Parameters**:
  - `id`: The unique identifier of the sale item.
- **Response**:
  - **204 No Content**: If the item is successfully deleted.
  - **400 Bad Request**: If the item cannot be deleted.

### PUT /sale/item/{id}

- **Description**: Update a specific sale item.
- **Path Parameters**:
  - `id`: The unique identifier of the sale item.
- **Request Body**:
  ```json
  {
    "Product": "Product",
    "Quantity": 1,
    "UnitPrice": 100.0,
    "IsCancelled": false
  }
  ```
- **Response**:
  - **200 OK**: Returns the updated sale item details.
  - **400 Bad Request**: Validation errors.

---

This documentation provides detailed information on how to use the `SaleController` endpoints, including expected request and response formats.