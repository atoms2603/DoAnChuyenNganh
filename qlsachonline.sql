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
	[quequan] [nvarchar](50)null,
	[nghedanh] [nvarchar](20)null,
	[gioitinh] [bit] null,
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
	[manhaxuatban] [varchar](10) NOT NULL,
	FOREIGN KEY (manhaxuatban) REFERENCES nhaxuatban(manhaxuatban),
	[tensach] [nvarchar](50) null,
	[namxuatban] [int] null,
	[sochuong] [int] null,
	[hinhanh] [image] null,
	[tomtat] [nvarchar] null,
	[phi] [money] null,


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
	[ngaygiaodich] [datetime] null,
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
	[id] int not null IDENTITY(1,1),
	[masach] [varchar](10) NOT NULL ,
	[matg] [varchar](20) NOT NULL ,
	FOREIGN KEY (masach) REFERENCES sach(masach),
	FOREIGN KEY (matg) REFERENCES tacgia(matg),
CONSTRAINT [PK_sach_tacgia] PRIMARY KEY CLUSTERED 
(
	[id] asc
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tacgia]    Script Date: 18/10/2021 2:00:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE sach_theloai(
	[id] int not null IDENTITY(1,1),
	[masach] [varchar](10) NOT NULL,
	[maloai] [varchar](10) NOT NULL,
	FOREIGN KEY (masach) REFERENCES sach(masach),
	FOREIGN KEY (maloai) REFERENCES theloai(maloai),
CONSTRAINT [PK_sach_theloai] PRIMARY KEY CLUSTERED 
(
	[id] asc
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

CREATE TABLE luusach(
	[id] int not null IDENTITY(1,1),
	[masach] [varchar](10) NOT NULL,
	[taikhoan] [varchar](50) NOT NULL,
	[ngayluu] [datetime] null,
	FOREIGN KEY (masach) REFERENCES sach(masach),
	FOREIGN KEY (taikhoan) REFERENCES user_login(taikhoan),
CONSTRAINT [PK_luusach] PRIMARY KEY CLUSTERED 
(
	[id] asc
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

insert into nhaxuatban values ('NXB001',N'Kim Đồng',null)
insert into nhaxuatban values ('NXB002',N'Nhà xuất bản trẻ',null)
insert into nhaxuatban values ('NXB003',N'Nhà xuất bản Dân trí',null)
insert into nhaxuatban values ('NXB004',N'Nhà Xuất Bản Tổng hợp TP.HCM',null)
insert into nhaxuatban values ('NXB005',N'Nhà Xuất Bản Phụ Nữ',null)
insert into nhaxuatban values ('NXB006',N'Nhà Xuất Bản Thanh Niên',null)

insert into tacgia values ('TG001',N'Khải Đơn',16/02/1975,N'Việt Nam',null,1)
insert into tacgia values ('TG002',N'Phạm Lữ Ân',15/7/1988,N'Việt Nam',null,0)
insert into tacgia values ('TG003',N'Nguyễn Ngọc Thạch',12/8/1990,N'Việt Nam',null,1)
insert into tacgia values ('TG004',N'Nguyễn Cảnh Hà',16/02/1980,N'Việt Nam',null,0)
insert into tacgia values ('TG005',N'Trần Đăng Khoa',15/7/1990,N'Việt Nam',null,1)
insert into tacgia values ('TG006',N'Linh Anh',12/8/1995,N'Việt Nam',null,0)

insert into theloai values ('TL001',N'Hành động',null)
insert into theloai values ('TL002',N'Phiêu lưu',null)
insert into theloai values ('TL003',N'Văn học',null)
insert into theloai values ('TL004',N'Vũ trụ',null)
insert into theloai values ('TL005',N'Viễn tưởng',null)
insert into theloai values ('TL006',N'Siêu nhiên',null)
insert into theloai values ('TL007',N'Dân gian',null)
insert into theloai values ('TL008',N'Chính trị',null)
insert into theloai values ('TL009',N'Xã hội',null)
insert into theloai values ('TL010',N'Lịch sử',null)
insert into theloai values ('TL011',N'Công nghệ',null)
insert into theloai values ('TL012',N'Tôn giáo',null)

insert into sach values('S001','NXB001',N'Hoa rơi cửa phật',2015,10,null,null,0)
insert into sach values('S002','NXB001',N'Cây cam ngọt của tôi',2018,20,null,null,0) 
insert into sach values('S003','NXB002',N'Con đường tu tiên của tôi',2019,50,null,null,100000) 
insert into sach values('S004','NXB002',N'Hoa vẫn nở mỗi ngày',2020,100,null,null,50000)
insert into sach values('S005','NXB001',N'Vạn sự tùy duyên',2017,30,null,null,0)
insert into sach values('S006','NXB004',N'Đắc nhân tâm',2021,65,null,null,150000)
insert into sach values('S007','NXB003',N'Muôn kiếp nhân sinh',2015,10,null,null,0)
insert into sach values('S008','NXB005',N'Nóng giận là bản năng',2021,20,null,null,0) 
insert into sach values('S009','NXB006',N'Nhà đầu tư thông minh',2019,50,null,null,100000) 
insert into sach values('S010','NXB005',N'Hai số phận',2020,100,null,null,50000)
insert into sach values('S011','NXB004',N'Hoàng tử bé',2019,30,null,null,0)
insert into sach values('S012','NXB003',N'Tâm lý học',2021,10,null,null,150000)

insert into sach_tacgia values('S001','TG001')
insert into sach_tacgia values('S001','TG003')
insert into sach_tacgia values('S002','TG001')
insert into sach_tacgia values('S003','TG002')
insert into sach_tacgia values('S004','TG002')
insert into sach_tacgia values('S004','TG003')
insert into sach_tacgia values('S005','TG001')
insert into sach_tacgia values('S006','TG002')
insert into sach_tacgia values('S007','TG005')
insert into sach_tacgia values('S008','TG006')
insert into sach_tacgia values('S008','TG005')
insert into sach_tacgia values('S009','TG003')
insert into sach_tacgia values('S010','TG004')
insert into sach_tacgia values('S011','TG002')
insert into sach_tacgia values('S012','TG005')
insert into sach_tacgia values('S012','TG001')


insert into sach_theloai values('S001','TL001')
insert into sach_theloai values('S001','TL002')
insert into sach_theloai values('S002','TL002')
insert into sach_theloai values('S003','TL003')
insert into sach_theloai values('S004','TL003')
insert into sach_theloai values('S004','TL004')
insert into sach_theloai values('S005','TL001')
insert into sach_theloai values('S006','TL005')
insert into sach_theloai values('S006','TL006')
insert into sach_theloai values('S007','TL004')
insert into sach_theloai values('S008','TL008')
insert into sach_theloai values('S008','TL010')
insert into sach_theloai values('S009','TL011')
insert into sach_theloai values('S010','TL007')
insert into sach_theloai values('S011','TL012')
insert into sach_theloai values('S012','TL009')
insert into sach_theloai values('S012','TL009')


drop database QLSACHONLINE


