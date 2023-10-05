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
	insert into Users Values ( 'admin','admin@gmail.com','admin123',getdate());
	insert into Users Values ( 'user1','user1@gmail.com','123',getdate());
	insert into Users Values ( 'user2','user2@gmail.com','123',getdate());
	insert into Users Values ( 'user3','user3@gmail.com','123',getdate());
	set dateformat dmy
	

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

	insert into SanPham Values ('SP31','Samsung Galaxy A51 5G','LH02','CT02', N'Cái',6300000, 6900000,50);
	insert into SanPham Values ('SP32','Samsung Galaxy A14','LH02','CT02', N'Cái',2300000, 2450000,50);
	insert into SanPham Values ('SP33','OPPO Find N2 Flip 5G','LH03','CT03', N'Cái',18000000, 19900000,50);
	insert into SanPham Values ('SP34','OPPO Reno9 T 5G','LH03','CT03', N'Cái',7700000, 8400000,50);
	insert into SanPham Values ('SP35','OPPO Reno7 series','LH03','CT03', N'Cái',12500000, 13900000,50);
	insert into SanPham Values ('SP36','OPPO A72s','LH03','CT03', N'Cái',4700000, 5000000,50);
	insert into SanPham Values ('SP37','OPPO A36','LH03','CT03', N'Cái',3700000, 4100000,50);
	insert into SanPham Values ('SP38','OPPO A52','LH03','CT03', N'Cái',5300000, 5700000,50);
	insert into SanPham Values ('SP39','OPPO Reno10 5G','LH03','CT03', N'Cái',12700000, 12900000,50);
	insert into SanPham Values ('SP40','OPPO Find X2 Pro 5G','LH03','CT03', N'Cái',17700000, 17900000,50);
	insert into SanPham Values ('SP41','Samsung Galaxy A24','LH02','CT02', N'Cái',3800000, 4000000,50);

	insert into SanPham Values ('SP42','Samsung Galaxy Z Fold4 5G 256GB','LH02','CT02', N'Cái',23000000, 24500000,50);
	insert into SanPham Values ('SP43','IPhone 15 Pro 256GB','LH01','CT01', N'Cái',27000000,28000000,50);
	insert into SanPham Values ('SP44','IPhone 15 Pro 512GB','LH01','CT01', N'Cái',33000000,35000000,50);
	insert into SanPham Values ('SP45','IPhone 15 Pro 1TB','LH01','CT01', N'Cái',30000000,40000000,50);
	insert into SanPham Values ('SP46','OPPO A72s','LH03','CT03', N'Cái',4700000, 5000000,50);
	insert into SanPham Values ('SP47','OPPO A36','LH03','CT03', N'Cái',3700000, 4100000,50);
	insert into SanPham Values ('SP48','OPPO A52','LH03','CT03', N'Cái',5300000, 5700000,50);
	insert into SanPham Values ('SP49','OPPO Reno10 5G','LH03','CT03', N'Cái',12700000, 12900000,50);
	insert into SanPham Values ('SP50','OPPO Find X2 Pro 5G','LH03','CT03', N'Cái',17700000, 17900000,50);

	--Khach Hang--
	insert into KhachHang Values ('KH01', N'Nguyễn Quốc An',N'Cần Thơ','0123456789','nguyenquocan300503@gmail.com');
	insert into KhachHang Values ('KH02', N'Huỳnh Phú Lộc',N'Cần Thơ','0135643589','huynhquloc@gmail.com');
	insert into KhachHang Values ('KH03', N'Bạch Gia Quốc',N'Hậu Giang','0135663789','bachgiacuoc@gmail.com');
	insert into KhachHang Values ('KH04', N'Ngô Thái Toàn',N'Sóc Trăng','025356789','ngothaitoan@gmail.com');
	insert into KhachHang Values ('KH05', N'Nguyễn Văn Hoài',N'Bạc Liêu','025746789','nguyenvanhai@gmail.com');
	insert into KhachHang Values ('KH06', N'Nguyễn Hoàng Đạo',N'Cần Thơ','0123443789','');
	insert into KhachHang Values ('KH07', N'Nguyễn Hoài Thương',N'Cần Thơ','0135643589','');
	insert into KhachHang Values ('KH08', N'Ngô Hải Nguyên Bách',N'Cần Thơ','013534379','');
	insert into KhachHang Values ('KH09', N'Lê Gia Bảo',N'Cần Thơ','0948405402','');
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
	insert into KhachHang Values ('KH28', N'Nguyễn Tuấn Khang',N'Cần Thơ','0257446789','');
	insert into KhachHang Values ('KH29', N'Nguyễn Văn Nghĩa',N'Bạc Liêu','0257496789','');
	insert into KhachHang Values ('KH30', N'Nguyễn Văn Hậu',N'Hậu Giang','0257376789','');
	insert into KhachHang Values ('KH31', N'Nguyễn Thị Ngân Thanh',N'Cần Thơ','0257076789','');
	insert into KhachHang Values ('KH32', N'Lê Văn Tình',N'Vĩnh Long','0257476789','');
	insert into KhachHang Values ('KH33', N'Nguyễn Phước Thọ',N'Cà Mau','0227476789','');

	insert into KhachHang Values ('KH34', N'Nguyễn Hữu Phước',N'Thanh Hóa','0227376789','');
	insert into KhachHang Values ('KH35', N'Nguyễn Thị Hồng Thủy',N'Hà Nội','0227476785','');
	insert into KhachHang Values ('KH36', N'Nguyễn Văn Hài',N'Tiền Giang','0227476759','');
	insert into KhachHang Values ('KH37', N'Nguyễn Văn Tuấn',N'Cần Thơ','0227476089','');
	insert into KhachHang Values ('KH40', N'Nguyễn Vĩnh Khang',N'Cần Thơ','0247446789','');
	insert into KhachHang Values ('KH41', N'Nguyễn Thị Hồng Ân',N'Mỹ Tho','0217496789','');
	insert into KhachHang Values ('KH42', N'Võ Thị Hồng Hoa',N'Hà Nội','0252376789','');
	insert into KhachHang Values ('KH43', N'Lê Thị Mỹ',N'Bắc Ninh','0457076789','');
	insert into KhachHang Values ('KH44', N'Lê Văn Minh',N'Vĩnh Long','0257476785','');
	insert into KhachHang Values ('KH45', N'Võ Thị Hồng My',N'Hậu Giang','0227476389','');
	insert into KhachHang Values ('KH46', N'Nguyễn Tuấn Khang',N'Cà Mau','0257426789','');
	insert into KhachHang Values ('KH47', N'Nguyễn Hữu Hậu',N'Bạc Liêu','0257416789','');
	insert into KhachHang Values ('KH48', N'Nguyễn Văn Hậu',N'Hậu Giang','0257376789','');
	insert into KhachHang Values ('KH49', N'Nguyễn Thị Thanh Ngân',N'Cần Thơ','0457076789','');
	insert into KhachHang Values ('KH50', N'Lê Văn Bách',N'Vĩnh Long','0257476759','');
	insert into KhachHang Values ('KH51', N'Nguyễn Hữu Thọ',N'Cà Mau','0227474789','');
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
	insert into HoaDon Values ('HD32', 'NV04','KH26','07-03-2023','07-03-2023');
	insert into HoaDon Values ('HD33', 'NV05','KH27','13-05-2023','13-05-2023');
	insert into HoaDon Values ('HD34', 'NV06','KH28','18-05-2023','19-05-2023');
	insert into HoaDon Values ('HD35', 'NV01','KH29','10-05-2023','10-05-2023');
	insert into HoaDon Values ('HD36', 'NV02','KH31','10-03-2023','12-03-2023');
	insert into HoaDon Values ('HD37', 'NV09','KH30','10-04-2023','10-04-2023');
	insert into HoaDon Values ('HD38', 'NV10','KH24','10-01-2023','11-01-2023');
	insert into HoaDon Values ('HD39', 'NV06','KH25','10-07-2023','10-07-2023');
	insert into HoaDon Values ('HD40', 'NV07','KH21','10-09-2023','10-09-2023');
	insert into HoaDon Values ('HD41', 'NV01','KH04','22-09-2023','23-09-2023');

	insert into HoaDon Values ('HD42', 'NV01','KH30','07-03-2023','07-03-2023');
	insert into HoaDon Values ('HD43', 'NV06','KH31','13-05-2023','13-05-2023');
	insert into HoaDon Values ('HD44', 'NV06','KH32','18-05-2023','19-05-2023');
	insert into HoaDon Values ('HD45', 'NV01','KH33','10-05-2023','10-05-2023');
	insert into HoaDon Values ('HD46', 'NV05','KH34','10-03-2023','12-03-2023');
	insert into HoaDon Values ('HD47', 'NV08','KH35','10-04-2023','10-04-2023');
	insert into HoaDon Values ('HD48', 'NV10','KH35','10-01-2023','11-01-2023');
	insert into HoaDon Values ('HD49', 'NV06','KH37','10-07-2023','10-07-2023');
	insert into HoaDon Values ('HD50', 'NV02','KH36','10-09-2023','10-09-2023');

	insert into HoaDon Values ('HD51', 'NV01','KH04','22-09-2023','23-09-2023');
	insert into HoaDon Values ('HD52', 'NV02','KH37','04-03-2023','04-03-2023');
	insert into HoaDon Values ('HD53', 'NV06','KH31','13-06-2023','18-06-2023');
	insert into HoaDon Values ('HD54', 'NV03','KH32','18-12-2023','19-12-2023');
	insert into HoaDon Values ('HD55', 'NV01','KH44','12-05-2023','12-05-2023');
	insert into HoaDon Values ('HD56', 'NV05','KH45','10-03-2023','12-03-2023');
	insert into HoaDon Values ('HD57', 'NV08','KH46','23-02-2023','23-02-2023');
	insert into HoaDon Values ('HD58', 'NV10','KH47','10-01-2023','11-01-2023');
	insert into HoaDon Values ('HD59', 'NV07','KH40','10-07-2023','10-07-2023');
	insert into HoaDon Values ('HD60', 'NV08','KH48','10-11-2023','10-11-2023');


	insert into HoaDon Values ('HD61', 'NV01','KH45','22-01-2023','23-01-2023');
	insert into HoaDon Values ('HD62', 'NV02','KH37','04-06-2023','04-06-2023');
	insert into HoaDon Values ('HD63', 'NV06','KH42','13-06-2023','18-06-2023');
	insert into HoaDon Values ('HD64', 'NV10','KH11','18-12-2023','19-12-2023');
	insert into HoaDon Values ('HD65', 'NV04','KH43','12-05-2023','12-05-2023');
	insert into HoaDon Values ('HD66', 'NV10','KH45','10-03-2023','12-03-2023');
	insert into HoaDon Values ('HD67', 'NV08','KH51','23-02-2023','23-02-2023');
	insert into HoaDon Values ('HD68', 'NV09','KH47','10-01-2023','11-01-2023');
	insert into HoaDon Values ('HD69', 'NV07','KH50','10-07-2023','10-07-2023');
	insert into HoaDon Values ('HD70', 'NV08','KH51','10-11-2023','10-11-2023');

	insert into HoaDon Values ('HD71', 'NV01','KH45','22-01-2023','23-01-2023');
	insert into HoaDon Values ('HD72', 'NV02','KH37','10-11-2023','10-11-2023');
	insert into HoaDon Values ('HD73', 'NV06','KH42','13-06-2023','18-06-2023');
	insert into HoaDon Values ('HD74', 'NV10','KH11','18-12-2023','19-12-2023');
	insert into HoaDon Values ('HD75', 'NV04','KH43','12-05-2023','12-05-2023');
	insert into HoaDon Values ('HD76', 'NV10','KH45','10-04-2023','12-04-2023');
	insert into HoaDon Values ('HD77', 'NV08','KH51','23-02-2023','23-02-2023');
	insert into HoaDon Values ('HD78', 'NV09','KH47','10-08-2023','11-08-2023');
	insert into HoaDon Values ('HD79', 'NV07','KH50','10-07-2023','10-07-2023');


		insert into HoaDon Values ('HD80', 'NV01','KH04','22-02-2023','23-02-2023');
	insert into HoaDon Values ('HD81', 'NV01','KH04','22-09-2023','23-09-2023');
	insert into HoaDon Values ('HD82', 'NV02','KH37','04-03-2023','04-03-2023');
	insert into HoaDon Values ('HD83', 'NV06','KH31','13-06-2023','18-06-2023');
	insert into HoaDon Values ('HD84', 'NV03','KH32','18-12-2023','19-12-2023');
	insert into HoaDon Values ('HD85', 'NV01','KH44','12-05-2023','12-05-2023');
	insert into HoaDon Values ('HD86', 'NV05','KH45','10-03-2023','12-03-2023');
	insert into HoaDon Values ('HD87', 'NV08','KH46','23-02-2023','23-02-2023');
	insert into HoaDon Values ('HD88', 'NV10','KH47','10-01-2023','11-01-2023');
	insert into HoaDon Values ('HD89', 'NV07','KH40','10-07-2023','10-07-2023');
	insert into HoaDon Values ('HD90', 'NV08','KH48','10-11-2023','10-11-2023');

	insert into HoaDon Values ('HD91', 'NV01','KH16','22-08-2023','23-08-2023');
	insert into HoaDon Values ('HD92', 'NV05','KH04','04-09-2023','04-09-2023');
	insert into HoaDon Values ('HD93', 'NV06','KH08','13-11-2023','18-11-2023');
	insert into HoaDon Values ('HD94', 'NV09','KH32','18-12-2023','19-12-2023');
	insert into HoaDon Values ('HD95', 'NV01','KH44','12-05-2023','12-05-2023');
	insert into HoaDon Values ('HD96', 'NV09','KH06','10-03-2023','12-03-2023');
	insert into HoaDon Values ('HD97', 'NV08','KH44','23-02-2023','23-02-2023');
	insert into HoaDon Values ('HD98', 'NV10','KH47','10-10-2023','11-10-2023');
	insert into HoaDon Values ('HD99', 'NV07','KH40','10-07-2023','10-07-2023');
	insert into HoaDon Values ('HD100', 'NV08','KH48','10-11-2023','10-11-2023');

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



