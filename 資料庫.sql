USE [mydb2]
GO
/****** Object:  Table [dbo].[member]    Script Date: 2023/2/4 下午 09:30:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[member](
	[uid] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NULL,
	[phone] [nvarchar](50) NULL,
	[address] [nvarchar](50) NULL,
	[email] [nvarchar](50) NULL,
	[birth] [date] NULL,
	[password] [nvarchar](50) NULL,
 CONSTRAINT [PK_member] PRIMARY KEY CLUSTERED 
(
	[uid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[orderDetial]    Script Date: 2023/2/4 下午 09:30:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[orderDetial](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[uid] [int] NULL,
	[orderid] [int] NULL,
	[productid] [int] NULL,
	[product_name] [nvarchar](100) NULL,
	[count] [int] NULL,
	[addon] [nvarchar](100) NULL,
	[subtotal] [int] NULL,
 CONSTRAINT [PK_orderDetial] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[orderList]    Script Date: 2023/2/4 下午 09:30:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[orderList](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[uid] [int] NULL,
	[orderid] [int] NULL,
	[updated] [date] NULL,
	[price] [int] NULL,
	[discount] [int] NULL,
	[total] [int] NULL,
	[pickup] [nvarchar](50) NULL,
	[receive_name] [nvarchar](50) NULL,
	[receive_phone] [nvarchar](50) NULL,
	[receive_mail] [nvarchar](50) NULL,
	[receive_address] [nvarchar](50) NULL,
	[state] [int] NULL,
 CONSTRAINT [PK_orderList] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[product]    Script Date: 2023/2/4 下午 09:30:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[product](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[pname] [nvarchar](100) NULL,
	[price] [int] NULL,
	[pdesc] [nvarchar](500) NULL,
	[pimage] [nvarchar](100) NULL,
 CONSTRAINT [PK_product] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[member] ON 

INSERT [dbo].[member] ([uid], [name], [phone], [address], [email], [birth], [password]) VALUES (1, N'周杰倫', N'0987654321', N'台北市林口區', N'jay@yahoo.com.tw', CAST(N'1979-01-18' AS Date), N'1234')
INSERT [dbo].[member] ([uid], [name], [phone], [address], [email], [birth], [password]) VALUES (2, N'蔡依林', N'0987654322', N'台北市新莊區', N'jolin@yahoo.com', CAST(N'1980-09-15' AS Date), N'1234')
INSERT [dbo].[member] ([uid], [name], [phone], [address], [email], [birth], [password]) VALUES (3, N'林俊傑', N'0988999765', N'台北市', N'jj@yahoo.com', CAST(N'1981-03-27' AS Date), N'1234')
INSERT [dbo].[member] ([uid], [name], [phone], [address], [email], [birth], [password]) VALUES (4, N'羅志祥', N'0999776885', N'基隆市', N'pig@yahoo.com', CAST(N'1979-12-26' AS Date), N'1234')
INSERT [dbo].[member] ([uid], [name], [phone], [address], [email], [birth], [password]) VALUES (5, N'玖壹壹', N'0936593992', N'台北市中山區', N'nine@yahoo.com', CAST(N'2009-09-11' AS Date), N'1234')
INSERT [dbo].[member] ([uid], [name], [phone], [address], [email], [birth], [password]) VALUES (6, N'戴愛玲', N'0951376535', N'屏東縣春日鄉', N'Juiguu@yahoo.com', CAST(N'1978-06-22' AS Date), N'1234')
INSERT [dbo].[member] ([uid], [name], [phone], [address], [email], [birth], [password]) VALUES (7, N'蕭敬騰', N'0943769316', N'花蓮縣', N'hsiao@yahoo.com', CAST(N'1987-03-30' AS Date), N'1234')
INSERT [dbo].[member] ([uid], [name], [phone], [address], [email], [birth], [password]) VALUES (8, N'9m88', N'0936942358', N'台北市', N'Joanne@yahoo.com', CAST(N'1990-11-20' AS Date), N'1234')
INSERT [dbo].[member] ([uid], [name], [phone], [address], [email], [birth], [password]) VALUES (9, N'吳卓源', N'0957328742', N'台北市', N'julia@yahoo.com', CAST(N'1994-10-06' AS Date), N'1234')
INSERT [dbo].[member] ([uid], [name], [phone], [address], [email], [birth], [password]) VALUES (10, N'五月天', N'0953766333', N'台北市', N'mayday@yahoo.com', CAST(N'1999-07-07' AS Date), N'1234')
INSERT [dbo].[member] ([uid], [name], [phone], [address], [email], [birth], [password]) VALUES (11, N'測試二', N'0974185263', N'高雄市三民區', N'test2@yahoo.com', CAST(N'1992-02-21' AS Date), N'1234')
INSERT [dbo].[member] ([uid], [name], [phone], [address], [email], [birth], [password]) VALUES (12, N'測試一', N'0985223267', N'高雄市前金區', N'ex@yahoo.com', CAST(N'1996-04-25' AS Date), N'1234')
SET IDENTITY_INSERT [dbo].[member] OFF
SET IDENTITY_INSERT [dbo].[orderDetial] ON 

INSERT [dbo].[orderDetial] ([id], [uid], [orderid], [productid], [product_name], [count], [addon], [subtotal]) VALUES (1, 1, 607403411, 1, N'黑森林蛋糕', 1, N'無須加購', 120)
INSERT [dbo].[orderDetial] ([id], [uid], [orderid], [productid], [product_name], [count], [addon], [subtotal]) VALUES (2, 1, 607403411, 2, N'法式草莓塔', 1, N'中杯那堤 (+$100)', 200)
INSERT [dbo].[orderDetial] ([id], [uid], [orderid], [productid], [product_name], [count], [addon], [subtotal]) VALUES (3, 1, 455986099, 2, N'法式草莓塔', 1, N'無須加購', 100)
INSERT [dbo].[orderDetial] ([id], [uid], [orderid], [productid], [product_name], [count], [addon], [subtotal]) VALUES (4, 1, 455986099, 4, N'紫薯雙色蛋糕捲', 1, N'大杯那堤 (+$115)', 225)
INSERT [dbo].[orderDetial] ([id], [uid], [orderid], [productid], [product_name], [count], [addon], [subtotal]) VALUES (5, 1, 350024650, 1, N'黑森林蛋糕', 3, N'中杯那堤 (+$100)', 660)
INSERT [dbo].[orderDetial] ([id], [uid], [orderid], [productid], [product_name], [count], [addon], [subtotal]) VALUES (6, 1, 350024650, 2, N'法式草莓塔', 3, N'大杯那堤 (+$115)', 645)
INSERT [dbo].[orderDetial] ([id], [uid], [orderid], [productid], [product_name], [count], [addon], [subtotal]) VALUES (7, 2, 293742450, 6, N'蘋果可麗露', 1, N'中杯那堤 (+$100)', 165)
INSERT [dbo].[orderDetial] ([id], [uid], [orderid], [productid], [product_name], [count], [addon], [subtotal]) VALUES (8, 2, 293742450, 8, N'柚香焙茶蛋糕', 1, N'無須加購', 120)
INSERT [dbo].[orderDetial] ([id], [uid], [orderid], [productid], [product_name], [count], [addon], [subtotal]) VALUES (9, 2, 293742450, 19, N'葡萄乾司康', 1, N'大杯那堤 (+$115)', 180)
INSERT [dbo].[orderDetial] ([id], [uid], [orderid], [productid], [product_name], [count], [addon], [subtotal]) VALUES (10, 3, 641928867, 11, N'糖霜檸檬蛋糕', 3, N'中杯那堤 (+$100)', 1080)
INSERT [dbo].[orderDetial] ([id], [uid], [orderid], [productid], [product_name], [count], [addon], [subtotal]) VALUES (11, 3, 641928867, 12, N'可可伯爵薄餅', 1, N'無須加購', 130)
INSERT [dbo].[orderDetial] ([id], [uid], [orderid], [productid], [product_name], [count], [addon], [subtotal]) VALUES (12, 3, 641928867, 10, N'棉花糖巧克力餅', 2, N'無須加購', 70)
INSERT [dbo].[orderDetial] ([id], [uid], [orderid], [productid], [product_name], [count], [addon], [subtotal]) VALUES (13, 3, 641928867, 18, N'檸檬年輪蛋糕', 1, N'中杯那堤 (+$100)', 460)
INSERT [dbo].[orderDetial] ([id], [uid], [orderid], [productid], [product_name], [count], [addon], [subtotal]) VALUES (14, 4, 830870566, 16, N'法式千層薄餅', 2, N'大杯那堤 (+$115)', 420)
INSERT [dbo].[orderDetial] ([id], [uid], [orderid], [productid], [product_name], [count], [addon], [subtotal]) VALUES (15, 4, 830870566, 15, N'檸檬塔', 1, N'大杯那堤 (+$115)', 185)
INSERT [dbo].[orderDetial] ([id], [uid], [orderid], [productid], [product_name], [count], [addon], [subtotal]) VALUES (16, 5, 633987264, 17, N'岩漿巧克力蛋糕', 2, N'中杯那堤 (+$100)', 380)
INSERT [dbo].[orderDetial] ([id], [uid], [orderid], [productid], [product_name], [count], [addon], [subtotal]) VALUES (17, 5, 633987264, 18, N'檸檬年輪蛋糕', 3, N'無須加購', 1080)
INSERT [dbo].[orderDetial] ([id], [uid], [orderid], [productid], [product_name], [count], [addon], [subtotal]) VALUES (18, 6, 662030343, 8, N'柚香焙茶蛋糕', 5, N'無須加購', 600)
INSERT [dbo].[orderDetial] ([id], [uid], [orderid], [productid], [product_name], [count], [addon], [subtotal]) VALUES (19, 6, 662030343, 9, N'經典千層薄餅', 1, N'中杯那堤 (+$100)', 220)
INSERT [dbo].[orderDetial] ([id], [uid], [orderid], [productid], [product_name], [count], [addon], [subtotal]) VALUES (20, 1, 931659818, 18, N'檸檬年輪蛋糕', 1, N'無須加購', 360)
INSERT [dbo].[orderDetial] ([id], [uid], [orderid], [productid], [product_name], [count], [addon], [subtotal]) VALUES (21, 1, 931659818, 13, N'經典起司蛋糕', 2, N'大杯那堤 (+$115)', 430)
INSERT [dbo].[orderDetial] ([id], [uid], [orderid], [productid], [product_name], [count], [addon], [subtotal]) VALUES (22, 10, 159176077, 3, N'貓掌小蛋糕', 5, N'中杯那堤 (+$100)', 825)
INSERT [dbo].[orderDetial] ([id], [uid], [orderid], [productid], [product_name], [count], [addon], [subtotal]) VALUES (23, 9, 378610542, 15, N'檸檬塔', 1, N'無須加購', 70)
INSERT [dbo].[orderDetial] ([id], [uid], [orderid], [productid], [product_name], [count], [addon], [subtotal]) VALUES (24, 9, 378610542, 11, N'糖霜檸檬蛋糕', 1, N'中杯那堤 (+$100)', 360)
INSERT [dbo].[orderDetial] ([id], [uid], [orderid], [productid], [product_name], [count], [addon], [subtotal]) VALUES (25, 1, 317826509, 1, N'黑森林蛋糕', 1, N'無須加購', 120)
INSERT [dbo].[orderDetial] ([id], [uid], [orderid], [productid], [product_name], [count], [addon], [subtotal]) VALUES (26, 1, 317826509, 2, N'法式草莓塔', 1, N'大杯那堤 (+$115)', 215)
INSERT [dbo].[orderDetial] ([id], [uid], [orderid], [productid], [product_name], [count], [addon], [subtotal]) VALUES (27, 8, 918209125, 16, N'法式千層薄餅', 1, N'大杯那堤 (+$115)', 210)
INSERT [dbo].[orderDetial] ([id], [uid], [orderid], [productid], [product_name], [count], [addon], [subtotal]) VALUES (28, 8, 918209125, 9, N'經典千層薄餅', 2, N'大杯那堤 (+$115)', 470)
INSERT [dbo].[orderDetial] ([id], [uid], [orderid], [productid], [product_name], [count], [addon], [subtotal]) VALUES (29, 7, 514731408, 4, N'紫薯雙色蛋糕捲', 3, N'無須加購', 330)
INSERT [dbo].[orderDetial] ([id], [uid], [orderid], [productid], [product_name], [count], [addon], [subtotal]) VALUES (30, 7, 514731408, 12, N'可可伯爵薄餅', 1, N'大杯那堤 (+$115)', 245)
INSERT [dbo].[orderDetial] ([id], [uid], [orderid], [productid], [product_name], [count], [addon], [subtotal]) VALUES (31, 1, 195480650, 2, N'法式草莓塔', 1, N'中杯那堤 (+$100)', 200)
INSERT [dbo].[orderDetial] ([id], [uid], [orderid], [productid], [product_name], [count], [addon], [subtotal]) VALUES (32, 1, 195480650, 6, N'蘋果可麗露', 1, N'大杯那堤 (+$115)', 180)
SET IDENTITY_INSERT [dbo].[orderDetial] OFF
SET IDENTITY_INSERT [dbo].[orderList] ON 

INSERT [dbo].[orderList] ([id], [uid], [orderid], [updated], [price], [discount], [total], [pickup], [receive_name], [receive_phone], [receive_mail], [receive_address], [state]) VALUES (1, 1, 607403411, CAST(N'2022-10-31' AS Date), 200, 50, 150, N'自取', N'周杰倫', N'0987654321', N'jay@yahoo.com.tw', N'台北市林口區', 1)
INSERT [dbo].[orderList] ([id], [uid], [orderid], [updated], [price], [discount], [total], [pickup], [receive_name], [receive_phone], [receive_mail], [receive_address], [state]) VALUES (2, 1, 455986099, CAST(N'2022-10-31' AS Date), 225, 50, 175, N'自取', N'周杰倫', N'0987654300', N'jay@yahoo.com.tw', N'台北市林口區', 1)
INSERT [dbo].[orderList] ([id], [uid], [orderid], [updated], [price], [discount], [total], [pickup], [receive_name], [receive_phone], [receive_mail], [receive_address], [state]) VALUES (3, 1, 350024650, CAST(N'2022-10-31' AS Date), 645, 50, 595, N'自取', N'周杰倫', N'0987654321', N'jay@yahoo.com.tw', N'台北市林口區', 1)
INSERT [dbo].[orderList] ([id], [uid], [orderid], [updated], [price], [discount], [total], [pickup], [receive_name], [receive_phone], [receive_mail], [receive_address], [state]) VALUES (4, 2, 293742450, CAST(N'2022-10-31' AS Date), 180, 100, 80, N'自取', N'蔡依林', N'0987654322', N'jolin@yahoo.com', N'台北市新莊區', 0)
INSERT [dbo].[orderList] ([id], [uid], [orderid], [updated], [price], [discount], [total], [pickup], [receive_name], [receive_phone], [receive_mail], [receive_address], [state]) VALUES (5, 3, 641928867, CAST(N'2022-10-31' AS Date), 460, 100, 360, N'自取', N'林俊傑', N'0988999765', N'jj@yahoo.com', N'台北市', 0)
INSERT [dbo].[orderList] ([id], [uid], [orderid], [updated], [price], [discount], [total], [pickup], [receive_name], [receive_phone], [receive_mail], [receive_address], [state]) VALUES (6, 4, 830870566, CAST(N'2022-10-31' AS Date), 185, 50, 135, N'宅配', N'羅志祥', N'0999776885', N'pig@yahoo.com', N'基隆市', 0)
INSERT [dbo].[orderList] ([id], [uid], [orderid], [updated], [price], [discount], [total], [pickup], [receive_name], [receive_phone], [receive_mail], [receive_address], [state]) VALUES (7, 5, 633987264, CAST(N'2022-10-31' AS Date), 1080, 50, 1030, N'自取', N'玖壹壹', N'0936593992', N'nine@yahoo.com', N'台北市中山區', 0)
INSERT [dbo].[orderList] ([id], [uid], [orderid], [updated], [price], [discount], [total], [pickup], [receive_name], [receive_phone], [receive_mail], [receive_address], [state]) VALUES (8, 6, 662030343, CAST(N'2022-10-31' AS Date), 220, 50, 170, N'宅配', N'戴愛玲', N'0951376535', N'Juiguu@yahoo.com', N'屏東縣春日鄉', 0)
INSERT [dbo].[orderList] ([id], [uid], [orderid], [updated], [price], [discount], [total], [pickup], [receive_name], [receive_phone], [receive_mail], [receive_address], [state]) VALUES (9, 1, 931659818, CAST(N'2022-11-01' AS Date), 430, 50, 380, N'宅配', N'周杰倫', N'0987654321', N'jay@yahoo.com.tw', N'台北市林口區', 0)
INSERT [dbo].[orderList] ([id], [uid], [orderid], [updated], [price], [discount], [total], [pickup], [receive_name], [receive_phone], [receive_mail], [receive_address], [state]) VALUES (10, 10, 159176077, CAST(N'2022-11-01' AS Date), 825, 0, 825, N'自取', N'阿信', N'0953766333', N'mayday@yahoo.com', N'台北市', 0)
INSERT [dbo].[orderList] ([id], [uid], [orderid], [updated], [price], [discount], [total], [pickup], [receive_name], [receive_phone], [receive_mail], [receive_address], [state]) VALUES (11, 9, 378610542, CAST(N'2022-11-01' AS Date), 360, 50, 310, N'宅配', N'吳卓源', N'0957328742', N'julia@yahoo.com', N'台北市', 0)
INSERT [dbo].[orderList] ([id], [uid], [orderid], [updated], [price], [discount], [total], [pickup], [receive_name], [receive_phone], [receive_mail], [receive_address], [state]) VALUES (12, 1, 317826509, CAST(N'2022-11-02' AS Date), 215, 50, 165, N'宅配', N'周杰倫', N'0987654321', N'jay@yahoo.com.tw', N'台北市林口區', 0)
INSERT [dbo].[orderList] ([id], [uid], [orderid], [updated], [price], [discount], [total], [pickup], [receive_name], [receive_phone], [receive_mail], [receive_address], [state]) VALUES (13, 8, 918209125, CAST(N'2022-11-02' AS Date), 470, 50, 420, N'宅配', N'9m88', N'0936942358', N'Joanne@yahoo.com', N'台北市', 0)
INSERT [dbo].[orderList] ([id], [uid], [orderid], [updated], [price], [discount], [total], [pickup], [receive_name], [receive_phone], [receive_mail], [receive_address], [state]) VALUES (14, 7, 514731408, CAST(N'2022-11-02' AS Date), 245, 50, 195, N'自取', N'蕭敬騰', N'0943769316', N'hsiao@yahoo.com', N'花蓮縣', 0)
INSERT [dbo].[orderList] ([id], [uid], [orderid], [updated], [price], [discount], [total], [pickup], [receive_name], [receive_phone], [receive_mail], [receive_address], [state]) VALUES (15, 1, 195480650, CAST(N'2022-11-03' AS Date), 180, 50, 130, N'宅配', N'周杰倫', N'0987654321', N'jay@yahoo.com.tw', N'台北市林口區', 0)
SET IDENTITY_INSERT [dbo].[orderList] OFF
SET IDENTITY_INSERT [dbo].[product] ON 

INSERT [dbo].[product] ([id], [pname], [price], [pdesc], [pimage]) VALUES (1, N'黑森林蛋糕', 120, N'融合苦甜巧克力和香甜鮮奶油，混入濃醇酒漬櫻桃丁，最後以巧克力碎片代表黑森林的樹木。整體巧克力香氣濃郁，淡雅櫻桃酒風味，是下午茶的好選擇。', N'P001.jpg')
INSERT [dbo].[product] ([id], [pname], [price], [pdesc], [pimage]) VALUES (2, N'法式草莓塔', 100, N'有大顆的草莓塊搭上薄塔皮。在台灣草莓季尚未開始前，可以搶先享用到法國的草莓風味。', N'P002.jpg')
INSERT [dbo].[product] ([id], [pname], [price], [pdesc], [pimage]) VALUES (3, N'貓掌小蛋糕', 65, N'可愛貓掌造型小蛋糕，以巧克力奶油磅蛋糕為主體，因應萬聖節，推出黑貓掌造型，擄獲貓奴的心。(一組兩只)', N'P014.jpg')
INSERT [dbo].[product] ([id], [pname], [price], [pdesc], [pimage]) VALUES (4, N'紫薯雙色蛋糕捲', 110, N'以竹炭戚風蛋糕為主體，中間捲入富有口感的地瓜奶油餡，上方擠上條狀紫薯泥，再插上貓耳造型巧克力片，以蛋糕捲起的樣子為貓咪尾巴造型，是款萬聖節感十足的蛋糕。', N'P010.jpg')
INSERT [dbo].[product] ([id], [pname], [price], [pdesc], [pimage]) VALUES (5, N'玉米片起司餅乾', 40, N'奶油餅乾混入鹹香的起司粉，沾上玉米脆片烤成的餅乾。脆脆的玉米片與酥鬆的餅乾組合，是辦公室最佳的小零嘴。', N'P016.jpg')
INSERT [dbo].[product] ([id], [pname], [price], [pdesc], [pimage]) VALUES (6, N'蘋果可麗露', 65, N'含有蘭姆酒的原味可麗露，灌入有蘋果威士忌的蘋果慕斯內餡，香甜感十足，又帶點微醺的成人風味。', N'P015.jpg')
INSERT [dbo].[product] ([id], [pname], [price], [pdesc], [pimage]) VALUES (7, N'芋泥波士頓派', 85, N'滿滿的芋泥和蜜芋頭塊夾入鬆軟又有彈性的戚風蛋糕體中，再抹上一層鮮奶油。入口即可感受到綿密芋泥、滑順鮮奶油及蛋糕體細緻蛋香，所交織的美好風味。', N'P003.jpg')
INSERT [dbo].[product] ([id], [pname], [price], [pdesc], [pimage]) VALUES (8, N'柚香焙茶蛋糕', 120, N'清爽的柚香慕斯搭配焙茶戚風蛋糕，抹入一層薄薄的榛果內餡提味，最外層淋上脆皮巧克力。是款多層次口感與創意風味的結合。', N'P011.jpg')
INSERT [dbo].[product] ([id], [pname], [price], [pdesc], [pimage]) VALUES (9, N'經典千層薄餅', 120, N'更升級的精緻展現 26層慢慢堆疊的經典薄餅，餅皮極為細緻，與夾層的鮮奶油幾乎融為一體，添加頂級白蘭地與香甜奶酒，尾韻帶著淡淡的大人風味。', N'P006.jpg')
INSERT [dbo].[product] ([id], [pname], [price], [pdesc], [pimage]) VALUES (10, N'棉花糖巧克力餅', 35, N'棉花糖烘烤後融入巧克力餅乾中的黏滑口感，豐富餅乾的整體展現，香甜不膩讓人喜愛。', N'P017.jpg')
INSERT [dbo].[product] ([id], [pname], [price], [pdesc], [pimage]) VALUES (11, N'糖霜檸檬蛋糕', 260, N'清新的檸檬香甜搭配奶油香氣十足的蛋糕。蛋糕使用水蒸式烤法，口感介於重奶油磅蛋糕與海綿蛋糕之間。清新檸檬皮拌入顆粒感的糖霜，覆蓋在蛋香十足與濃厚奶油風味的蛋糕上。整體口感紮實，香氣濃郁。', N'P009.jpg')
INSERT [dbo].[product] ([id], [pname], [price], [pdesc], [pimage]) VALUES (12, N'可可伯爵薄餅', 130, N'細緻軟嫩的薄餅皮中，夾藏伯爵紅茶內餡，頂層撒上滿滿的可可粉，口感綿密滑順，更具層次感。', N'P007.jpg')
INSERT [dbo].[product] ([id], [pname], [price], [pdesc], [pimage]) VALUES (13, N'經典起司蛋糕', 100, N'使用濃郁的Cream Cheese及酸奶創造出綿密香濃的乳酪蛋糕，再加上底層的消化餅乾，增添整體口感。', N'P008.jpg')
INSERT [dbo].[product] ([id], [pname], [price], [pdesc], [pimage]) VALUES (14, N'咖啡松露蛋糕', 85, N'以義大利烘焙咖啡融合巧克力蛋糕，其中蘊含迷人的巧克力榛果及酥脆的餅乾脆片，多層次的組合展現豐富口感，裝飾的巧克力粉猶如從土裡挖出來的松露一般而以之命名。', N'P005.jpg')
INSERT [dbo].[product] ([id], [pname], [price], [pdesc], [pimage]) VALUES (15, N'檸檬塔', 70, N'選用酸甜的檸檬調合奶油交織出清爽滑順的檸檬奶醬，搭配烘烤至香酥的塔皮與海綿蛋糕，相當受到星巴克顧客的喜愛與好評。', N'P012.jpg')
INSERT [dbo].[product] ([id], [pname], [price], [pdesc], [pimage]) VALUES (16, N'法式千層薄餅', 95, N'一片片輕薄Q彈的法式餅皮，搭配香氣迷人的香草卡士達餡；透過主廚輕柔手法，細心呵護的將每一層餅皮中裹上滑順的香草卡士達餡，交疊成美好的法式千層薄餅。', N'P004.jpg')
INSERT [dbo].[product] ([id], [pname], [price], [pdesc], [pimage]) VALUES (17, N'岩漿巧克力蛋糕', 90, N'溫熱鬆軟的英式布丁蛋糕體切開來是深黑濃郁的巧克力岩漿，充滿讓人愛不釋口的幸福感。', N'P013.jpg')
INSERT [dbo].[product] ([id], [pname], [price], [pdesc], [pimage]) VALUES (18, N'檸檬年輪蛋糕', 360, N'年輪蛋糕推出新風味，清新的檸檬香氣，微酸的風味搭著蛋香，很適合初夏的季節。', N'P018.jpg')
INSERT [dbo].[product] ([id], [pname], [price], [pdesc], [pimage]) VALUES (19, N'葡萄乾司康', 65, N'司康麵糰中除了濃郁奶油香氣外更有淡淡的楓糖香氣，並添加了充滿果香的葡萄乾，外酥內軟，最適合搭配咖啡或茶隨時享用。', N'P019.jpg')
INSERT [dbo].[product] ([id], [pname], [price], [pdesc], [pimage]) VALUES (20, N'長條蜂蜜蛋糕', 300, N'廣受顧客喜愛的蜂蜜蛋糕，在母親節檔期持續供應，綿密的蛋糕體有著濃郁的蛋香，不論自己食用或送禮都非常適合。', N'P020.jpg')
INSERT [dbo].[product] ([id], [pname], [price], [pdesc], [pimage]) VALUES (21, N'測試蛋糕2', 120, N'好吃哦', N'202210311404497881.jpg')
SET IDENTITY_INSERT [dbo].[product] OFF
ALTER TABLE [dbo].[orderDetial]  WITH CHECK ADD  CONSTRAINT [FK_orderDetial_product] FOREIGN KEY([productid])
REFERENCES [dbo].[product] ([id])
GO
ALTER TABLE [dbo].[orderDetial] CHECK CONSTRAINT [FK_orderDetial_product]
GO
