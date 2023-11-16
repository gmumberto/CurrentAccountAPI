USE [CurrentAccountAPI]
GO

/****** Object:  Table [dbo].[Transaction_TB]    Script Date: 16/11/2023 00:54:51 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Transaction_TB](
	[transactionID] [int] IDENTITY(1,1) NOT NULL,
	[custumerID] [int] NOT NULL,
	[transactionDate] [datetime] NOT NULL,
	[transactionAmount] [decimal](18, 2) NOT NULL,
	[transactionReceivedFromAccount] [int] NULL,
	[transactionSentToAccount] [int] NULL,
	[transactionRemainingBalance] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_Transaction_TB] PRIMARY KEY CLUSTERED 
(
	[transactionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


