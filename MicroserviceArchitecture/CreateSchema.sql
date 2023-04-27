CREATE TABLE [dbo].[Employe]
(
 [RecId] Bigint NOT NULL,
 [Name] Nvarchar(128) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
 [Type_Enum_Id] Tinyint NULL,
 [CreatedOn] Datetime NOT NULL,
 [UpdatedOn] Datetime NULL,
 [RowVersion] Rowversion NOT NULL
)
go

-- Add keys for table dbo.Employe

ALTER TABLE [dbo].[Employe] ADD CONSTRAINT [PK_Employe] PRIMARY KEY ([RecId])
go

-- Table dbo.Department

CREATE TABLE [dbo].[Department]
(
 [RecId] Bigint NOT NULL,
 [Name] Nvarchar(128) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
 [CreatedOn] Datetime NOT NULL,
 [UpdatedOn] Datetime NULL,
 [RowVersion] Rowversion NOT NULL
)
go

-- Add keys for table dbo.Department

ALTER TABLE [dbo].[Department] ADD CONSTRAINT [PK_Department] PRIMARY KEY ([RecId])
go

CREATE TABLE [dbo].[DepartmentEmployees]
(
 [RecId] Bigint NOT NULL,
 [Department_RecId] Bigint NULL,
 [Employe_RecId] Bigint NULL,
 [CreatedOn] Datetime NOT NULL,
 [UpdatedOn] Datetime NULL,
 [RowVersion] Rowversion NOT NULL
)
go

-- Add keys for table dbo.DepartmentEmployees

ALTER TABLE [dbo].[DepartmentEmployees] ADD CONSTRAINT [PK_DepartmentEmployees] PRIMARY KEY ([RecId])
go

ALTER TABLE [dbo].[DepartmentEmployees] ADD CONSTRAINT [Department_FK1] FOREIGN KEY ([Department_RecId]) REFERENCES [dbo].[Department] ([RecId]) ON UPDATE NO ACTION ON DELETE NO ACTION
go

ALTER TABLE [dbo].[DepartmentEmployees] ADD CONSTRAINT [Employe_FK1] FOREIGN KEY ([Employe_RecId]) REFERENCES [dbo].[Employe] ([RecId]) ON UPDATE NO ACTION ON DELETE NO ACTION
go