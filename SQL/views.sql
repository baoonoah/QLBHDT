
-- doanh thu theo ngay
CREATE VIEW DoanhThuTheoNgay
AS
SELECT DATEPART(DAY, HD.NgayLapHD) AS Ngay,
		DATEPART(MONTH, HD.NgayLapHD) AS Thang,
       SUM(CTHD.SoLuong * SP.GiaBan) AS DoanhThu
FROM HoaDon HD, ChiTietHoaDon CTHD, SanPham SP
WHERE HD.MaHD = CTHD.MaHD and  CTHD.MaSP = SP.MaSP
GROUP BY HD.NgayLapHD

-- doanh thu theo thang
CREATE VIEW DoanhThuTheoThang
AS
SELECT
       DATEPART(MONTH, HD.NgayLapHD) AS Thang,
       SUM(CTHD.SoLuong * SP.GiaBan) AS DoanhThu
FROM HoaDon HD, ChiTietHoaDon CTHD, SanPham SP
WHERE HD.MaHD = CTHD.MaHD and  CTHD.MaSP = SP.MaSP
GROUP BY DATEPART(MONTH, HD.NgayLapHD)

-- doanh thu theo qui

CREATE VIEW DoanhThuTheoQui
AS
SELECT 
       DATEPART(QUARTER, HD.NgayLapHD) AS Qui,
       DATEPART(YEAR, HD.NgayLapHD) AS Nam,
       SUM(CTHD.SoLuong * SP.GiaBan) AS DoanhThu
FROM HoaDon HD, ChiTietHoaDon CTHD, SanPham SP
WHERE HD.MaHD = CTHD.MaHD and  CTHD.MaSP = SP.MaSP
GROUP BY DATEPART(QUARTER, HD.NgayLapHD), DATEPART(YEAR, HD.NgayLapHD)
-- doanh thu theo nam
CREATE VIEW DoanhThuTheoNam
AS
SELECT 
       DATEPART(YEAR, HD.NgayLapHD) AS Nam,
       SUM(CTHD.SoLuong * SP.GiaBan) AS DoanhThu
FROM HoaDon HD, ChiTietHoaDon CTHD, SanPham SP
WHERE HD.MaHD = CTHD.MaHD and  CTHD.MaSP = SP.MaSP
GROUP BY DATEPART(YEAR, HD.NgayLapHD)

--ton kho
CREATE VIEW SanPhamBanRavaTonKHo
AS
SELECT SP.MaSP,
       SP.TenSP,
       SUM(CTHD.SoLuong) AS SoLuonBanRa,
       SP.SoLuong- SUM(CTHD.SoLuong) AS SoLuongTon
FROM SanPham SP, ChiTietHoaDon CTHD
WHERE SP.MaSP = CTHD.MaSP
GROUP BY SP.MaSP, SP.TenSP,SP.SoLuong;

--nv

CREATE VIEW NhanVienKyLuc
AS
SELECT NV.MaNV,NV.HoLot,NV.Ten,
       COUNT(HD.MaHD) AS SoDonHang,
       SUM(CTHD.SoLuong * SP.GiaBan) AS DoanhThu
FROM NhanVien NV, HoaDon HD, ChiTietHoaDon CTHD,SanPham SP 
WHERE NV.MaNV = HD.MaNV
  AND HD.MaHD = CTHD.MaHD
GROUP BY NV.MaNV,NV.HoLot,NV.Ten;

--loi nhuan theo thang 

CREATE VIEW LoiNhuanThang
AS
SELECT 
       CTHD.MaSP,
	   DATEPART(MONTH, HD.NgayLapHD) AS Thang,
	   DATEPART(YEAR, HD.NgayLapHD) AS Nam,
       SUM((SP.GiaBan - SP.GiaNhap) * CTHD.SoLuong) AS LoiNhuan
FROM HoaDon HD, ChiTietHoaDon CTHD, SanPham SP
WHERE HD.MaHD = CTHD.MaHD
  AND CTHD.MaSP = SP.MaSP
GROUP BY DATEPART(MONTH, HD.NgayLapHD), DATEPART(YEAR, HD.NgayLapHD),CTHD.MaSP;

--loi nhuan sp
create view LoiNhuanSP
as
select a.MaSP, Sum(b.SoLuong * (a.GiaBan-a.GiaNhap)) as LoiNhuan
from SanPham a , ChiTietHoaDon b
where a.MaSP = b.MaSP
group by a.MaSP

----
select *from LoiNhuanSP
