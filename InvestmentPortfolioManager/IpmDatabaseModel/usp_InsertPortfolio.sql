CREATE PROCEDURE [dbo].[usp_InsertPortfolio]
    @Name nvarchar(256)
AS
BEGIN
    -- Create balance books
    INSERT INTO [dbo].[BalanceBooks]
               ([CashBalance]
               ,[AssetsBookCost]
               ,[AssetsMarketPrice]
               ,[Yield]
               ,[YieldPercent]
               ,[Return]
               ,[ReturnPercent])
         VALUES
               (0
               ,0
               ,0
               ,0
               ,0
               ,0
               ,0);

    DECLARE @BalanceBookId int;
    SET @BalanceBookId = SCOPE_IDENTITY();

    INSERT INTO dbo.BalanceBooks_PortfolioBalanceBook
            (BalanceBookId) 
        VALUES
            (@BalanceBookId);

    INSERT INTO dbo.Portfolios
            (Name, BalanceBook_BalanceBookId)
        VALUES
            (@Name, @BalanceBookId);

    SELECT SCOPE_IDENTITY() as PortfolioId;
END
