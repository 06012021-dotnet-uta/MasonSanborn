CREATE DATABASE P0Db


CREATE TABLE Customers
(
 CustomerId int NOT NULL IDENTITY(1, 1),
 FirstName  varchar(50) NOT NULL ,
 LastName   varchar(50) NOT NULL ,
 UserName   varchar(50) NOT NULL ,
 Password   varchar(50) NOT NULL ,


 CONSTRAINT PK_customers PRIMARY KEY CLUSTERED (CustomerId ASC)
);
GO

CREATE TABLE Locations
(
 LocationId          int NOT NULL IDENTITY(1, 1),
 LocationName        varchar(20) NOT NULL ,
 LocationAddress     varchar(50) NOT NULL ,
 LocationPhoneNumber varchar(15) NULL ,


 CONSTRAINT PK_locations PRIMARY KEY CLUSTERED (LocationId ASC)
);
GO



CREATE TABLE Products
(
 ProductId   int NOT NULL IDENTITY(1, 1),
 ProductName varchar(20) NOT NULL ,
 Price       decimal(10,2) NOT NULL ,
 Description varchar(50) NULL ,
 Category    varchar(20) NULL ,


 CONSTRAINT PK_products PRIMARY KEY CLUSTERED (ProductId ASC)
);
GO



--uajdsofguijas[dogj[odsijf[oaisdjfois
CREATE TABLE Inventory
(
 ProductId      int NOT NULL ,
 LocationId     int NOT NULL ,
 NumberProducts int NOT NULL ,

 CONSTRAINT PK_inventory PRIMARY KEY CLUSTERED (ProductId, LocationId),
 CONSTRAINT FK_42 FOREIGN KEY (ProductId)  REFERENCES Products(ProductId),
 CONSTRAINT FK_45 FOREIGN KEY (LocationId)  REFERENCES Locations(LocationId)
);
GO


CREATE NONCLUSTERED INDEX fkIdx_43 ON Inventory 
 (
  ProductId ASC
 )

GO

CREATE NONCLUSTERED INDEX fkIdx_46 ON Inventory 
 (
  LocationId ASC
 )

GO


-- asdmfoiasdjgopijasdgo;ijsad[oj
CREATE TABLE Orders
(
 OrderId    int NOT NULL IDENTITY(1, 1),
 OrderTime  datetime NOT NULL ,
 CustomerId int NOT NULL ,
 LocationId int NOT NULL ,


 CONSTRAINT PK_orders PRIMARY KEY CLUSTERED (OrderId ASC),
 CONSTRAINT FK_24 FOREIGN KEY (CustomerId)  REFERENCES Customers(CustomerId),
 CONSTRAINT FK_30 FOREIGN KEY (LocationId)  REFERENCES Locations(LocationId)
);
GO


CREATE NONCLUSTERED INDEX fkIdx_25 ON Orders 
 (
  CustomerId ASC
 )

GO

CREATE NONCLUSTERED INDEX fkIdx_31 ON Orders 
 (
  LocationId ASC
 )

GO



-- oadisfj[oiasdjgpiouasdhjgo[8idsajf[
CREATE TABLE OrderedProducts
(
 OrderId       int NOT NULL ,
 ProductId     int NOT NULL ,
 NumberOrdered int NOT NULL ,

 CONSTRAINT PK_orderedProduct PRIMARY KEY CLUSTERED (OrderId, ProductId),
 CONSTRAINT FK_49 FOREIGN KEY (OrderId)  REFERENCES Orders(OrderId),
 CONSTRAINT FK_52 FOREIGN KEY (ProductId)  REFERENCES Products(ProductId)

);
GO


CREATE NONCLUSTERED INDEX fkIdx_50 ON OrderedProducts 
 (
  OrderId ASC
 )

GO

CREATE NONCLUSTERED INDEX fkIdx_53 ON OrderedProducts
 (
  ProductId ASC
 )

GO