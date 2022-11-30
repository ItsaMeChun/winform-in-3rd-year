use master
go
if exists (select name from sysdatabases where name = N'BookLibrary')
	drop database BookLibrary
go
CREATE DATABASE BookLibrary
go
USE BookLibrary
GO

--tao table
CREATE TABLE [Sach]
(
	[MaSach] [varchar](20) NOT NULL,
	[TenSach] [nvarchar](200) NULL,
	[MaLoaiSach] [varchar](20) NULL,
	[SoLuong] [int] NULL,
	[MaTG] [varchar](20) NULL,
	CONSTRAINT [PK_Sach] PRIMARY KEY (MaSach)
)

CREATE TABLE [LoaiSach]
(
	[MaLoaiSach] [varchar](20) NOT NULL,
	[TenLoai] [nvarchar](200) NULL,
	[KieuSach] [nvarchar](200) NULL,
	CONSTRAINT [PK_LoaiSach] PRIMARY KEY (MaLoaiSach)
)

CREATE TABLE [NguoiMuon]
(
	[MaDG] [varchar](20) NOT NULL,
	[TenDG] [nvarchar](200) NULL,
	[GioiTinh] [nvarchar](5),
	[NgaySinh] [Date] NULL,
	[DiaChi] [nvarchar](200) NULL,
	CONSTRAINT [PK_NguoiMuon] PRIMARY KEY (MADG)
)

CREATE TABLE [TacGia]
(
	[MaTG] [varchar](20) NOT NULL,
	[TenTG] [nvarchar](200) NULL,
	CONSTRAINT [PK_TacGia] PRIMARY KEY (MATG)
)

CREATE TABLE [MuonTraSach]
(
	[MaPhieuMuon] int Identity(1,1) NOT NULL,
	[MaDG] [varchar](20) NOT NULL,
	[MaSach] [varchar](20) NOT NULL,
	[SoLuong] [int] NULL,
	[NgayMuon] [date] NULL,
	[NgayHenTra] [date] NULL,
	[NgayTra] [date] NULL,
	CONSTRAINT [PK_MuonTraSach] PRIMARY KEY (MaPhieuMuon)
)
-- add fk cho sach vs loai sach
ALTER TABLE [dbo].[Sach]  WITH CHECK ADD FOREIGN KEY([MaLoaiSach])
REFERENCES [dbo].[LoaiSach] ([MaLoaiSach])
GO
--add fk cho tac gia vs sach
ALTER TABLE [dbo].[Sach]  WITH CHECK ADD FOREIGN KEY([MaTG])
REFERENCES [dbo].[TacGia] ([MaTG])
GO
-- add fk cho muon tra sach vs sach
ALTER TABLE [dbo].[MuonTraSach]  WITH CHECK ADD FOREIGN KEY([MaSach])
REFERENCES [dbo].[Sach] ([MaSach])
GO
-- add fk cho muon tra sach vs nguoi muon
ALTER TABLE [dbo].[MuonTraSach]  WITH CHECK ADD FOREIGN KEY([MaDG])
REFERENCES [dbo].[NguoiMuon] ([MaDG])
GO
------ insert into table Sach
set dateformat dmy
INSERT INTO dbo.[TacGia]([MaTG],[TenTG]) VALUES ('TG01', N'Nguyễn Nhật Ánh')
INSERT INTO dbo.[TacGia]([MaTG],[TenTG]) VALUES ('TG02', N'Trang Hạ')
INSERT INTO dbo.[TacGia]([MaTG],[TenTG]) VALUES ('TG03', N'Hồ Anh Thái')
INSERT INTO dbo.[TacGia]([MaTG],[TenTG]) VALUES ('TG04', N'Nguyễn Vĩnh Nguyên')
INSERT INTO dbo.[TacGia]([MaTG],[TenTG]) VALUES ('TG05', N'Nguyễn Trương Quý')
INSERT INTO dbo.[TacGia]([MaTG],[TenTG]) VALUES ('TG06', N'Đỗ Bích Thúy')
INSERT INTO dbo.[TacGia]([MaTG],[TenTG]) VALUES ('TG07', N'Nguyễn Mai Chi')
INSERT INTO dbo.[TacGia]([MaTG],[TenTG]) VALUES ('TG08', N'Nguyễn Ngọc Thạch')
INSERT INTO dbo.[TacGia]([MaTG],[TenTG]) VALUES ('TG09', N'Hạ Vũ')

INSERT INTO dbo.[LoaiSach]([MaLoaiSach],[TenLoai],[KieuSach]) VALUES ('L01',N'Truyện Ngắn',N'Bìa dày')
INSERT INTO dbo.[LoaiSach]([MaLoaiSach],[TenLoai],[KieuSach]) VALUES ('L02',N'Tiểu Thuyết',N'Bìa mỏng')

