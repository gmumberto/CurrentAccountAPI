USE [CurrentAccountAPI]
GO

/****** Object:  Table [dbo].[Costumer_TB]    Script Date: 16/11/2023 00:27:40 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Custumer_TB](
	[costumerID] [int] IDENTITY(1,1) NOT NULL,
	[costumerName] [char](20) NOT NULL,
	[costumerSurename] [char](20) NOT NULL,
	[costumerAmountInAccount] [decimal](18, 2) NOT NULL,
	[costumerCredit] [decimal](18, 2) NOT NULL,
	[costumerAccount] [int] NOT NULL,
 CONSTRAINT [PK_Costumer_TB] PRIMARY KEY CLUSTERED 
(
	[costumerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


