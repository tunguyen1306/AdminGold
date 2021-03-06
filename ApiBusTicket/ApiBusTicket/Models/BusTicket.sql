USE [ApiBusTicket]
GO
/****** Object:  Table [dbo].[Description services]    Script Date: 02/16/2017 10:39:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Description services](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[MaDV] [nvarchar](50) NOT NULL,
	[TenDV] [nvarchar](50) NULL,
	[SOKHOITAO] [nvarchar](50) NULL,
	[SOTHUTU] [nvarchar](50) NULL,
	[SOPHUCVU] [nvarchar](50) NULL,
	[Cam] [bit] NULL,
	[TOMTAT] [nvarchar](50) NULL,
	[Service] [nvarchar](50) NULL,
	[Giave] [nvarchar](50) NULL,
 CONSTRAINT [PK_Description services] PRIMARY KEY CLUSTERED 
(
	[MaDV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DICHVU]    Script Date: 02/16/2017 10:39:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DICHVU](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NGAY] [datetime] NULL,
	[SQMS] [nvarchar](50) NULL,
	[GIOLAYSO] [datetime] NULL,
	[dichvu] [nvarchar](50) NULL,
	[GIAVE] [nvarchar](50) NULL,
	[MATUYEN] [nvarchar](50) NULL,
	[TENTUYEN] [nvarchar](50) NULL,
	[MATRAMDAU] [nvarchar](50) NULL,
	[MATRAMCUOI] [nvarchar](50) NULL,
	[LOTRINH] [nvarchar](50) NULL,
	[BienSoXe] [nvarchar](50) NULL,
	[TRANGTHAI] [nvarchar](50) NULL,
	[PHUCVU] [bit] NULL,
	[GHICHU] [nvarchar](50) NULL,
	[Contro] [bit] NULL,
	[Doc] [bit] NULL,
	[DATCHO] [bit] NULL,
	[GIO_GOC] [datetime] NULL,
	[BINH_CHON] [nvarchar](50) NULL,
	[GIO_BINHCHON] [datetime] NULL,
	[NGONNGU] [nvarchar](50) NULL,
	[DIEMGIAODICH] [nvarchar](50) NULL,
	[MANV] [nvarchar](50) NULL,
	[QUAYCHUYEN] [nvarchar](50) NULL,
	[QUAYTHAMCHIEU] [nvarchar](50) NULL,
	[SODIENTHOAI] [nvarchar](50) NULL,
	[QUAY] [nvarchar](50) NULL,
	[GIOPHUCVU] [datetime] NULL,
	[MAXE] [nvarchar](50) NULL,
	[MATAIXE] [nvarchar](50) NULL,
	[MATRAM] [nvarchar](50) NULL,
	[IDTUYEN] [nvarchar](50) NULL,
	[KYHIEUVE] [nvarchar](50) NULL,
	[MAUSO] [nvarchar](50) NULL,
	[MATRAMGIUA] [nvarchar](50) NULL,
 CONSTRAINT [PK_DICHVU] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DMHOADON]    Script Date: 02/16/2017 10:39:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DMHOADON](
	[IDHOADON] [varchar](50) NOT NULL,
	[MAXE] [varchar](50) NULL,
	[KYHIEUVE] [varchar](50) NULL,
	[MAUSO] [varchar](50) NULL,
	[TONGSOVEPHATHANH] [int] NULL,
	[SOVEHIENTAI] [int] NULL,
	[IDVE] [int] NULL,
 CONSTRAINT [PK_DMHOADON] PRIMARY KEY CLUSTERED 
(
	[IDHOADON] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DMTAIXE]    Script Date: 02/16/2017 10:39:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DMTAIXE](
	[MATAIXE] [nvarchar](50) NOT NULL,
	[TENTAIXE] [nvarchar](50) NULL,
	[TUOI] [int] NULL,
	[GIOITINH] [nvarchar](50) NULL,
	[BANGLAI] [nvarchar](50) NULL,
	[SDT] [nvarchar](50) NULL,
	[DIACHINOIO] [nvarchar](50) NULL,
	[EMAIL] [varbinary](50) NULL,
 CONSTRAINT [PK_DMTAIXE] PRIMARY KEY CLUSTERED 
(
	[MATAIXE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DMTRAM]    Script Date: 02/16/2017 10:39:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DMTRAM](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MATRAM] [nvarchar](50) NULL,
	[TENTRAM] [nvarchar](50) NULL,
 CONSTRAINT [PK_DMTRAM] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DMTUYEN]    Script Date: 02/16/2017 10:39:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DMTUYEN](
	[IDTUYEN] [nvarchar](50) NOT NULL,
	[MATUYEN] [nvarchar](50) NULL,
	[TENTUYENENG] [nvarchar](50) NULL,
	[TENTUYENVN] [nvarchar](50) NULL,
	[MATRAMDAU] [nvarchar](50) NULL,
	[MATRAMGIUA] [nvarchar](50) NULL,
	[MATRAMCUOI] [nvarchar](50) NULL,
	[TONGTRAM] [nvarchar](50) NULL,
	[MUCDO] [int] NULL,
	[THOIGIANTOANTRAM] [datetime] NULL,
	[GIAVE1] [int] NULL,
	[DIENGIAIVE1] [nvarchar](50) NULL,
	[CAMVE1] [bit] NULL,
	[IDVE1IDHOADON] [nvarchar](50) NULL,
	[GIAVE2] [int] NULL,
	[DIENGIAIVE2] [nvarchar](50) NULL,
	[CAMVE2] [bit] NULL,
	[IDVE2IDHOADON] [nvarchar](50) NULL,
	[GIAVE3] [int] NULL,
	[DIENGIAIVE3] [nvarchar](50) NULL,
	[CAMVE3] [bit] NULL,
	[IDVE3IDHOADON] [nvarchar](50) NULL,
	[GIAVE4] [int] NULL,
	[DIENGIAIVE4] [nvarchar](50) NULL,
	[CAMVE4] [bit] NULL,
	[IDVE4IDHOADON] [nvarchar](50) NULL,
	[GIAVE5] [int] NULL,
	[DIENGIAIVE5] [nvarchar](50) NULL,
	[CAMVE5] [bit] NULL,
	[IDVE5IDHOADON] [nvarchar](50) NULL,
	[GIAVE6] [int] NULL,
	[DIENGIAIVE6] [nvarchar](50) NULL,
	[CAMVE6] [int] NULL,
	[IDVE6IDHOADON] [nvarchar](50) NULL,
 CONSTRAINT [PK_DMTUYEN] PRIMARY KEY CLUSTERED 
(
	[IDTUYEN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DMTUYENCHITIETTRAM]    Script Date: 02/16/2017 10:39:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DMTUYENCHITIETTRAM](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IDTUYEN] [nchar](10) NULL,
	[MATRAM] [nchar](10) NULL,
	[TRAMDAU] [bit] NULL,
	[TRAMCUOI] [bit] NULL,
 CONSTRAINT [PK_DMTUYENCHITIETTRAM] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DMXE]    Script Date: 02/16/2017 10:39:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DMXE](
	[MAXE] [nvarchar](50) NOT NULL,
	[SOXE] [nvarchar](50) NULL,
	[LOAIXE] [nvarchar](50) NULL,
	[MATAIXE] [nvarchar](50) NULL,
	[SOGHE] [nvarchar](50) NULL,
 CONSTRAINT [PK_DMXE] PRIMARY KEY CLUSTERED 
(
	[MAXE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Docso]    Script Date: 02/16/2017 10:39:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Docso](
	[id] [int] NOT NULL,
	[NGAY] [datetime] NULL,
	[SQMS] [nchar](10) NULL,
	[GIOLAYSO] [datetime] NULL,
	[QUAY] [nvarchar](50) NULL,
	[Doc] [bit] NULL,
	[NGONNGU] [nvarchar](50) NULL,
	[BIENKIEMSOAT] [nvarchar](50) NULL,
	[TRONGTAI] [nvarchar](50) NULL,
	[TENTAIXE] [nvarchar](50) NULL,
	[MATHE] [nvarchar](50) NULL,
	[SODIENTHOAI] [nvarchar](50) NULL,
	[Giovao] [nvarchar](50) NULL,
	[Giolayhang] [nvarchar](50) NULL,
	[Giora] [nvarchar](50) NULL,
	[PLANT] [nvarchar](50) NULL,
	[CHECKOUT] [bit] NULL,
	[PO] [nvarchar](50) NULL,
	[GIAYPHEP] [nvarchar](50) NULL,
 CONSTRAINT [PK_Docso] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HIENTHI]    Script Date: 02/16/2017 10:39:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HIENTHI](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NGANHANG] [nvarchar](50) NULL,
	[SQMS] [nvarchar](50) NULL,
	[STT] [nvarchar](50) NULL,
	[Dichvu] [nvarchar](50) NULL,
	[Check] [bit] NULL,
 CONSTRAINT [PK_HIENTHI] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LCD]    Script Date: 02/16/2017 10:39:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LCD](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PHONG] [nvarchar](50) NULL,
	[SQMS] [nvarchar](50) NULL,
	[NEXT] [nvarchar](50) NULL,
	[CAM] [bit] NULL,
	[STT] [nvarchar](50) NULL,
	[COUNTER] [nvarchar](50) NULL,
 CONSTRAINT [PK_LCD] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LCDKios]    Script Date: 02/16/2017 10:39:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LCDKios](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PHONG] [nvarchar](50) NULL,
	[CounterName] [nvarchar](50) NULL,
	[SQMS] [nvarchar](50) NULL,
	[NEXT] [nvarchar](50) NULL,
	[CAM] [bit] NULL,
	[STT] [nvarchar](50) NULL,
	[COUNTER] [nvarchar](50) NULL,
	[TRANGTHAI] [nvarchar](50) NULL,
	[STATUS] [nvarchar](50) NULL,
	[MAU] [nvarchar](50) NULL,
	[Loai] [nvarchar](50) NULL,
	[DienGiai] [nvarchar](50) NULL,
 CONSTRAINT [PK_LCDKios] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LOTRINHCHOXE]    Script Date: 02/16/2017 10:39:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LOTRINHCHOXE](
	[IDLOTRINH] [int] IDENTITY(1,1) NOT NULL,
	[MAXE] [nvarchar](50) NULL,
	[IDTUYEN] [nvarchar](50) NULL,
	[MATAIXE] [nvarchar](50) NULL,
	[CAM] [bit] NULL,
	[KICHHOAT] [bit] NULL,
 CONSTRAINT [PK_LOTRINHCHOXE] PRIMARY KEY CLUSTERED 
(
	[IDLOTRINH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PGD]    Script Date: 02/16/2017 10:39:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PGD](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[MAPGD] [nvarchar](50) NULL,
	[TENPGD] [nvarchar](50) NULL,
	[DIACHI] [nvarchar](50) NULL,
	[Tel] [nvarchar](50) NULL,
	[KHUVUC] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Ghichu] [nvarchar](50) NULL,
 CONSTRAINT [PK_PGD] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PHAN LOAI PGD]    Script Date: 02/16/2017 10:39:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PHAN LOAI PGD](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[MAKHUVUC] [nvarchar](50) NULL,
	[TENKHUVUC] [nvarchar](50) NULL,
	[Ghichu] [nvarchar](50) NULL,
 CONSTRAINT [PK_PHAN LOAI PGD] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
