CREATE PROCEDURE [dbo].[usp_DeletePortfolio]
    @PortfolioId int
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON;

    DELETE FROM [dbo].[Portfolios]
        WHERE PortfolioId = @PortfolioId;
END
