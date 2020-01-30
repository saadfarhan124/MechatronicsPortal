
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 01/01/2020 14:34:49
-- Generated from EDMX file: D:\MechatronicsPortal\MechatronicsPortal\Models\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [MechaAlumni];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Alumni_EmployeeInformation]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EmployeeInformation] DROP CONSTRAINT [FK_Alumni_EmployeeInformation];
GO
IF OBJECT_ID(N'[dbo].[FK_Alumni_Users]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PersonalInformation] DROP CONSTRAINT [FK_Alumni_Users];
GO
IF OBJECT_ID(N'[dbo].[FK_Alumni_Users_Educational]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EducationalInformation] DROP CONSTRAINT [FK_Alumni_Users_Educational];
GO
IF OBJECT_ID(N'[dbo].[FK_Professuianl_Alumni_Users]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProfessionalDetails] DROP CONSTRAINT [FK_Professuianl_Alumni_Users];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[AlumniUsersAuthenticate]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AlumniUsersAuthenticate];
GO
IF OBJECT_ID(N'[dbo].[EducationalInformation]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EducationalInformation];
GO
IF OBJECT_ID(N'[dbo].[EmployeeInformation]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EmployeeInformation];
GO
IF OBJECT_ID(N'[dbo].[PersonalInformation]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PersonalInformation];
GO
IF OBJECT_ID(N'[dbo].[ProfessionalDetails]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProfessionalDetails];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'AlumniUsersAuthenticates'
CREATE TABLE [dbo].[AlumniUsersAuthenticates] (
    [alumni_id] int  NOT NULL,
    [alumni_username] int  NULL,
    [almuni_password] varchar(50)  NULL
);
GO

-- Creating table 'EducationalInformations'
CREATE TABLE [dbo].[EducationalInformations] (
    [Id] int  NOT NULL,
    [latest_qualification] varchar(50)  NOT NULL,
    [degree_title] varchar(50)  NOT NULL,
    [institute] varchar(50)  NOT NULL,
    [year_of_completion] varchar(50)  NOT NULL,
    [majors] varchar(50)  NOT NULL,
    [alumni_id] int  NOT NULL
);
GO

-- Creating table 'PersonalInformations'
CREATE TABLE [dbo].[PersonalInformations] (
    [full_name] varchar(50)  NOT NULL,
    [department] varchar(50)  NOT NULL,
    [reg_number] int  NOT NULL,
    [email] varchar(50)  NOT NULL,
    [contact_number] varchar(50)  NOT NULL,
    [pec_registration] varchar(50)  NULL,
    [id] int IDENTITY(1,1) NOT NULL,
    [alumni_id] int  NOT NULL
);
GO

-- Creating table 'ProfessionalDetails'
CREATE TABLE [dbo].[ProfessionalDetails] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [alumni_id] int  NOT NULL,
    [job_title] varchar(50)  NOT NULL,
    [company_name] varchar(50)  NOT NULL,
    [department] varchar(50)  NOT NULL,
    [work_location] varchar(50)  NOT NULL,
    [work_contact] varchar(50)  NOT NULL,
    [email] varchar(50)  NOT NULL,
    [start_date] varchar(50)  NOT NULL,
    [supervisor_name] varchar(50)  NOT NULL,
    [supervisor_email] varchar(50)  NOT NULL,
    [supervisor_contact] varchar(50)  NOT NULL
);
GO

-- Creating table 'EmployeeInformations'
CREATE TABLE [dbo].[EmployeeInformations] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [alumni_id] int  NOT NULL,
    [company_name] varchar(50)  NOT NULL,
    [address] varchar(50)  NOT NULL,
    [name] varchar(50)  NOT NULL,
    [designation] varchar(50)  NOT NULL,
    [industry] varchar(50)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [alumni_id] in table 'AlumniUsersAuthenticates'
ALTER TABLE [dbo].[AlumniUsersAuthenticates]
ADD CONSTRAINT [PK_AlumniUsersAuthenticates]
    PRIMARY KEY CLUSTERED ([alumni_id] ASC);
GO

-- Creating primary key on [Id] in table 'EducationalInformations'
ALTER TABLE [dbo].[EducationalInformations]
ADD CONSTRAINT [PK_EducationalInformations]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [id] in table 'PersonalInformations'
ALTER TABLE [dbo].[PersonalInformations]
ADD CONSTRAINT [PK_PersonalInformations]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [Id] in table 'ProfessionalDetails'
ALTER TABLE [dbo].[ProfessionalDetails]
ADD CONSTRAINT [PK_ProfessionalDetails]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'EmployeeInformations'
ALTER TABLE [dbo].[EmployeeInformations]
ADD CONSTRAINT [PK_EmployeeInformations]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [alumni_id] in table 'PersonalInformations'
ALTER TABLE [dbo].[PersonalInformations]
ADD CONSTRAINT [FK_Alumni_Users]
    FOREIGN KEY ([alumni_id])
    REFERENCES [dbo].[AlumniUsersAuthenticates]
        ([alumni_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Alumni_Users'
CREATE INDEX [IX_FK_Alumni_Users]
ON [dbo].[PersonalInformations]
    ([alumni_id]);
GO

-- Creating foreign key on [alumni_id] in table 'EducationalInformations'
ALTER TABLE [dbo].[EducationalInformations]
ADD CONSTRAINT [FK_Alumni_Users_Educational]
    FOREIGN KEY ([alumni_id])
    REFERENCES [dbo].[AlumniUsersAuthenticates]
        ([alumni_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Alumni_Users_Educational'
CREATE INDEX [IX_FK_Alumni_Users_Educational]
ON [dbo].[EducationalInformations]
    ([alumni_id]);
GO

-- Creating foreign key on [alumni_id] in table 'ProfessionalDetails'
ALTER TABLE [dbo].[ProfessionalDetails]
ADD CONSTRAINT [FK_Professuianl_Alumni_Users]
    FOREIGN KEY ([alumni_id])
    REFERENCES [dbo].[AlumniUsersAuthenticates]
        ([alumni_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Professuianl_Alumni_Users'
CREATE INDEX [IX_FK_Professuianl_Alumni_Users]
ON [dbo].[ProfessionalDetails]
    ([alumni_id]);
GO

-- Creating foreign key on [alumni_id] in table 'EmployeeInformations'
ALTER TABLE [dbo].[EmployeeInformations]
ADD CONSTRAINT [FK_Alumni_EmployeeInformation]
    FOREIGN KEY ([alumni_id])
    REFERENCES [dbo].[AlumniUsersAuthenticates]
        ([alumni_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Alumni_EmployeeInformation'
CREATE INDEX [IX_FK_Alumni_EmployeeInformation]
ON [dbo].[EmployeeInformations]
    ([alumni_id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------