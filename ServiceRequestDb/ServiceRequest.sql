CREATE TABLE [dbo].[ServiceRequest]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [BuildingCode] NVARCHAR(50) NOT NULL, 
    [Description] NVARCHAR(MAX) NOT NULL, 
    [CreatedDate] DATETIME NOT NULL, 
    [LastModifiedDate] DATETIME NULL, 
    [CreatedBy] NVARCHAR(50) NOT NULL, 
    [LastModifiedBy] NVARCHAR(50) NULL, 
    [CurrentStatus] NVARCHAR(50) NOT NULL, 
    [UserEmail] NVARCHAR(100) NOT NULL, 
    [Sevierity] NVARCHAR(50) NOT NULL
)
