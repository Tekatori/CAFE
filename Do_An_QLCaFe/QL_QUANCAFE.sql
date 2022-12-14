--Tạo Database
create database [QL_QUANCAFE]

USE [QL_QUANCAFE]
GO
SET ANSI_NULLS ON
GO
--Tạo Bảng
CREATE TABLE NHANVIEN
(
	MANV INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	TENNV NVARCHAR(30) NOT NULL,
	NGAYSINH DATETIME,
	MAPHAI BIT NOT NULL,
	DIACHI NVARCHAR(50) NOT NULL,
	SDT NVARCHAR(15)NOT NULL,
	MAVT INT NOT NULL,
	LUONG FLOAT NOT NULL
)

GO
CREATE TABLE GIOITINH
(
	MAPHAI BIT PRIMARY KEY NOT NULL,
	PHAI NVARCHAR(5) NOT NULL
)

GO 
CREATE TABLE VITRI
(
	MAVT INT IDENTITY (1,1) PRIMARY KEY NOT NULL,
	TENVT NVARCHAR(10) NOT NULL
)

GO 
CREATE TABLE ACCOUNT
(
	USERNAME NVARCHAR(25) PRIMARY KEY NOT NULL,
	DISPLAYNAME NVARCHAR(25) NOT NULL,
	PASSWORD NVARCHAR(25) NOT NULL,
	TYPEACCOUNT NVARCHAR(10) NOT NULL
)

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON

GO
CREATE TABLE BILL
(
	ID INT IDENTITY (1,1) PRIMARY KEY NOT NULL,
	NAMETABLE NVARCHAR(40) NOT NULL,
	NAMEFOOD NVARCHAR(40) NOT NULL,
	COUNTS INT NOT NULL
)

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON

GO
CREATE TABLE CATEGORY
(
	NAME NVARCHAR(100) NOT NULL PRIMARY KEY
)

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON

GO
CREATE TABLE FOOD
(
	NAME NVARCHAR(40) NOT NULL PRIMARY KEY,
	NAMECATEGORY NVARCHAR(40) NOT NULL,
	PRICE FLOAT NOT NULL
)

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON

GO
CREATE TABLE TABLEF
(
	NAME NVARCHAR(40) NOT NULL PRIMARY KEY,
	STT NVARCHAR(40) NOT NULL,
	TOTAL FLOAT NOT NULL
)

--Khóa Ngoại
GO
ALTER TABLE NHANVIEN
ADD CONSTRAINT FK_NHANVIEN_GT FOREIGN KEY (MAPHAI) REFERENCES GIOITINH(MAPHAI),
CONSTRAINT FK_NHANVIEN_VT FOREIGN KEY (MAVT) REFERENCES VITRI(MAVT)

GO
ALTER TABLE BILL
ADD CONSTRAINT FK_BILL_TABLEF FOREIGN KEY(NAMETABLE) REFERENCES TABLEF(NAME),
CONSTRAINT FK_BILL_FOOD FOREIGN KEY (NAMEFOOD) REFERENCES FOOD(NAME)

GO 
ALTER TABLE FOOD
ADD CONSTRAINT FK_FOOD_CATEGORY FOREIGN KEY(NAMECATEGORY) REFERENCES CATEGORY(NAME)
GO
-- Ràng buộc
ALTER TABLE ACCOUNT
ADD CONSTRAINT DEF_DISPLAYNAME DEFAULT (N'NO NAME..') FOR DISPLAYNAME,
CONSTRAINT DEF_PASSWORD DEFAULT ('0000') FOR PASSWORD,
CONSTRAINT DEF_TYPEACCOUNT DEFAULT (N'CASHIER') FOR TYPEACCOUNT
ALTER TABLE ACCOUNT
ADD CONSTRAINT UNI_USERNAME UNIQUE(USERNAME)
GO

ALTER TABLE GIOITINH
ADD CONSTRAINT DEF_PHAI DEFAULT (N'NỮ') FOR PHAI,
CONSTRAINT CHK_PHAI CHECK (PHAI=N'NAM' OR PHAI=N'NỮ')
GO

ALTER TABLE BILL
ADD CONSTRAINT DEF_COUNTS DEFAULT ((1)) FOR COUNTS
GO
 
