
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 09/17/2018 15:47:48
-- Generated from EDMX file: C:\Users\Thomas Diethelm\source\repos\WPFTestAppRessourcen\WPFTestAppRessourcen\RPModell.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [TestDatabase];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_PersonZuweisung]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Zuweisungen] DROP CONSTRAINT [FK_PersonZuweisung];
GO
IF OBJECT_ID(N'[dbo].[FK_AuftragZuweisung]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Zuweisungen] DROP CONSTRAINT [FK_AuftragZuweisung];
GO
IF OBJECT_ID(N'[dbo].[FK_AuftragskategorieAuftrag]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Aufträge] DROP CONSTRAINT [FK_AuftragskategorieAuftrag];
GO
IF OBJECT_ID(N'[dbo].[FK_ZuweisungskategorieZuweisung]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Zuweisungen] DROP CONSTRAINT [FK_ZuweisungskategorieZuweisung];
GO
IF OBJECT_ID(N'[dbo].[FK_TeamPerson]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Personen] DROP CONSTRAINT [FK_TeamPerson];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Personen]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Personen];
GO
IF OBJECT_ID(N'[dbo].[Aufträge]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Aufträge];
GO
IF OBJECT_ID(N'[dbo].[Zuweisungen]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Zuweisungen];
GO
IF OBJECT_ID(N'[dbo].[Auftragskategorien]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Auftragskategorien];
GO
IF OBJECT_ID(N'[dbo].[Zuweisungskategorien]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Zuweisungskategorien];
GO
IF OBJECT_ID(N'[dbo].[Teams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Teams];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Personen'
CREATE TABLE [dbo].[Personen] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Vorname] nvarchar(max)  NOT NULL,
    [Kürzel] nvarchar(max)  NOT NULL,
    [Team_Id] int  NOT NULL
);
GO

-- Creating table 'Aufträge'
CREATE TABLE [dbo].[Aufträge] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Bezeichnung] nvarchar(max)  NOT NULL,
    [Stunden] int  NOT NULL,
    [Beginn] datetime  NOT NULL,
    [Status] smallint  NOT NULL,
    [Auftragskategorie_Id] int  NOT NULL
);
GO

-- Creating table 'Zuweisungen'
CREATE TABLE [dbo].[Zuweisungen] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Stunden] int  NOT NULL,
    [Von] datetime  NOT NULL,
    [Bis] datetime  NOT NULL,
    [Person_Id] int  NOT NULL,
    [Auftrag_Id] int  NOT NULL,
    [Zuweisungskategorie_Id] int  NOT NULL
);
GO

-- Creating table 'Auftragskategorien'
CREATE TABLE [dbo].[Auftragskategorien] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Bezeichnung] nvarchar(max)  NOT NULL,
    [Kürzel] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Zuweisungskategorien'
CREATE TABLE [dbo].[Zuweisungskategorien] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Bezeichnung] nvarchar(max)  NOT NULL,
    [Kürzel] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Teams'
CREATE TABLE [dbo].[Teams] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Bezeichnung] nvarchar(max)  NOT NULL,
    [Kürzel] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Personen'
ALTER TABLE [dbo].[Personen]
ADD CONSTRAINT [PK_Personen]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Aufträge'
ALTER TABLE [dbo].[Aufträge]
ADD CONSTRAINT [PK_Aufträge]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Zuweisungen'
ALTER TABLE [dbo].[Zuweisungen]
ADD CONSTRAINT [PK_Zuweisungen]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Auftragskategorien'
ALTER TABLE [dbo].[Auftragskategorien]
ADD CONSTRAINT [PK_Auftragskategorien]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Zuweisungskategorien'
ALTER TABLE [dbo].[Zuweisungskategorien]
ADD CONSTRAINT [PK_Zuweisungskategorien]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Teams'
ALTER TABLE [dbo].[Teams]
ADD CONSTRAINT [PK_Teams]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Person_Id] in table 'Zuweisungen'
ALTER TABLE [dbo].[Zuweisungen]
ADD CONSTRAINT [FK_PersonZuweisung]
    FOREIGN KEY ([Person_Id])
    REFERENCES [dbo].[Personen]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonZuweisung'
CREATE INDEX [IX_FK_PersonZuweisung]
ON [dbo].[Zuweisungen]
    ([Person_Id]);
GO

-- Creating foreign key on [Auftrag_Id] in table 'Zuweisungen'
ALTER TABLE [dbo].[Zuweisungen]
ADD CONSTRAINT [FK_AuftragZuweisung]
    FOREIGN KEY ([Auftrag_Id])
    REFERENCES [dbo].[Aufträge]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AuftragZuweisung'
CREATE INDEX [IX_FK_AuftragZuweisung]
ON [dbo].[Zuweisungen]
    ([Auftrag_Id]);
GO

-- Creating foreign key on [Auftragskategorie_Id] in table 'Aufträge'
ALTER TABLE [dbo].[Aufträge]
ADD CONSTRAINT [FK_AuftragskategorieAuftrag]
    FOREIGN KEY ([Auftragskategorie_Id])
    REFERENCES [dbo].[Auftragskategorien]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AuftragskategorieAuftrag'
CREATE INDEX [IX_FK_AuftragskategorieAuftrag]
ON [dbo].[Aufträge]
    ([Auftragskategorie_Id]);
GO

-- Creating foreign key on [Zuweisungskategorie_Id] in table 'Zuweisungen'
ALTER TABLE [dbo].[Zuweisungen]
ADD CONSTRAINT [FK_ZuweisungskategorieZuweisung]
    FOREIGN KEY ([Zuweisungskategorie_Id])
    REFERENCES [dbo].[Zuweisungskategorien]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ZuweisungskategorieZuweisung'
CREATE INDEX [IX_FK_ZuweisungskategorieZuweisung]
ON [dbo].[Zuweisungen]
    ([Zuweisungskategorie_Id]);
GO

-- Creating foreign key on [Team_Id] in table 'Personen'
ALTER TABLE [dbo].[Personen]
ADD CONSTRAINT [FK_TeamPerson]
    FOREIGN KEY ([Team_Id])
    REFERENCES [dbo].[Teams]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TeamPerson'
CREATE INDEX [IX_FK_TeamPerson]
ON [dbo].[Personen]
    ([Team_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------