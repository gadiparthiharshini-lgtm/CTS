/*****************************************************************************************
  File   : 01-Ranking-and-Window-Functions.sql
  Skill  : Advanced SQL - Ranking / Window Functions
  Schema : Online Retail Store
  Topic  : ROW_NUMBER() vs RANK() vs DENSE_RANK() with PARTITION BY / ORDER BY

  My goal (student notes):
  --------------------------------------------------------------------------------------
  Exercise 1 - "Find the top 3 most expensive products in each category using different
  ranking functions."
    - Use ROW_NUMBER() to assign a UNIQUE rank within each category.
    - Use RANK() and DENSE_RANK() to see how TIES are handled differently.
    - Partition by Category, order by Price DESC.

  This script is self-contained: it creates the schema, inserts sample data (including
  deliberate PRICE TIES inside a category so the ranking differences are visible), then
  runs the solution queries. Safe to re-run (drops objects first).
*****************************************************************************************/

-------------------------------------------------------------------------------
-- 0) Clean up first so the script is idempotent (re-runnable in SSMS)
--    Drop child tables before parent tables (FK order).
-------------------------------------------------------------------------------
IF OBJECT_ID('dbo.OrderDetails', 'U') IS NOT NULL DROP TABLE dbo.OrderDetails;
IF OBJECT_ID('dbo.Orders',       'U') IS NOT NULL DROP TABLE dbo.Orders;
IF OBJECT_ID('dbo.Products',     'U') IS NOT NULL DROP TABLE dbo.Products;
IF OBJECT_ID('dbo.Customers',    'U') IS NOT NULL DROP TABLE dbo.Customers;
GO

-------------------------------------------------------------------------------
-- 1) Schema : Online Retail Store
-------------------------------------------------------------------------------
CREATE TABLE dbo.Customers (
    CustomerID  INT          PRIMARY KEY,
    Name        VARCHAR(100) NOT NULL,
    Region      VARCHAR(50)  NULL
);

CREATE TABLE dbo.Products (
    ProductID    INT           PRIMARY KEY,
    ProductName  VARCHAR(100)  NOT NULL,
    Category     VARCHAR(50)   NOT NULL,
    Price        DECIMAL(10,2) NOT NULL
);

CREATE TABLE dbo.Orders (
    OrderID     INT  PRIMARY KEY,
    CustomerID  INT  NOT NULL,
    OrderDate   DATE NOT NULL,
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
    (1, 'Alice Brown',  'East'),
    (2, 'Bob Carter',   'West'),
    (3, 'Carla Diaz',   'North');

-- Products: a few per Category, with DELIBERATE PRICE TIES so RANK / DENSE_RANK
-- / ROW_NUMBER produce visibly different results.
--   Electronics: 1200, 1200 (tie), 900, 750, 500
--   Furniture  :  600,  600 (tie), 600 (3-way tie!), 350
--   Stationery :   50,   40,  40 (tie), 25
INSERT INTO dbo.Products (ProductID, ProductName, Category, Price) VALUES
    (1,  'Laptop Pro 15',     'Electronics', 1200.00),
    (2,  'Tablet Max',        'Electronics', 1200.00),   -- tie with Laptop Pro 15
    (3,  'Smartphone X',      'Electronics',  900.00),
    (4,  'Wireless Earbuds',  'Electronics',  750.00),
    (5,  'Bluetooth Speaker', 'Electronics',  500.00),

    (6,  'Oak Desk',          'Furniture',    600.00),
    (7,  'Office Chair',      'Furniture',    600.00),   -- 3-way tie at 600 ...
    (8,  'Bookshelf',         'Furniture',    600.00),   -- ... continues
    (9,  'Side Table',        'Furniture',    350.00),

    (10, 'Premium Pen',       'Stationery',    50.00),
    (11, 'Notebook A4',       'Stationery',    40.00),
    (12, 'Sticky Notes Pack', 'Stationery',    40.00),   -- tie at 40
    (13, 'Pencil Box',        'Stationery',    25.00);

INSERT INTO dbo.Orders (OrderID, CustomerID, OrderDate) VALUES
    (101, 1, '2024-01-10'),
    (102, 2, '2024-02-15'),
    (103, 1, '2024-03-01');

INSERT INTO dbo.OrderDetails (OrderDetailID, OrderID, ProductID, Quantity) VALUES
    (1001, 101, 1, 1),
    (1002, 101, 3, 2),
    (1003, 102, 6, 1),
    (1004, 103, 10, 5);
GO

-------------------------------------------------------------------------------
-- 3) Exercise 1 (a):
--    Show ROW_NUMBER, RANK and DENSE_RANK side by side, per category.
--    PARTITION BY Category restarts the numbering for each category.
--    ORDER BY Price DESC ranks the most expensive product first.
-------------------------------------------------------------------------------
SELECT
    p.Category,
    p.ProductName,
    p.Price,
    ROW_NUMBER() OVER (PARTITION BY p.Category ORDER BY p.Price DESC) AS RowNum,
    RANK()       OVER (PARTITION BY p.Category ORDER BY p.Price DESC) AS RankNo,
    DENSE_RANK() OVER (PARTITION BY p.Category ORDER BY p.Price DESC) AS DenseRankNo
FROM dbo.Products AS p
ORDER BY p.Category, p.Price DESC;
GO

/*  How ties differ (this is the key learning) - look at Furniture (3 rows at 600):

    ProductName    Price  RowNum  RankNo  DenseRankNo
    Oak Desk       600    1       1       1
    Office Chair   600    2       1       1      <- RANK & DENSE_RANK repeat for ties
    Bookshelf      600    3       1       1
    Side Table     350    4       4       2

    - ROW_NUMBER : ALWAYS unique (1,2,3,4) - ties broken arbitrarily.
    - RANK       : ties share the same rank, then SKIPS numbers (1,1,1,4) -> there is a gap.
    - DENSE_RANK : ties share the same rank, NO gap (1,1,1,2).
*/

-------------------------------------------------------------------------------
-- 4) Exercise 1 (b):
--    Top 3 most expensive products per category, using a CTE + ROW_NUMBER.
--    ROW_NUMBER guarantees we get exactly 3 rows per category even when prices tie.
-------------------------------------------------------------------------------
WITH RankedProducts AS (
    SELECT
        p.Category,
        p.ProductName,
        p.Price,
        ROW_NUMBER() OVER (PARTITION BY p.Category ORDER BY p.Price DESC) AS rn
    FROM dbo.Products AS p
)
SELECT Category, ProductName, Price, rn AS RankInCategory
FROM RankedProducts
WHERE rn <= 3          -- filter to the top 3 per category
ORDER BY Category, rn;
GO

/*  Expected top-3 result (ties resolved arbitrarily by ROW_NUMBER):

    Category     ProductName        Price   RankInCategory
    Electronics  Laptop Pro 15      1200    1
    Electronics  Tablet Max         1200    2
    Electronics  Smartphone X        900    3
    Furniture    Oak Desk            600    1
    Furniture    Office Chair        600    2
    Furniture    Bookshelf           600    3
    Stationery   Premium Pen          50    1
    Stationery   Notebook A4          40    2
    Stationery   Sticky Notes Pack    40    3

    NOTE: If we wanted to KEEP all tied products in "top 3 by price" we would filter on
    DENSE_RANK() <= 3 instead, which could return more than 3 rows per category.
*/
