USE [master]
GO
/****** Object:  Database [CrudOpDB]    Script Date: 13/12/2022 17:04:07 ******/
CREATE DATABASE [CrudOpDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CrudOpDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\CrudOpDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CrudOpDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\CrudOpDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CrudOpDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CrudOpDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CrudOpDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CrudOpDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CrudOpDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CrudOpDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [CrudOpDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CrudOpDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CrudOpDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CrudOpDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CrudOpDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CrudOpDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CrudOpDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CrudOpDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CrudOpDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CrudOpDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [CrudOpDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CrudOpDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CrudOpDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CrudOpDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CrudOpDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CrudOpDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CrudOpDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CrudOpDB] SET RECOVERY FULL 
GO
ALTER DATABASE [CrudOpDB] SET  MULTI_USER 
GO
ALTER DATABASE [CrudOpDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CrudOpDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CrudOpDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CrudOpDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CrudOpDB] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'CrudOpDB', N'ON'
GO
USE [CrudOpDB]
GO
/****** Object:  Table [dbo].[tbl_Contacts]    Script Date: 13/12/2022 17:04:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Contacts](
	[ContactID] [int] IDENTITY(1,1) NOT NULL,
	[ProfessionID] [int] NOT NULL,
	[fName] [nvarchar](50) NOT NULL,
	[lName] [nvarchar](50) NULL,
	[emailAddr] [nvarchar](max) NOT NULL,
	[Company] [nvarchar](100) NOT NULL,
	[Category] [tinyint] NOT NULL,
 CONSTRAINT [PK_tbl_Contacts] PRIMARY KEY CLUSTERED 
(
	[ContactID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Profession]    Script Date: 13/12/2022 17:04:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Profession](
	[ProfessionID] [int] IDENTITY(1,1) NOT NULL,
	[Profession] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](200) NULL,
 CONSTRAINT [PK_tbl_Profession] PRIMARY KEY CLUSTERED 
(
	[ProfessionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tbl_Contacts] ON 

INSERT [dbo].[tbl_Contacts] ([ContactID], [ProfessionID], [fName], [lName], [emailAddr], [Company], [Category]) VALUES (1, 1, N'Diljeet', NULL, N'diljeet@antheminfotech.com', N'antheminfotech', 2)
INSERT [dbo].[tbl_Contacts] ([ContactID], [ProfessionID], [fName], [lName], [emailAddr], [Company], [Category]) VALUES (3, 2, N'Sachin', N'Chahal', N'sachin@s.com', N'antheminfotech', 2)
INSERT [dbo].[tbl_Contacts] ([ContactID], [ProfessionID], [fName], [lName], [emailAddr], [Company], [Category]) VALUES (6, 1, N'Dev', N'Kumar', N'dev@d.com', N'ABCABC', 1)
INSERT [dbo].[tbl_Contacts] ([ContactID], [ProfessionID], [fName], [lName], [emailAddr], [Company], [Category]) VALUES (7, 4, N'Testing', N'Users', N'Testing@t.com', N'XYZXYZ', 2)
INSERT [dbo].[tbl_Contacts] ([ContactID], [ProfessionID], [fName], [lName], [emailAddr], [Company], [Category]) VALUES (13, 1, N'First', N'Last', N'First@First.com', N'First Company', 1)
SET IDENTITY_INSERT [dbo].[tbl_Contacts] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_Profession] ON 

INSERT [dbo].[tbl_Profession] ([ProfessionID], [Profession], [Description]) VALUES (1, N'Manager', N'Manage all role')
INSERT [dbo].[tbl_Profession] ([ProfessionID], [Profession], [Description]) VALUES (2, N'Jr. Developer', NULL)
INSERT [dbo].[tbl_Profession] ([ProfessionID], [Profession], [Description]) VALUES (3, N'Senior Developer', NULL)
INSERT [dbo].[tbl_Profession] ([ProfessionID], [Profession], [Description]) VALUES (4, N'Cleaning Staff', N'Cleaning all items and floor')
INSERT [dbo].[tbl_Profession] ([ProfessionID], [Profession], [Description]) VALUES (5, N'Account Staff', NULL)
INSERT [dbo].[tbl_Profession] ([ProfessionID], [Profession], [Description]) VALUES (11, N'Bottle Cleaner', N'To clean bottle')
INSERT [dbo].[tbl_Profession] ([ProfessionID], [Profession], [Description]) VALUES (12, N'System Operator', N'Required to test all system are working properly')
INSERT [dbo].[tbl_Profession] ([ProfessionID], [Profession], [Description]) VALUES (13, N'asdgcx', N'eds')
INSERT [dbo].[tbl_Profession] ([ProfessionID], [Profession], [Description]) VALUES (14, N'System Operator XYZ', N'xyz need to operate')
SET IDENTITY_INSERT [dbo].[tbl_Profession] OFF
GO
ALTER TABLE [dbo].[tbl_Contacts]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Contacts_tbl_Profession] FOREIGN KEY([ProfessionID])
REFERENCES [dbo].[tbl_Profession] ([ProfessionID])
GO
ALTER TABLE [dbo].[tbl_Contacts] CHECK CONSTRAINT [FK_tbl_Contacts_tbl_Profession]
GO
/****** Object:  StoredProcedure [dbo].[AddContact]    Script Date: 13/12/2022 17:04:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[AddContact]
@ProfessionID int
           ,@fName nvarchar(30)
           ,@lName nvarchar(30)
           ,@emailAddr nvarchar(max)
           ,@Company nvarchar(50)
           ,@Category tinyint
as
begin
INSERT INTO [dbo].[tbl_Contacts]
           ([ProfessionID]
           ,[fName]
           ,[lName]
           ,[emailAddr]
           ,[Company]
           ,[Category])
     VALUES(@ProfessionID,@fName,@lName,@emailAddr,@Company,@Category)
end
GO
/****** Object:  StoredProcedure [dbo].[AddNewProfession]    Script Date: 13/12/2022 17:04:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[AddNewProfession]  
(   
   @Profession nvarchar (50),  
   @Description nvarchar (200)  
)  
as  
begin  
   Insert into tbl_Profession values(@Profession,@Description)  
End 
GO
/****** Object:  StoredProcedure [dbo].[DeleteProf_Contact]    Script Date: 13/12/2022 17:04:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[DeleteProf_Contact]
@ProfessionID int
as
Begin
	Begin Try
		Begin Tran

		-- Delete First from Child table
		DELETE FROM [dbo].[tbl_Contacts] WHERE ProfessionID = @ProfessionID

		-- Finally Delete from parent table
		DELETE FROM [dbo].[tbl_Profession] WHERE ProfessionID = @ProfessionID

		Commit Tran
	End Try
	Begin Catch
		Rollback Tran
	End Catch
End


GO
/****** Object:  StoredProcedure [dbo].[GetAllContact]    Script Date: 13/12/2022 17:04:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GetAllContact]
@Category int
as
begin
SELECT [ContactID]
      ,[Profession]
      ,concat([fName] , [lName]) as [Name]
      ,[emailAddr]
      ,[Company]
      ,(case when [Category] = 1
             then 'Client'
             when [Category] = 2
             then 'Vendor'
             else ''
        end) AS [Category]
  FROM [CrudOpDB].[dbo].[tbl_Contacts]
  join [CrudOpDB].[dbo].[tbl_Profession]
  on [tbl_Contacts].ProfessionID = [tbl_Profession].ProfessionID
  where ([Category] = @Category or @Category = 0 )
end
GO
/****** Object:  StoredProcedure [dbo].[GetAllProfessions]    Script Date: 13/12/2022 17:04:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[GetAllProfessions]  
as  
begin  
   select ROW_NUMBER() OVER (order by [ProfessionID] desc) SerialNo, [ProfessionID], [Profession], [Description] from tbl_Profession
End 
GO
/****** Object:  StoredProcedure [dbo].[GetContact]    Script Date: 13/12/2022 17:04:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[GetContact]
@ContactID int
as
begin
SELECT [ContactID]
      ,[ProfessionID]
      ,[fName]
	  ,[lName]
      ,[emailAddr]
      ,[Company]
      ,[Category]
  FROM [CrudOpDB].[dbo].[tbl_Contacts]
  where ([ContactID] = @ContactID )
end
GO
/****** Object:  StoredProcedure [dbo].[UpdateContact]    Script Date: 13/12/2022 17:04:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [dbo].[UpdateContact]
@ContactID int,
@ProfessionID int
           ,@fName nvarchar(30)
           ,@lName nvarchar(30)
           ,@emailAddr nvarchar(max)
           ,@Company nvarchar(50)
           ,@Category tinyint
as
begin
UPDATE [dbo].[tbl_Contacts]
SET [ProfessionID] = @ProfessionID
      ,[fName] = @fName
      ,[lName] = @lName
      ,[emailAddr] = @emailAddr
      ,[Company] = @Company
      ,[Category] = @Category
	  where [ContactID] = @ContactID
end
GO
/****** Object:  StoredProcedure [dbo].[UpdateProfession]    Script Date: 13/12/2022 17:04:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create proc [dbo].[UpdateProfession]
@PID int,
@Prof nvarchar(50),
@desc nvarchar(200)
as
begin

UPDATE [dbo].[tbl_Profession]
   SET [Profession] = @Prof
      ,[Description] = @desc
 WHERE ProfessionID = @PID
end


GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'0 - All,
1 - Client,
2 - Vendor
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbl_Contacts'
GO
USE [master]
GO
ALTER DATABASE [CrudOpDB] SET  READ_WRITE 
GO
