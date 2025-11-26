-- ===============================
-- Tao co so du lieu
-- ===============================
CREATE DATABASE [ShopBanAoKhoac]
GO

USE [ShopBanAoKhoac]
GO

-- =============================S==
-- Bang San pham
-- ===============================
CREATE TABLE SanPham (
    MaSP INT IDENTITY(1,1) PRIMARY KEY,
    TenSP NVARCHAR(100) NOT NULL,
    Loai NVARCHAR(50),
    Gia DECIMAL(18,2) NOT NULL,
    SoLuong INT NOT NULL
);

-- ===============================
-- Bang Khach hang
-- ===============================
CREATE TABLE KhachHang (
    MaKH INT IDENTITY(1,1) PRIMARY KEY,
    HoTen NVARCHAR(100) NOT NULL,
    DienThoai NVARCHAR(20),
    Email NVARCHAR(100),
    LoaiKhach NVARCHAR(50) -- Ví dụ: Vàng, Bạc, Đồng
);

-- ===============================
-- Bang Nhan vien
-- ===============================
CREATE TABLE NhanVien (
    MaNV INT IDENTITY(1,1) PRIMARY KEY,
    TaiKhoan NVARCHAR(50) NOT NULL,
    MatKhau NVARCHAR(50) NOT NULL,
    HoTen NVARCHAR(100),
    VaiTro NVARCHAR(20) -- Quản lý / Nhân viên
);

-- ===============================
-- Bang Nha cung cap
-- ===============================
CREATE TABLE NhaCungCap (
    MaNCC INT IDENTITY(1,1) PRIMARY KEY,
    TenNCC NVARCHAR(100),
    DienThoai NVARCHAR(20),
    Email NVARCHAR(100)
);

-- ===============================
-- Bang Phieu nhap hang
-- ===============================
CREATE TABLE PhieuNhap (
    MaPN INT IDENTITY(1,1) PRIMARY KEY,
    MaNCC INT FOREIGN KEY REFERENCES NhaCungCap(MaNCC),
    NgayNhap DATETIME DEFAULT GETDATE()
);

-- ===============================
-- Bang Chi tiet phieu nhap
-- ===============================
CREATE TABLE ChiTietPhieuNhap (
    MaCTPN INT IDENTITY(1,1) PRIMARY KEY,
    MaPN INT FOREIGN KEY REFERENCES PhieuNhap(MaPN),
    MaSP INT FOREIGN KEY REFERENCES SanPham(MaSP),
    SoLuong INT,
    Gia DECIMAL(18,2)
);

-- ===============================
-- Bang Hoa don ban hang
-- ===============================
CREATE TABLE HoaDon (
    MaHD INT IDENTITY(1,1) PRIMARY KEY,
    MaKH INT FOREIGN KEY REFERENCES KhachHang(MaKH),
    MaNV INT FOREIGN KEY REFERENCES NhanVien(MaNV),
    NgayLap DATETIME DEFAULT GETDATE(),
    TongTien DECIMAL(18,2)
);

-- ===============================
-- Bang Chi tiet hoa don
-- ===============================
CREATE TABLE ChiTietHoaDon (
    MaCTHD INT IDENTITY(1,1) PRIMARY KEY,
    MaHD INT FOREIGN KEY REFERENCES HoaDon(MaHD),
    MaSP INT FOREIGN KEY REFERENCES SanPham(MaSP),
    SoLuong INT,
    Gia DECIMAL(18,2)
);

-- ===============================
-- Bang Lich Su Mua Hang
-- ===============================
CREATE TABLE LichSuMuaHang (
    MaLS INT IDENTITY(1,1) PRIMARY KEY,
    MaKH INT,
    MaSP INT,
    NgayMua DATE,
    SoLuong INT,
    FOREIGN KEY (MaKH) REFERENCES KhachHang(MaKH),
    FOREIGN KEY (MaSP) REFERENCES SanPham(MaSP)
);

-- Du lieu mau Bang NhaCungCap
INSERT INTO NhaCungCap (TenNCC, DienThoai, Email) VALUES
(N'ABC Co., Ltd', '0911222333', 'abc@gmail.com'),
(N'Def Corp', '0988777666', 'def@gmail.com'),
(N'XYZ Supply', '0903344556', 'xyz@gmail.com'),
(N'Mega Trade', '0912345678', 'mega@gmail.com'),
(N'Fashion Hub', '0922333444', 'fashion@gmail.com'),
(N'TechSource', '0933444555', 'tech@gmail.com'),
(N'StylePro', '0944555666', 'style@gmail.com'),
(N'Golden Co.', '0955666777', 'golden@gmail.com'),
(N'Elite Supplier', '0966777888', 'elite@gmail.com'),
(N'Urban Shop', '0977888999', 'urban@gmail.com');

