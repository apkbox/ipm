CREATE TABLE [dbo].[BalanceBooks](
	[BalanceBookId] [int] IDENTITY(1,1) NOT NULL,
	[CashBalance] [decimal](18, 0) NOT NULL,
	[AssetsBookCost] [decimal](18, 0) NOT NULL,
	[AssetsMarketPrice] [decimal](18, 0) NOT NULL,
	[Yield] [decimal](18, 0) NOT NULL,
	[YieldPercent] [decimal](18, 0) NOT NULL,
	[Return] [decimal](18, 0) NOT NULL,
	[ReturnPercent] [decimal](18, 0) NOT NULL,
 CONSTRAINT [PK_BalanceBooks] PRIMARY KEY CLUSTERED 
(
	[BalanceBookId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
