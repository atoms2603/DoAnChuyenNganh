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

insert into userlogin values('abc','abc','0123','ridofugaming@gmail.com',1)
insert into userlogin values('abc2','abc2','0123','abc2@gmail.com',0)
insert into userlogin values('abc3','abc3','0123','abc3@gmail.com',1)

insert into nhaxuatban values ('NXB001',N'Kim Đồng',null)
insert into nhaxuatban values ('NXB002',N'Nhà xuất bản trẻ',null)
insert into nhaxuatban values ('NXB003',N'Nhà xuất bản Dân trí',null)
insert into nhaxuatban values ('NXB004',N'Nhà Xuất Bản Tổng hợp TP.HCM',null)
insert into nhaxuatban values ('NXB005',N'Nhà Xuất Bản Phụ Nữ',null)
insert into nhaxuatban values ('NXB006',N'Nhà Xuất Bản Thanh Niên',null)

insert into tacgia values ('TG001',N'Khải Đơn','2/16/1975',N'Việt Nam',null,1)
insert into tacgia values ('TG002',N'Phạm Lữ Ân','7/15/1988',N'Việt Nam',null,0)
insert into tacgia values ('TG003',N'Nguyễn Ngọc Thạch','2/27/1990',N'Việt Nam',null,1)
insert into tacgia values ('TG004',N'Nguyễn Cảnh Hà','1/30/1980',N'Việt Nam',null,0)
insert into tacgia values ('TG005',N'Trần Đăng Khoa','5/7/1990',N'Việt Nam',null,1)
insert into tacgia values ('TG006',N'Linh Anh','12/8/1995',N'Việt Nam',null,0)
insert into tacgia values ('TG007',N'Khang Tĩnh Văn','12/8/1995',N'Việt Nam',null,1)
insert into tacgia values ('TG008',N'Tân Di Ổ','11/5/1986',N'Việt Nam',null,1)
insert into tacgia values ('TG009',N'Bao Nhung','3/4/1992',N'Việt Nam',null,0)
insert into tacgia values ('TG010',N'Guillaume Musso','3/17/1982',N'Việt Nam',null,0)
insert into tacgia values ('TG011',N'Richelle Mead','3/1/1990',N'Việt Nam',null,0)

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
insert into theloai values ('TL013',N'Tình yêu',null)

