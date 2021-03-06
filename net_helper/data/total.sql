USE [HtmlSelect]
GO
/****** 对象:  Table [dbo].[total]    脚本日期: 06/18/2014 16:18:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[total](
	[timespan] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[website] [nvarchar](500) COLLATE Chinese_PRC_CI_AS NULL,
	[start_time] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[host] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[client] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[total0] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[total1] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[total2] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[total3] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[total5] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[total6] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[total_more] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL
) ON [PRIMARY]
