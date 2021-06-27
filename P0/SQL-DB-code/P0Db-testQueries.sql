INSERT INTO Orders(OrderTime, CustomerId, LocationId)
VALUES (GETDATE(), 1, 1);

INSERT INTO Products(ProductName, Price, Description, Category)
VALUES
	('Chicken', 6.96, 'Fresh Chicken Breasts', 'Meat'),
	('Beef', 7, 'Natural Ground Beef', 'Meat');


INSERT INTO Inventory(ProductId, LocationId, NumberProducts)
VALUES
	((SELECT ProductId FROM Products WHERE ProductId = 1), (SELECT LocationId FROM Locations WHERE LocationId = 1), 6),
	((SELECT ProductId FROM Products WHERE ProductId = 1), (SELECT LocationId FROM Locations WHERE LocationId = 3), 4),
	((SELECT ProductId FROM Products WHERE ProductId = 2), (SELECT LocationId FROM Locations WHERE LocationId = 1), 5);

--INSERT INTO Locations(LocationName, LocationAddress, LocationPhoneNumber)
--VALUES
--	('NorthMart', '001 North Sunshine', '(111)-111-1111'),
--	('EastMart', '002 East Sunshine', '(222)-222-2222'),
--	('SouthMart', '003 South Sunshine', '(333)-333-3333'),
--	('WestMart', '004 West Sunshine', '(444)-444-4444');

INSERT INTO OrderedProducts(OrderId, ProductId, NumberOrdered)
VALUES
	((SELECT OrderId FROM Orders WHERE OrderId = 3), (SELECT ProductId FROM Products WHERE ProductId = 1), 2),
	((SELECT OrderId FROM Orders WHERE OrderId = 3), (SELECT ProductId FROM Products WHERE ProductId = 2), 1);
		

SELECT * FROM OrderedProducts
SELECT * FROM Orders
SELECT * FROM Customers

SELECT * FROM Inventory
SELECT * FROM Locations
SELECT * FROM Products


SELECT ProductName FROM OrderedProducts, Products WHERE (Products.ProductId = OrderedProducts.ProductId AND OrderedProducts.OrderId = 3)
-- productname -> product.prouductName if(products.productId == orderedProducts.ProductId && OrderedProducts.OrderId == 3)

SELECT ProductName, FirstName FROM OrderedProducts, Products, Customers, Orders WHERE (Products.ProductId = OrderedProducts.ProductId AND OrderedProducts.OrderId = 3 AND Orders.CustomerId = Customers.CustomerId AND Orders.OrderId = OrderedProducts.OrderId)

SELECT Orders.OrderId, Products.Price FROM OrderedProducts, Products, Orders WHERE Orders.OrderId = 3 AND OrderedProducts.OrderId = Orders.OrderId AND OrderedProducts.ProductId = Products.ProductId
SELECT SUM(Products.Price * OrderedProducts.NumberOrdered) FROM OrderedProducts, Products, Orders WHERE Orders.OrderId = 3 AND OrderedProducts.OrderId = Orders.OrderId AND OrderedProducts.ProductId = Products.ProductId
SELECT Orders.OrderId, SUM(Products.Price * OrderedProducts.NumberOrdered) FROM OrderedProducts, Products, Orders WHERE Orders.OrderId = 3 AND OrderedProducts.OrderId = Orders.OrderId AND OrderedProducts.ProductId = Products.ProductId GROUP BY Orders.OrderId
