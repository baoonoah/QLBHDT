Create Database onThiTH2

use onThiTH2

create table GIANG_VIEN
(
	Ma_GV nvarchar(30),
	primary key(Ma_GV),
	Ten_GV nvarchar(30),
	Sdt_GV nvarchar(15),
	Email_GV nvarchar(30),

)
 create table HOC_KY
 (
	Ma_HK nvarchar(30),
	primary key(Ma_HK),
	Namhoc nvarchar(30),
	Hocky nvarchar(30)
 )

 create table MON_HOC
 (
	Ma_MH nvarchar(30),
	primary key(Ma_MH),
	Ten_MH nvarchar(20),
	So_TC int not null,
	Sotiet int not null
 )

 create table LOP
 (
	Ma_LOP nvarchar(30),
	primary key(Ma_LOP),
	Ten_LOP nvarchar(20),
 )
  create table SINH_VIEN
  (
	Ma_SV nvarchar(30),
	primary key(Ma_SV),
	Ten_SV nvarchar(20),
	Sdt_SV nvarchar(20),
	Email nvarchar(20),
	Ma_LOP nvarchar(30),
	Constraint FK_Ma_LOP_SINH_VIEN foreign key (Ma_LOP) references LOP(Ma_LOP),
  )

  create table SO_DAU_BAI
  (
	ID_BH INT IDENTITY(1,1),
	primary key(ID_BH),
	Ma_GV nvarchar(30),
	Constraint FK_Ma_GV_SO_DAU_BAI foreign key (Ma_GV) references GIANG_VIEN(Ma_GV),
	Ma_HK nvarchar(30),
	Constraint FK_Ma_HK_SO_DAU_BAI foreign key (Ma_HK) references HOC_KY(Ma_HK),
	Ma_MH nvarchar(30),
	Constraint FK_Ma_MH_SO_DAU_BAI foreign key (Ma_MH) references MON_HOC(Ma_MH),
	Ma_LOP nvarchar(30),
	Constraint FK_Ma_LOP_SO_DAU_BAI foreign key (Ma_LOP) references LOP(Ma_LOP),
	Thoigian_batdau datetime not null,
	Thoigian_ketthuc datetime not null,
	Soluong_vang int not null,
	Noidung_BH nvarchar(40),
	DG_Hoctap nvarchar(40),
	DG_Renluyen nvarchar(40),
	Sogio int not null,

  )

  create table QUATRINH_HOCTAP
  (
	Ma_SV nvarchar(30),
	primary key(Ma_SV),
	Ma_HK nvarchar(30),
	Constraint FK_Ma_HK_QUATRINH_HOCTAP foreign key (Ma_HK) references HOC_KY(Ma_HK),
	Ma_MH nvarchar(30),
	Constraint FK_Ma_MH_QUATRINH_HOCTAP foreign key (Ma_MH) references MON_HOC(Ma_MH),
	Ngay_lenlop INT not null,
	Constraint FK_Ngay_lenlop_QUATRINH_HOCTAP foreign key (Ngay_lenlop) references SO_DAU_BAI(ID_BH),
	Thamgia_BH bit,
  )

  
set dateformat DMY

insert into GIANG_VIEN Values ('GV001', 'Nguyen Van A1', '07234123121', 'nva1@gmail.com');
insert into GIANG_VIEN Values ('GV002', 'Nguyen Van A2', '05234123122', 'nva2@gmail.com');
insert into GIANG_VIEN Values ('GV003', 'Nguyen Van A3', '09034123123', 'nva3@gmail.com');
insert into GIANG_VIEN Values ('GV004', 'Nguyen Van A4', '01229923124', 'nva4@gmail.com');
insert into GIANG_VIEN Values ('GV005', 'Nguyen Van A5', '05234121115', 'nva5@gmail.com');



insert into HOC_KY Values ('MaHK001', '2020','HocKy1');
insert into HOC_KY Values ('MaHK002', '2020','HocKy2');
insert into HOC_KY Values ('MaHK003', '2021','HocKy1');
insert into HOC_KY Values ('MaHK004', '2021','HocKy2');
insert into HOC_KY Values ('MaHK005', '2022','HocKy1');
insert into HOC_KY Values ('MaHK006', '2022','HocKy2');
insert into HOC_KY Values ('MaHK007', '2023','HocKy1');
insert into HOC_KY Values ('MaHK008', '2023','HocKy2');
insert into HOC_KY Values ('MaHK009', '2024','HocKy1');
insert into HOC_KY Values ('MaHK010', '2024','HocKy2');

insert into MON_HOC Values ('MaMH001', 'SQLServer','4','60');
insert into MON_HOC Values ('MaMH002', 'Lập trình web PHP','4','120');
insert into MON_HOC Values ('MaMH003', 'Cơ sở dữ liệu','4','120');
insert into MON_HOC Values ('MaMH004', 'LTTB Di động','4','60');
insert into MON_HOC Values ('MaMH005', 'Mạng máy tính','4','60');

insert into LOP Values('MaLOP001','21.1UDPM');
insert into LOP Values('MaLOP002','22.1UDPM');
insert into LOP Values('MaLOP003','23.1UDPM');
insert into LOP Values('MaLOP004','24.1UDPM');
insert into LOP Values('MaLOP005','25.1UDPM');


insert into SINH_VIEN Values('MaSV001','Nguyen Van A1','0867648294','nva1@gmail.com','MaLOP001');
insert into SINH_VIEN Values('MaSV002','Nguyen Van A2','0321354657','nva2@gmail.com','MaLOP002');
insert into SINH_VIEN Values('MaSV003','Nguyen Van A3','0875623221','nva3@gmail.com','MaLOP003');
insert into SINH_VIEN Values('MaSV004','Nguyen Van A4','0962467723','nva4@gmail.com','MaLOP004');
insert into SINH_VIEN Values('MaSV005','Nguyen Van A5','0933656432','nva5@gmail.com','MaLOP005');
insert into SINH_VIEN Values('MaSV006','Nguyen Van A6','0933665432','nva6@gmail.com','MaLOP005');


insert into SO_DAU_BAI Values('GV001','MaHK001','MaMH001','MaLOP001','04-03-2019','4-3-2020','01','Nội dung buoi hoc','Tốt','Tốt',2);
insert into SO_DAU_BAI Values('GV002','MaHK002','MaMH002','MaLOP002','05-03-2020','5-3-2021','02','Nội dung buoi hoc','Tốt','Tốt',2);
insert into SO_DAU_BAI Values('GV003','MaHK003','MaMH003','MaLOP003','06-03-2021','6-3-2022','03','Nội dung buoi hoc','Khá','Tốt',2);
insert into SO_DAU_BAI Values('GV004','MaHK004','MaMH004','MaLOP004','05-03-2022','5-3-2023','01','Nội dung buoi hoc','Tốt','Tốt',2);
insert into SO_DAU_BAI Values('GV005','MaHK005','MaMH005','MaLOP005','04-03-2023','4-3-2024','01','Nội dung buoi hoc','Tốt','Tốt',2);


insert into QUATRINH_HOCTAP Values('MaSV001','MaHK001','MaMH001',1,'True');
insert into QUATRINH_HOCTAP Values('MaSV002','MaHK002','MaMH002',1,'True');
insert into QUATRINH_HOCTAP Values('MaSV003','MaHK003','MaMH003',1,'True');
insert into QUATRINH_HOCTAP Values('MaSV004','MaHK004','MaMH004',1,'True');
insert into QUATRINH_HOCTAP Values('MaSV005','MaHK005','MaMH005',1,'True');