ALTER TABLE FOOD
ADD CONSTRAINT DEF_PRICE DEFAULT ((0)) FOR PRICE
GO
 
ALTER TABLE TABLEF
ADD CONSTRAINT DEF_STT DEFAULT (N'TRONG') FOR STT,
CONSTRAINT DEF_TOTAL DEFAULT ((0)) FOR TOTAL
GO

--Tạo trigger updateTableF
create trigger trigger_updateTableF on TABLEF
for insert, update
as
begin
	if((select TOTAL from inserted)>=0)
		commit tran
	else
		rollback tran
end

--Tạo trigger updateAccount
create trigger trigger_updateAccount on ACCOUNT
for insert, update
as
begin
	if((select TYPEACCOUNT from inserted) = 'ADMIN' or (select TYPEACCOUNT from inserted) = 'CASHIER' )
		commit tran
	else
		rollback tran
end

--Thêm dữ liệu
INSERT INTO GIOITINH
VALUES ('0',N'Nam'),
('1',N'Nữ')
GO

INSERT INTO VITRI
VALUES(N'Phục Vụ'),
(N'Pha Chế'),
(N'Tạp Vụ'),
(N'Thu Ngân')
GO


SET DATEFORMAT DMY
GO
INSERT INTO NHANVIEN
VALUES(N'Nguyễn Kim ','05/08/1998',1,N'371 Ðiện Biên Phủ P.24 Q.Bình Thạnh','0938373728',1,'3000000' ),
(N'Võ Thanh Điền','16/10/2001',0,N'Hẻm 86 Phan Văn Hân P.17 Q.Bình Thạnh','01639331034',2,'5000000' ),
(N'Trần Hữu Danh','06/01/2001',0,N'Quận 8','01678844350',2,'5000000' ),
(N'Huỳnh Hoàng Chương','05/05/2001',0,N'Quận Thủ Đức','09058378955',1,'3000000' ),
(N'Trương Chí Hoàng','06/08/2001',0,N'475A Ðiện Biên Phủ P.25 Q.Bình Thạnh','0962462416',3,'3500000' ),
(N'Phạm Tuyết ','07/01/1995',1,N'81/D3 P.25 Q.Bình Thạnh','01639330332',4,'4000000' )
 
 GO
 INSERT INTO ACCOUNT
 VALUES (N'admin', N'Quản Lý 1', N'admin', N'ADMIN'),
(N'admin2', N'Quản Lý 2', N'admin', N'ADMIN'),
(N'barista', N'Pha Chế 1', N'barista', N'CASHIER'),
(N'user', N'Thu Ngân 1', N'fblc', N'CASHIER')

GO
INSERT INTO CATEGORY 
VALUES (N'CAFE'),
(N'Kem'),
(N'Nước ngọt'),
(N'Sinh tố'),
(N'Trà sữa'),
(N'Trái cây')

GO
INSERT INTO FOOD
VALUES (N'7 up', N'Nước ngọt', 10000),
(N'CF đá', N'CAFE', 10000),
(N'CF đen', N'CAFE', 10000),
(N'CF Pin ó', N'CAFE', 50000),
(N'CF sữa đá', N'CAFE', 12000),
(N'CF sữa nóng', N'CAFE', 12000),
(N'CF Trung Nguyên', N'CAFE', 24000),
(N'Coca', N'Nước ngọt', 10000),
(N'Dừa', N'Trái cây', 25000),
(N'Kem Ký', N'Kem', 40000),
(N'Kem Ly', N'Kem', 15000),
(N'Kem tươi', N'Kem', 30000),
(N'Nước chanh', N'Trái cây', 9000),
(N'Nước me', N'Trái cây', 8000),
(N'Nước suối', N'Nước ngọt', 5000),
(N'Pepsi', N'Nước ngọt', 10000),
(N'ST bơ', N'Sinh tố', 13000),
(N'ST dâu', N'Sinh tố', 14000),
(N'ST đặc biệt', N'Sinh tố', 18000),
(N'ST mảng cầu', N'Sinh tố', 16000),
(N'Sting', N'Nước ngọt', 10000),
(N'TS hạt', N'Trà sữa', 25000),
(N'TS thạch', N'Trà sữa', 28000)

