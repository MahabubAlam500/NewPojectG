USE [AjxDB]
GO
/****** Object:  Table [dbo].[district]    Script Date: 5/4/2019 8:01:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[district](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DivListID] [int] NOT NULL,
	[name] [nvarchar](max) NULL,
 CONSTRAINT [PK_district] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[divList]    Script Date: 5/4/2019 8:01:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[divList](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_divList] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Upazila]    Script Date: 5/4/2019 8:01:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Upazila](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[districtId] [int] NOT NULL,
	[name] [nvarchar](max) NULL,
 CONSTRAINT [PK_Upazila] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

ALTER TABLE [dbo].[district]  WITH CHECK ADD  CONSTRAINT [FK_district_divList_DivListID] FOREIGN KEY([DivListID])
REFERENCES [dbo].[divList] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[district] CHECK CONSTRAINT [FK_district_divList_DivListID]
GO
ALTER TABLE [dbo].[Upazila]  WITH CHECK ADD  CONSTRAINT [FK_Upazila_district_districtId] FOREIGN KEY([districtId])
REFERENCES [dbo].[district] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Upazila] CHECK CONSTRAINT [FK_Upazila_district_districtId]
GO
