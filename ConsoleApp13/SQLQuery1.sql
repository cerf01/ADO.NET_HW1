CREATE DATABASE FruitAndVeg
GO

USE FruitAndVeg
GO

CREATE TABLE Info
(
	Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Name] NVARCHAR(MAX) NOT NULL,
	[Type] NVARCHAR(MAX) NOT NULL,
	Color NVARCHAR(MAX) NOT NULL,
	Calories FLOAT NOT NULL
);

INSERT INTO Info VALUES
('Apple', 'Fruit','Red',51.2)

INSERT INTO Info VALUES
('Carrot', 'Veg','Orange',41.3 )

INSERT INTO Info VALUES
('Tomato', 'Veg','Red',18.0 )

INSERT INTO Info VALUES
('Potato', 'Veg','Brown', 164.0 )

INSERT INTO Info VALUES
('Pipeapple', 'Fruit','Yallow', 50.0 )

INSERT INTO Info VALUES
('Banana', 'Fruit','Yallow', 88.7 )

INSERT INTO Info VALUES
('Cucumber', 'Veg','Green', 16.0)
  
 INSERT INTO Info VALUES
('Purple Plum', 'Fruit','Purple', 35.0 )