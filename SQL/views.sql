
-- doanh thu theo ngay
CREATE VIEW DoanhThuTheoNgay
AS
SELECT DATEPART(DAY, HD.NgayLapHD) AS Ngay,
		
       SUM(CTHD.SoLuong * SP.GiaBan) AS DoanhThu
FROM HoaDon HD, ChiTietHoaDon CTHD, SanPham SP
WHERE HD.MaHD = CTHD.MaHD and  CTHD.MaSP = SP.MaSP
GROUP BY DATEPART(DAY, HD.NgayLapHD)

-- doanh thu theo thang
CREATE VIEW DoanhThuTheoThang
AS
SELECT
       DATEPART(MONTH, HD.NgayLapHD) AS Thang,
	   DATEPART(YEAR, HD.NgayLapHD) AS Nam,
       SUM(CTHD.SoLuong * SP.GiaBan) AS DoanhThu
FROM HoaDon HD, ChiTietHoaDon CTHD, SanPham SP
WHERE HD.MaHD = CTHD.MaHD and  CTHD.MaSP = SP.MaSP
GROUP BY DATEPART(MONTH, HD.NgayLapHD),DATEPART(YEAR, HD.NgayLapHD)

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
-- doanh thu khachhang
CREATE VIEW DoanhThuKhachHang
AS
SELECT 
       KH.MaKH,KH.TenKH,
       SUM(CTHD.SoLuong * SP.GiaBan) AS DoanhThu
FROM HoaDon HD, ChiTietHoaDon CTHD, KhachHang KH, SanPham SP
WHERE HD.MaHD = CTHD.MaHD and HD.MaKH = KH.MaKH and CTHD.MaSP = SP.MaSP
GROUP BY  KH.MaKH,KH.TenKH
-- doanh thu sanpham
CREATE VIEW DoanhThuSP
AS
SELECT 
       SP.MaSP,SP.TenSP,
       SUM(CTHD.SoLuong * SP.GiaBan) AS DoanhThu
FROM HoaDon HD, ChiTietHoaDon CTHD, KhachHang KH, SanPham SP
WHERE HD.MaHD = CTHD.MaHD and HD.MaKH = KH.MaKH and CTHD.MaSP = SP.MaSP
GROUP BY SP.MaSP,SP.TenSP

--so luong ban ra
CREATE VIEW SanPhamBanRa
AS
SELECT SP.MaSP,
       SP.TenSP,
       SUM(CTHD.SoLuong) AS SoLuonBanRa
       
FROM SanPham SP, ChiTietHoaDon CTHD
WHERE SP.MaSP = CTHD.MaSP
GROUP BY SP.MaSP, SP.TenSP;
--so luong ton kho
CREATE VIEW SanPhamTonKho
AS
SELECT SP.MaSP,
       SP.TenSP,
       SP.SoLuong- SUM(CTHD.SoLuong) AS SoLuongTon
FROM SanPham SP, ChiTietHoaDon CTHD
WHERE SP.MaSP = CTHD.MaSP
GROUP BY SP.MaSP, SP.TenSP,SP.SoLuong;

--nhanvien ky luc
CREATE VIEW NhanVien_1_DH
AS
SELECT top 1 NV.MaNV,NV.HoLot,NV.Ten,
       COUNT(HD.MaHD) AS SoDonHang
FROM NhanVien NV, HoaDon HD, ChiTietHoaDon CTHD,SanPham SP 
WHERE NV.MaNV = HD.MaNV
  AND HD.MaHD = CTHD.MaHD and SP.MaSP = CTHD.MaSP
GROUP BY NV.MaNV,NV.HoLot,NV.Ten
order by COUNT(HD.MaHD) desc

CREATE VIEW NhanVien_1_DT
AS
SELECT top 1  NV.MaNV,NV.HoLot,NV.Ten,
       Sum(CTHD.SoLuong * SP.GiaBan) AS DoanhThu
FROM NhanVien NV, HoaDon HD, ChiTietHoaDon CTHD,SanPham SP 
WHERE NV.MaNV = HD.MaNV
  AND HD.MaHD = CTHD.MaHD and SP.MaSP = CTHD.MaSP
GROUP BY NV.MaNV,NV.HoLot,NV.Ten
order by  Sum(CTHD.SoLuong * SP.GiaBan)  desc

--khach hang top 1
CREATE VIEW KhachHang_vip
AS
SELECT top 1 
       KH.MaKH,KH.TenKH,
       SUM(CTHD.SoLuong * SP.GiaBan) AS DoanhThu
FROM HoaDon HD, ChiTietHoaDon CTHD, KhachHang KH, SanPham SP
WHERE HD.MaHD = CTHD.MaHD and HD.MaKH = KH.MaKH and CTHD.MaSP = SP.MaSP
GROUP BY  KH.MaKH,KH.TenKH
Having SUM(CTHD.SoLuong * SP.GiaBan) >= 100000000
order by SUM(CTHD.SoLuong * SP.GiaBan) desc


--loi nhuan theo thang 
CREATE VIEW LoiNhuanThang
AS
SELECT 
	   DATEPART(MONTH, HD.NgayLapHD) AS Thang,
	   DATEPART(YEAR, HD.NgayLapHD) AS Nam,
       SUM((SP.GiaBan - SP.GiaNhap) * CTHD.SoLuong) AS LoiNhuan
FROM HoaDon HD, ChiTietHoaDon CTHD, SanPham SP
WHERE HD.MaHD = CTHD.MaHD 
  AND CTHD.MaSP = SP.MaSP
GROUP BY DATEPART(MONTH, HD.NgayLapHD), DATEPART(YEAR, HD.NgayLapHD);

--loi nhuan sp
create view LoiNhuanSP
as
select a.MaSP,a.TenSP, Sum(b.SoLuong * (a.GiaBan-a.GiaNhap)) as LoiNhuan
from SanPham a , ChiTietHoaDon b
where a.MaSP = b.MaSP
group by a.MaSP,a.tensp
----
