CREATE DATABASE QuanLyQuan
GO

USE QuanLyQuan
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
	id INT IDENTITY,
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
	totalPrice FLOAT,
	discount INT DEFAULT 0,
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


--Thêm tài khoản admin mặc định
INSERT dbo.Account (userName, displayName, Type , passWord)
VALUES (N'admin' , N'Admin' , 1, N'1962026656160185351301320480154111117132155')
GO

--Tạo Stored Procedure Lấy ListAccount qua userName
CREATE proc USP_GetListAccountByUserName
@userName NVARCHAR(100)
AS
BEGIN
	SELECT * FROM dbo.Account WHERE userName = @userName
END
GO

-- Tạo Stored Procedure kiểm tra đăng nhập
CREATE PROC USP_Login
@userName NVARCHAR(100), @passWord NVARCHAR(100)
AS
BEGIN
	SELECT * FROM dbo.Account WHERE userName = @userName AND passWord = @passWord
END
GO


--Thêm bàn từ 1- 10
DECLARE @i INT = 1

WHILE @i <= 10
BEGIN
	INSERT dbo.TableFood (name) VALUES (N'Bàn ' + CAST(@i AS NVARCHAR(100)))
	SET @i= @i + 1
END
GO
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
GO
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

GO


--Thêm Bill

--Thêm BilInfor

--Tạo Stored Procedure lấy ra danh sách bàn ăn đang có
CREATE PROC USP_GetTableList
AS SELECT * FROM dbo.TableFood
GO

--Tạo Stored Procedure thêm Bill vào bàn hiện tại
CREATE PROC USP_INSERTBill
@idTable INT
AS
BEGIN
	INSERT dbo.Bill (dateCheckIn , dateCheckOut , idTable , status, discount)
	VALUES (GETDATE() , NULL , @idTable , 0, 0)
END
GO


--Tạo Stored Procedure thêm BillInfo vào Bill hiện tại

CREATE PROC USP_INSERTBillInfo
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

--Tạo Trigger Khi update dữ liệu BillInfo
CREATE TRIGGER UTG_UpdateBillInfo
ON dbo.BillInfo FOR INSERT, UPDATE
AS
BEGIN
	DECLARE @idBill INT
	SELECT @idBill = idBill FROM inserted

	DECLARE @idTable INT
	SELECT @idTable = idTable FROM dbo.Bill WHERE id = @idBill AND status = 0
	
	DECLARE @count INT
	SELECT @count = COUNT(*) FROM dbo.BillInfo WHERE idBill = @idBill

	IF (@count > 0 )
		UPDATE dbo.TableFood SET status = N'Có người' WHERE id = @idTable
	ELSE
		UPDATE dbo.TableFood SET status = N'Trống' WHERE id = @idTable
		
END
GO

--Tạo Trigger Khi update dữ liệu Bill
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

--Tạo Stored Procedure để chuyển đổi hai bàn (Chuyển đổi Bill và BillInfo)

CREATE PROC USP_SwitchTable
@idTable1 INT , @idTable2 INT
AS
BEGIN
	DECLARE @idFirstBill INT
	DECLARE @idSeconrdBill INT

	DECLARE @isFirstTableEmty INT = 1
	DECLARE @isSecorndTableEmty INT = 1

	SELECT @idSeconrdBill = id FROM dbo.Bill WHERE idTable = @idTable2 AND status = 0
	SELECT @idFirstBill = id FROM dbo.Bill WHERE idTable = @idTable1 AND status = 0

	IF(@idFirstBill IS NULL)
	BEGIN
		INSERT dbo.Bill (dateCheckIn, dateCheckOut, idTable, status)
		VALUES (GETDATE(), NULL, @idTable1, 0)
		SELECT @idFirstBill = MAX(id) FROM dbo.Bill WHERE idTable = @idTable1 AND status = 0

		
	END
	SELECT @isFirstTableEmty = COUNT(*) FROM dbo.BillInfo WHERE idBill = @idFirstBill
	IF(@idSeconrdBill IS NULL)
	BEGIN
		INSERT dbo.Bill (dateCheckIn, dateCheckOut, idTable, status)
		VALUES (GETDATE(), NULL, @idTable2, 0)
		SELECT @idSeconrdBill = MAX(id) FROM dbo.Bill WHERE idTable = @idTable2 AND status = 0

		
	END
	SELECT @isSecorndTableEmty = COUNT(*) FROM dbo.BillInfo WHERE idBill = @idSeconrdBill

	SELECT id INTO IdBillInfoTable FROM dbo.BillInfo WHERE idBill = @idSeconrdBill
	UPDATE dbo.BillInfo SET idBill = @idSeconrdBill WHERE idBill = @idFirstBill
	UPDATE dbo.BillInfo SET idBill = @idFirstBill WHERE id IN (SELECT * FROM IdBillInfoTable)
	DROP TABLE IdBillInfoTable

	IF (@isFirstTableEmty = 0)
		UPDATE dbo.TableFood SET status = N'Trống' WHERE id = @idTable2
	IF (@isSecorndTableEmty = 0)
		UPDATE dbo.TableFood SET status = N'Trống' WHERE id = @idTable1
END
GO

--Tạo Stored Procedure lấy danh sách Bill theo ngày

