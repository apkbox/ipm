CREATE TABLE [dbo].[BalanceBooks_PortfolioBalanceBook]
    (
            [BalanceBookId] [int] NOT NULL,
        CONSTRAINT [PK_BalanceBooks_PortfolioBalanceBook] PRIMARY KEY CLUSTERED
            ([BalanceBookId] ASC)
        WITH 
            (PAD_INDEX = OFF,
             STATISTICS_NORECOMPUTE = OFF,
             IGNORE_DUP_KEY = OFF,
             ALLOW_ROW_LOCKS = ON,
             ALLOW_PAGE_LOCKS = ON)
        ON [PRIMARY]
    ) ON [PRIMARY];
GO

ALTER TABLE [dbo].[BalanceBooks_PortfolioBalanceBook] 
    WITH CHECK ADD
    CONSTRAINT [FK_PortfolioBalanceBook_inherits_BalanceBook]
    FOREIGN KEY ([BalanceBookId])
    REFERENCES [dbo].[BalanceBooks] ([BalanceBookId])
    ON DELETE CASCADE;
GO

ALTER TABLE [dbo].[BalanceBooks_PortfolioBalanceBook]
    CHECK CONSTRAINT [FK_PortfolioBalanceBook_inherits_BalanceBook];
GO
