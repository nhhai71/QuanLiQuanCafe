CREATE DATABASE QUANLIQUANCAFE

GO
USE QUANLIQUANCAFE

-- Food
-- Table
-- FoodCategory
-- Account
-- Bill
-- BillInfo

CREATE TABLE TableFood
(
	id INT IDENTITY PRIMARY KEY,
	name NVARCHAR(100) NOT NULL DEFAULT N'Chưa đặt tên',
	status NVARCHAR(100) NOT NULL DEFAULT N'Trống'-- Trống || Có người
)

CREATE TABLE Account
(
	UserName NVARCHAR(100) PRIMARY KEY DEFAULT N'Kter',
	DisplayName NVARCHAR(100) NOT NULL DEFAULT N'Chưa đặt tên',
	Password NVARCHAR(100) NOT NULL DEFAULT N'0',
	Type INT NOT NULL DEFAULT 0 -- 1. Adim || 0. Staff
)

CREATE TABLE Food
(
	id INT IDENTITY PRIMARY KEY,
	name NVARCHAR(100) NOT NULL DEFAULT N'Chưa đặt tên',
	idCategory INT NOT NULL,
	price FLOAT NOT NULL  DEFAULT 0,

	FOREIGN KEY (idCategory) REFERENCES FoodCategory(id)
)

CREATE TABLE FoodCategory
(
	id INT IDENTITY PRIMARY KEY,
	name NVARCHAR(100) NOT NULL DEFAULT N'Chưa đặt tên'
)

CREATE TABLE Bill
(
	id INT IDENTITY PRIMARY KEY,
	idTable INT NOT NULL,
	DateCheckIn DATE NOT NULL DEFAULT GETDATE(),
	DataCheckOut DATE NOT NULL,
	status INT NOT NULL, -- 1. Đã thanh toán || 0: Chưa thanh toán
	
	FOREIGN KEY(idTable) REFERENCES TableFood(id)
)

CREATE TABLE BillInfo
(
	id INT IDENTITY PRIMARY KEY,
	idBill INT NOT NULL,
	idFood INT NOT NULL,
	count INT NOT NULL DEFAULT 0,

	FOREIGN KEY(idBill) REFERENCES Bill(id),
	FOREIGN KEY(idFood) REFERENCES Food(id)
)



INSERT INTO Account (UserName,DisplayName,Password,Type) VALUES (N'K9',N'RongK9',N'1',1)
INSERT INTO Account (UserName,DisplayName,Password,Type) VALUES (N'Staff',N'Staff',N'1',0)

SELECT*FROM Account

-- Store procedure là chương trình thủ tục
-- Ta có thể Transact -SQL EXECUTE (EXEC) để thực thi các Store-Procedure
-- Store Procedure khác các hàm xử lí bởi nó có giá trị trả về
-- Không chứa trong tên và chúng không được sử dụng trong biểu thức

-- Động: có thể chỉnh sửa khối lệnh, tái sử dụng nhiều lần
-- Nhanh hơn: tự phân tích cú pháp cho tối ưu. Và tạo ra bản sao để lần thực hiện tiếp theo không chạy lại từ đầu
-- Bảo mật: Giới hạn quyền cho User nào sử dụng, User nào không
-- Giảm bandwith: Vói các gói transaction lớn, vài  ngàn lệnh cùng một lúc thì dùng Store sẽ đảm bảo



/*CREATE PROC <Ten Store>
[Ten tham so neu co]
As
BEGIN
	<Code xử lí>
END 
*/

GO

CREATE PROC USP_GetAccountByUserName
@userName nvarchar(100)
AS
BEGIN
	SELECT*FROM Account WHERE UserName=@userName;
END

EXEC USP_GetAccountByUserName @userName=N'K9';

SELECT *FROM Account WHERE UserName=N'K9' AND Password=2 OR 1=1


CREATE PROC USP_Login
@userName NVARCHAR(100),@password NVARCHAR(100)
AS
BEGIN
	SELECT*FROM Account WHERE UserName=@userName AND Password=@password
END 

-- tạo có sở dữ liệu cho tableFood
DECLARE @i INT = 11
WHILE @i<=20
BEGIN
	INSERT TableFood (name) VALUES (N'Bàn '+CAST(@i AS NVARCHAR(100)))
	SET @i=@i+1
END 

SELECT *FROM TableFood 

DECLARE @x INT =2
WHILE @x<=13
BEGIN
	DELETE TableFood WHERE  id=@x
	SET @x =@x+1
END 

GO

CREATE PROC USP_TableList
AS SELECT *FROM TableFood 

GO

EXEC dbo.USP_TableList


UPDATE dbo.TableFood
SET status=N'Có người'
WHERE id=2 OR id=4