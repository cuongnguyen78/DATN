/*
Created		11/04/2022
Modified		11/04/2022
Project		
Model			
Company		
Author		
Version		
Database		MS SQL 2005 
*/

Create database SachOnline
go
use SachOnline
go

Create table [SanPham]
(
	[MaSP] Nvarchar(50) NOT NULL,
	[TenSP] Nvarchar(50) NULL,
	[Gia] Integer NULL,
	[MoTa] Nvarchar(50) NULL,
	[HinhAnh] Nvarchar(50) NULL,
	[MaDanhMuc] Nvarchar(50) NOT NULL,
	[MaNXB] Nvarchar(50) NOT NULL,
Constraint [pk_SanPham] Primary Key ([MaSP])
) 
go

Create table [DanhMucSanPham]
(
	[MaDanhMuc] Nvarchar(50) NOT NULL,
	[TenDanhMuc] Nvarchar(50) NULL,
Constraint [pk_DanhMucSanPham] Primary Key ([MaDanhMuc])
) 
go

Create table [NhaXuatBan]
(
	[MaNXB] Nvarchar(50) NOT NULL,
	[TenNhaXuatBan] Nvarchar(50) NULL,
Constraint [pk_NhaXuatBan] Primary Key ([MaNXB])
) 
go

Create table [KhachHang]
(
	[SDT] Nvarchar(10) NOT NULL,
	[TenKH] Nvarchar(50) NULL,
	[Email] Nvarchar(50) NULL,
	[MatKhau] Nvarchar(50) NULL,
	[DiaChi] Nvarchar(50) NULL,
Constraint [pk_KhachHang] Primary Key ([SDT])
) 
go

Create table [AccountAdmin]
(
	[MaTK] Nvarchar(50) NOT NULL,
	[MatKhau] Nvarchar(50) NULL,
	[Ten] Nvarchar(50) NULL,
	[SDT] Nvarchar(10) NULL,
	[Quyen] Nvarchar(50) NULL,
Constraint [pk_AccountAdmin] Primary Key ([MaTK])
) 
go

Create table [GioHang]
(
	[SDT] Nvarchar(10) NOT NULL,
	[MaSP] Nvarchar(50) NOT NULL,
	[SoLuong] Integer NULL,
Constraint [pk_GioHang] Primary Key ([SDT],[MaSP])
) 
go

Create table [BLOG]
(
	[MaBlog] Nvarchar(50) NOT NULL,
	[TenBlog] Ntext NULL,
	[NoiDungBlog] Ntext NULL,
Constraint [pk_BLOG] Primary Key ([MaBlog])
) 
go

Create table [HoaDon]
(
	[MAHD] Integer identity(1,1) NOT NULL,
	[NgayTao] Datetime NULL,
	[TinhTrang] Nvarchar(50) NULL,
	[SDT] Nvarchar(10) NOT NULL,
Constraint [pk_HoaDon] Primary Key ([MAHD])
) 
go

Create table [ChiTietHoaDon]
(
	[MAHD] Integer NOT NULL,
	[MaSP] Nvarchar(50) NOT NULL,
	[SoLuong] Integer NOT NULL,
Constraint [pk_ChiTietHoaDon] Primary Key ([MAHD],[MaSP])
) 
go


Alter table [GioHang] add  foreign key([MaSP]) references [SanPham] ([MaSP])  on update no action on delete no action 
go
Alter table [ChiTietHoaDon] add  foreign key([MaSP]) references [SanPham] ([MaSP])  on update no action on delete no action 
go
Alter table [SanPham] add  foreign key([MaDanhMuc]) references [DanhMucSanPham] ([MaDanhMuc])  on update no action on delete no action 
go
Alter table [SanPham] add  foreign key([MaNXB]) references [NhaXuatBan] ([MaNXB])  on update no action on delete no action 
go
Alter table [GioHang] add  foreign key([SDT]) references [KhachHang] ([SDT])  on update no action on delete no action 
go
Alter table [HoaDon] add  foreign key([SDT]) references [KhachHang] ([SDT])  on update no action on delete no action 
go
Alter table [ChiTietHoaDon] add  foreign key([MAHD]) references [HoaDon] ([MAHD])  on update no action on delete no action 
go


Set quoted_identifier on
go


Set quoted_identifier off
go


/* Roles permissions */


/* Users permissions */

insert into DanhMucSanPham values('DM01',N'Sách Thiếu Nhi')
insert into DanhMucSanPham values('DM02',N'Sách Giáo Khoa')
insert into DanhMucSanPham values('DM03',N'Sách Kinh Tế')
insert into DanhMucSanPham values('DM04',N'Sách Văn Học')
insert into DanhMucSanPham values('DM05',N'Sách Kỹ Năng Sống')
insert into DanhMucSanPham values('DM06',N'Sách Chuyên Ngành')

