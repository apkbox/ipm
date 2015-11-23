CREATE PROCEDURE [dbo].[usp_UpdatePortfolio]
    @PortfolioId int,
    @Name nvarchar(256)
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON;

    UPDATE dbo.Portfolios
    SET Name = @Name
    WHERE PortfolioId = @PortfolioId;
END