insert into sach values('S001','NXB006',N'Ai gõ cửa lúc nữa đêm',2016,'aigocualucnuadem.png',N'Một ngày cuối tháng Tư, cô nữ sinh Lương Tiểu Như bị sát hại trong căn phòng trọ gần trường Đại học Y, 
tư thế chết vô cùng kỳ quái khiến người ta cảm thấy hết sức khó hiểu. 
Khám nghiệm bên ngoài cho thấy nạn nhân bị bóp cổ dẫn đến tử vong, 
nhưng sau khi giải phẫu tử thi, cảnh sát phát hiện quả tim của cô đã bị đánh cắp. 
Việc điều tra rơi vào bế tắc khi hung thủ không để lại chút dấu vết nào. 
Không cam tâm để em gái phải chết oan uổng, chị gái của Lương Tiểu Như là Lương Mộc Tử đã nhờ người bạn thám tử tư của mình là Na Phàm giúp điều tra vụ án. 
Từ đây, hàng loạt những bí mật được mở ra, hé lộ một tội ác khủng khiếp.',0)

insert into sach values('S002','NXB001',N'Trái tim sắt đá',2018,'traitimda.png',N'Buổi sáng, không khí ồn ào và bụi bặm.
Thành phố Hải Dương tuy còn nghèo những vẫn là một thành phố đông đúc. Mà trơi vào thu cũng không thể trong xanh như cái thời xưa được nữa
. Đôi khi sự phát triển của con người cũng làm hại con người không ngờ.',0)

insert into sach values('S003','NXB002',N'Tháng ngày ước hẹn',0000,'thangngayuochen.png',N'Hôn nhân đối với Phong Lan quả thật như một cánh cửa, 
cô vô cùng khát khao được đi vào bên trong, nhưng cô phải tìm được chìa khóa mở cánh cửa này, 
mà chìa khóa đó lại chính là cảm giác yêu một người. ',0)

insert into sach values('S004','NXB003',N'Hẹn em ngày đó',0000,'HenEmNgayDo.png',N'..Thảm thực vật um tùm và rực rỡ sắc màu, làm thành một chiếc tổ lớn cho mọi loại chim: vẹt, sáo, chim hét... Elliot men theo cầu thang gỗ chạy uốn
khúc giữa những bụi đỗ quyền, hoa chuông, hoa giấy dẫn tới những căn nhà gỗ bài trí theo kiểu nghệ thuật nằm vắt vẻo trên sườn đồi. Đi được nửa
đường, anh dừng lại trước cánh cổng của một khu vườn ngồn ngang. Như mỗi lần tới đây, anh trèo qua hàng rào và đứng ngay trên bậc thềm của một
ngôi nhà bằng gỗ sơn nơi uể oải phát ra một đoạn điệp khúc của Marvin Gaye. Anh định gõ cửa, nhưng thấy cửa mở, anh vào luôn không gọi trước, rất
nóng ruột muốn thổ lộ những mối bận tâm của mình với người bạn...',0)

insert into sach values('S005','NXB004',N'Hóa ra anh vẫn ở đây',0000,'HoaRaAnhVanODay.png',N'Khi nếm trải cảnh phúc bất hạnh mới biết được hạnh phúc quý giá thế nào...
Ông trời cho họ gần nhau nơi chân trời góc bể, tưởng như không thể tìm thấy nhau, rồi lại bắt họ xa nhau đằng đẳng 4 năm trời, có lẽ, tình của họ còn
chưa đủ nặng...
Khi nếm trải cảnh phúc bất hạnh mới biết được hạnh phúc quý giá thế nào...
Ông trời cho họ gần nhau nơi chân trời góc bể, tưởng như không thể tìm thấy nhau, rồi lại bắt họ xa nhau đẳng đẫng 4 năm trời, có lẽ, tình của họ còn
chưa đủ nặng...',1)

insert into sach values('S006','NXB005',N'Sương giá',0000,'SuongGia.png',N'Lâu lắm rồi không có câu chuyện nào như thế này về ma cà rồng, khi dân gian Bancăng, thần thoại Rumani và nhịp sống Hoa Kỳ đánh nhuyễn làm một
để phá bỏ mọi ước lệ xưa nay về các nhân vật hút máu. Từ đó tạo ra một khung cảnh hoàn toàn mới, vừa hiện thực, vừa phi thực, vừa tàn bạo vừa lãng
mạn tới mức bóng bẩy mơ hồ.
Lấy Rose - một ma cà rồng lai xinh đẹp làm trung tâm, câu chuyện xoay quanh những tháng cuối cùng của cô ở Học viện Thánh Vladimir trước khi vào
nghề bảo vệ các ma cà rồng sống (Moroi) chống lại các ma cà rồng chết(Strigoi). Là một cô gái nóng bỏng, Rose được các chàng trai săn đón nồng nhiệt,
nhưng người duy nhất cô say mê thì cứ tránh né thờ ơ. Cuộc sống học đường tưởng sẽ mãi trôi đi trong ẩm ương vùng vằng như thế, bỗng đâu rung
động vì những trận tàn sát nhằm vào các Moroi hoàng gia ở thế giới bên ngoài. Dư chấn của nó thấm qua vòng pháp thuật, lan vào trường và thức tỉnh
cả những học sinh vốn dĩ vô tâm nhất. Cùng bạn bè, Rose dấn thân vào cuộc săn đuổi Strigoi đầu tiên của đời giám hộ, đềể rồi giữa vòng sinh từ mới hiểu
ra, thu hoạch lớn nhất của con người không phải là kỹ năng giành giật trong sống chết, mà là sức mạnh cao cả của tình bạn, trí tuệ và sự hi sinh.',1)


insert into tacgiasach values('S001','TG007')
insert into tacgiasach values('S002','TG009')
insert into tacgiasach values('S003','TG008')
insert into tacgiasach values('S004','TG010')
insert into tacgiasach values('S005','TG008')
insert into tacgiasach values('S006','TG011')

insert into theloaisach values('S001','TL005')
insert into theloaisach values('S002','TL009')
insert into theloaisach values('S002','TL007')
insert into theloaisach values('S003','TL009')
insert into theloaisach values('S004','TL003')
insert into theloaisach values('S005','TL013')
insert into theloaisach values('S006','TL005')


insert into chuong values('C001','S001',N'Chương 1: Lương Tiểu Như bị bóp cổ dến chết','S001_CHUONG1.pdf')
insert into chuong values('C002','S001',N'Chương 2: Thân thế nạn nhân','S001_CHUONG2.pdf')
insert into chuong values('C003','S001',N'Chương 3: Lương Tiêu Như bị gièm pha','S001_CHUONG3.pdf')
insert into chuong values('C004','S001',N'Chương 4: Quay lại nơi xảy ra án mạng','S001_CHUONG4.pdf')
insert into chuong values('C005','S001',N'Chương 5: Nghi phạm vô hinh','S001_CHUONG5.pdf')
insert into chuong values('C006','S001',N'Chương 6: Số điện thoại kỳ lạ','S001_CHUONG6.pdf')

insert into chuong values('C001','S002',N'Chương 1','S002_CHUONG1.pdf')
insert into chuong values('C002','S002',N'Chương 2','S002_CHUONG2.pdf')
insert into chuong values('C003','S002',N'Chương 3','S002_CHUONG3.pdf')
insert into chuong values('C004','S002',N'Chương 4','S002_CHUONG4.pdf')

insert into chuong values('C001','S003',N'Chương 1: Cái tát của tình củ','S003_CHUONG1.pdf')
insert into chuong values('C002','S003',N'Chương 2: Người bên miệng mãng xà','S003_CHUONG2.pdf')
insert into chuong values('C003','S003',N'Chương 3: Màu xanh lam rất hợp với chị','S003_CHUONG3.pdf')
insert into chuong values('C004','S003',N'Chương 4: Thua người, không có nghĩa là thua cả cuộc đời','S003_CHUONG4.pdf')
insert into chuong values('C005','S003',N'Chương 5: Chúng ta hãy tĩnh lặng lại','S003_CHUONG5.pdf')
insert into chuong values('C006','S003',N'Chương 6: Những sắc thái thô thiển của Lang và Sói','S003_CHUONG6.pdf')
insert into chuong values('C007','S003',N'Chương 7: Sai thời điểm cũng là do duyên phận','S003_CHUONG7.pdf')
insert into chuong values('C008','S003',N'Chương 8: Ánh mắt đói khát','S003_CHUONG8.pdf')
insert into chuong values('C009','S003',N'Chương 9: Người con trai luôn nhớ nhung cô','S003_CHUONG9.pdf')

insert into chuong values('C001','S004',N'Chương 1','S004_CHUONG1.pdf')
insert into chuong values('C002','S004',N'Chương 2','S004_CHUONG2.pdf')
insert into chuong values('C003','S004',N'Chương 3','S004_CHUONG3.pdf')
insert into chuong values('C004','S004',N'Chương 4','S004_CHUONG4.pdf')

insert into chuong values('C001','S005',N'Chương 1: Mùa hè đằng đẵng ấy, con người đáng ghét ấy','S005_CHUONG1.pdf')
insert into chuong values('C002','S005',N'Chương 2: Chỉ là tôi muốn em nhìn đến tôi','S005_CHUONG2.pdf')
insert into chuong values('C003','S005',N'Chương 3: Chẳng ai vượt qua nổi những xao động thanh xuân','S005_CHUONG3.pdf')
insert into chuong values('C004','S005',N'Chương 4: Ai muốn trở thành cô bé Lọ Lem','S005_CHUONG4.pdf')
insert into chuong values('C005','S005',N'Chương 5: Loài hạ trùng chẳng thể bàn chuyện băng lạnh','S005_CHUONG5.pdf')
insert into chuong values('C006','S005',N'Chương 6: Đất trời vĩnh cửu và đất trời long lở','S005_CHUONG6.pdf')
insert into chuong values('C007','S005',N'Chương 7: Bồ Tát cũng không biết được tôi buồn đến thế nào','S005_CHUONG7.pdf')
insert into chuong values('C008','S005',N'Chương 8: Nếu tôi đồng ý thay đổi, thì em sẽ bằng lòng chứ?','S005_CHUONG8.pdf')
insert into chuong values('C009','S005',N'Chương 9: Hãy thứ lỗi vì em ích kỷ','S005_CHUONG9.pdf')

insert into chuong values('C001','S006',N'Chương 1','S006_CHUONG1.pdf')
insert into chuong values('C002','S006',N'Chương 2','S006_CHUONG2.pdf')
insert into chuong values('C003','S006',N'Chương 3','S006_CHUONG3.pdf')
insert into chuong values('C004','S006',N'Chương 4','S006_CHUONG4.pdf')
insert into chuong values('C005','S006',N'Chương 5','S006_CHUONG5.pdf')
insert into chuong values('C006','S006',N'Chương 6','S006_CHUONG6.pdf')
insert into chuong values('C007','S006',N'Chương 7','S006_CHUONG7.pdf')
insert into chuong values('C008','S006',N'Chương 8','S006_CHUONG8.pdf')
insert into chuong values('C009','S006',N'Chương 9','S006_CHUONG9.pdf')
insert into chuong values('C010','S006',N'Chương 10','S006_CHUONG10.pdf')
insert into chuong values('C011','S006',N'Chương 11','S006_CHUONG11.pdf')
insert into chuong values('C012','S006',N'Chương 12','S006_CHUONG12.pdf')