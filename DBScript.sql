CREATE DATABASE Interview
Go

USE [Interview]
GO

/****** Object:  Table [dbo].[Employee]    Script Date: 06/10/2020 12:58:51 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Employee](
	[EmployeeID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](32) NOT NULL,
	[FirstName] [nvarchar](64) NOT NULL,
	[LastName] [varchar](64) NOT NULL,
	[Gender] [varchar](1) NOT NULL,
	[DateOfBirth] [datetime] NOT NULL,
	[Email] [varchar](128) NOT NULL,
	[JobRole] [varchar](128) NOT NULL,
	[Salary] [decimal](18, 0) NOT NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[EmployeeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO