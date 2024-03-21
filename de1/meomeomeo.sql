Create Database onthiTH1
use onthiTH1

create table GIANG_VIEN
(
	Ma_GV nvarchar(10) not null,
	primary key(Ma_GV),
	Ten_GV nvarchar(30),
	Sdt_GV nvarchar(15),
	Email_GV nvarchar(30),

)

create table PHONG
(
	Ma_phong nvarchar(10) not null,
	primary key(Ma_phong),
	Ten_phong nvarchar(30),
	Vitri_phong nvarchar(30),
	Nguoi_quanly nvarchar(10) not null,
	Constraint FK_Nguoi_quanly_Phong foreign key (Nguoi_quanly) references GIANG_VIEN(Ma_GV),
)

create table THIET_BI
(
	Ma_TB nvarchar(10) not null,
	primary key(Ma_TB),
	Ten_TB nvarchar(30),
	Code_TB nvarchar(30),
	Ngaynhap_TB datetime not null,
	Thongtin_TB nvarchar(30),
	Vitri_truoc_TB nvarchar(10) not null,
	Constraint FK_Vitri_truoc_TB_THIET_BI foreign key (Vitri_truoc_TB) references PHONG(Ma_phong),
	Vitri_hientai_TB nvarchar(10) not null,
	Constraint FK_Vitri_hientai_TB_THIET_BI foreign key (Vitri_hientai_TB) references PHONG(Ma_phong),
	Tinhtrang_TB nvarchar(40),
)

create table THANH_LY
(
	Ma_TL nvarchar(10) not null,
	primary key(Ma_TL),
	Ma_TB nvarchar(10) not null,
	Constraint FK_Ma_TB_THANH_LY foreign key (Ma_TB) references THIET_BI(Ma_TB),
	Ngaygiao_TB datetime not null,
	Nguoinhan_TB nvarchar(10) not null,
	Constraint FK_Nguoinhan_TB_THANH_LY foreign key (Nguoinhan_TB) references GIANG_VIEN(Ma_GV),
)

create table SUA_CHUA
(
	Ma_SC nvarchar(10) not null,
	primary key(Ma_SC),
	Ma_TB nvarchar(10) not null,
	Constraint FK_Ma_TB_SUA_CHUA foreign key (Ma_TB) references THIET_BI(Ma_TB),

	Ngaygiao_TB datetime not null,
	Nguoinhan_TB nvarchar(30),
	Tinhtrang_TB_lucgiao nvarchar(60),
	Tinhtrang_TB nvarchar(60),
)

set dateformat DMY

insert into GIANG_VIEN Values ('GV001', 'Nguyen Van A1', '07234123121', 'nva1@gmail.com');
insert into GIANG_VIEN Values ('GV002', 'Nguyen Van A2', '05234123122', 'nva2@gmail.com');
insert into GIANG_VIEN Values ('GV003', 'Nguyen Van A3', '09034123123', 'nva3@gmail.com');
insert into GIANG_VIEN Values ('GV004', 'Nguyen Van A4', '01229923124', 'nva4@gmail.com');
insert into GIANG_VIEN Values ('GV005', 'Nguyen Van A5', '05234121115', 'nva5@gmail.com');


insert into PHONG Values ('MaP001', 'Ke toan', 'Lau 1', 'GV001');
insert into PHONG Values ('MaP002', 'Nhan su', 'Lau 2', 'GV002');
insert into PHONG Values ('MaP003', 'Hanh chinh', 'Lau 3', 'GV003');
insert into PHONG Values ('MaP004', 'Tuyen sinh', 'Lau 4', 'GV004');
insert into PHONG Values ('MaP005', 'Kho', 'Lau 5', 'GV005');


insert into THIET_BI Values ('MaTB001', 'May in', 'TB0001', '27-02-2000','Thong tin them','MaP005','MaP003','Con su dung duoc');
insert into THIET_BI Values ('MaTB002', 'May loc nuoc', 'TB0002', '27-02-2000','Thong tin them','MaP005','MaP002','Con su dung duoc');
insert into THIET_BI Values ('MaTB003', 'May tinh cam tay', 'TB0003', '27-02-2000','Thong tin them','MaP005','MaP001','Con su dung duoc');
insert into THIET_BI Values ('MaTB004', 'Dien thoai ban', 'TB0005', '27-02-2000','Thong tin them','MaP005','MaP003','Con su dung duoc');

insert into THANH_LY Values ('MaTL0001', 'MaTB001', '23-02-2000','GV005');
insert into THANH_LY Values ('MaTL0002', 'MaTB002', '25-02-2000','GV005');
insert into THANH_LY Values ('MaTL0003', 'MaTB003', '25-02-2000','GV005');
insert into THANH_LY Values ('MaTL0004', 'MaTB004', '25-02-2000','GV005');



insert into SUA_CHUA Values ('MaSC0001', 'MaTB001', '14-06-2000', 'Nguyen Van B1','Vo kinh','Da sua thanh cong');
insert into SUA_CHUA Values ('MaSC0002', 'MaTB002', '21-06-2000', 'Nguyen Van B2','Khong the lam lanh nuoc','Da sua thanh cong');
insert into SUA_CHUA Values ('MaSC0003', 'MaTB003', '04-07-2000', 'Nguyen Van B3','Dut day dien thoai','Da sua thanh cong');



CREATE VIEW ThanhLyThietBi AS
SELECT Ma_TL AS Ma_HoatDong,
       Ma_TB AS Ma_ThietBi,
       Ngaygiao_TB AS NgayGiao,
       Nguoinhan_TB AS NguoiNhan
FROM THANH_LY;

CREATE VIEW GoiThietBiSuaChua AS
SELECT Ma_SC AS Ma_HoatDong,
       Ma_TB AS Ma_ThietBi,
       Ngaygiao_TB AS NgayGiao,
       Nguoinhan_TB AS NguoiNhan,
       Tinhtrang_TB_lucgiao AS TinhTrangLucGiao
FROM SUA_CHUA;

CREATE VIEW TraoTraThietBiSuaChua AS
SELECT Ma_SC AS Ma_HoatDong,
       Ma_TB AS Ma_ThietBi,
       Ngaygiao_TB AS NgayGiao,
       Nguoinhan_TB AS NguoiNhan,
       Tinhtrang_TB AS TinhTrang
FROM SUA_CHUA;
