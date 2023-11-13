CREATE DATABASE QuanLyQuanCafe
GO

USE QuanLyQuanCafe
GO

-- Food
-- TableFood
-- FoodCategory
-- Account
-- Bill
-- BillInfor

CREATE TABLE TableFood 
(
	id INT IDENTITY PRIMARY KEY,
	name NVARCHAR(100) NOT NULL DEFAULT N'Chưa đặt tên',
	status NVARCHAR(100) NOT NULL DEFAULT N'Trống', --Trống || có người

)
GO

CREATE TABLE Account
(
	
	displayName NVARCHAR(100) NOT NULL,
	userName NVARCHAR(100) PRIMARY KEY,
	passWord NVARCHAR(100) NOT NULL DEFAULT 0,
	Type INT NOT NULL DEFAULT 0 -- 1: admin, 0: staff
)
GO

CREATE TABLE FoodCategory
(
	id INT IDENTITY PRIMARY KEY,
	name NVARCHAR(100) NOT NULL DEFAULT N'Chưa đặt tên',
	
)
GO



CREATE TABLE Food
(
	id INT  IDENTITY PRIMARY KEY,
	name NVARCHAR(100) NOT NULL DEFAULT N'Chưa đặt tên',
	idCategory INT NOT NULL,
	price FLOAT NOT NULL DEFAULT 0,

	FOREIGN KEY (idCategory) REFERENCES dbo.FoodCategory(id)
)
GO

CREATE TABLE Bill
(
	id INT IDENTITY PRIMARY KEY,
	dateCheckIn DATE NOT NULL DEFAULT GETDATE(),
	dateCheckOut DATE,
	idTable INT NOT NULL,
	status INT NOT NULL DEFAULT 0, -- 1 đã thanh toán, 0: chưa thánh toán

	FOREIGN KEY (idTable) REFERENCES dbo.TableFood(id)
)
GO

CREATE TABLE BillInfo
(
	id INT IDENTITY PRIMARY KEY,
	idBill INT NOT NULL,
	idFood INT NOT NULL,
	count INT NOT NULL DEFAULT 0
	
	FOREIGN KEY (idBill) REFERENCES dbo.Bill(id),
	FOREIGN KEY (idFood) REFERENCES dbo.Food(id)
)
GO

INSERT INTO dbo.Account
        ( UserName ,
          DisplayName ,
          PassWord ,
          Type
        )
VALUES  ( N'K9' , -- UserName - nvarchar(100)
          N'RongK9' , -- DisplayName - nvarchar(100)
          N'1' , -- PassWord - nvarchar(1000)
          1  -- Type - int
        )
INSERT INTO dbo.Account
        ( UserName ,
          DisplayName ,
          PassWord ,
          Type
        )
VALUES  ( N'staff' , -- UserName - nvarchar(100)
          N'staff' , -- DisplayName - nvarchar(100)
          N'1' , -- PassWord - nvarchar(1000)
          0  -- Type - int
        )
GO


CREATE proc USP_GetListAccountByUserName
@userName NVARCHAR(100)
AS
BEGIN
	SELECT * FROM dbo.Account WHERE userName = @userName
END
GO

EXEC dbo.USP_GetListAccountByUserName @userName = N'K9'
GO

CREATE PROC USP_Login
@userName NVARCHAR(100), @passWord NVARCHAR(100)
AS
BEGIN
	SELECT * FROM dbo.Account WHERE userName = @userName AND passWord = @passWord
END
GO

EXEC dbo.USP_Login @userName = N'K9', @passWord = N'1'

--Thêm bàn
INSERT dbo.TableFood (name , status)

VALUES (N'Bàn 1')

DECLARE @i INT = 0

WHILE @i <= 10
BEGIN
	INSERT dbo.TableFood (name) VALUES (N'Bàn ' + CAST(@i AS NVARCHAR(100)))
	SET @i= @i + 1
END
-- Thêm caterogy
INSERT dbo.FoodCategory (name)
VALUES (N'Hải sản')

INSERT dbo.FoodCategory (name)
VALUES (N'Nông sản')

INSERT dbo.FoodCategory (name)
VALUES (N'Lâm sản')

INSERT dbo.FoodCategory (name)
VALUES (N'Thủy sản')

INSERT dbo.FoodCategory (name)
VALUES (N'Đồ uống')

-- Thêm món ăn

INSERT dbo.Food (name, idCategory, price)
VALUES (N'Mực một nắng', 1, 150000)

INSERT dbo.Food (name, idCategory, price)
VALUES (N'Nghêu hấp xả', 1, 50000)

INSERT dbo.Food (name, idCategory, price)
VALUES (N'Cơm cháy chà bông', 2, 100000)

INSERT dbo.Food (name, idCategory, price)
VALUES (N'Lợn rừng quay', 3, 350000)