GO
INSERT INTO TABLEF
VALUES (N'Bàn 01', N'TRONG', 0),
(N'Bàn 02', N'TRONG', 0),
(N'Bàn 03', N'TRONG', 0),
(N'Bàn 04', N'TRONG', 0),
(N'Bàn 05', N'TRONG', 0),
(N'Bàn 06', N'TRONG', 0),
(N'Bàn 07', N'TRONG', 0),
(N'Bàn 08', N'TRONG', 0),
(N'Bàn 09', N'TRONG', 0),
(N'Bàn 10', N'TRONG', 0),
(N'Bàn 11', N'TRONG', 0),
(N'Bàn 12', N'TRONG', 0),
(N'Bàn 13', N'TRONG', 0),
(N'Bàn 14', N'TRONG', 0),
(N'Bàn 15', N'TRONG', 0),
(N'Bàn 16', N'TRONG', 0),
(N'Bàn 17', N'TRONG', 0),
(N'Bàn 18', N'TRONG', 0),
(N'Bàn 19', N'TRONG', 0),
(N'Bàn 20', N'TRONG', 0),
(N'Bàn 21', N'TRONG', 0),
(N'Bàn 22', N'TRONG', 0),
(N'Bàn 23', N'TRONG', 0),
(N'Bàn 24', N'TRONG', 0),
(N'Bàn VIP 1', N'TRONG', 0),
(N'Bàn VIP 2', N'TRONG', 0),
(N'Bàn VIP 3', N'TRONG', 0),
(N'Bàn VIP 4', N'TRONG', 0)



---Tạo function ktDN
create function ktDN (@username nvarchar(50), @pass nvarchar(50))
returns table
as
	return (select ACC.USERNAME, ACC.PASSWORD from ACCOUNT ACC
		    where acc.USERNAME = @username and acc.PASSWORD = @pass)

---Tạo function loginDN
create function loginDN (@username nvarchar(50), @pass nvarchar(50))
returns table
as
	return (select * from ACCOUNT ACC
		    where acc.USERNAME = @username and acc.PASSWORD = @pass)

select * from dbo.loginDN('admin', 'admin')

--Tạo function getTable
create function getTable ()
returns table
as
	return (select * from TABLEF)

select * from dbo.getTable()

--Tạo function getBillDK
create function getBillDK (@tblName nvarchar(50))
returns table
as
	return (select * from BILL where NAMETABLE = @tblName)

select * from dbo.getBillDK(N'Bàn 01')


--Tạo function getCategory
create function getCategory ()
returns table
as
	return (select * from CATEGORY)

select * from dbo.getCategory()


--Tạo function getFood
create function getFood (@categoryName nvarchar(50))
returns table
as
	return (select * from FOOD where NAMECATEGORY = @categoryName)

select * from dbo.getFood(N'Nước ngọt')

--Tạo procedure updatePreTable
create proc updatePreTable @TableName nvarchar(50)
as
update TABLEF
set STT = 'DATTRUOC'
where NAME = @TableName

exec updatePreTable N'Bàn 01'

--Tạo procedure openTable
create proc openTable @TableName nvarchar(50)
as
update TABLEF
set STT = 'ONLINE'
where NAME = @TableName

exec openTable N'Bàn 01'

select * from TABLEF

--Tạo function getThongKeFood
create function getThongKeFood ()
returns table
as
	return (select * from FOOD)

select * from dbo.getThongKeFood()

--Tạo function getNV
create function getNV ()
returns table
as
	return (select * from NHANVIEN)

select * from dbo.getNV()

--Tạo procedure InsertCategory
create proc InsertCategory @Name nvarchar(50)
as
Insert into CATEGORY values (@Name)

exec InsertCategory N'Thẻ cào'

--Tạo procedure DeleteCategory
create proc DeleteCategory @Name nvarchar(50)
as
Delete CATEGORY where NAME = @Name

exec DeleteCategory N'Thẻ cào'

select * from CATEGORY

--Tạo function SearchCategory
create function SearchCategory (@Name nvarchar(50))
returns table
as
	return (select * from CATEGORY where NAME = @Name)
	
