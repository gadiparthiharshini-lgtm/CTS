/*****************************************************************************************
  File   : 01-Index-Handson.sql
  Skill  : Advanced SQL - Indexes
  Schema : Online Retail Store
  Topic  : Non-clustered, clustered, and composite indexes (+ how to measure impact)

  Three exercises:
    Exercise 1 : Non-clustered index on Products.ProductName
    Exercise 2 : Clustered index on Orders.OrderDate
    Exercise 3 : Composite index on Orders(CustomerID, OrderDate)

  How to MEASURE the difference in SSMS:
    - Turn on the Actual Execution Plan : Query menu -> "Include Actual Execution Plan"
      (or Ctrl+M), then run the query and look for "Index Seek" vs "Table/Index Scan".
    - Turn on timing/IO stats with the statements below, then run before/after queries
      and compare CPU time, elapsed time, and logical reads.

  Self-contained: schema + sample data + index statements. Re-runnable (drops first).
*****************************************************************************************/

SET STATISTICS TIME ON;   -- prints CPU time + elapsed time for each statement
SET STATISTICS IO   ON;   -- prints logical/physical reads (fewer reads = better)
GO

-------------------------------------------------------------------------------
-- 0) Idempotent cleanup
-------------------------------------------------------------------------------
IF OBJECT_ID('dbo.OrderDetails', 'U') IS NOT NULL DROP TABLE dbo.OrderDetails;
IF OBJECT_ID('dbo.Orders',       'U') IS NOT NULL DROP TABLE dbo.Orders;
IF OBJECT_ID('dbo.Products',     'U') IS NOT NULL DROP TABLE dbo.Products;
IF OBJECT_ID('dbo.Customers',    'U') IS NOT NULL DROP TABLE dbo.Customers;
GO

-------------------------------------------------------------------------------
-- 1) Schema : Online Retail Store
--    NOTE for Exercise 2: a PRIMARY KEY is created as a CLUSTERED index by default.
--    A table can have only ONE clustered index, so to make OrderDate the clustered
--    key I must declare the Orders PK as NONCLUSTERED (see comment in Ex.2).
-------------------------------------------------------------------------------
CREATE TABLE dbo.Customers (
    CustomerID INT PRIMARY KEY,
    Name       VARCHAR(100) NOT NULL,
    Region     VARCHAR(50)  NULL
);

CREATE TABLE dbo.Products (
    ProductID   INT PRIMARY KEY,
    ProductName VARCHAR(100)  NOT NULL,
    Category    VARCHAR(50)   NOT NULL,
    Price       DECIMAL(10,2) NOT NULL
);

CREATE TABLE dbo.Orders (
    OrderID    INT NOT NULL,
    CustomerID INT NOT NULL,
    OrderDate  DATE NOT NULL,
    -- PK declared NONCLUSTERED on purpose, so OrderDate can be the clustered index later.
    CONSTRAINT PK_Orders PRIMARY KEY NONCLUSTERED (OrderID),
    CONSTRAINT FK_Orders_Customers FOREIGN KEY (CustomerID)
        REFERENCES dbo.Customers (CustomerID)
);

CREATE TABLE dbo.OrderDetails (
    OrderDetailID INT PRIMARY KEY,
    OrderID       INT NOT NULL,
    ProductID     INT NOT NULL,
    Quantity      INT NOT NULL,
    CONSTRAINT FK_OD_Orders   FOREIGN KEY (OrderID)   REFERENCES dbo.Orders (OrderID),
    CONSTRAINT FK_OD_Products FOREIGN KEY (ProductID) REFERENCES dbo.Products (ProductID)
);
GO

-------------------------------------------------------------------------------
-- 2) Sample data
-------------------------------------------------------------------------------
INSERT INTO dbo.Customers (CustomerID, Name, Region) VALUES
    (1, 'Alice Brown', 'East'),
    (2, 'Bob Carter',  'West'),
    (3, 'Carla Diaz',  'North');

INSERT INTO dbo.Products (ProductID, ProductName, Category, Price) VALUES
    (1, 'Laptop Pro 15',    'Electronics', 1200.00),
    (2, 'Smartphone X',     'Electronics',  900.00),
    (3, 'Wireless Mouse',   'Electronics',   25.00),
    (4, 'Oak Desk',         'Furniture',    600.00),
    (5, 'Office Chair',     'Furniture',    450.00),
    (6, 'Premium Pen',      'Stationery',    50.00);

INSERT INTO dbo.Orders (OrderID, CustomerID, OrderDate) VALUES
    (101, 1, '2024-01-10'),
    (102, 2, '2024-02-15'),
    (103, 1, '2024-03-01'),
    (104, 3, '2024-03-01'),
    (105, 1, '2024-04-20');