insert into ChiTietHoaDon Values ('HD20', 'SP11',1);
 insert into ChiTietHoaDon Values ('HD21', 'SP12',1);
 insert into ChiTietHoaDon Values ('HD22', 'SP13',1);
 insert into ChiTietHoaDon Values ('HD23', 'SP11',1);
 insert into ChiTietHoaDon Values ('HD24', 'SP01',1);
 insert into ChiTietHoaDon Values ('HD25', 'SP131',1);
 insert into ChiTietHoaDon Values ('HD26', 'SP08',1);
 insert into ChiTietHoaDon Values ('HD27', 'SP08',1);
 insert into ChiTietHoaDon Values ('HD28', 'SP09',1);
 insert into ChiTietHoaDon Values ('HD29', 'SP30',1);
 insert into ChiTietHoaDon Values ('HD30', 'SP23',1);
 insert into ChiTietHoaDon Values ('HD31', 'SP27',1);
 insert into ChiTietHoaDon Values ('HD32', 'SP24',1);
 insert into ChiTietHoaDon Values ('HD33', 'SP25',1);
 insert into ChiTietHoaDon Values ('HD34', 'SP23',1);
 insert into ChiTietHoaDon Values ('HD35', 'SP31',1);
 insert into ChiTietHoaDon Values ('HD36', 'SP02',1);
 insert into ChiTietHoaDon Values ('HD37', 'SP06',1);
 insert into ChiTietHoaDon Values ('HD38', 'SP05',1);
 insert into ChiTietHoaDon Values ('HD39', 'SP09',1);
 insert into ChiTietHoaDon Values ('HD40', 'SP10',1);
 insert into ChiTietHoaDon Values ('HD41', 'SP30',1);
 insert into ChiTietHoaDon Values ('HD42', 'SP16',1);
 insert into ChiTietHoaDon Values ('HD43', 'SP17',1);
 insert into ChiTietHoaDon Values ('HD44', 'SP15',1);
 insert into ChiTietHoaDon Values ('HD45', 'SP14',1);
 insert into ChiTietHoaDon Values ('HD46', 'SP13',1);
 insert into ChiTietHoaDon Values ('HD47', 'SP25',1);
 insert into ChiTietHoaDon Values ('HD48', 'SP29',1);
 insert into ChiTietHoaDon Values ('HD49', 'SP28',1);
 insert into ChiTietHoaDon Values ('HD50', 'SP26',1);
 insert into ChiTietHoaDon Values ('HD51', 'SP23',1);
 insert into ChiTietHoaDon Values ('HD52', 'SP21',1);
 insert into ChiTietHoaDon Values ('HD53', 'SP20',1);
 insert into ChiTietHoaDon Values ('HD54', 'SP11',1);
 insert into ChiTietHoaDon Values ('HD55', 'SP12',1);
 insert into ChiTietHoaDon Values ('HD56', 'SP13',1);
 insert into ChiTietHoaDon Values ('HD57', 'SP14',1);
 insert into ChiTietHoaDon Values ('HD58', 'SP14',1);
 insert into ChiTietHoaDon Values ('HD59', 'SP16',1);
 insert into ChiTietHoaDon Values ('HD60', 'SP17',1);
 insert into ChiTietHoaDon Values ('HD61', 'SP18',1);
 insert into ChiTietHoaDon Values ('HD62', 'SP19',1);
 insert into ChiTietHoaDon Values ('HD63', 'SP20',1);
 insert into ChiTietHoaDon Values ('HD64', 'SP03',1);
 insert into ChiTietHoaDon Values ('HD65', 'SP04',1);
 insert into ChiTietHoaDon Values ('HD66', 'SP05',1);
 insert into ChiTietHoaDon Values ('HD67', 'SP06',1);
 insert into ChiTietHoaDon Values ('HD68', 'SP07',1);
 insert into ChiTietHoaDon Values ('HD69', 'SP31',1);
 insert into ChiTietHoaDon Values ('HD70', 'SP09',1);
 insert into ChiTietHoaDon Values ('HD71', 'SP08',1);
 insert into ChiTietHoaDon Values ('HD72', 'SP12',1);
 insert into ChiTietHoaDon Values ('HD73', 'SP13',1);
 insert into ChiTietHoaDon Values ('HD74', 'SP14',1);
 insert into ChiTietHoaDon Values ('HD75', 'SP15',1);
 insert into ChiTietHoaDon Values ('HD76', 'SP16',1);
 insert into ChiTietHoaDon Values ('HD77', 'SP17',1);
 insert into ChiTietHoaDon Values ('HD78', 'SP18',1);
 insert into ChiTietHoaDon Values ('HD79', 'SP19',1);
 insert into ChiTietHoaDon Values ('HD80', 'SP20',1);
 insert into ChiTietHoaDon Values ('HD81', 'SP22',1);
 insert into ChiTietHoaDon Values ('HD82', 'SP23',1);
 insert into ChiTietHoaDon Values ('HD83', 'SP24',1);
 insert into ChiTietHoaDon Values ('HD84', 'SP25',1);
 insert into ChiTietHoaDon Values ('HD85', 'SP26',1);
 insert into ChiTietHoaDon Values ('HD86', 'SP27',1);
 insert into ChiTietHoaDon Values ('HD87', 'SP28',1);
 insert into ChiTietHoaDon Values ('HD88', 'SP29',1);
 insert into ChiTietHoaDon Values ('HD89', 'SP30',1);
 insert into ChiTietHoaDon Values ('HD90', 'SP31',1);
 insert into ChiTietHoaDon Values ('HD91', 'SP32',1);
 insert into ChiTietHoaDon Values ('HD92', 'SP33',1);
 insert into ChiTietHoaDon Values ('HD93', 'SP34',1);
 insert into ChiTietHoaDon Values ('HD94', 'SP35',1);
 insert into ChiTietHoaDon Values ('HD95', 'SP36',1);
 insert into ChiTietHoaDon Values ('HD96', 'SP37',1);
 insert into ChiTietHoaDon Values ('HD97', 'SP38',1);
 insert into ChiTietHoaDon Values ('HD98', 'SP39',1);
 insert into ChiTietHoaDon Values ('HD99', 'SP40',1);
 insert into ChiTietHoaDon Values ('HD100', 'SP41',1);