select * from dbo.SearchCategory ('Kem')

--Tạo function getNV1
create function getNV1 ()
returns table
as
	return (SELECT MANV,TENNV,NGAYSINH,MAPHAI,DIACHI,SDT,MAVT,LUONG FROM NHANVIEN)

select * from dbo.getNV1()

--Tạo function getVT
create function getVT ()
returns table
as
	return (SELECT * FROM VITRI)

select * from dbo.getVT()

--Tạo function getGT
create function getGT ()
returns table
as
	return (SELECT * FROM GIOITINH)

select * from dbo.getGT()

--Tạo procedure InsertNV
create proc InsertNV @TENNV nvarchar(50), @NGAYSINH datetime, @MAPHAI bit, @DIACHI nvarchar(50), @SDT nvarchar(10),@MAVT int, @LUONG float
as
Insert into NHANVIEN values (@TENNV,@NGAYSINH,@MAPHAI,@DIACHI,@SDT,@MAVT,@LUONG)

exec InsertNV N'Vũ Quang Phụng', '1998-12-20', 0, N'20 đường 7D Q.Tân Bình', '0102345641', 4, 3000000

--Tạo procedure DeleteNV
create proc DeleteNV @TENNV nvarchar(50)
as
Delete NHANVIEN where TENNV = @TENNV

exec DeleteNV N'Vũ Quang Phụng'

select * from NHANVIEN

--Tạo procedure UpdateNV
create proc UpdateNV @manv nchar(50), @TENNV nvarchar(50), @NGAYSINH datetime, @MAPHAI bit, @DIACHI nvarchar(50), @SDT nvarchar(10),@MAVT int, @LUONG float
as
update NHANVIEN
set TENNV=@TENNV,NGAYSINH = @NgaySinh , MAPHAI = @MaPhai,DIACHI = @DIACHI,SDT=@SDT,MAVT = @MAVT,LUONG = @LUONG 
where MANV=@manv



--Tạo function getAccount
create function getAccount ()
returns table
as
	return (select * from ACCOUNT)

select * from dbo.getAccount()

--Tạo procedure InsertAccount
create proc InsertAccount @USERNAME nvarchar(50), @DISPLAYNAME nvarchar(50), @PASSWORD nvarchar(50), @TYPEACCOUNT nvarchar(50)
as
Insert into ACCOUNT values (@USERNAME,@DISPLAYNAME,@PASSWORD,@TYPEACCOUNT)

exec InsertAccount 'user2', N'Thu Ngân 2', 'user2', 'CASHIER'

select * from dbo.getAccount()

--Tạo procedure DeleteAccount
create proc DeleteAccount @USERNAME nvarchar(50)
as
Delete ACCOUNT where USERNAME = @USERNAME

exec DeleteAccount 'user2'

select * from dbo.getAccount()

--Tạo procedure UpdateAccount
create proc UpdateAccount @USERNAME nvarchar(50), @DISPLAYNAME nvarchar(50), @PASSWORD nvarchar(50), @TYPEACCOUNT nvarchar(50)
as
update ACCOUNT
set DISPLAYNAME = @DISPLAYNAME , PASSWORD = @PASSWORD, TYPEACCOUNT = @TYPEACCOUNT 
where USERNAME = @USERNAME

exec UpdateAccount 'user2', N'Thu Ngân 2', 'user2', 'ADMIN'

select * from dbo.getAccount()

--Tạo function getTableF
create function getTableF ()
returns table
as
	return (SELECT * FROM TABLEF)

select * from dbo.getTableF()

--Tạo procedure InsertTableF
create proc InsertTableF @NAME nvarchar(50), @STT nvarchar(50), @TOTAL float
as
Insert into TABLEF values(@NAME,@STT,@TOTAL)

exec InsertTableF 'user2', '2', 8.0

select * from dbo.getTableF()

--Tạo procedure DeleteTableF
create proc DeleteTableF @NAME nvarchar(50)
as
Delete TABLEF where NAME = @NAME

exec DeleteTableF 'user2'

--Tạo function getBill
create function getBill ()
returns table
as
	return (SELECT * FROM BILL)

select * from dbo.getBill()

