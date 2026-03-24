CREATE DATABASE ProductDb;

-- Create Products Table
USE ProductDb;

CREATE TABLE Products (
    ProductId INT PRIMARY KEY IDENTITY(1,1),
    ProductName VARCHAR(100),
    Category VARCHAR(50),
    Price DECIMAL(10,2)
);

--Create Stored Procedures
--Insert

CREATE PROCEDURE sp_InsertProduct
    @ProductName VARCHAR(100),
    @Category VARCHAR(50),
    @Price DECIMAL(10,2)
AS
BEGIN
    INSERT INTO Products(ProductName, Category, Price)
    VALUES (@ProductName, @Category, @Price);
END;

--Get All
CREATE PROCEDURE sp_GetAllProducts
AS
BEGIN
    SELECT * FROM Products;
END;

  -- Get product by id
  CREATE PROCEDURE sp_GetProductById
    @ProductId INT
AS
BEGIN
    SELECT * 
    FROM Products
    WHERE ProductId = @ProductId;
END;


--Update product info

CREATE PROCEDURE sp_UpdateProduct
    @ProductId INT,
    @ProductName VARCHAR(100),
    @Category VARCHAR(50),
    @Price DECIMAL(10,2)
AS
BEGIN
    UPDATE Products
    SET ProductName = @ProductName,
        Category = @Category,
        Price = @Price
    WHERE ProductId = @ProductId;
END;

--Delete product
CREATE PROCEDURE sp_DeleteProduct
    @ProductId INT
AS
BEGIN
    DELETE FROM Products WHERE ProductId = @ProductId;
END;
