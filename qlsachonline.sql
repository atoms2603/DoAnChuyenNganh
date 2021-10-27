create database QLSACHONLINE

USE [QLSACHONLINE]
GO
/****** Object:  Table [dbo].[tacgia]    Script Date: 18/10/2021 2:00:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE tacgia(
	[matg] [varchar](20) NOT NULL,
	[tentg] [nvarchar](50) NULL,
	[ngaysinh] [datetime]null,
 CONSTRAINT [PK_tacgia] PRIMARY KEY CLUSTERED 
(
	[matg] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[theloai]    Script Date: 18/10/2021 2:00:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE theloai(
	[maloai] [varchar](10) NOT NULL,
	[tentl] [nvarchar](50) NULL,
	[ghichu] [nvarchar](200)null,
 CONSTRAINT [PK_theloai] PRIMARY KEY CLUSTERED 
(
	[maloai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[nhasanxuat]    Script Date: 18/10/2021 2:00:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE nhaxuatban(
	[manhaxuatban] [varchar](10) NOT NULL,
	[tennhaxuatban] [nvarchar](50) NULL,
	[diachi] [nvarchar](50) null,
 CONSTRAINT [PK_nhaxuatban] PRIMARY KEY CLUSTERED 
(
	[manhaxuatban] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tacgia]    Script Date: 18/10/2021 2:00:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE user_login(
	[taikhoan] [varchar](50) NOT NULL,
	[matkhau] [varchar](50)not NULL,
	[sdt] [varchar](10) NULL,
	[email] [nvarchar](50)not NULL,
	[status] [bit] null,
 CONSTRAINT [PK_user_login] PRIMARY KEY CLUSTERED 
(
	[taikhoan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]


GO
/****** Object:  Table [dbo].[sach]    Script Date: 18/10/2021 2:00:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE sach(
	[masach] [varchar](10) NOT NULL,
	[maloai] [varchar](10) NOT NULL,
	[matg] [varchar](20) NOT NULL,
	[manhaxuatban] [varchar](10) NOT NULL,
	FOREIGN KEY (maloai) REFERENCES theloai(maloai),
	FOREIGN KEY (matg) REFERENCES tacgia(matg),
	FOREIGN KEY (manhaxuatban) REFERENCES nhaxuatban(manhaxuatban),
	[tensach] [nvarchar](50) null,
	[namxuatban] [int] null,
	[sochuong] [int] null,
	[phi] [money] null

 CONSTRAINT [PK_sach] PRIMARY KEY CLUSTERED 
(
	[masach] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
ALTER TABLE sach
ALTER COLUMN tensach nvarchar(50)

GO
/****** Object:  Table [dbo].[tacgia]    Script Date: 18/10/2021 2:00:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE giaodich(
	[magd] [varchar] (10)not null,
	[taikhoan] [varchar](50) NOT NULL,
	[masach] [varchar](10) NOT NULL,
	FOREIGN KEY (taikhoan) REFERENCES user_login(taikhoan),
	FOREIGN KEY (masach) REFERENCES sach(masach),
 CONSTRAINT [PK_giaodich] PRIMARY KEY CLUSTERED 
(
	[magd] asc
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tacgia]    Script Date: 18/10/2021 2:00:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE sach_tacgia(
	[masach] [varchar](10) NOT NULL,
	[matg] [varchar](20) NOT NULL,
	FOREIGN KEY (masach) REFERENCES sach(masach),
	FOREIGN KEY (matg) REFERENCES tacgia(matg),
 CONSTRAINT [PK_sach_tacgia] PRIMARY KEY CLUSTERED 
(
	[masach] asc,
	[matg] asc
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tacgia]    Script Date: 18/10/2021 2:00:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE sach_theloai(
	[masach] [varchar](10) NOT NULL,
	[maloai] [varchar](10) NOT NULL,
	FOREIGN KEY (masach) REFERENCES sach(masach),
	FOREIGN KEY (maloai) REFERENCES theloai(maloai),
 CONSTRAINT [PK_sach_theloai] PRIMARY KEY CLUSTERED 
(
	[masach] asc,
	[maloai] asc
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

insert into nhaxuatban values ('NXB001','Kim Dong')
insert into nhaxuatban values ('NXB002','Nha xuat ban tre')

insert into tacgia values ('TG001',N'Khải Đơn')
insert into tacgia values ('TG002',N'Phạm Lữ Ân')
insert into tacgia values ('TG003',N'Nguyễn Ngọc Thạch')

insert into theloai values ('TL001',N'Hành động')
insert into theloai values ('TL002',N'Phiêu lưu')
insert into theloai values ('TL003',N'Văn học')
insert into theloai values ('TL004',N'Vũ trụ')

insert into sach values('S001','TL001','TG001','NXB001',N'Hoa rơi cửa phật',2015,10,0)
insert into sach values('S002','TL001','TG002','NXB001',N'Cây cam ngọt của tôi',2018,20,0) 
insert into sach values('S003','TL002','TG001','NXB002',N'Con đường tu tiên của tôi',2019,50,100000) 
insert into sach values('S004','TL003','TG003','NXB002',N'Hoa vẫn nở mỗi ngày',2020,100,50000)
insert into sach values('S005','TL002','TG003','NXB001',N'Vạn sự tùy duyên',2017,30,0)
insert into sach values('S006','TL004','TG002','NXB001',N'Đắc nhân tâm',2021,65,150000)

drop database QLSACHONLINE