go 
insert into NhaXuatBan values('NXB01',N'NXB Giáo dục VIỆT NAM')
insert into NhaXuatBan values('NXB02',N'NXB TRẺ')
insert into NhaXuatBan values('NXB03',N'KINH TẾ')
insert into NhaXuatBan values('NXB04',N'NXB MỸ THUẬT')
insert into NhaXuatBan values('NXB05',N'NXB VĂN HỌC')
insert into NhaXuatBan values('NXB06',N'KHOA HỌC VÀ KỸ THUẬT')

go

insert into SanPham values('SP001',N'Đại Số và Giải tích 11',10000,N'Kích thước 17x24 trọng lượng 350g',N'daisovagiaitich11.jpg',N'DM02',N'NXB01')
insert into SanPham values('SP002',N'Hình Học 12',12000,N'Kích thước 17x24 trọng lượng 150g',N'hinhhoc12.jpg',N'DM02',N'NXB01')
insert into SanPham values('SP003',N'Hóa Học 12',14000,N'Kích thước 17x24 trọng lượng 250g',N'hoahoc12.jpg',N'DM02',N'NXB01')
insert into SanPham values('SP004',N'Lịch Sử 12',8000,N'Kích thước 17x24 trọng lượng 300g',N'lichsu12.jpg',N'DM02',N'NXB01')
insert into SanPham values('SP005',N'Ngữ Văn 12 Tập 2',15000,N'Kích thước 17x24 trọng lượng 350g',N'nguvan12tap2.jpg',N'DM02',N'NXB01')

insert into SanPham values('SP006',N'Hệ Mờ và Ứng Dụng',25000,N'Kích thước 17x24 trọng lượng 250g',N'hemo.jpg',N'DM06',N'NXB06')
insert into SanPham values('SP007',N'Kỹ Thuật Lập Trình',35000,N'Kích thước 17x24 trọng lượng 250g',N'KTLT.jpg',N'DM06',N'NXB06')
insert into SanPham values('SP008',N'Lập Trình Hướng Đối Tượng Với C++',45000,N'Kích thước 17x24 trọng lượng 250g',N'OOPCPP.jpg',N'DM06',N'NXB06')
insert into SanPham values('SP009',N'Lập Trình Hướng Đối Tượng với Java',35000,N'Kích thước 17x24 trọng lượng 250g',N'OOPJava.jpg',N'DM06',N'NXB06')
insert into SanPham values('SP010',N'Lập trình Ứng Dụng CSDL trên WEB',15000,N'Kích thước 17x24 trọng lượng 250g',N'ungdungcsdltrenweb.jpg',N'DM06',N'NXB06')

insert into SanPham values('SP011',N'3 Người Thầy Vĩ Đại',55000,N'Kích thước 17x24 trọng lượng 550g',N'3nguoithayvidai.jpg',N'DM05',N'NXB02')
insert into SanPham values('SP012',N'Đọc Vị Bất Kỳ Ai',45000,N'Kích thước 17x24 trọng lượng 550g',N'docvibatkyai.jpg',N'DM05',N'NXB02')
insert into SanPham values('SP013',N'Flow - Dòng Chảy',55000,N'Kích thước 17x24 trọng lượng 550g',N'dongchay.jpg',N'DM05',N'NXB02')
insert into SanPham values('SP014',N'Khéo Ăn Khéo Nói Sẽ Có Được Thiên Hạ',25000,N'Kích thước 17x24 trọng lượng 550g',N'kheoankhoenoi.jpg',N'DM05',N'NXB02')
insert into SanPham values('SP015',N'Khi Bạn Đang Mơ Thì Người Khác Đang Nỗ Lực',35000,N'Kích thước 17x24 trọng lượng 550g',N'khibandangmothinguoikhacdangnoluc.jpg',N'DM05',N'NXB02')

insert into SanPham values('SP016',N'Báo Cáo Tài Chính',65000,N'Kích thước 17x24 trọng lượng 550g',N'baocaotaichinh.jpg',N'DM03',N'NXB03')
insert into SanPham values('SP017',N'Đầu Tư Tài Chính',55000,N'Kích thước 17x24 trọng lượng 550g',N'DauTuTaiChinh.jpg',N'DM03',N'NXB03')
insert into SanPham values('SP018',N'Dạy Con Làm Giàu',75000,N'Kích thước 17x24 trọng lượng 550g',N'Dayconlamgiay.jpg',N'DM03',N'NXB03')
insert into SanPham values('SP019',N'Không Bao Giờ Thất Bại',50000,N'Kích thước 17x24 trọng lượng 550g',N'NeverFail.jpg',N'DM03',N'NXB03')
insert into SanPham values('SP020',N'Nhà Đầu Tư Thông Minh',100000,N'Kích thước 17x24 trọng lượng 550g',N'nhadaututhongminh.jpg',N'DM03',N'NXB03')