INSERT dbo.Food (name, idCategory, price)
VALUES (N'Tôm hấp bia', 4, 170000)

INSERT dbo.Food (name, idCategory, price)
VALUES (N'Cocacola', 5, 10000)

INSERT dbo.Food (name, idCategory, price)
VALUES (N'Pessi', 5, 10000)
SELECT * FROM dbo.TableFood

--Thêm Bill
INSERT dbo.Bill (dateCheckIn,dateCheckOut, idTable, status)
VALUES (GETDATE(), NULL, 1, 0)

INSERT dbo.Bill (dateCheckIn,dateCheckOut, idTable, status)
VALUES (GETDATE(), NULL, 2, 0)

INSERT dbo.Bill (dateCheckIn,dateCheckOut, idTable, status)
VALUES (GETDATE(), GETDATE(), 3, 1)

INSERT dbo.Bill (dateCheckIn,dateCheckOut, idTable, status)
VALUES (GETDATE(), Null, 6, 0)

--Thêm BilInfor
INSERT dbo.BillInfo (idBill, idFood, count)
VALUES (1, 1, 2)

INSERT dbo.BillInfo (idBill, idFood, count)
VALUES (2, 1, 2)

INSERT dbo.BillInfo (idBill, idFood, count)
VALUES (2, 5, 2)

INSERT dbo.BillInfo (idBill, idFood, count)
VALUES (3, 4, 1)

INSERT dbo.BillInfo (idBill, idFood, count)
VALUES (4, 6, 2)

INSERT dbo.BillInfo (idBill, idFood, count)
VALUES (4, 4, 1)

SELECT * FROM dbo.Bill
SELECT * FROM dbo.BillInfo
SELECT * FROM dbo.Food
SELECT * FROM dbo.FoodCategory

SELECT f.name, bi.count, f.price, f.price*bi.count AS totalPrice FROM dbo.BillInfo AS bi, dbo.Bill AS b, dbo.Food AS f WHERE bi.idBill = b.id AND bi.idFood = f.id AND b.idTable = 3
UPDATE dbo.TableFood SET status = N'Có người' WHERE id = 8

CREATE PROC USP_GetTableList
AS SELECT * FROM dbo.TableFood
GO

ALTER PROC USP_INSERTBill
@idTable INT
AS
BEGIN
	INSERT dbo.Bill (dateCheckIn , dateCheckOut , idTable , status, discount)
	VALUES (GETDATE() , NULL , @idTable , 0, 0)
END
GO

CREATE PROC USP_INSERTBillInfo
@idBill INT, @idFood INT, @count INT
AS
BEGIN
	INSERT dbo.BillInfo ( idBill, idFood, count)
	VALUES (@idBill, @idFood, @count)
END
GO

ALTER PROC USP_INSERTBillInfo
@idBill INT, @idFood INT, @count INT
AS
BEGIN
	DECLARE @isExitBillInfo INT
	DECLARE @foodCount INT = 1
	SELECT @isExitBillInfo = id, @foodCount = count FROM dbo.BillInfo WHERE idBill = @idBill AND idFood = @idFood
	IF (@isExitBillInfo > 0)
	BEGIN
		DECLARE @newCount INT = @foodCount + @count
		IF (@newCount > 0)
			UPDATE dbo.BillInfo SET count = @foodCount + @count WHERE idFood = @idFood
		ELSE
			DELETE dbo.BillInfo WHERE idBill = @idBill AND idFood = @idFood
	END
	ELSE
	BEGIN
		INSERT dbo.BillInfo ( idBill, idFood, count)
		VALUES (@idBill, @idFood, @count)
	END
END
GO

DELETE dbo.BillInfo
DELETE dbo.Bill



CREATE TRIGGER UTG_UpdateBillInfo
ON dbo.BillInfo FOR INSERT, UPDATE
AS
BEGIN
	DECLARE @idBill INT
	SELECT @idBill = idBill FROM inserted

	DECLARE @idTable INT
	SELECT @idTable = idTable FROM dbo.Bill WHERE id = @idBill AND status = 0

	UPDATE dbo.TableFood SET status = N'Có người' WHERE id = @idTable
END
GO

CREATE TRIGGER UTG_UpdateBill
ON dbo.Bill FOR UPDATE
AS
BEGIN
	DECLARE @idBill INT
	SELECT @idBill = id FROM inserted
	
	DECLARE @idTable INT
	SELECT @idTable = idTable FROM dbo.Bill WHERE id = @idBill

	DECLARE @count INT = 0
	SELECT @count = COUNT(*) FROM dbo.Bill WHERE idTable = @idTable AND status = 0

	IF(@count = 0)
		UPDATE dbo.TableFood SET status = N'Trống' WHERE id = @idTable
END
GO 

ALTER TABLE dbo.Bill
ADD discount INT

UPDATE dbo.Bill SET discount = 0




