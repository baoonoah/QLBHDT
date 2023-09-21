create database QLBHDT
use QLBHDT
	create table NhanVien

	(
   		MaNV nvarchar(20) not null,
   		HoLot nvarchar(30) not null,
		Ten nvarchar (10) not null,
   		NgaySinh datetime not null,
   		DiaChi nvarchar(255) not null,
   		DienThoai nvarchar(15) not null,
   		Constraint  PK_MaNV Primary key (MaNV),
	)
	create table KhachHang
	(
   		MaKH nvarchar(20) not null,
   		TenKH nvarchar(30) not null,
		DiaChi nvarchar(255) not null,
   		DienThoai nvarchar(15) not null,
		Email nvarchar(30),
   		Constraint  PK_MaKH Primary key (MaKH),

	)

	create table LoaiHang

	(
   		MaLoaiHang nvarchar(20) not null,
   		TenLoaiHang nvarchar(30) not null,
   		Constraint  PK_MaLoaiHang Primary key (MaLoaiHang)
	)

	create table NhaCungCap

	(
   		MaCongTy nvarchar(20) not null,
   		TenCongTy nvarchar(50) not null,
   		DiaChi nvarchar(255) not null,
   		DienThoai nvarchar(20) not null,
   		Constraint  PK_MaCongTy Primary key (MaCongTy)
	)
	create table SanPham
	(
   		MaSP nvarchar(20) not null,
 		TenSP nvarchar(255) not null,
   		MaLoaiHang nvarchar(20) not null,
   		MaCongTy nvarchar(20) not null,
   		DonViTinh nvarchar(10) not null,
   		GiaNhap numeric(10, 0) not null,
   		GiaBan numeric(10, 0) not null,    
   		SoLuong numeric (18, 0 ) not null
   		Constraint  PK_MASP Primary key (MaSP),
   		Constraint  FK_MaCongTy_SanPham foreign key (MaCongTy) references NhaCungCap(MaCongTy),
   		Constraint  FK_MaLoaiHang_SanPham foreign key (MaLoaiHang) references LoaiHang(MaLoaiHang),
   		Constraint CK_SoLuong check (SoLuong >=0),
   		Constraint CK_GiaNhap check (GiaNhap >=0),
   		Constraint CK_GiaBan check (GiaBan >=0),
	)



	create table HoaDon
	(
   		MaHD nvarchar(20) not null,
   		MaNV nvarchar(20) not null,
   		MaKH nvarchar(20) not null,
   		NgayLapHD datetime not null,
   		NgayNhanHang datetime not null,
   		Constraint  PK_MaHD Primary key (MaHD),
   		Constraint  FK_MaNV_HoaDon foreign key (MaNV) references NhanVien(MaNV),
   		Constraint  FK_MaKH_HoaDon foreign key (MaKH) references KhachHang(MaKH),
   		Constraint CK_NgayNhanHang check (NgayNhanHang >= NgayLapHD),
     
	)


	create table ChiTietHoaDon

	(
   		MaHD nvarchar(20) not null,
   		MaSP nvarchar(20) not null,
   		SoLuong numeric (18, 0 ) not null,
   		Constraint  PK_ChiTietHoaDon Primary key (MaHD,MaSP),
   		Constraint  FK_MaHD_ChiTietHoaDon foreign key (MaHD) references HoaDon(MaHD),
   		Constraint  FK_MaSP_ChiTietHoaDon foreign key (MaSP) references SanPham(MaSP),
   		Constraint CK_SoLuong_ChiTietHoaDon check (SoLuong >=0),


	)

	CREATE TABLE Users (
		Id INT PRIMARY KEY,
		Username VARCHAR(255) NOT NULL,
		Email VARCHAR(255) NOT NULL,
		Password VARCHAR(255) NOT NULL,
		ThoiGianTao DATETIME DEFAULT GETDATE()
	);



	--User--
	insert into Users Values (1, 'admin','admin@gmail.com','admin123','');
	insert into Users Values (2, 'user1','user1@gmail.com','user123','');
	insert into Users Values (3, 'user2','user2@gmail.com','user123','');


	--Nhan vien--
	insert into NhanVien Values ('NV01', N'Nguyễn Ngọc', N'Bích', '07-08-1998',N'89 Đặng Khôi', '0918557788');
	insert into NhanVien Values ('NV02', N'Hà Vĩnh', N'Phát', '09-08-1996',N'26 Lê Quý Đôn', '0918352074');
	insert into NhanVien Values ('NV03', N'Trần Tuyết', N'Oanh', '07-05-1997',N'77 Trương Định', '0918409295');
	insert into NhanVien Values ('NV04', N'Nguyễn Kim', N'Ngọc', '08-02-1995',N'92 Lê Thánh Tôn', '0918552666');
	insert into NhanVien Values ('NV05', N'Nguyễn Văn', N'Thanh', '02-02-1995',N'62A Cách Mạng Tháng Tám', '0918356645');
	insert into NhanVien Values ('NV06', N'Lê Thị', N'Diệu', '07-04-1997',N'62A Cách Mạng Tháng Tám', '0918356645');
	insert into NhanVien Values ('NV07', N'Nguyễn Thị Hồng', N'Hạnh', '03-03-1993',N'22A Hòa Bình', '0918356645');
	insert into NhanVien Values ('NV08', N'Đinh Thị', N'Thúy', '07-02-1998',N'15A 30 tháng 4', '0918356645');
	insert into NhanVien Values ('NV09', N'Võ Thị Hồng', N'My', '02-12-1999',N'22A Cách Mạng Tháng Tám', '0918356645');
	insert into NhanVien Values ('NV10', N'Nguyễn Thành', N'Tín', '02-10-1999',N'23A Cách Mạng Tháng Tám', '0918356645');
	--Loai Hang--
	insert into LoaiHang Values ('LH01', 'Iphone');
	insert into LoaiHang Values ('LH02', 'Samsung');
	insert into LoaiHang Values ('LH03', 'Oppo');
	insert into LoaiHang Values ('LH04', 'Xiaomi');
	--nha cung cap--
	insert into NhaCungCap Values ('CT01', 'Apple',N'Tòa nhà Deutsches Haus Ho Chi Minh City, Số 33, đường Lê Duẩn, phường Bến Nghé, quận 1,TP. Hồ Chí Minh, Việt Nam','18001192');
	insert into NhaCungCap Values ('CT02', 'Samsung',N'Tầng 3, Crescent Mall, 101 Tôn Dật Tiên, P. Tân Phú, Q.7, TP.HCM.','1800-588-890');
	insert into NhaCungCap Values ('CT03', 'Oppo',N'62A Cách Mạng Tháng Tám, phường Võ Thị Sáu, Quận 3, TP.HCM.','1800-588841');
	insert into NhaCungCap Values ('CT04', 'Xiaomi',N'Xiaomi Office Building, 68 Qinghe Middle Street, Beijing, Beijing, 100085','86-010-60606666');
	--San Pham--
	insert into SanPham Values ('SP01','IPhone 14 Pro Max 128GB','LH01','CT01', N'Cái',23000000,25000000,50);
	insert into SanPham Values ('SP02','Samsung Galaxy Z Fold5 5G','LH02','CT02', N'Cái',35000000, 36900000,50);
	insert into SanPham Values ('SP03','OPPO Reno10 5G','LH03','CT03', N'Cái',9700000, 9900000,50);
	insert into SanPham Values ('SP04','Xiaomi Redmi Note 12 Pro 5G','LH04','CT04', N'Cái',11000000, 12000000,50);
	insert into SanPham Values ('SP05','IPhone 13 Pro Max 256GB','LH01','CT01', N'Cái',17000000,18000000,50);
	insert into SanPham Values ('SP06','IPhone 12 Pro 256GB','LH01','CT01', N'Cái',15000000,17500000,50);
	insert into SanPham Values ('SP07','IPhone 12 Mini 128GB','LH01','CT01', N'Cái',12000000,14500000,50);
	insert into SanPham Values ('SP08','IPhone 11 Pro 128GB','LH01','CT01', N'Cái',13000000,13500000,50);
	insert into SanPham Values ('SP09','IPhone X','LH01','CT01', N'Cái',10000000,11000000,50);
	insert into SanPham Values ('SP10','IPhone 8 Plus','LH01','CT01', N'Cái',7800000,8000000,50);
	insert into SanPham Values ('SP11','Xiaomi 12T','LH04','CT04', N'Cái',10000000, 12000000,50);
	insert into SanPham Values ('SP12','Xiaomi Redmi 12','LH04','CT04', N'Cái',3500000, 3790000,50);
	insert into SanPham Values ('SP13','Xiaomi 13 Series','LH04','CT04', N'Cái',16000000, 16990000,50);
	insert into SanPham Values ('SP14','Xiaomi K30 5G Racing Edition','LH04','CT04', N'Cái',57000000, 600000,50);
	insert into SanPham Values ('SP15','Xiaomi 12 5G','LH04','CT04', N'Cái',11000000, 12000000,50);
	insert into SanPham Values ('SP16','Samsung Galaxy A24','LH02','CT02', N'Cái',6000000, 6200000,50);
	insert into SanPham Values ('SP17','Samsung Galaxy S23 Ultra 5G','LH02','CT02', N'Cái',24000000,25900000,50);
	insert into SanPham Values ('SP18','Samsung Galaxy S21 FE 5G','LH02','CT02', N'Cái',9000000, 9990000,50);
	insert into SanPham Values ('SP19','Samsung Galaxy Z Flip5 5G','LH02','CT02', N'Cái',20000000, 21900000,50);
	insert into SanPham Values ('SP20','Samsung Galaxy A54 5G','LH02','CT02', N'Cái',9300000, 9900000,50);
	insert into SanPham Values ('SP21','Samsung Galaxy A23','LH02','CT02', N'Cái',3800000, 4000000,50);
	insert into SanPham Values ('SP22','Samsung Galaxy A04','LH02','CT02', N'Cái',2300000, 2450000,50);
	insert into SanPham Values ('SP23','OPPO Find N2 Flip 5G','LH03','CT03', N'Cái',18000000, 19900000,50);
	insert into SanPham Values ('SP24','OPPO Reno8 T 5G','LH03','CT03', N'Cái',7700000, 8400000,50);
	insert into SanPham Values ('SP25','OPPO Reno8 series','LH03','CT03', N'Cái',12500000, 13900000,50);
	insert into SanPham Values ('SP26','OPPO A77s','LH03','CT03', N'Cái',4700000, 5000000,50);
	insert into SanPham Values ('SP27','OPPO A38','LH03','CT03', N'Cái',3700000, 4100000,50);
	insert into SanPham Values ('SP28','OPPO A58','LH03','CT03', N'Cái',5300000, 5700000,50);
	insert into SanPham Values ('SP29','OPPO Reno10 Pro 5G','LH03','CT03', N'Cái',13700000, 13900000,50);
	insert into SanPham Values ('SP30','OPPO Find X5 Pro 5G','LH03','CT03', N'Cái',17700000, 17900000,50);
	--Khach Hang--
	insert into KhachHang Values ('KH01', N'Nguyễn Quốc An',N'Cần Thơ','0123456789','nguyenquocan300503@gmail.com');
	insert into KhachHang Values ('KH02', N'Huỳnh Phú Lộc',N'Cần Thơ','0135643589','huynhquloc@gmail.com');
	insert into KhachHang Values ('KH03', N'Bạch Gia Quốc',N'Hậu Giang','0135663789','bachgiacuoc@gmail.com');
	insert into KhachHang Values ('KH04', N'Ngô Thái Toàn',N'Sóc Trăng','025356789','ngothaitoan@gmail.com');
	insert into KhachHang Values ('KH05', N'Nguyễn Văn Hoài',N'Bạc Liêu','025746789','nguyenvanhai@gmail.com');
	insert into KhachHang Values ('KH06', N'Nguyễn Hoàng Đạo',N'Cần Thơ','0123443789','');
	insert into KhachHang Values ('KH07', N'Nguyễn Hoài Thương',N'Cần Thơ','0135643589','');
	insert into KhachHang Values ('KH08', N'Ngô Hải Nguyên Bách',N'Cần Thơ','013534379','');
	insert into KhachHang Values ('KH09', N'Lê Gia Bảo',N'Cần Thơ','025466789','');
	insert into KhachHang Values ('KH10', N'Nguyễn Văn Khánh',N'Cần Thơ','025236789','');
	insert into KhachHang Values ('KH11', N'Nguyễn Bá Đạt',N'Cần Thơ','025724789','');
	insert into KhachHang Values ('KH12', N'Nguyễn Bá Đạo',N'Cần Thơ','022324789','');
	insert into KhachHang Values ('KH13', N'Nguyễn Văn A',N'Cần Thơ','025723589','');
	insert into KhachHang Values ('KH14', N'Nguyễn Văn B',N'Cần Thơ','02354789','');
	insert into KhachHang Values ('KH15', N'Nguyễn Văn C',N'Cần Thơ','02356789','');
	insert into KhachHang Values ('KH16', N'Nguyễn Văn D',N'Cần Thơ','02334789','');
	insert into KhachHang Values ('KH17', N'Nguyễn Văn E',N'Cần Thơ','02354789','');
	insert into KhachHang Values ('KH18', N'Nguyễn Văn F',N'Cần Thơ','02355789','');
	insert into KhachHang Values ('KH19', N'Nguyễn Văn J',N'Cần Thơ','02358789','');
	insert into KhachHang Values ('KH20', N'Nguyễn Văn K',N'Cần Thơ','02354789','');
	insert into KhachHang Values ('KH21', N'Nguyễn Văn L',N'Cần Thơ','02354289','');
	insert into KhachHang Values ('KH22', N'Nguyễn Văn M',N'Cần Thơ','02354189','');
	insert into KhachHang Values ('KH23', N'Nguyễn Văn N',N'Cần Thơ','02354709','');
	insert into KhachHang Values ('KH24', N'Nguyễn Văn H',N'Cần Thơ','02354779','');
	insert into KhachHang Values ('KH25', N'Nguyễn Văn T',N'Cần Thơ','02354739','');
	--Hoa Don--
	insert into HoaDon Values ('HD01', 'NV01','KH01','10-05-2023','14-05-2023');
	insert into HoaDon Values ('HD02', 'NV02','KH02','10-06-2023','13-06-2023');
	insert into HoaDon Values ('HD03', 'NV03','KH03','07-07-2023','19-07-2023');
	insert into HoaDon Values ('HD04', 'NV04','KH04','10-08-2023','13-08-2023');
	insert into HoaDon Values ('HD05', 'NV05','KH05','10-09-2023','13-09-2023');
	insert into HoaDon Values ('HD06', 'NV01','KH09','10-05-2023','14-05-2023');
	insert into HoaDon Values ('HD07', 'NV01','KH08','10-06-2023','13-06-2023');
	insert into HoaDon Values ('HD08', 'NV04','KH07','07-07-2023','19-07-2023');
	insert into HoaDon Values ('HD09', 'NV04','KH06','10-08-2023','13-08-2023');
	insert into HoaDon Values ('HD10', 'NV05','KH10','10-09-2023','13-09-2023');
	insert into HoaDon Values ('HD11', 'NV04','KH07','07-07-2023','19-07-2023');
	insert into HoaDon Values ('HD12', 'NV04','KH06','10-08-2023','13-08-2023');
	insert into HoaDon Values ('HD13', 'NV05','KH10','10-09-2023','13-09-2023');
	insert into HoaDon Values ('HD14', 'NV04','KH07','07-07-2023','19-07-2023');
	insert into HoaDon Values ('HD15', 'NV04','KH02','10-08-2023','13-08-2023');
	insert into HoaDon Values ('HD16', 'NV02','KH15','10-10-2023','13-10-2023');
	insert into HoaDon Values ('HD17', 'NV04','KH16','07-11-2023','19-11-2023');
	insert into HoaDon Values ('HD18', 'NV04','KH12','10-12-2023','13-12-2023');
	insert into HoaDon Values ('HD19', 'NV05','KH13','10-11-2023','13-11-2023');
	insert into HoaDon Values ('HD20', 'NV04','KH15','07-03-2023','19-03-2023');
	insert into HoaDon Values ('HD21', 'NV04','KH19','10-02-2023','13-02-2023');
	insert into HoaDon Values ('HD22', 'NV02','KH17','10-05-2023','13-05-2023');
	insert into HoaDon Values ('HD23', 'NV05','KH11','10-05-2023','13-05-2023');
	insert into HoaDon Values ('HD24', 'NV06','KH20','18-05-2023','20-05-2023');
	insert into HoaDon Values ('HD25', 'NV07','KH14','10-05-2023','13-05-2023');
	insert into HoaDon Values ('HD26', 'NV02','KH18','10-03-2023','13-03-2023');
	insert into HoaDon Values ('HD27', 'NV09','KH23','10-04-2023','13-04-2023');
	insert into HoaDon Values ('HD28', 'NV10','KH24','10-05-2023','13-05-2023');
	insert into HoaDon Values ('HD29', 'NV06','KH25','10-07-2023','13-07-2023');
	insert into HoaDon Values ('HD30', 'NV08','KH21','10-09-2023','13-09-2023');
	insert into HoaDon Values ('HD31', 'NV01','KH01','10-09-2023','13-09-2023');

	set dateformat dmy
	--Chi Tiet Hoa Don
	
	insert into ChiTietHoaDon Values ('HD01', 'SP02',2);
	insert into ChiTietHoaDon Values ('HD01', 'SP01',1);
	insert into ChiTietHoaDon Values ('HD02', 'SP05',1);
	insert into ChiTietHoaDon Values ('HD03', 'SP07',1);
	insert into ChiTietHoaDon Values ('HD03', 'SP09',1);
	insert into ChiTietHoaDon Values ('HD03', 'SP10',1);
	insert into ChiTietHoaDon Values ('HD03', 'SP11',1);
	insert into ChiTietHoaDon Values ('HD04', 'SP03',1);
	insert into ChiTietHoaDon Values ('HD05', 'SP30',1);
	insert into ChiTietHoaDon Values ('HD02', 'SP01',1);
	insert into ChiTietHoaDon Values ('HD03', 'SP04',1);
	insert into ChiTietHoaDon Values ('HD04', 'SP02',1);
	insert into ChiTietHoaDon Values ('HD05', 'SP29',1);
	insert into ChiTietHoaDon Values ('HD06', 'SP05',1);
	insert into ChiTietHoaDon Values ('HD07', 'SP07',1);
	insert into ChiTietHoaDon Values ('HD08', 'SP03',1);
	insert into ChiTietHoaDon Values ('HD09', 'SP30',1);
	insert into ChiTietHoaDon Values ('HD07', 'SP05',1);
	insert into ChiTietHoaDon Values ('HD06', 'SP07',1);
	insert into ChiTietHoaDon Values ('HD10', 'SP03',1);
	insert into ChiTietHoaDon Values ('HD10', 'SP04',1);
	insert into ChiTietHoaDon Values ('HD10', 'SP05',1);
	insert into ChiTietHoaDon Values ('HD10', 'SP06',1);
	insert into ChiTietHoaDon Values ('HD01', 'SP08',1);
	insert into ChiTietHoaDon Values ('HD30', 'SP09',1);
	insert into ChiTietHoaDon Values ('HD30', 'SP02',1);
	insert into ChiTietHoaDon Values ('HD30', 'SP01',1);
	insert into ChiTietHoaDon Values ('HD30', 'SP04',1);
	insert into ChiTietHoaDon Values ('HD30', 'SP22',1);
	insert into ChiTietHoaDon Values ('HD29', 'SP10',1);
	insert into ChiTietHoaDon Values ('HD28', 'SP02',1);
	insert into ChiTietHoaDon Values ('HD26', 'SP07',1);
	insert into ChiTietHoaDon Values ('HD28', 'SP09',2);
	insert into ChiTietHoaDon Values ('HD25', 'SP07',1);
	insert into ChiTietHoaDon Values ('HD25', 'SP02',1);
	insert into ChiTietHoaDon Values ('HD24', 'SP24',2);
	insert into ChiTietHoaDon Values ('HD28', 'SP30',1);
	insert into ChiTietHoaDon Values ('HD23', 'SP10',1);
	insert into ChiTietHoaDon Values ('HD22', 'SP01',1);
	insert into ChiTietHoaDon Values ('HD21', 'SP03',1);
	insert into ChiTietHoaDon Values ('HD20', 'SP16',1);
	insert into ChiTietHoaDon Values ('HD20', 'SP17',1);
	insert into ChiTietHoaDon Values ('HD19', 'SP05',1);
	insert into ChiTietHoaDon Values ('HD18', 'SP08',1);
	insert into ChiTietHoaDon Values ('HD17', 'SP13',1);
	insert into ChiTietHoaDon Values ('HD16', 'SP14',1);
	insert into ChiTietHoaDon Values ('HD15', 'SP17',2);
	insert into ChiTietHoaDon Values ('HD14', 'SP03',1);
	insert into ChiTietHoaDon Values ('HD13', 'SP07',1);
	insert into ChiTietHoaDon Values ('HD12', 'SP03',1);
	insert into ChiTietHoaDon Values ('HD11', 'SP05',1);
	insert into ChiTietHoaDon Values ('HD12', 'SP05',1);
	insert into ChiTietHoaDon Values ('HD13', 'SP27',1);
	insert into ChiTietHoaDon Values ('HD31', 'SP04',1);

	set dateformat dmy
	SELECT * FROM NhaCungCap
	SELECT * FROM  LoaiHang
	SELECT * FROM SanPham
	SELECT * FROM NhanVien
	SELECT * FROM KhachHang
	SELECT * FROM HoaDon
	SELECT * FROM ChiTietHoaDon

--sản phẩm bán nhiều nhất
SELECT A.MaSP,B.TenSP, SUM(A.SoLuong) AS TongSoLuongBan
FROM ChiTietHoaDon as A , SanPham as B
GROUP BY A.MaSP,B.TenSP 
ORDER BY TongSoLuongBan DESC;

--Khách hàng mua nhiều nhất
SELECT  MaKH, COUNT(*) AS SoLanMua
FROM HoaDon
GROUP BY MaKH
ORDER BY SoLanMua DESC;