insert into SanPham values('SP021',N'Cậu Bé Rồng',5000,N'Kích thước 17x24 trọng lượng 550g',N'cauberong.jpg',N'DM01',N'NXB04')
insert into SanPham values('SP022',N'Em Bé Hồ Lô',6000,N'Kích thước 17x24 trọng lượng 550g',N'embeholo.jpg',N'DM01',N'NXB04')
insert into SanPham values('SP023',N'Tập Tô Màu',7000,N'Kích thước 17x24 trọng lượng 550g',N'tomau.jpg',N'DM01',N'NXB04')
insert into SanPham values('SP024',N'Tôi Muốn Làm Họa Sĩ',5000,N'Kích thước 17x24 trọng lượng 550g',N'tomuonlamhoasi.jpg',N'DM01',N'NXB04')
insert into SanPham values('SP025',N'Thế Giới Cổ Tích',8000,N'Kích thước 17x24 trọng lượng 550g',N'thegioicotich.jpg',N'DM01',N'NXB04')

insert into SanPham values('SP026',N'Bố Già',155000,N'Kích thước 17x24 trọng lượng 550g',N'BoGia.jpg',N'DM04',N'NXB05')
insert into SanPham values('SP027',N'Cây Cam Ngọt Của Tôi',85000,N'Kích thước 17x24 trọng lượng 550g',N'CayCamNgot.jpg',N'DM04',N'NXB05')
insert into SanPham values('SP028',N'Hai Số Phận',95000,N'Kích thước 17x24 trọng lượng 550g',N'HaiSoPhan.jpg',N'DM04',N'NXB05')
insert into SanPham values('SP029',N'Nhà Giả Kim',100000,N'Kích thước 17x24 trọng lượng 550g',N'NhaGiaKim.jpg',N'DM04',N'NXB05')
insert into SanPham values('SP030',N'Tam Quốc Diễn Nghĩa',250000,N'Kích thước 17x24 trọng lượng 550g',N'TamQuocDienNghia.jpg',N'DM04',N'NXB05')



GO

insert into KhachHang values('0123456789',N'Nguyễn Văn Nam','VanNam@gmail.com','0123456789',N'Chí Tân')
insert into KhachHang values('0987654321',N'Trần Thu Trang','Trang@gmail.com','0987654321',N'Hoài Đức')
insert into KhachHang values('0962781328',N'Nguyễn Mạnh Cường','CuongNguyen@gmail.com','0962781328',N'Phú Thọ')


insert into BLOG values('BLOG01',N'Tại sao phải đọc sách?',N'Một loạt các nghiên cứu khoa học đã chứng minh rằng đọc sách mang lại rất nhiều lợi ích cho sức khỏe tinh thần của bạn, đồng thời giúp bạn cải thiện bản thân một cách toàn diện.')
insert into BLOG values('BLOG02',N'Nên đọc sách vào thời gian nào?',N'Nhiều chuyên gia khẳng định rằng đọc sách vào buổi sáng là thời điểm tốt nhất để đọc. Chúng ta tỉnh táo và tập trung nhất vào buổi sáng, điều này giúp chúng ta lưu giữ thông tin mới tốt hơn. Nếu bạn khó ngủ vào ban đêm, đọc sách có thể giúp ích cho bạn.')
insert into BLOG values('BLOG03',N'Tại sao phải đọc sách?',N'Một loạt các nghiên cứu khoa học đã chứng minh rằng đọc sách mang lại rất nhiều lợi ích cho sức khỏe tinh thần của bạn, đồng thời giúp bạn cải thiện bản thân một cách toàn diện.')
insert into BLOG values('BLOG04',N'Nên đọc sách vào thời gian nào?',N'Nhiều chuyên gia khẳng định rằng đọc sách vào buổi sáng là thời điểm tốt nhất để đọc. Chúng ta tỉnh táo và tập trung nhất vào buổi sáng, điều này giúp chúng ta lưu giữ thông tin mới tốt hơn. Nếu bạn khó ngủ vào ban đêm, đọc sách có thể giúp ích cho bạn.')
go
insert into AccountAdmin values('ADMIN001',N'0962781328',N'Nguyễn Mạnh Cường',N'0962781328',N'ADMIN')
insert into AccountAdmin values('ADMIN002',N'0123456789',N'Nguyễn Thị Nữ',N'0123456789',N'NV')