--Tạo procedure InsertBill
create proc InsertBill @NAMETABLE nvarchar(50), @NAMEFOOD nvarchar(50), @COUNTS int
as
Insert into BILL values(@NAMETABLE,@NAMEFOOD,@COUNTS)

exec InsertBill N'Bàn 01', '7 up', 8

select * from dbo.getBill()

--Tạo function getCountsBill
create function getCountsBill (@NAMETABLE nvarchar(50), @NAMEFOOD nvarchar(50))
returns table
as
	return (SELECT COUNTS FROM BILL where NAMETABLE = @NAMETABLE and NAMEFOOD = @NAMEFOOD)

	select * from dbo.getCountsBill(N'Bàn 10', N'CF đá')

--Tạo procedure DeleteBill
create proc DeleteBill @NAMEFOOD nvarchar(50), @NAMETABLE nvarchar(50)
as
	Delete BILL where NAMEFOOD = @NAMEFOOD and NAMETABLE = @NAMETABLE

exec DeleteBill '7 up', N'Bàn 01'

--Tạo function getFoodPrice
create function getFoodPrice (@NAME nvarchar(50))
returns table
as
	return (select PRICE from FOOD where NAME = @NAME)

select * from dbo.getFoodPrice('7 up')
--
create proc updatecount @NAMEFOOD nvarchar(50), @NAMETABLE nvarchar(50),@Cadd int
as
update BILL
set COUNTS = COUNTs + @Cadd
where NAMEFOOD = @NAMEFOOD and NAMETABLE =@NAMETABLE

exec updatecount N'CF đá', N'Bàn 10',1

--Tạo proc UpdateBill
create proc UpdateBill @NAMEFOOD nvarchar(50), @NAMETABLE nvarchar(50)
as
	Update TABLEF
	set TOTAL = TOTAL - (select * from dbo.getFoodPrice(@NAMEFOOD))
	where NAME = @NAMETABLE

exec UpdateBill '7 up', N'Bàn 01'

select * from dbo.getTableF()

--Tạo function getIDBill
create function getIDBill (@NAMEFOOD nvarchar(50), @NAMETABLE nvarchar(50))
returns table
as
	return (select id from BILL where NAMEFOOD = @NAMEFOOD AND NAMETABLE = @NAMETABLE)

--Tạo proc UpdateBillCount
create proc UpdateBillCount @COUNTS int, @ID int
as
	Update BILL
	set COUNTS = COUNTS - @COUNTS
	where ID = @ID

--Tạo function getTableF_Food
create function getTableF_Food (@NAMETABLE nvarchar(50))
returns table
as
	return (select * from TABLEF,BILL where NAMETABLE = @NAMETABLE AND TABLEF.NAME = BILL.NAMETABLE)

select * from dbo.getTableF_Food (N'Bàn 01')

--Tạo procedure UpdateTableNull
create proc UpdateTableNull @NAMETABLE nvarchar(50)
as
	Update TABLEF
	set STT	= N'TRONG',TOTAL=0
	where NAME = @NAMETABLE

exec UpdateTableNull N'Bàn 01'

select * from dbo.getTableF()

--Tạo procedure DeleteBillTable
create proc DeleteBillTable @NAMETABLE nvarchar(50)
as
	Delete BILL where NAMETABLE = @NAMETABLE

exec DeleteBillTable N'Bàn 01'

--Tạo procedure UpdateAccount
create proc UpdateAccountInfo @PASSWORD nvarchar(50), @DISPLAYNAME nvarchar(50), @USERNAME nvarchar(50)
as
	Update ACCOUNT
	set PASSWORD = @PASSWORD, DISPLAYNAME=@DISPLAYNAME
	where USERNAME=@USERNAME

exec UpdateAccountInfo 'ccduynek', 'Ka Ta 1', 'kata'

select * from dbo.ACCOUNT

--Tạo procedure UpdateChangeTable
create proc UpdateChangeTable @CURRENTTABLE nvarchar(50), @TABLECHANGE nvarchar(50)
as
	Update TABLEF
	set NAME = @TABLECHANGE
	where NAME = @CURRENTTABLE


select * from dbo.ACCOUNT

--Đăng nhập, Main, Category, Nhân Viên, Account, TableF(Ko có update), Bill, Food, Pay