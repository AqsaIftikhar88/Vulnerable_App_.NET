USE [webproject]
GO
/****** This file is just for an example for idea of database table whiich are used for login and registeration of users and admin******/
/****** Object:  Table [dbo].[Admin_login] ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Admin_login](
	[admin_name] [nvarchar](50) NOT NULL,
	[password] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Admin_login] PRIMARY KEY CLUSTERED 
(
	[admin_name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[user_table] ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[user_table](
	[user_name] [nvarchar](50) NOT NULL,
	[email_address] [nvarchar](50) NOT NULL,
	[password] [nvarchar](50) NOT NULL,
	[confirm_password] [nvarchar](50) NOT NULL
) ON [PRIMARY]
GO
