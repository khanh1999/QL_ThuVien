USE [QuanLyThuVien]
GO
/****** Object:  Table [dbo].[Muon]    Script Date: 12/08/2023 9:39:37 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Muon](
	[MaSach] [nchar](10) NOT NULL,
	[MaMuon] [nchar](10) NOT NULL,
	[NgayMuon] [date] NOT NULL,
	[NgayTra] [date] NOT NULL,
 CONSTRAINT [PK_Muon_1] PRIMARY KEY CLUSTERED 
(
	[MaSach] ASC,
	[MaMuon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NgMuon]    Script Date: 12/08/2023 9:39:37 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NgMuon](
	[MaMuon] [nchar](10) NOT NULL,
	[HoTen] [nvarchar](50) NOT NULL,
	[DiaChi] [nvarchar](50) NOT NULL,
	[SDT] [nchar](10) NULL,
 CONSTRAINT [PK_Muon] PRIMARY KEY CLUSTERED 
(
	[MaMuon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sach]    Script Date: 12/08/2023 9:39:37 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sach](
	[MaSach] [nchar](10) NOT NULL,
	[TenSach] [nvarchar](50) NOT NULL,
	[MaLoai] [nchar](10) NOT NULL,
	[SoLuong] [int] NOT NULL,
	[TenTgia] [nvarchar](50) NOT NULL,
	[Gia] [money] NOT NULL,
 CONSTRAINT [PK_Sach] PRIMARY KEY CLUSTERED 
(
	[MaSach] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Muon] ([MaSach], [MaMuon], [NgayMuon], [NgayTra]) VALUES (N'S05       ', N'M01       ', CAST(N'2022-08-14' AS Date), CAST(N'2022-08-17' AS Date))
INSERT [dbo].[Muon] ([MaSach], [MaMuon], [NgayMuon], [NgayTra]) VALUES (N'S08       ', N'M03       ', CAST(N'2022-08-14' AS Date), CAST(N'2022-08-16' AS Date))
GO
INSERT [dbo].[NgMuon] ([MaMuon], [HoTen], [DiaChi], [SDT]) VALUES (N'M01       ', N'Phan Minh Quân', N'1604 Nguyễn Xiển', N'0777919108')
INSERT [dbo].[NgMuon] ([MaMuon], [HoTen], [DiaChi], [SDT]) VALUES (N'M03       ', N'Hoài Nam', N'377 Bình Quới', N'0931095010')
INSERT [dbo].[NgMuon] ([MaMuon], [HoTen], [DiaChi], [SDT]) VALUES (N'zxc       ', N'ádadasd', N'ádasdas', N'gxahwefa  ')
GO
INSERT [dbo].[Sach] ([MaSach], [TenSach], [MaLoai], [SoLuong], [TenTgia], [Gia]) VALUES (N'S02       ', N'Toán Cao Cấp A2', N'GD        ', 2, N'BQK', 50000.0000)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [MaLoai], [SoLuong], [TenTgia], [Gia]) VALUES (N'S03       ', N'To The Moon', N'KH        ', 1, N'DHN', 110000.0000)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [MaLoai], [SoLuong], [TenTgia], [Gia]) VALUES (N'S04       ', N'Cơ Sở Dữ Liệu', N'VH        ', 1, N'DHN', 50000.0000)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [MaLoai], [SoLuong], [TenTgia], [Gia]) VALUES (N'S05       ', N'Toán Cao Cấp A2', N'GD        ', 2, N'SQH', 50000.0000)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [MaLoai], [SoLuong], [TenTgia], [Gia]) VALUES (N'S07       ', N'Anh Văn Cơ Bản', N'NN        ', 4, N'VTL', 60000.0000)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [MaLoai], [SoLuong], [TenTgia], [Gia]) VALUES (N'S08       ', N'Anh Văn Chuyên Ngành 1', N'NN        ', 2, N'VTL', 80000.0000)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [MaLoai], [SoLuong], [TenTgia], [Gia]) VALUES (N'S09       ', N'Giao Dục Công Dân', N'GD        ', 4, N'BQK', 40000.0000)
GO
ALTER TABLE [dbo].[Muon]  WITH CHECK ADD  CONSTRAINT [FK_Muon_NgMuon] FOREIGN KEY([MaMuon])
REFERENCES [dbo].[NgMuon] ([MaMuon])
GO
ALTER TABLE [dbo].[Muon] CHECK CONSTRAINT [FK_Muon_NgMuon]
GO
ALTER TABLE [dbo].[Muon]  WITH CHECK ADD  CONSTRAINT [FK_Muon_Sach] FOREIGN KEY([MaSach])
REFERENCES [dbo].[Sach] ([MaSach])
GO
ALTER TABLE [dbo].[Muon] CHECK CONSTRAINT [FK_Muon_Sach]
GO
