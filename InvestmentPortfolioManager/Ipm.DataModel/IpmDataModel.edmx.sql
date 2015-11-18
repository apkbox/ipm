
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/18/2015 02:30:43
-- Generated from EDMX file: D:\Projects\ipm\InvestmentPortfolioManager\Ipm.DataModel\IpmDataModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [IpmDb];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_AccountCashTransaction]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CashTransactions] DROP CONSTRAINT [FK_AccountCashTransaction];
GO
IF OBJECT_ID(N'[dbo].[FK_PortfolioAccount]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Accounts] DROP CONSTRAINT [FK_PortfolioAccount];
GO
IF OBJECT_ID(N'[dbo].[FK_AccountAssetTransaction]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AssetTransactions] DROP CONSTRAINT [FK_AccountAssetTransaction];
GO
IF OBJECT_ID(N'[dbo].[FK_AssetAssetInstance]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AssetInstances] DROP CONSTRAINT [FK_AssetAssetInstance];
GO
IF OBJECT_ID(N'[dbo].[FK_AccountAssetInstance]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AssetInstances] DROP CONSTRAINT [FK_AccountAssetInstance];
GO
IF OBJECT_ID(N'[dbo].[FK_AssetInstanceAssetTransaction]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AssetTransactions] DROP CONSTRAINT [FK_AssetInstanceAssetTransaction];
GO
IF OBJECT_ID(N'[dbo].[FK_AssetTransactionCashTransaction]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CashTransactions] DROP CONSTRAINT [FK_AssetTransactionCashTransaction];
GO
IF OBJECT_ID(N'[dbo].[FK_PortfolioPortfolioBalanceBook]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Portfolios] DROP CONSTRAINT [FK_PortfolioPortfolioBalanceBook];
GO
IF OBJECT_ID(N'[dbo].[FK_AccountAccountBalanceBook]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Accounts] DROP CONSTRAINT [FK_AccountAccountBalanceBook];
GO
IF OBJECT_ID(N'[dbo].[FK_PortfolioBalanceBook_inherits_BalanceBook]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BalanceBooks_PortfolioBalanceBook] DROP CONSTRAINT [FK_PortfolioBalanceBook_inherits_BalanceBook];
GO
IF OBJECT_ID(N'[dbo].[FK_AccountBalanceBook_inherits_BalanceBook]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BalanceBooks_AccountBalanceBook] DROP CONSTRAINT [FK_AccountBalanceBook_inherits_BalanceBook];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Assets]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Assets];
GO
IF OBJECT_ID(N'[dbo].[AssetInstances]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AssetInstances];
GO
IF OBJECT_ID(N'[dbo].[Portfolios]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Portfolios];
GO
IF OBJECT_ID(N'[dbo].[Accounts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Accounts];
GO
IF OBJECT_ID(N'[dbo].[BalanceBooks]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BalanceBooks];
GO
IF OBJECT_ID(N'[dbo].[CashTransactions]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CashTransactions];
GO
IF OBJECT_ID(N'[dbo].[AssetTransactions]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AssetTransactions];
GO
IF OBJECT_ID(N'[dbo].[BalanceBooks_PortfolioBalanceBook]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BalanceBooks_PortfolioBalanceBook];
GO
IF OBJECT_ID(N'[dbo].[BalanceBooks_AccountBalanceBook]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BalanceBooks_AccountBalanceBook];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Assets'
CREATE TABLE [dbo].[Assets] (
    [AssetId] int IDENTITY(1,1) NOT NULL,
    [TickerSymbol] nvarchar(max)  NOT NULL,
    [AssetName] nvarchar(max)  NOT NULL,
    [DividendYield] decimal(18,0)  NOT NULL,
    [MER] decimal(18,0)  NOT NULL,
    [LastMarketPrice] decimal(18,0)  NOT NULL,
    [LastQuoteDate] datetime  NOT NULL
);
GO

-- Creating table 'AssetInstances'
CREATE TABLE [dbo].[AssetInstances] (
    [AssetInstanceId] int IDENTITY(1,1) NOT NULL,
    [BookCost] decimal(18,0)  NOT NULL,
    [MarketPrice] decimal(18,0)  NOT NULL,
    [Asset_AssetId] int  NOT NULL,
    [Account_AccountId] int  NULL
);
GO

-- Creating table 'Portfolios'
CREATE TABLE [dbo].[Portfolios] (
    [PortfolioId] int IDENTITY(1,1) NOT NULL,
    [BalanceBook_BalanceBookId] int  NOT NULL
);
GO

-- Creating table 'Accounts'
CREATE TABLE [dbo].[Accounts] (
    [AccountId] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NULL,
    [Currency] nvarchar(max)  NULL,
    [Portfolio_PortfolioId] int  NOT NULL,
    [BalanceBook_BalanceBookId] int  NOT NULL
);
GO

-- Creating table 'BalanceBooks'
CREATE TABLE [dbo].[BalanceBooks] (
    [BalanceBookId] int IDENTITY(1,1) NOT NULL,
    [CashBalance] decimal(18,0)  NOT NULL,
    [AssetsBookCost] decimal(18,0)  NOT NULL,
    [AssetsMarketPrice] decimal(18,0)  NOT NULL,
    [Yield] decimal(18,0)  NOT NULL,
    [YieldPercent] decimal(18,0)  NOT NULL,
    [Return] decimal(18,0)  NOT NULL,
    [ReturnPercent] decimal(18,0)  NOT NULL
);
GO

-- Creating table 'CashTransactions'
CREATE TABLE [dbo].[CashTransactions] (
    [CashTransactionId] int IDENTITY(1,1) NOT NULL,
    [TransactionDate] datetime  NOT NULL,
    [SettlementDate] datetime  NULL,
    [Description] nvarchar(max)  NULL,
    [Comment] nvarchar(max)  NULL,
    [Amount] decimal(18,0)  NOT NULL,
    [IsImported] bit  NOT NULL,
    [Account_AccountId] int  NOT NULL,
    [AssetTransaction_AssetTransactionId] int  NULL
);
GO

-- Creating table 'AssetTransactions'
CREATE TABLE [dbo].[AssetTransactions] (
    [AssetTransactionId] int IDENTITY(1,1) NOT NULL,
    [TransactionType] int  NOT NULL,
    [TransactionDate] datetime  NOT NULL,
    [SettlementDate] datetime  NULL,
    [TickerSymbol] nvarchar(max)  NOT NULL,
    [AssetName] nvarchar(max)  NULL,
    [Description] nvarchar(max)  NULL,
    [Comment] nvarchar(max)  NULL,
    [Price] decimal(18,0)  NOT NULL,
    [Quantity] decimal(18,0)  NOT NULL,
    [Commission] decimal(18,0)  NOT NULL,
    [Amount] decimal(18,0)  NOT NULL,
    [IsImported] bit  NOT NULL,
    [Account_AccountId] int  NOT NULL,
    [AssetInstance_AssetInstanceId] int  NULL
);
GO

-- Creating table 'BalanceBooks_PortfolioBalanceBook'
CREATE TABLE [dbo].[BalanceBooks_PortfolioBalanceBook] (
    [BalanceBookId] int  NOT NULL
);
GO

-- Creating table 'BalanceBooks_AccountBalanceBook'
CREATE TABLE [dbo].[BalanceBooks_AccountBalanceBook] (
    [BalanceBookId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [AssetId] in table 'Assets'
ALTER TABLE [dbo].[Assets]
ADD CONSTRAINT [PK_Assets]
    PRIMARY KEY CLUSTERED ([AssetId] ASC);
GO

-- Creating primary key on [AssetInstanceId] in table 'AssetInstances'
ALTER TABLE [dbo].[AssetInstances]
ADD CONSTRAINT [PK_AssetInstances]
    PRIMARY KEY CLUSTERED ([AssetInstanceId] ASC);
GO

-- Creating primary key on [PortfolioId] in table 'Portfolios'
ALTER TABLE [dbo].[Portfolios]
ADD CONSTRAINT [PK_Portfolios]
    PRIMARY KEY CLUSTERED ([PortfolioId] ASC);
GO

-- Creating primary key on [AccountId] in table 'Accounts'
ALTER TABLE [dbo].[Accounts]
ADD CONSTRAINT [PK_Accounts]
    PRIMARY KEY CLUSTERED ([AccountId] ASC);
GO

-- Creating primary key on [BalanceBookId] in table 'BalanceBooks'
ALTER TABLE [dbo].[BalanceBooks]
ADD CONSTRAINT [PK_BalanceBooks]
    PRIMARY KEY CLUSTERED ([BalanceBookId] ASC);
GO

-- Creating primary key on [CashTransactionId] in table 'CashTransactions'
ALTER TABLE [dbo].[CashTransactions]
ADD CONSTRAINT [PK_CashTransactions]
    PRIMARY KEY CLUSTERED ([CashTransactionId] ASC);
GO

-- Creating primary key on [AssetTransactionId] in table 'AssetTransactions'
ALTER TABLE [dbo].[AssetTransactions]
ADD CONSTRAINT [PK_AssetTransactions]
    PRIMARY KEY CLUSTERED ([AssetTransactionId] ASC);
GO

-- Creating primary key on [BalanceBookId] in table 'BalanceBooks_PortfolioBalanceBook'
ALTER TABLE [dbo].[BalanceBooks_PortfolioBalanceBook]
ADD CONSTRAINT [PK_BalanceBooks_PortfolioBalanceBook]
    PRIMARY KEY CLUSTERED ([BalanceBookId] ASC);
GO

-- Creating primary key on [BalanceBookId] in table 'BalanceBooks_AccountBalanceBook'
ALTER TABLE [dbo].[BalanceBooks_AccountBalanceBook]
ADD CONSTRAINT [PK_BalanceBooks_AccountBalanceBook]
    PRIMARY KEY CLUSTERED ([BalanceBookId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Account_AccountId] in table 'CashTransactions'
ALTER TABLE [dbo].[CashTransactions]
ADD CONSTRAINT [FK_AccountCashTransaction]
    FOREIGN KEY ([Account_AccountId])
    REFERENCES [dbo].[Accounts]
        ([AccountId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AccountCashTransaction'
CREATE INDEX [IX_FK_AccountCashTransaction]
ON [dbo].[CashTransactions]
    ([Account_AccountId]);
GO

-- Creating foreign key on [Portfolio_PortfolioId] in table 'Accounts'
ALTER TABLE [dbo].[Accounts]
ADD CONSTRAINT [FK_PortfolioAccount]
    FOREIGN KEY ([Portfolio_PortfolioId])
    REFERENCES [dbo].[Portfolios]
        ([PortfolioId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PortfolioAccount'
CREATE INDEX [IX_FK_PortfolioAccount]
ON [dbo].[Accounts]
    ([Portfolio_PortfolioId]);
GO

-- Creating foreign key on [Account_AccountId] in table 'AssetTransactions'
ALTER TABLE [dbo].[AssetTransactions]
ADD CONSTRAINT [FK_AccountAssetTransaction]
    FOREIGN KEY ([Account_AccountId])
    REFERENCES [dbo].[Accounts]
        ([AccountId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AccountAssetTransaction'
CREATE INDEX [IX_FK_AccountAssetTransaction]
ON [dbo].[AssetTransactions]
    ([Account_AccountId]);
GO

-- Creating foreign key on [Asset_AssetId] in table 'AssetInstances'
ALTER TABLE [dbo].[AssetInstances]
ADD CONSTRAINT [FK_AssetAssetInstance]
    FOREIGN KEY ([Asset_AssetId])
    REFERENCES [dbo].[Assets]
        ([AssetId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AssetAssetInstance'
CREATE INDEX [IX_FK_AssetAssetInstance]
ON [dbo].[AssetInstances]
    ([Asset_AssetId]);
GO

-- Creating foreign key on [Account_AccountId] in table 'AssetInstances'
ALTER TABLE [dbo].[AssetInstances]
ADD CONSTRAINT [FK_AccountAssetInstance]
    FOREIGN KEY ([Account_AccountId])
    REFERENCES [dbo].[Accounts]
        ([AccountId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AccountAssetInstance'
CREATE INDEX [IX_FK_AccountAssetInstance]
ON [dbo].[AssetInstances]
    ([Account_AccountId]);
GO

-- Creating foreign key on [AssetInstance_AssetInstanceId] in table 'AssetTransactions'
ALTER TABLE [dbo].[AssetTransactions]
ADD CONSTRAINT [FK_AssetInstanceAssetTransaction]
    FOREIGN KEY ([AssetInstance_AssetInstanceId])
    REFERENCES [dbo].[AssetInstances]
        ([AssetInstanceId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AssetInstanceAssetTransaction'
CREATE INDEX [IX_FK_AssetInstanceAssetTransaction]
ON [dbo].[AssetTransactions]
    ([AssetInstance_AssetInstanceId]);
GO

-- Creating foreign key on [AssetTransaction_AssetTransactionId] in table 'CashTransactions'
ALTER TABLE [dbo].[CashTransactions]
ADD CONSTRAINT [FK_AssetTransactionCashTransaction]
    FOREIGN KEY ([AssetTransaction_AssetTransactionId])
    REFERENCES [dbo].[AssetTransactions]
        ([AssetTransactionId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AssetTransactionCashTransaction'
CREATE INDEX [IX_FK_AssetTransactionCashTransaction]
ON [dbo].[CashTransactions]
    ([AssetTransaction_AssetTransactionId]);
GO

-- Creating foreign key on [BalanceBook_BalanceBookId] in table 'Portfolios'
ALTER TABLE [dbo].[Portfolios]
ADD CONSTRAINT [FK_PortfolioPortfolioBalanceBook]
    FOREIGN KEY ([BalanceBook_BalanceBookId])
    REFERENCES [dbo].[BalanceBooks_PortfolioBalanceBook]
        ([BalanceBookId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PortfolioPortfolioBalanceBook'
CREATE INDEX [IX_FK_PortfolioPortfolioBalanceBook]
ON [dbo].[Portfolios]
    ([BalanceBook_BalanceBookId]);
GO

-- Creating foreign key on [BalanceBook_BalanceBookId] in table 'Accounts'
ALTER TABLE [dbo].[Accounts]
ADD CONSTRAINT [FK_AccountAccountBalanceBook]
    FOREIGN KEY ([BalanceBook_BalanceBookId])
    REFERENCES [dbo].[BalanceBooks_AccountBalanceBook]
        ([BalanceBookId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AccountAccountBalanceBook'
CREATE INDEX [IX_FK_AccountAccountBalanceBook]
ON [dbo].[Accounts]
    ([BalanceBook_BalanceBookId]);
GO

-- Creating foreign key on [BalanceBookId] in table 'BalanceBooks_PortfolioBalanceBook'
ALTER TABLE [dbo].[BalanceBooks_PortfolioBalanceBook]
ADD CONSTRAINT [FK_PortfolioBalanceBook_inherits_BalanceBook]
    FOREIGN KEY ([BalanceBookId])
    REFERENCES [dbo].[BalanceBooks]
        ([BalanceBookId])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [BalanceBookId] in table 'BalanceBooks_AccountBalanceBook'
ALTER TABLE [dbo].[BalanceBooks_AccountBalanceBook]
ADD CONSTRAINT [FK_AccountBalanceBook_inherits_BalanceBook]
    FOREIGN KEY ([BalanceBookId])
    REFERENCES [dbo].[BalanceBooks]
        ([BalanceBookId])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------