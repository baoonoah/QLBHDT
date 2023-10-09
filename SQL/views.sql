

CREATE VIEW DoanhThu
AS
SELECT DATEPART(DAY, HD.NgayLapHD) AS Ngay,
       DATEPART(MONTH, HD.NgayLapHD) AS Thang,
       DATEPART(QUARTER, HD.NgayLapHD) AS Qui,
       DATEPART(YEAR, HD.NgayLapHD) AS Nam,
       SUM(CTHD.SoLuong * SP.GiaBan) AS DoanhThu
FROM HoaDon HD, ChiTietHoaDon CTHD, SanPham SP
WHERE HD.MaHD = CTHD.MaHD
GROUP BY HD.NgayLapHD


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

-- theo thang 

CREATE VIEW LoiNhuan
AS
SELECT DATEPART(MONTH, HD.NgayLapHD) AS Thang,
       CTHD.MaSP,
       SUM((SP.GiaBan - SP.GiaNhap) * CTHD.SoLuong) AS LoiNhuan
FROM HoaDon HD, ChiTietHoaDon CTHD, SanPham SP
WHERE HD.MaHD = CTHD.MaHD
  AND CTHD.MaSP = SP.MaSP
GROUP BY DATEPART(MONTH, HD.NgayLapHD), CTHD.MaSP;
select *from LoiNhuan