INSERT INTO dbo.[Sach]([MaSach],[TenSach],[MaLoaiSach],[SoLuong],[MaTG]) VALUES ('S01', N'Phòng trọ ba người','L01',10,'TG01')
INSERT INTO dbo.[Sach]([MaSach],[TenSach],[MaLoaiSach],[SoLuong],[MaTG]) VALUES ('S02', N'Cảm ơn người lớn','L01',10,'TG01')
INSERT INTO dbo.[Sach]([MaSach],[TenSach],[MaLoaiSach],[SoLuong],[MaTG]) VALUES ('S03', N'Chuyện kể dưới ngọn đèn đường','L01',10,'TG02')
INSERT INTO dbo.[Sach]([MaSach],[TenSach],[MaLoaiSach],[SoLuong],[MaTG]) VALUES ('S04', N'Đàn bà ba mươi','L01',10,'TG02')
INSERT INTO dbo.[Sach]([MaSach],[TenSach],[MaLoaiSach],[SoLuong],[MaTG]) VALUES ('S05', N'Trong sương hồng hiện ra','L01',10,'TG03')
INSERT INTO dbo.[Sach]([MaSach],[TenSach],[MaLoaiSach],[SoLuong],[MaTG]) VALUES ('S06', N'Lũ con hoang','L01',10,'TG03')
INSERT INTO dbo.[Sach]([MaSach],[TenSach],[MaLoaiSach],[SoLuong],[MaTG]) VALUES ('S07', N'Đà Lạt một thời hương xa','L01',10,'TG04')
INSERT INTO dbo.[Sach]([MaSach],[TenSach],[MaLoaiSach],[SoLuong],[MaTG]) VALUES ('S08', N'Một thời Hà Nội hát - Tim cũng không ngờ làm nên lời ca','L01',10,'TG05')
INSERT INTO dbo.[Sach]([MaSach],[TenSach],[MaLoaiSach],[SoLuong],[MaTG]) VALUES ('S09', N'Hà Nội bảo thế là thường','L01',10,'TG05')
INSERT INTO dbo.[Sach]([MaSach],[TenSach],[MaLoaiSach],[SoLuong],[MaTG]) VALUES ('S010', N'Thương nhau như người thân','L01',10,'TG06')
INSERT INTO dbo.[Sach]([MaSach],[TenSach],[MaLoaiSach],[SoLuong],[MaTG]) VALUES ('S011', N'Tôi đã trở về trên núi cao','L01',10,'TG06')
INSERT INTO dbo.[Sach]([MaSach],[TenSach],[MaLoaiSach],[SoLuong],[MaTG]) VALUES ('S015', N'Những tọa độ song song','L01',10,'TG07')
INSERT INTO dbo.[Sach]([MaSach],[TenSach],[MaLoaiSach],[SoLuong],[MaTG]) VALUES ('S013', N'Tuổi trẻ hoang dại','L01',10,'TG08')
INSERT INTO dbo.[Sach]([MaSach],[TenSach],[MaLoaiSach],[SoLuong],[MaTG]) VALUES ('S012', N'Khóc giữa Sài Gòn','L01',10,'TG08')
INSERT INTO dbo.[Sach]([MaSach],[TenSach],[MaLoaiSach],[SoLuong],[MaTG]) VALUES ('S016', N'Hôm nay tôi thất tình','L01',10,'TG09')
INSERT INTO dbo.[Sach]([MaSach],[TenSach],[MaLoaiSach],[SoLuong],[MaTG]) VALUES ('S017', N'Con rơi','L01',10,'TG09')

INSERT INTO dbo.[NguoiMuon]([MaDG],[TenDG],[GioiTinh],[NgaySinh],[DiaChi]) VALUES ('DG01',N'Lê Phan Hoàng Long',N'Nam','13-04-2021',N'Quận 4')
INSERT INTO dbo.[NguoiMuon]([MaDG],[TenDG],[GioiTinh],[NgaySinh],[DiaChi]) VALUES ('DG02',N'Nguyễn Đức Minh Trung',N'Nam','29-01-2001',N'Quận 4')
INSERT INTO dbo.[NguoiMuon]([MaDG],[TenDG],[GioiTinh],[NgaySinh],[DiaChi]) VALUES ('DG03',N'Trần Hữu Thịnh',N'Nam','10-04-2001',N'Quận 8')
INSERT INTO dbo.[NguoiMuon]([MaDG],[TenDG],[GioiTinh],[NgaySinh],[DiaChi]) VALUES ('DG04',N'Lý Trường Khang',N'Nam','30-10-2001',N'Quận 6')
INSERT INTO dbo.[NguoiMuon]([MaDG],[TenDG],[GioiTinh],[NgaySinh],[DiaChi]) VALUES ('DG05',N'Nguyễn Đăng Khoa',N'Nam','30-08-2001',N'Quận 8')
INSERT INTO dbo.[NguoiMuon]([MaDG],[TenDG],[GioiTinh],[NgaySinh],[DiaChi]) VALUES ('DG06',N'Hữu Phong',N'Nam','31-12-2000',N'Hà Nội')
INSERT INTO dbo.[NguoiMuon]([MaDG],[TenDG],[GioiTinh],[NgaySinh],[DiaChi]) VALUES ('DG07',N'Nam Tàu',N'Nam','12-06-2000',N'Hà Nội') --tại sao nó lại tên nam tàu ?
INSERT INTO dbo.[NguoiMuon]([MaDG],[TenDG],[GioiTinh],[NgaySinh],[DiaChi]) VALUES ('DG08',N'Trần Duy Hưng',N'Nam','13-04-2000',N'Hà Nội')
