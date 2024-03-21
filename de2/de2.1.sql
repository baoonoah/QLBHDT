create database thi1
use thi1

create table SO_DAU_BAI
(
ID_BH nvarchar(10) not null
Primary key (ID_BH),
Ma_GV nvarchar(10) not null,
Ma_HK nvarchar(10) not null,
Ma_MH nvarchar(10) not null,
Ma_LOP nvarchar(10) not null,
Thoigian_batdau datetime,
Thoigian_ketthuc datetime,
Soluong_vang int not null,
Noidung_BH nvarchar(255) not null,
DG_Hoctap nvarchar(100) not null,
DG_Renluyen nvarchar(100) not null,
Sogio int not null
);

create table GIANG_VIEN
(
Ma_GV nvarchar(10) not null
Primary key (Ma_GV),
Ten_GV nvarchar(25) not null,
Sdt_GV int,
Email_GV nvarchar(30) not null
);

create table HOC_KY (
Ma_HK nvarchar(10) not null
Primary key (Ma_HK),
Namhoc int,
Hocky nvarchar(10)
);


create table MON_HOC(
Ma_MH nvarchar(10) not null
Primary key (Ma_MH),
Ten_MH nvarchar(10) not null,
So_TC int not null,
Sotiet int not null
);

create table LOP (
Ma_LOP nvarchar(10) not null
Primary key (Ma_LOP),
Ten_LOP nvarchar(10) not null
);


create table SINH_VIEN (
Ma_SV nvarchar(10) not null
Primary key (Ma_SV),
Ten_SV nvarchar(25) not null,
Sdt_SV int,
Email_SV nvarchar(30) not null,
Ma_LOP nvarchar(10) not null

);


create table QUATRINH_HOCTAP( 
Ma_SV nvarchar(10) not null
Primary key (Ma_SV),
Ma_HK nvarchar(10) not null,
Ma_MH nvarchar(10) not null,
Ngay_lenlop datetime,
Thamgia_BH bit
);

CREATE VIEW So_Buoi_Vang AS
	SELECT SDB.Ma_MH,HK.Ma_HK,MH.Ten_MH, Sum(SDB.Soluong_vang) AS SoBuoiVang
	from SO_DAU_BAI SDB, MON_HOC MH, HOC_KY HK
	where SDB.Ma_MH = MH.Ma_MH and SDB.Ma_HK = HK.Ma_HK
	GROUP BY SDB.Ma_MH,HK.Ma_HK, MH.Ten_MH;


CREATE VIEW So_Gio_Con_Lai AS
SELECT MH.Ma_MH,HK.Ma_HK,HK.Namhoc,MH.Sotiet, MH.Sotiet - SUM(SDB.Sogio) AS SoGioConLai
from SO_DAU_BAI SDB, MON_HOC MH, HOC_KY HK
where SDB.Ma_MH = MH.Ma_MH and SDB.Ma_HK = HK.Ma_HK
GROUP BY MH.Ma_MH,HK.Ma_HK, HK.Namhoc, MH.Sotiet;


	CREATE VIEW MH_KetThuc AS
	SELECT SDB.Ma_MH,HK.Ma_HK,HK.Namhoc,MH.Ten_MH
	from SO_DAU_BAI SDB, MON_HOC MH, HOC_KY HK
	where SDB.Ma_MH = MH.Ma_MH and SDB.Ma_HK = HK.Ma_HK and ((MH.Sotiet *45/60) - SDB.Sogio <= 0)
	GROUP BY SDB.Ma_MH,HK.Ma_HK,HK.Namhoc, MH.Ten_MH;
