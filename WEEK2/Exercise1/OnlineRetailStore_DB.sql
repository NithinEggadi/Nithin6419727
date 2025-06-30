USE OnlineRetailDB;
GO
DROP TABLE IF EXISTS Product;
DROP TABLE IF EXISTS Category;

CREATE TABLE Category (
    CategoryID INT PRIMARY KEY,
    CategoryName VARCHAR(100)
);


CREATE TABLE Product (
    ProductID INT PRIMARY KEY,
    ProductName VARCHAR(100),
    Price DECIMAL(10, 2),
    CategoryID INT FOREIGN KEY REFERENCES Category(CategoryID)
);

INSERT INTO Category VALUES
(1, 'Electronics'),
(2, 'Clothing'),
(3, 'Books');


INSERT INTO Product VALUES
(101, 'Laptop', 1000.00, 1),
(102, 'Smartphone', 800.00, 1),
(103, 'Tablet', 800.00, 1),
(104, 'T-Shirt', 25.00, 2),
(105, 'Jeans', 40.00, 2),
(106, 'Jacket', 40.00, 2),
(107, 'Fiction Book', 15.00, 3),
(108, 'Non-Fiction Book', 25.00, 3),
(109, 'Comics', 15.00, 3);


SELECT * FROM Category;
SELECT * FROM Product;