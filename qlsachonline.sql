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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tacgia]    Script Date: 18/10/2021 2:00:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE userlogin(
	[taikhoan] [varchar](50) NOT NULL,
	[matkhau] [varchar](50)not NULL,
	[sdt] [varchar](10) NULL,
	[email] [nvarchar](50)not NULL,
	[status] [bit] null,
 CONSTRAINT [PK_userlogin] PRIMARY KEY CLUSTERED 
(
	[taikhoan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
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
	[tensach] [nvarchar](50) null,
	[namxuatban] [int] null,
	[hinhanh] [nvarchar](200) null,
	[tomtat] [nvarchar](max) null,
	[premium] [bit] not null,

 CONSTRAINT [PK_sach] PRIMARY KEY CLUSTERED 
(
	[masach] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[sach]    Script Date: 18/10/2021 2:00:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE chuong(
	[machuong] [varchar](10) NOT NULL,
	[masach] [varchar](10) NOT NULL,
	[tenchuong] [nvarchar](100) null,
	[noidung][nvarchar](100) null,
 CONSTRAINT [PK_chuong] PRIMARY KEY CLUSTERED 
(
	[machuong] ASC,
	[masach]asc
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


GO
/****** Object:  Table [dbo].[sach]    Script Date: 18/10/2021 2:00:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE goi(
	[magoi] [varchar](10) NOT NULL,
	[tengoi] [varchar](100) NOT NULL,
	[motagoi] [nvarchar](max) null,
	[thoihan] int not null,
	[gia] money null,
 CONSTRAINT [PK_goi] PRIMARY KEY CLUSTERED 
(
	[magoi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[sach]    Script Date: 18/10/2021 2:00:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE usergoi(
	[id] int identity,
	[magoi] [varchar](10) NOT NULL,
	[taikhoan] [varchar](50) NOT NULL,
	[ngaymua] datetime not null,
	[ngayhethan] datetime not null,
 CONSTRAINT [PK_usergoi] PRIMARY KEY CLUSTERED 
(
	[id] ASC,
	[magoi] ASC,
	[taikhoan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tacgia]    Script Date: 18/10/2021 2:00:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE tacgiasach(
	[masach] [varchar](10) NOT NULL ,
	[matg] [varchar](20) NOT NULL ,
CONSTRAINT [PK_tacgiasach] PRIMARY KEY CLUSTERED 
(
	[masach] asc,
	[matg] asc
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tacgia]    Script Date: 18/10/2021 2:00:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE theloaisach(
	[masach] [varchar](10) NOT NULL,
	[maloai] [varchar](10) NOT NULL,
CONSTRAINT [PK_theloaisach] PRIMARY KEY CLUSTERED 
(
	[masach] asc,
	[maloai] asc
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

CREATE TABLE luusach(
	[masach] [varchar](10) NOT NULL,
	[taikhoan] [varchar](50) NOT NULL,
	[ngayluu] [datetime] null,
CONSTRAINT [PK_luusach] PRIMARY KEY CLUSTERED 
(
	[masach] asc,
	[taikhoan] asc
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


GO
/****** Object:  Table [dbo].[tacgia]    Script Date: 18/10/2021 2:00:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE adminlogin(
	[taikhoan] [varchar](50) NOT NULL,
	[matkhau] [varchar](50)not NULL,
 CONSTRAINT [PK_adminlogin] PRIMARY KEY CLUSTERED 
(
	[taikhoan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[sach]  WITH CHECK ADD  CONSTRAINT [FK_sach_nhaxuatban] FOREIGN KEY([manhaxuatban])
REFERENCES [dbo].[nhaxuatban] ([manhaxuatban])
GO
ALTER TABLE [dbo].[sach] CHECK CONSTRAINT [FK_sach_nhaxuatban]

GO
ALTER TABLE [dbo].[chuong]  WITH CHECK ADD  CONSTRAINT [FK_chuong_sach] FOREIGN KEY([masach])
REFERENCES [dbo].[sach] ([masach])
GO
ALTER TABLE [dbo].[chuong] CHECK CONSTRAINT [FK_chuong_sach]

GO
ALTER TABLE [dbo].[tacgiasach]  WITH CHECK ADD  CONSTRAINT [FK_tacgiasach_sach] FOREIGN KEY([masach])
REFERENCES [dbo].[sach] ([masach])
GO
ALTER TABLE [dbo].[tacgiasach] CHECK CONSTRAINT [FK_tacgiasach_sach]

GO
ALTER TABLE [dbo].[tacgiasach]  WITH CHECK ADD  CONSTRAINT [FK_tacgiasach_tacgia] FOREIGN KEY([matg])
REFERENCES [dbo].[tacgia] ([matg])
GO
ALTER TABLE [dbo].[tacgiasach] CHECK CONSTRAINT [FK_tacgiasach_tacgia]

GO
ALTER TABLE [dbo].[theloaisach]  WITH CHECK ADD  CONSTRAINT [FK_theloaisach_sach] FOREIGN KEY([masach])
REFERENCES [dbo].[sach] ([masach])
GO
ALTER TABLE [dbo].[theloaisach] CHECK CONSTRAINT [FK_theloaisach_sach]


GO
ALTER TABLE [dbo].[theloaisach]  WITH CHECK ADD  CONSTRAINT [FK_theloaisach_theloai] FOREIGN KEY([maloai])
REFERENCES [dbo].[theloai] ([maloai])
GO
ALTER TABLE [dbo].[theloaisach] CHECK CONSTRAINT [FK_theloaisach_theloai]


GO
ALTER TABLE [dbo].[usergoi]  WITH CHECK ADD  CONSTRAINT [FK_usergoi_userlogin] FOREIGN KEY([taikhoan])
REFERENCES [dbo].[userlogin] ([taikhoan])
GO
ALTER TABLE [dbo].[usergoi] CHECK CONSTRAINT [FK_usergoi_userlogin]

GO
ALTER TABLE [dbo].[usergoi]  WITH CHECK ADD  CONSTRAINT [FK_usergoi_goi] FOREIGN KEY([magoi])
REFERENCES [dbo].[goi] ([magoi])
GO
ALTER TABLE [dbo].[usergoi] CHECK CONSTRAINT [FK_usergoi_goi]




GO
ALTER TABLE [dbo].[luusach]  WITH CHECK ADD  CONSTRAINT [FK_luusach_userlogin] FOREIGN KEY([taikhoan])
REFERENCES [dbo].[userlogin] ([taikhoan])
GO
ALTER TABLE [dbo].[luusach] CHECK CONSTRAINT [FK_luusach_userlogin]

GO
ALTER TABLE [dbo].[luusach]  WITH CHECK ADD  CONSTRAINT [FK_luusach_sach] FOREIGN KEY([masach])
REFERENCES [dbo].[sach] ([masach])
GO
ALTER TABLE [dbo].[luusach] CHECK CONSTRAINT [FK_luusach_sach]

insert into adminlogin values('admin','admin')

insert into goi values('G001',N'Gói 1 ngày',N'Mua gói đọc sách premium với thời hạn 1 ngày',1,10000)
insert into goi values('G002',N'Gói 7 ngày',N'Mua gói đọc sách premium với thời hạn 7 ngày',7,70000)
insert into goi values('G003',N'Gói 30 ngày',N'Mua gói đọc sách premium với thời hạn 30 ngày',30,300000)
insert into goi values('G004',N'Gói 90 ngày',N'Mua gói đọc sách premium với thời hạn 90 ngày',90,900000)

insert into userlogin values('abc','abc','0123','abc@gmail.com',1)
insert into userlogin values('abc2','abc2','0123','abc2@gmail.com',1)
insert into userlogin values('abc3','abc3','0123','abc3@gmail.com',1)

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

insert into sach values('S001','NXB001',N'Hoa rơi cửa phật',2015,null,null,0)
insert into sach values('S002','NXB001',N'Cây cam ngọt của tôi',2018,null,null,0) 
insert into sach values('S003','NXB002',N'Con đường tu tiên của tôi',2019,null,null,1) 
insert into sach values('S004','NXB002',N'Hoa vẫn nở mỗi ngày',2020,null,null,1)
insert into sach values('S005','NXB001',N'Vạn sự tùy duyên',2017,null,null,0)
insert into sach values('S006','NXB004',N'Đắc nhân tâm',2021,null,null,1)
insert into sach values('S007','NXB003',N'Muôn kiếp nhân sinh',2015,null,null,0)
insert into sach values('S008','NXB005',N'Nóng giận là bản năng',2021,null,null,0) 
insert into sach values('S009','NXB006',N'Nhà đầu tư thông minh',2019,null,null,1) 
insert into sach values('S010','NXB005',N'Hai số phận',2020,null,null,1)
insert into sach values('S011','NXB004',N'Hoàng tử bé',2019,null,null,0)
insert into sach values('S012','NXB003',N'Tâm lý học',2021,null,null,1)

insert into tacgiasach values('S001','TG001')
insert into tacgiasach values('S001','TG003')
insert into tacgiasach values('S002','TG001')
insert into tacgiasach values('S003','TG002')
insert into tacgiasach values('S004','TG002')
insert into tacgiasach values('S004','TG003')
insert into tacgiasach values('S005','TG001')
insert into tacgiasach values('S006','TG002')
insert into tacgiasach values('S007','TG005')
insert into tacgiasach values('S008','TG006')
insert into tacgiasach values('S008','TG005')
insert into tacgiasach values('S009','TG003')
insert into tacgiasach values('S010','TG004')
insert into tacgiasach values('S011','TG002')
insert into tacgiasach values('S012','TG005')
insert into tacgiasach values('S012','TG001')


insert into theloaisach values('S001','TL001')
insert into theloaisach values('S001','TL002')
insert into theloaisach values('S002','TL002')
insert into theloaisach values('S003','TL003')
insert into theloaisach values('S004','TL003')
insert into theloaisach values('S004','TL004')
insert into theloaisach values('S005','TL001')
insert into theloaisach values('S006','TL005')
insert into theloaisach values('S006','TL006')
insert into theloaisach values('S007','TL004')
insert into theloaisach values('S008','TL008')
insert into theloaisach values('S008','TL010')
insert into theloaisach values('S009','TL011')
insert into theloaisach values('S010','TL007')
insert into theloaisach values('S011','TL012')
insert into theloaisach values('S012','TL009')
insert into theloaisach values('S012','TL008')

insert into chuong values('C001','S001',N'Chương 1',null)
insert into chuong values('C002','S001',N'Chương 2',null)
insert into chuong values('C003','S001',N'Chương 3',null)
insert into chuong values('C004','S001',N'Chương 4',null)
insert into chuong values('C005','S001',N'Chương 5',null)
insert into chuong values('C006','S001',N'Chương 6',null)

insert into chuong values('C001','S002',N'Chương 1',null)
insert into chuong values('C002','S002',N'Chương 2',null)
insert into chuong values('C003','S002',N'Chương 3',null)
insert into chuong values('C004','S002',N'Chương 4',null)
insert into chuong values('C005','S002',N'Chương 5',null)
insert into chuong values('C006','S002',N'Chương 6',null)

insert into chuong values('C001','S003',N'Chương 1',null)
insert into chuong values('C002','S003',N'Chương 2',null)
insert into chuong values('C003','S003',N'Chương 3',null)
insert into chuong values('C004','S003',N'Chương 4',null)
insert into chuong values('C005','S003',N'Chương 5',null)
insert into chuong values('C006','S003',N'Chương 6',null)

insert into chuong values('C001','S004',N'Chương 1',null)
insert into chuong values('C002','S004',N'Chương 2',null)
insert into chuong values('C003','S004',N'Chương 3',null)
insert into chuong values('C004','S004',N'Chương 4',null)
insert into chuong values('C005','S004',N'Chương 5',null)
insert into chuong values('C006','S004',N'Chương 6',null)

insert into chuong values('C001','S005',N'Chương 1',null)
insert into chuong values('C002','S005',N'Chương 2',null)
insert into chuong values('C003','S005',N'Chương 3',null)
insert into chuong values('C004','S005',N'Chương 4',null)
insert into chuong values('C005','S005',N'Chương 5',null)
insert into chuong values('C006','S005',N'Chương 6',null)

insert into chuong values('C001','S006',N'Chương 1',null)
insert into chuong values('C002','S006',N'Chương 2',null)
insert into chuong values('C003','S006',N'Chương 3',null)
insert into chuong values('C004','S006',N'Chương 4',null)
insert into chuong values('C005','S006',N'Chương 5',null)
insert into chuong values('C006','S006',N'Chương 6',null)

insert into chuong values('C001','S007',N'Chương 1',null)
insert into chuong values('C002','S007',N'Chương 2',null)
insert into chuong values('C003','S007',N'Chương 3',null)
insert into chuong values('C004','S007',N'Chương 4',null)
insert into chuong values('C005','S007',N'Chương 5',null)
insert into chuong values('C006','S007',N'Chương 6',null)

insert into chuong values('C001','S008',N'Chương 1',null)
insert into chuong values('C002','S008',N'Chương 2',null)
insert into chuong values('C003','S008',N'Chương 3',null)
insert into chuong values('C004','S008',N'Chương 4',null)
insert into chuong values('C005','S008',N'Chương 5',null)
insert into chuong values('C006','S008',N'Chương 6',null)

insert into chuong values('C001','S009',N'Chương 1',null)
insert into chuong values('C002','S009',N'Chương 2',null)
insert into chuong values('C003','S009',N'Chương 3',null)
insert into chuong values('C004','S009',N'Chương 4',null)
insert into chuong values('C005','S009',N'Chương 5',null)
insert into chuong values('C006','S009',N'Chương 6',null)


insert into chuong values('C001','S010',N'Chương 1',null)
insert into chuong values('C002','S010',N'Chương 2',null)
insert into chuong values('C003','S010',N'Chương 3',null)
insert into chuong values('C004','S010',N'Chương 4',null)
insert into chuong values('C005','S010',N'Chương 5',null)
insert into chuong values('C006','S010',N'Chương 6',null)

insert into chuong values('C001','S011',N'Chương 1',null)
insert into chuong values('C002','S011',N'Chương 2',null)
insert into chuong values('C003','S011',N'Chương 3',null)
insert into chuong values('C004','S011',N'Chương 4',null)
insert into chuong values('C005','S011',N'Chương 5',null)
insert into chuong values('C006','S011',N'Chương 6',null)

insert into chuong values('C001','S012',N'Chương 1',null)
insert into chuong values('C002','S012',N'Chương 2',null)
insert into chuong values('C003','S012',N'Chương 3',null)
insert into chuong values('C004','S012',N'Chương 4',null)
insert into chuong values('C005','S012',N'Chương 5',null)
insert into chuong values('C006','S012',N'Chương 6',null)
