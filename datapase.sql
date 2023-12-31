USE [master]
GO
/****** Object:  Database [QuanLyDongPhuc]    Script Date: 11/16/2023 8:34:46 PM ******/
CREATE DATABASE [QuanLyDongPhuc]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QuanLyDongPhuc', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\QuanLyDongPhuc.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'QuanLyDongPhuc_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\QuanLyDongPhuc_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [QuanLyDongPhuc] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QuanLyDongPhuc].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QuanLyDongPhuc] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QuanLyDongPhuc] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QuanLyDongPhuc] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QuanLyDongPhuc] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QuanLyDongPhuc] SET ARITHABORT OFF 
GO
ALTER DATABASE [QuanLyDongPhuc] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [QuanLyDongPhuc] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [QuanLyDongPhuc] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QuanLyDongPhuc] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QuanLyDongPhuc] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QuanLyDongPhuc] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QuanLyDongPhuc] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QuanLyDongPhuc] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QuanLyDongPhuc] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QuanLyDongPhuc] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QuanLyDongPhuc] SET  DISABLE_BROKER 
GO
ALTER DATABASE [QuanLyDongPhuc] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QuanLyDongPhuc] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QuanLyDongPhuc] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QuanLyDongPhuc] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QuanLyDongPhuc] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QuanLyDongPhuc] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QuanLyDongPhuc] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QuanLyDongPhuc] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [QuanLyDongPhuc] SET  MULTI_USER 
GO
ALTER DATABASE [QuanLyDongPhuc] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QuanLyDongPhuc] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QuanLyDongPhuc] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QuanLyDongPhuc] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [QuanLyDongPhuc]
GO
/****** Object:  StoredProcedure [dbo].[QLDP_Get_InfoNhanVien]    Script Date: 11/16/2023 8:34:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[QLDP_Get_InfoNhanVien]
@MaNV nvarchar(20)
as
SELECT [MaNV]
      ,[TenNV]
      ,[NgaySinh]
      ,[GioiTinh]
      ,[ChucVu]
      ,nv.[MaPhongBan]
	  ,pb.TenPhongBan
	  
  FROM [QuanLyDongPhuc].[dbo].[NhanVien] nv,  [QuanLyDongPhuc].[dbo].[PhongBan] pb 
  where nv.MaPhongBan = pb.MaPhongBan and nv.MaNV=@MaNV
GO
/****** Object:  Table [dbo].[CapPhat]    Script Date: 11/16/2023 8:34:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CapPhat](
	[MaCapPhat] [nchar](10) NOT NULL,
	[TenNV] [nvarchar](50) NULL,
	[TenDongPhuc] [nvarchar](50) NULL,
	[TenPhongBan] [nvarchar](50) NULL,
	[GioiTinh] [nvarchar](10) NULL,
	[SoLuong] [int] NULL,
	[Size] [varchar](10) NULL,
	[DonGia] [int] NULL,
	[TongTien] [int] NULL,
	[NgayNhan] [datetime] NULL,
 CONSTRAINT [PK_CapPhat] PRIMARY KEY CLUSTERED 
(
	[MaCapPhat] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DongPhuc]    Script Date: 11/16/2023 8:34:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DongPhuc](
	[MaDongPhuc] [nchar](10) NOT NULL,
	[TenPhongBan] [nvarchar](50) NULL,
	[TenDongPhuc] [nvarchar](50) NULL,
	[DonGia] [float] NULL,
	[DonViTinh] [nvarchar](10) NULL,
	[Size] [nchar](10) NULL,
	[TrangThai] [nvarchar](10) NULL,
	[NgayTao] [datetime] NULL,
 CONSTRAINT [PK_DongPhuc] PRIMARY KEY CLUSTERED 
(
	[MaDongPhuc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Login]    Script Date: 11/16/2023 8:34:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Login](
	[TaiKhoan] [nvarchar](20) NOT NULL,
	[MatKhau] [nvarchar](20) NULL,
 CONSTRAINT [PK_Login] PRIMARY KEY CLUSTERED 
(
	[TaiKhoan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 11/16/2023 8:34:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhanVien](
	[MaNV] [nchar](10) NOT NULL,
	[TenNV] [nvarchar](50) NULL,
	[NgaySinh] [datetime] NULL,
	[GioiTinh] [nvarchar](10) NULL,
	[ChucVu] [nvarchar](50) NULL,
	[TenPhongBan] [nvarchar](50) NULL,
 CONSTRAINT [PK_NhanVien] PRIMARY KEY CLUSTERED 
(
	[MaNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PhongBan]    Script Date: 11/16/2023 8:34:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhongBan](
	[MaPhongBan] [nchar](10) NOT NULL,
	[TenPhongBan] [nvarchar](100) NULL,
	[TrangThai] [nvarchar](20) NULL,
 CONSTRAINT [PK_PhongBan] PRIMARY KEY CLUSTERED 
(
	[MaPhongBan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[CapPhat] ([MaCapPhat], [TenNV], [TenDongPhuc], [TenPhongBan], [GioiTinh], [SoLuong], [Size], [DonGia], [TongTien], [NgayNhan]) VALUES (N'cp000002  ', N'nguyễn văn a', N'đồng phục phòng giám đốc', N'phòng nhân sự ', N'nam', 2, N'XL', 1000000, 2000000, CAST(N'2023-08-12 00:00:00.000' AS DateTime))
INSERT [dbo].[CapPhat] ([MaCapPhat], [TenNV], [TenDongPhuc], [TenPhongBan], [GioiTinh], [SoLuong], [Size], [DonGia], [TongTien], [NgayNhan]) VALUES (N'cp000003  ', N'trần thị hạnh', N'đồng phục phòng điều hành', N'phòng điều hành', N'nữ', 2, N'L         ', 300000, 460000, CAST(N'2023-12-06 00:00:00.000' AS DateTime))
INSERT [dbo].[CapPhat] ([MaCapPhat], [TenNV], [TenDongPhuc], [TenPhongBan], [GioiTinh], [SoLuong], [Size], [DonGia], [TongTien], [NgayNhan]) VALUES (N'cp000004  ', N'hồ ngọc trân', N'đồng phục phòng tài chính', N'phòng tài chính', N'nữ', 2, N'L', 400000, 800000, CAST(N'2023-03-23 00:00:00.000' AS DateTime))
INSERT [dbo].[CapPhat] ([MaCapPhat], [TenNV], [TenDongPhuc], [TenPhongBan], [GioiTinh], [SoLuong], [Size], [DonGia], [TongTien], [NgayNhan]) VALUES (N'cp000005  ', N'phạm thị huyền trân', N'đồng phục phòng coder', N'phòng coder', N'nữ', 3, N'L', 250000, 750000, CAST(N'2020-02-19 00:00:00.000' AS DateTime))
INSERT [dbo].[CapPhat] ([MaCapPhat], [TenNV], [TenDongPhuc], [TenPhongBan], [GioiTinh], [SoLuong], [Size], [DonGia], [TongTien], [NgayNhan]) VALUES (N'cp000006  ', N'trần thị tuyết nhi', N'đồng phục phòng hội trường', N'phòng hội trường', N'Nữ', 7, N'XXL', 500000, 3500000, CAST(N'2023-11-01 00:00:00.000' AS DateTime))
INSERT [dbo].[CapPhat] ([MaCapPhat], [TenNV], [TenDongPhuc], [TenPhongBan], [GioiTinh], [SoLuong], [Size], [DonGia], [TongTien], [NgayNhan]) VALUES (N'cp000007  ', N'phạm thị huyền trân', N'đồng phục phòng coder', N'phòng coder', N'nữ', 7, N'XXL', 250000, 1750000, CAST(N'2023-11-01 00:00:00.000' AS DateTime))
INSERT [dbo].[CapPhat] ([MaCapPhat], [TenNV], [TenDongPhuc], [TenPhongBan], [GioiTinh], [SoLuong], [Size], [DonGia], [TongTien], [NgayNhan]) VALUES (N'cp000008  ', N'trần thị bười', N'đồng phục phòng hội trường', N'phòng hội trường', N'Nữ', 2, N'XXL', 500000, 1000000, CAST(N'2023-11-02 00:00:00.000' AS DateTime))
INSERT [dbo].[CapPhat] ([MaCapPhat], [TenNV], [TenDongPhuc], [TenPhongBan], [GioiTinh], [SoLuong], [Size], [DonGia], [TongTien], [NgayNhan]) VALUES (N'cp000009  ', N'châu ngọc như', N'đồng phục phòng giám đốc ', N'phòng giám đốc ', N'Nữ', 2, N'M', 1000000, 2000000, CAST(N'1900-01-01 00:00:00.000' AS DateTime))
INSERT [dbo].[CapPhat] ([MaCapPhat], [TenNV], [TenDongPhuc], [TenPhongBan], [GioiTinh], [SoLuong], [Size], [DonGia], [TongTien], [NgayNhan]) VALUES (N'cp000010  ', N'trần thị hạnh', N'đồng phục phòng điều hành', N'phòng điều hành', N'Nữ', 4, N'M         ', 230000, 920000, CAST(N'2023-11-07 00:00:00.000' AS DateTime))
INSERT [dbo].[CapPhat] ([MaCapPhat], [TenNV], [TenDongPhuc], [TenPhongBan], [GioiTinh], [SoLuong], [Size], [DonGia], [TongTien], [NgayNhan]) VALUES (N'cp000011  ', N'trần thị tuyết nhi', N'đồng phục phòng hội trường', N'phòng hội trường', N'Nữ', 4, N'L         ', 450000, 1800000, CAST(N'2015-07-21 00:00:00.000' AS DateTime))
INSERT [dbo].[CapPhat] ([MaCapPhat], [TenNV], [TenDongPhuc], [TenPhongBan], [GioiTinh], [SoLuong], [Size], [DonGia], [TongTien], [NgayNhan]) VALUES (N'cp000012  ', N'nguyễn thanhnguyên', N'đồng phục phòng design', N'phòng design', N'Nam', 5, N'M         ', 280000, 1400000, CAST(N'2023-11-09 00:00:00.000' AS DateTime))
INSERT [dbo].[CapPhat] ([MaCapPhat], [TenNV], [TenDongPhuc], [TenPhongBan], [GioiTinh], [SoLuong], [Size], [DonGia], [TongTien], [NgayNhan]) VALUES (N'cp000013  ', N'nguyễn thanhnguyên', N'đồng phục phòng design', N'phòng design', N'Nam', 2, N'L         ', 300000, 600000, CAST(N'1990-01-01 00:00:00.000' AS DateTime))
INSERT [dbo].[CapPhat] ([MaCapPhat], [TenNV], [TenDongPhuc], [TenPhongBan], [GioiTinh], [SoLuong], [Size], [DonGia], [TongTien], [NgayNhan]) VALUES (N'cp000014  ', N'lý thị kiều dễm', N'đồng phục phòng design', N'phòng design', N'Nữ', 3, N'M         ', 280000, 840000, CAST(N'2023-11-09 00:00:00.000' AS DateTime))
INSERT [dbo].[CapPhat] ([MaCapPhat], [TenNV], [TenDongPhuc], [TenPhongBan], [GioiTinh], [SoLuong], [Size], [DonGia], [TongTien], [NgayNhan]) VALUES (N'cp000015  ', N'nguyễn thị thu nguyệt ', N'đồng phục phòng nhân sự ', N'phòng nhân sự ', N'Nữ', 4, N'L         ', 270000, 1080000, CAST(N'2023-11-09 00:00:00.000' AS DateTime))
INSERT [dbo].[CapPhat] ([MaCapPhat], [TenNV], [TenDongPhuc], [TenPhongBan], [GioiTinh], [SoLuong], [Size], [DonGia], [TongTien], [NgayNhan]) VALUES (N'cp000016  ', N'đoàn ngọc hải', N'đồng phục phòng hội trường', N'phòng hội trường', N'Nam', 2, N'L         ', 450000, 900000, CAST(N'2023-11-09 00:00:00.000' AS DateTime))
INSERT [dbo].[CapPhat] ([MaCapPhat], [TenNV], [TenDongPhuc], [TenPhongBan], [GioiTinh], [SoLuong], [Size], [DonGia], [TongTien], [NgayNhan]) VALUES (N'cp000017  ', N'hoàng trọng phi', N'đồng phục phòng điều hành', N'phòng điều hành', N'Nam', 4, N'XL        ', 500000, 2000000, CAST(N'1990-01-01 00:00:00.000' AS DateTime))
INSERT [dbo].[CapPhat] ([MaCapPhat], [TenNV], [TenDongPhuc], [TenPhongBan], [GioiTinh], [SoLuong], [Size], [DonGia], [TongTien], [NgayNhan]) VALUES (N'cp000018  ', N'dương văn lâm', N'đồng phục phòng nhân sự ', N'phòng nhân sự ', N'Nam', 2, N'XL        ', 250000, 500000, CAST(N'2023-11-09 00:00:00.000' AS DateTime))
INSERT [dbo].[CapPhat] ([MaCapPhat], [TenNV], [TenDongPhuc], [TenPhongBan], [GioiTinh], [SoLuong], [Size], [DonGia], [TongTien], [NgayNhan]) VALUES (N'cp000019  ', N'nguyễn văn a', N'đồng phục phòng giám đốc ', N'phòng giám đốc ', N'Nam', 4, N'L         ', 1000000, 4000000, CAST(N'2023-11-09 00:00:00.000' AS DateTime))
INSERT [dbo].[CapPhat] ([MaCapPhat], [TenNV], [TenDongPhuc], [TenPhongBan], [GioiTinh], [SoLuong], [Size], [DonGia], [TongTien], [NgayNhan]) VALUES (N'cp000020  ', N'phạm thị huyền trân', N'đồng phục phòng coder', N'phòng coder', N'Nữ', 3, N'XL        ', 550000, 1650000, CAST(N'2023-11-11 00:00:00.000' AS DateTime))
INSERT [dbo].[CapPhat] ([MaCapPhat], [TenNV], [TenDongPhuc], [TenPhongBan], [GioiTinh], [SoLuong], [Size], [DonGia], [TongTien], [NgayNhan]) VALUES (N'cp000021  ', N'bùi thị hạnh', N'đồng phục mai mặc', N'phòng mai mặc', N'Nữ', 3, N'XL        ', 400000, 1200000, CAST(N'2023-11-14 00:00:00.000' AS DateTime))
INSERT [dbo].[DongPhuc] ([MaDongPhuc], [TenPhongBan], [TenDongPhuc], [DonGia], [DonViTinh], [Size], [TrangThai], [NgayTao]) VALUES (N'dp001     ', N'phòng tài chính', N'đồng phục phòng tài chính', 400000, N'bộ	', N'L         ', N'còn hàng', CAST(N'2023-12-01 00:00:00.000' AS DateTime))
INSERT [dbo].[DongPhuc] ([MaDongPhuc], [TenPhongBan], [TenDongPhuc], [DonGia], [DonViTinh], [Size], [TrangThai], [NgayTao]) VALUES (N'dp002     ', N'phòng coder', N'đồng phục phòng coder', 550000, N'bộ        ', N'XL        ', N'còn hàng ', CAST(N'2023-11-19 00:00:00.000' AS DateTime))
INSERT [dbo].[DongPhuc] ([MaDongPhuc], [TenPhongBan], [TenDongPhuc], [DonGia], [DonViTinh], [Size], [TrangThai], [NgayTao]) VALUES (N'dp003     ', N'phòng điều hành', N'đồng phục phòng điều hành', 230000, N'bộ', N'M         ', N'còn hàng ', CAST(N'2023-05-15 00:00:00.000' AS DateTime))
INSERT [dbo].[DongPhuc] ([MaDongPhuc], [TenPhongBan], [TenDongPhuc], [DonGia], [DonViTinh], [Size], [TrangThai], [NgayTao]) VALUES (N'dp004     ', N'phòng nhân sự     ', N'đồng phục phòng nhân sự ', 250000, N'bộ', N'XL        ', N'còn hàng ', CAST(N'2023-06-18 00:00:00.000' AS DateTime))
INSERT [dbo].[DongPhuc] ([MaDongPhuc], [TenPhongBan], [TenDongPhuc], [DonGia], [DonViTinh], [Size], [TrangThai], [NgayTao]) VALUES (N'dp005     ', N'phòng design     ', N'đồng phục phòng design', 300000, N'bộ', N'L         ', N'còn hàng', CAST(N'2023-12-04 00:00:00.000' AS DateTime))
INSERT [dbo].[DongPhuc] ([MaDongPhuc], [TenPhongBan], [TenDongPhuc], [DonGia], [DonViTinh], [Size], [TrangThai], [NgayTao]) VALUES (N'dp006     ', N'phòng giám đốc     ', N'đồng phục phòng giám đốc ', 1000000, N'bộ', N'L         ', N'còn hàng ', CAST(N'2023-10-08 00:00:00.000' AS DateTime))
INSERT [dbo].[DongPhuc] ([MaDongPhuc], [TenPhongBan], [TenDongPhuc], [DonGia], [DonViTinh], [Size], [TrangThai], [NgayTao]) VALUES (N'dp007     ', N'phòng điều hành', N'đồng phục phòng điều hành', 500000, N'bộ', N'XL        ', N'còn hàng ', CAST(N'2023-10-31 00:00:00.000' AS DateTime))
INSERT [dbo].[DongPhuc] ([MaDongPhuc], [TenPhongBan], [TenDongPhuc], [DonGia], [DonViTinh], [Size], [TrangThai], [NgayTao]) VALUES (N'dp008     ', N'phòng hội trường', N'đồng phục phòng hội trường', 500000, N'bộ', N'XL        ', N'còn hàng ', CAST(N'2023-10-31 00:00:00.000' AS DateTime))
INSERT [dbo].[DongPhuc] ([MaDongPhuc], [TenPhongBan], [TenDongPhuc], [DonGia], [DonViTinh], [Size], [TrangThai], [NgayTao]) VALUES (N'dp009     ', N'phòng tài chính', N'đồng phục phòng tài chính', 350000, N'bộ', N'M         ', N'còn hàng ', CAST(N'2034-06-15 00:00:00.000' AS DateTime))
INSERT [dbo].[DongPhuc] ([MaDongPhuc], [TenPhongBan], [TenDongPhuc], [DonGia], [DonViTinh], [Size], [TrangThai], [NgayTao]) VALUES (N'dp010     ', N'phòng tài chính', N'đồng phục phòng tài chính', 4500000, N'bộ', N'XL        ', N'hết hàng ', CAST(N'2011-07-18 00:00:00.000' AS DateTime))
INSERT [dbo].[DongPhuc] ([MaDongPhuc], [TenPhongBan], [TenDongPhuc], [DonGia], [DonViTinh], [Size], [TrangThai], [NgayTao]) VALUES (N'dp011     ', N'phòng coder', N'đồng phục phòng coder', 500000, N'bộ', N'L         ', N'còn hàng ', CAST(N'2014-06-12 00:00:00.000' AS DateTime))
INSERT [dbo].[DongPhuc] ([MaDongPhuc], [TenPhongBan], [TenDongPhuc], [DonGia], [DonViTinh], [Size], [TrangThai], [NgayTao]) VALUES (N'dp012     ', N'phòng điều hành', N'đồng phục phòng điều hành', 300000, N'bộ', N'L         ', N'hết hàng ', CAST(N'1905-06-22 00:00:00.000' AS DateTime))
INSERT [dbo].[DongPhuc] ([MaDongPhuc], [TenPhongBan], [TenDongPhuc], [DonGia], [DonViTinh], [Size], [TrangThai], [NgayTao]) VALUES (N'dp013     ', N'phòng nhân sự ', N'đồng phục phòng nhân sự ', 270000, N'bộ', N'L         ', N'còn hàng ', CAST(N'1909-06-17 00:00:00.000' AS DateTime))
INSERT [dbo].[DongPhuc] ([MaDongPhuc], [TenPhongBan], [TenDongPhuc], [DonGia], [DonViTinh], [Size], [TrangThai], [NgayTao]) VALUES (N'dp014     ', N'phòng design', N'đồng phục phòng design', 280000, N'bộ', N'M         ', N'còn hàng ', CAST(N'1914-02-18 00:00:00.000' AS DateTime))
INSERT [dbo].[DongPhuc] ([MaDongPhuc], [TenPhongBan], [TenDongPhuc], [DonGia], [DonViTinh], [Size], [TrangThai], [NgayTao]) VALUES (N'dp015     ', N'phòng giám đốc ', N'đồng phục phòng giám đốc ', 120000, N'bộ', N'XL        ', N'còn hàng ', CAST(N'2021-06-24 00:00:00.000' AS DateTime))
INSERT [dbo].[DongPhuc] ([MaDongPhuc], [TenPhongBan], [TenDongPhuc], [DonGia], [DonViTinh], [Size], [TrangThai], [NgayTao]) VALUES (N'dp016     ', N'phòng hội trường', N'đồng phục phòng hội trường', 450000, N'bộ', N'L         ', N'còn hàng ', CAST(N'2004-06-25 00:00:00.000' AS DateTime))
INSERT [dbo].[DongPhuc] ([MaDongPhuc], [TenPhongBan], [TenDongPhuc], [DonGia], [DonViTinh], [Size], [TrangThai], [NgayTao]) VALUES (N'dp017     ', N'phòng design', N'đồng phục phòng design', 250000, N'bộ', N'XXL       ', N'còn hàng ', CAST(N'1900-01-01 00:00:00.000' AS DateTime))
INSERT [dbo].[DongPhuc] ([MaDongPhuc], [TenPhongBan], [TenDongPhuc], [DonGia], [DonViTinh], [Size], [TrangThai], [NgayTao]) VALUES (N'dp018     ', N'phòng mai mặc', N'đồng phục phòng mai mặc', 400000, N'bộ', N'XL        ', N'còn hàng ', CAST(N'2023-11-14 00:00:00.000' AS DateTime))
INSERT [dbo].[DongPhuc] ([MaDongPhuc], [TenPhongBan], [TenDongPhuc], [DonGia], [DonViTinh], [Size], [TrangThai], [NgayTao]) VALUES (N'dp019     ', N'phòng mai mặc', N'đồng phục phòng mai mặc', 360000, N'bộ', N'M         ', N'còn hàng ', CAST(N'2023-11-14 00:00:00.000' AS DateTime))
INSERT [dbo].[DongPhuc] ([MaDongPhuc], [TenPhongBan], [TenDongPhuc], [DonGia], [DonViTinh], [Size], [TrangThai], [NgayTao]) VALUES (N'dp020     ', N'phòng maketing', N'đồng phục phònng maketing', 600000, N'bộ', N'L         ', N'còn hàng ', CAST(N'2023-11-15 00:00:00.000' AS DateTime))
INSERT [dbo].[Login] ([TaiKhoan], [MatKhau]) VALUES (N'admin', N'12345')
INSERT [dbo].[Login] ([TaiKhoan], [MatKhau]) VALUES (N'nguyen', N'123')
INSERT [dbo].[Login] ([TaiKhoan], [MatKhau]) VALUES (N'sa', N'123456')
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [NgaySinh], [GioiTinh], [ChucVu], [TenPhongBan]) VALUES (N'nv01      ', N'nguyễn văn a', CAST(N'1995-06-23 00:00:00.000' AS DateTime), N'Nam', N'giám đốc', N'phòng giám đốc ')
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [NgaySinh], [GioiTinh], [ChucVu], [TenPhongBan]) VALUES (N'nv02      ', N'lý thị kiều dễm', CAST(N'1998-06-30 00:00:00.000' AS DateTime), N'Nữ', N'nhân viên design', N'phòng design')
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [NgaySinh], [GioiTinh], [ChucVu], [TenPhongBan]) VALUES (N'nv03      ', N'trần thị hạnh', CAST(N'1986-08-20 00:00:00.000' AS DateTime), N'Nữ', N'nhân viên điều hành', N'phòng điều hành')
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [NgaySinh], [GioiTinh], [ChucVu], [TenPhongBan]) VALUES (N'nv04      ', N'phạm thị huyền trân', CAST(N'2000-06-23 00:00:00.000' AS DateTime), N'Nữ', N'nhân viên coder', N'phòng coder')
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [NgaySinh], [GioiTinh], [ChucVu], [TenPhongBan]) VALUES (N'nv05      ', N'nguyễn thanhnguyên', CAST(N'2023-07-20 00:00:00.000' AS DateTime), N'Nam', N'nhân viên design', N'phòng design')
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [NgaySinh], [GioiTinh], [ChucVu], [TenPhongBan]) VALUES (N'nv06      ', N'hồ ngọc trân', CAST(N'2020-02-04 00:00:00.000' AS DateTime), N'Nữ', N'nhân viên tài chính', N'phòng tài chính')
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [NgaySinh], [GioiTinh], [ChucVu], [TenPhongBan]) VALUES (N'nv07      ', N'nguyễn thị thu nguyệt ', CAST(N'2019-02-12 00:00:00.000' AS DateTime), N'Nữ', N'nhân viên nhân sự', N'phòng nhân sự ')
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [NgaySinh], [GioiTinh], [ChucVu], [TenPhongBan]) VALUES (N'nv08      ', N'trần thị tuyết nhi', CAST(N'2023-11-01 00:00:00.000' AS DateTime), N'Nữ', N'quản lý hội trường ', N'phòng hội trường')
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [NgaySinh], [GioiTinh], [ChucVu], [TenPhongBan]) VALUES (N'nv09      ', N'đoàn ngọc hải', CAST(N'2020-02-29 00:00:00.000' AS DateTime), N'Nam', N'nhân viên hội trường ', N'phòng hội trường')
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [NgaySinh], [GioiTinh], [ChucVu], [TenPhongBan]) VALUES (N'nv10      ', N'trần thị bười', CAST(N'2019-02-28 00:00:00.000' AS DateTime), N'Nữ', N'quản lý hội trường', N'phòng hội trường')
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [NgaySinh], [GioiTinh], [ChucVu], [TenPhongBan]) VALUES (N'nv11      ', N'châu ngọc như', CAST(N'2002-10-24 00:00:00.000' AS DateTime), N'Nữ', N'trợ lý gám đốc', N'phòng giám đốc ')
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [NgaySinh], [GioiTinh], [ChucVu], [TenPhongBan]) VALUES (N'nv12      ', N'hoàng trọng phi', CAST(N'1995-07-19 00:00:00.000' AS DateTime), N'Nam', N'nhân viên điều hành', N'phòng điều hành')
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [NgaySinh], [GioiTinh], [ChucVu], [TenPhongBan]) VALUES (N'nv13      ', N'dương văn lâm', CAST(N'1995-06-21 00:00:00.000' AS DateTime), N'Nam', N'nhân viên nhân sự', N'phòng nhân sự ')
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [NgaySinh], [GioiTinh], [ChucVu], [TenPhongBan]) VALUES (N'nv14      ', N'bùi thị hạnh', CAST(N'2023-11-14 00:00:00.000' AS DateTime), N'Nữ', N'quản công phòng mai mặc', N'phòng mai mặc')
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [NgaySinh], [GioiTinh], [ChucVu], [TenPhongBan]) VALUES (N'nv15      ', N'mai cơ owen', CAST(N'2001-06-22 00:00:00.000' AS DateTime), N'Nam', N'nhân viên maketing', N'phòng maketing')
INSERT [dbo].[PhongBan] ([MaPhongBan], [TenPhongBan], [TrangThai]) VALUES (N'pb001     ', N'phòng tài chính', N'hoạt động')
INSERT [dbo].[PhongBan] ([MaPhongBan], [TenPhongBan], [TrangThai]) VALUES (N'pb002     ', N'phòng nhân sự ', N'hoạt động')
INSERT [dbo].[PhongBan] ([MaPhongBan], [TenPhongBan], [TrangThai]) VALUES (N'pb003     ', N'phòng giám đốc ', N'hoạt động')
INSERT [dbo].[PhongBan] ([MaPhongBan], [TenPhongBan], [TrangThai]) VALUES (N'pb004     ', N'phòng coder', N'hoạt động')
INSERT [dbo].[PhongBan] ([MaPhongBan], [TenPhongBan], [TrangThai]) VALUES (N'pb005     ', N'phòng điều hành', N'hoạt động')
INSERT [dbo].[PhongBan] ([MaPhongBan], [TenPhongBan], [TrangThai]) VALUES (N'pb006     ', N'phòng design', N'hoạt động')
INSERT [dbo].[PhongBan] ([MaPhongBan], [TenPhongBan], [TrangThai]) VALUES (N'pb007     ', N'phòng hội trường', N'hoạt động')
INSERT [dbo].[PhongBan] ([MaPhongBan], [TenPhongBan], [TrangThai]) VALUES (N'pb008     ', N'phòng mai mặc', N'ngưng hoạt động')
INSERT [dbo].[PhongBan] ([MaPhongBan], [TenPhongBan], [TrangThai]) VALUES (N'pb009     ', N'phòng maketing', N'hoạt động')
USE [master]
GO
ALTER DATABASE [QuanLyDongPhuc] SET  READ_WRITE 
GO