CREATE PROC USP_GetListBillByDate
@checkInDate DATE, @checkOutDate DATE
AS
BEGIN
	
	SELECT t.name AS [Tên bàn], b.totalPrice AS [Tổng tiền], b.dateCheckIn AS [Ngày vào], b.dateCheckOut AS [Ngày ra], b.discount AS [Giảm giá (%)]
	FROM dbo.Bill AS b, dbo.TableFood AS t
	WHERE dateCheckIn >= @checkInDate AND dateCheckOut <= @checkOutDate AND b.status = 1 AND t.id = b.idTable
END
GO

----Tạo Stored Procedure thay đổi thông tin tài khoản

CREATE PROC USP_UpdateAccount
@userName NVARCHAR(100), @displayName NVARCHAR(100), @passWord NVARCHAR(100), @newPassWord NVARCHAR(100)
AS
BEGIN
	DECLARE @isRightPass INT

	SELECT @isRightPass = COUNT(*) FROM dbo.Account WHERE userName = @userName AND passWord = @passWord

	IF (@isRightPass = 1)
	BEGIN
		IF (@newPassWord = NULL OR @newPassWord = '')
		BEGIN
			UPDATE dbo.Account SET displayName = @displayName WHERE userName = @userName
		END
		ELSE
			UPDATE dbo.Account SET displayName = @displayName, passWord = @newPassWord WHERE userName = @userName
	END
END
GO

--Tạo hàm chuyển đổi chuỗi có dấu sang chuỗi không dấu phục vụ cho việc tìm kiếm chính xác
CREATE FUNCTION [dbo].[fuConvertToUnsign1] ( @strInput NVARCHAR(4000) ) RETURNS NVARCHAR(4000) AS BEGIN IF @strInput IS NULL RETURN @strInput IF @strInput = '' RETURN @strInput DECLARE @RT NVARCHAR(4000) DECLARE @SIGN_CHARS NCHAR(136) DECLARE @UNSIGN_CHARS NCHAR (136) SET @SIGN_CHARS = N'ăâđêôơưàảãạáằẳẵặắầẩẫậấèẻẽẹéềểễệế ìỉĩịíòỏõọóồổỗộốờởỡợớùủũụúừửữựứỳỷỹỵý ĂÂĐÊÔƠƯÀẢÃẠÁẰẲẴẶẮẦẨẪẬẤÈẺẼẸÉỀỂỄỆẾÌỈĨỊÍ ÒỎÕỌÓỒỔỖỘỐỜỞỠỢỚÙỦŨỤÚỪỬỮỰỨỲỶỸỴÝ' +NCHAR(272)+ NCHAR(208) SET @UNSIGN_CHARS = N'aadeoouaaaaaaaaaaaaaaaeeeeeeeeee iiiiiooooooooooooooouuuuuuuuuuyyyyy AADEOOUAAAAAAAAAAAAAAAEEEEEEEEEEIIIII OOOOOOOOOOOOOOOUUUUUUUUUUYYYYYDD' DECLARE @COUNTER int DECLARE @COUNTER1 int SET @COUNTER = 1 WHILE (@COUNTER <=LEN(@strInput)) BEGIN SET @COUNTER1 = 1 WHILE (@COUNTER1 <=LEN(@SIGN_CHARS)+1) BEGIN IF UNICODE(SUBSTRING(@SIGN_CHARS, @COUNTER1,1)) = UNICODE(SUBSTRING(@strInput,@COUNTER ,1) ) BEGIN IF @COUNTER=1 SET @strInput = SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)-1) ELSE SET @strInput = SUBSTRING(@strInput, 1, @COUNTER-1) +SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)- @COUNTER) BREAK END SET @COUNTER1 = @COUNTER1 +1 END SET @COUNTER = @COUNTER +1 END SET @strInput = replace(@strInput,' ','-') RETURN @strInput END
GO
--Tạo Stored Procedure lấy Bill theo ngày và theo số trang

CREATE PROC USP_GetListBillByDateAndPage
@checkInDate DATE, @checkOutDate DATE, @page int
AS
BEGIN
	DECLARE @pageRows INT = 10
	DECLARE @selectRows INT = @pageRows * @page
	DECLARE @exceptRows INT = @pageRows * (@page - 1)

	;WITH BillShow AS (SELECT b.id, t.name AS [Tên bàn], b.totalPrice AS [Tổng tiền], b.dateCheckIn AS [Ngày vào], b.dateCheckOut AS [Ngày ra], b.discount AS [Giảm giá (%)]
	FROM dbo.Bill AS b, dbo.TableFood AS t
	WHERE dateCheckIn >= @checkInDate AND dateCheckOut <= @checkOutDate AND b.status = 1 AND t.id = b.idTable)

	SELECT TOP (@selectRows) * FROM BillShow
	EXCEPT
	SELECT TOP (@exceptRows) * FROM BillShow


END
GO

--Tạo Stored Procedure lấy  tổng số Bill theo ngày

CREATE PROC USP_GetNumBillByDate
@checkInDate DATE, @checkOutDate DATE
AS
BEGIN
	
	SELECT COUNT(*)
	FROM dbo.Bill AS b, dbo.TableFood AS t
	WHERE dateCheckIn >= @checkInDate AND dateCheckOut <= @checkOutDate AND b.status = 1 AND t.id = b.idTable
END
GO