-- Du lieu mau Bang SanPham
INSERT INTO SanPham (TenSP, Loai, Gia, SoLuong) VALUES
(N'Ao Khoac Nam', N'Nam', 500000, 50),
(N'Ao Khoac Nu', N'N?', 450000, 40),
(N'Ao Khoac Tre Em', N'Tr? Em', 300000, 30),
(N'Ao Len Nam', N'Nam', 350000, 25),
(N'Ao Len Nu', N'N?', 360000, 20),
(N'Ao Mua Nam', N'Nam', 200000, 60),
(N'Ao Mua Nu', N'N?', 220000, 55),
(N'Ao Hoodie', N'Unisex', 400000, 35),
(N'Ao Bomber', N'Nam', 600000, 15),
(N'Ao Vest Nu', N'N?', 700000, 10);

-- Du lieu mau Bang KhachHang
INSERT INTO KhachHang (HoTen, DienThoai, Email, LoaiKhach) VALUES
(N'Nguyen Van A', '0912345678', 'a@gmail.com', N'Vàng'),
(N'Tran Thi B', '0987654321', 'b@gmail.com', N'Bạc'),
(N'Le Van C', '0901234567', 'c@gmail.com', N'Đồng'),
(N'Pham Thi D', '0911122233', 'd@gmail.com', N'Bạc'),
(N'Hoang Van E', '0922333444', 'e@gmail.com', N'Vàng'),
(N'Nguyen Thi F', '0933444555', 'f@gmail.com', N'Đồng'),
(N'Tran Van G', '0944555666', 'g@gmail.com', N'Bạc'),
(N'Le Thi H', '0955666777', 'h@gmail.com', N'Vàng'),
(N'Pham Van I', '0966777888', 'i@gmail.com', N'Đồng'),
(N'Hoang Thi J', '0977888999', 'j@gmail.com', N'Bạc');

-- Du lieu mau Bang NhanVien
INSERT INTO NhanVien (TaiKhoan, MatKhau, HoTen, VaiTro) VALUES
(N'admin1', '123456', N'Nguyen Van NV1', N'Quản lý'),
(N'nv1', '123456', N'Tran Thi NV2', N'Nhân viên'),
(N'nv2', '123456', N'Le Van NV3', N'Nhân viên'),
(N'nv3', '123456', N'Pham Thi NV4', N'Nhân viên'),
(N'nv4', '123456', N'Hoang Van NV5', N'Nhân viên'),
(N'nv5', '123456', N'Nguyen Thi NV6', N'Nhân viên'),
(N'nv6', '123456', N'Tran Van NV7', N'Nhân viên'),
(N'nv7', '123456', N'Le Thi NV8', N'Nhân viên'),
(N'nv8', '123456', N'Pham Van NV9', N'Nhân viên'),
(N'nv9', '123456', N'Hoang Thi NV10', N'Nhân viên');

-- Du lieu mau Bang PhieuNhap
INSERT INTO PhieuNhap (MaNCC, NgayNhap) VALUES
(1, '2025-11-01'),
(2, '2025-11-02'),
(3, '2025-11-03'),
(4, '2025-11-04'),
(5, '2025-11-05'),
(6, '2025-11-06'),
(7, '2025-11-07'),
(8, '2025-11-08'),
(9, '2025-11-09'),
(10, '2025-11-10');

-- Du lieu mau Bang ChiTietPhieuNhap
INSERT INTO ChiTietPhieuNhap (MaPN, MaSP, SoLuong, Gia) VALUES
(1,1,10,500000),
(1,2,5,450000),
(2,3,15,300000),
(2,4,20,350000),
(3,5,10,360000),
(3,6,30,200000),
(4,7,25,220000),
(4,8,12,400000),
(5,9,8,600000),
(5,10,5,700000);

-- Du lieu mau Bang HoaDon
INSERT INTO HoaDon (MaKH, MaNV, NgayLap, TongTien) VALUES
(1,1,'2025-11-01', 1000000),
(2,2,'2025-11-02', 450000),
(3,3,'2025-11-03', 900000),
(4,4,'2025-11-04', 700000),
(5,5,'2025-11-05', 800000),
(6,6,'2025-11-06', 500000),
(7,7,'2025-11-07', 600000),
(8,8,'2025-11-08', 1200000),
(9,9,'2025-11-09', 400000),
(10,10,'2025-11-10', 300000);

-- Du lieu mau Bang ChiTietHoaDon
INSERT INTO ChiTietHoaDon (MaHD, MaSP, SoLuong, Gia) VALUES
(1,1,2,500000),
(1,2,1,450000),
(2,3,3,300000),
(3,4,2,350000),
(4,5,1,360000),
(5,6,4,200000),
(6,7,2,220000),
(7,8,3,400000),
(8,9,2,600000),
(9,10,1,700000);

-- Du lieu mau Bang LichSuMuaHang
INSERT INTO LichSuMuaHang (MaKH, MaSP, NgayMua, SoLuong) VALUES
(1,1,'2025-11-01',2),
(1,2,'2025-11-02',1),
(2,3,'2025-11-03',3),
(2,4,'2025-11-04',2),
(3,5,'2025-11-05',1),
(3,6,'2025-11-06',4),
(4,7,'2025-11-07',2),
(5,8,'2025-11-08',3),
(6,9,'2025-11-09',2),
(7,10,'2025-11-10',1);



