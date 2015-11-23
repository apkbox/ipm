CREATE TABLE [dbo].[Portfolios]
    (
        [PortfolioId] [int] IDENTITY(1,1) NOT NULL,
        [Name] [nvarchar](max) NOT NULL,
        [BalanceBook_BalanceBookId] [int] NOT NULL,
        CONSTRAINT [PK_Portfolios] PRIMARY KEY CLUSTERED ([PortfolioId] ASC)
        WITH
            (PAD_INDEX = OFF,
             STATISTICS_NORECOMPUTE = OFF,
             IGNORE_DUP_KEY = OFF,
             ALLOW_ROW_LOCKS = ON,
             ALLOW_PAGE_LOCKS = ON)
        ON [PRIMARY]
    ) 
    ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

ALTER TABLE [dbo].[Portfolios]
    WITH CHECK ADD CONSTRAINT [FK_PortfolioPortfolioBalanceBook] FOREIGN KEY ([BalanceBook_BalanceBookId])
    REFERENCES [dbo].[BalanceBooks_PortfolioBalanceBook] ([BalanceBookId])
GO

ALTER TABLE [dbo].[Portfolios] CHECK CONSTRAINT [FK_PortfolioPortfolioBalanceBook]
GO

