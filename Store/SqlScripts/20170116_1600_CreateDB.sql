﻿CREATE DATABASE switchDb

GO

CREATE TABLE switchDb.dbo.Switch (
  Id UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID()
 ,Name NVARCHAR(500) NULL
 ,CONSTRAINT PK_Switch_Id PRIMARY KEY CLUSTERED (Id)
 ,CONSTRAINT KEY_table1_asdf UNIQUE (Name)
)
GO

CREATE TABLE switchDb.dbo.Status (
  Id UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID()
 ,SwitchId UNIQUEIDENTIFIER NULL
 ,DateTime DATETIME2 NULL
 ,ActionSwitch INT NULL
 ,CONSTRAINT PK_Status_Id PRIMARY KEY CLUSTERED (Id)
 ,CONSTRAINT FK_Switch FOREIGN KEY (SwitchId) REFERENCES dbo.Switch (Id)
)
GO