INSERT INTO dbo.OrderDetails (OrderDetailID, OrderID, ProductID, Quantity) VALUES
    (1001, 101, 1, 1),
    (1002, 101, 3, 2),
    (1003, 102, 4, 1),
    (1004, 103, 6, 5),
    (1005, 105, 2, 1);
GO

/*=============================================================================
  EXERCISE 1 : Non-clustered index on Products.ProductName
=============================================================================*/

-- BEFORE: without an index on ProductName, this filter forces a full table/clustered
-- scan (SQL Server reads every row). On a big table this is slow.
SELECT ProductID, ProductName, Category, Price
FROM dbo.Products
WHERE ProductName = 'Laptop Pro 15';
GO

-- Create the non-clustered index (a separate B-tree sorted by ProductName that points
-- back to the data rows). "Fill in the blank" = the column being searched.
IF EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_Products_ProductName')
    DROP INDEX IX_Products_ProductName ON dbo.Products;
GO
CREATE NONCLUSTERED INDEX IX_Products_ProductName
    ON dbo.Products (ProductName);
GO

-- AFTER: the same query can now do an INDEX SEEK (jump straight to the matching row)
-- instead of a scan. Compare the execution plan + STATISTICS TIME/IO before vs after.
SELECT ProductID, ProductName, Category, Price
FROM dbo.Products
WHERE ProductName = 'Laptop Pro 15';
GO

/*  Takeaway:
    - SCAN  = read every row (no useful index)  -> O(n)
    - SEEK  = navigate the B-tree to the rows you want (index used) -> O(log n)
    On small sample data the optimizer may still scan (cheaper for tiny tables), but on
    real data volumes the seek wins clearly. STATISTICS IO logical reads should drop.
*/

/*=============================================================================
  EXERCISE 2 : Clustered index on Orders.OrderDate

  KEY CONCEPT: a table can have ONLY ONE clustered index because the clustered index
  IS the physical row order of the table. By default the PRIMARY KEY is clustered, so
  to cluster on OrderDate I had to declare PK_Orders as NONCLUSTERED above. If the PK
  were already clustered I would first need to DROP it (and any FKs referencing it),
  recreate it as NONCLUSTERED, then create the clustered index on OrderDate.
=============================================================================*/

-- BEFORE: range query on OrderDate without a supporting clustered index.
SELECT OrderID, CustomerID, OrderDate
FROM dbo.Orders
WHERE OrderDate BETWEEN '2024-02-01' AND '2024-03-31';
GO

IF EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_Orders_OrderDate')
    DROP INDEX IX_Orders_OrderDate ON dbo.Orders;
GO
-- Physically sorts the table rows by OrderDate -> excellent for date range scans/seeks.
CREATE CLUSTERED INDEX IX_Orders_OrderDate
    ON dbo.Orders (OrderDate);
GO

-- AFTER: the range query benefits because matching dates are stored contiguously.
SELECT OrderID, CustomerID, OrderDate
FROM dbo.Orders
WHERE OrderDate BETWEEN '2024-02-01' AND '2024-03-31';
GO

/*  Discussion:
    - Clustered index = the data IS the index leaf level (one per table).
    - Great for RANGE queries and ORDER BY on the clustered key.
    - Trade-off: inserts in random key order can cause page splits; that's why people
      often cluster on an ever-increasing key (identity / date) instead.
*/

/*=============================================================================
  EXERCISE 3 : Composite (multi-column) index on Orders(CustomerID, OrderDate)
=============================================================================*/

-- Typical query: "all orders for a customer within a date range" - uses BOTH columns.
SELECT OrderID, CustomerID, OrderDate
FROM dbo.Orders
WHERE CustomerID = 1
  AND OrderDate BETWEEN '2024-01-01' AND '2024-12-31';
GO

IF EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_Orders_Customer_OrderDate')
    DROP INDEX IX_Orders_Customer_OrderDate ON dbo.Orders;
GO
-- Column ORDER matters: leading column (CustomerID) is used for the equality filter,
-- then OrderDate narrows the range within that customer.
CREATE NONCLUSTERED INDEX IX_Orders_Customer_OrderDate
    ON dbo.Orders (CustomerID, OrderDate);
GO

-- AFTER: the optimizer can seek on CustomerID then range-scan OrderDate inside it.
SELECT OrderID, CustomerID, OrderDate
FROM dbo.Orders
WHERE CustomerID = 1
  AND OrderDate BETWEEN '2024-01-01' AND '2024-12-31';
GO

/*  Composite index notes:
    - The index helps when the query filters on the LEADING column(s).
    - WHERE CustomerID = 1               -> uses the index (leading col).
    - WHERE OrderDate = '...' (only)     -> usually CANNOT seek (OrderDate is 2nd col).
    - Order your columns by how queries filter (equality columns first, then range).
*/

SET STATISTICS TIME OFF;
SET STATISTICS IO   OFF;
GO
