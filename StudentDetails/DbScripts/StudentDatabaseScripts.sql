USE [master]
GO
/****** Object:  Database [StudentInformation]    Script Date: 9/17/2021 10:57:14 AM ******/
CREATE DATABASE [StudentInformation]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'StudentInformation', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\StudentInformation.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'StudentInformation_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\StudentInformation_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [StudentInformation] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [StudentInformation].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [StudentInformation] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [StudentInformation] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [StudentInformation] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [StudentInformation] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [StudentInformation] SET ARITHABORT OFF 
GO
ALTER DATABASE [StudentInformation] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [StudentInformation] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [StudentInformation] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [StudentInformation] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [StudentInformation] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [StudentInformation] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [StudentInformation] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [StudentInformation] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [StudentInformation] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [StudentInformation] SET  ENABLE_BROKER 
GO
ALTER DATABASE [StudentInformation] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [StudentInformation] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [StudentInformation] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [StudentInformation] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [StudentInformation] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [StudentInformation] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [StudentInformation] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [StudentInformation] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [StudentInformation] SET  MULTI_USER 
GO
ALTER DATABASE [StudentInformation] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [StudentInformation] SET DB_CHAINING OFF 
GO
ALTER DATABASE [StudentInformation] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [StudentInformation] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [StudentInformation] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [StudentInformation] SET QUERY_STORE = OFF
GO
USE [StudentInformation]
GO
/****** Object:  Table [dbo].[Student]    Script Date: 9/17/2021 10:57:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[FatherName] [varchar](50) NULL,
	[Age] [int] NULL,
	[City] [varchar](50) NULL,
	[ContactNumber] [bigint] NULL,
	[Email] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[CreateStudent]    Script Date: 9/17/2021 10:57:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[CreateStudent]
(
@Name varchar(50),
@Fathername varchar(50),
@Age int,
@City varchar(50),
@ContactNumber bigint,
@Email varchar(50)
)
as 
insert into Student values(@Name,@Fathername,@Age,@City,@ContactNumber,@Email)
GO
/****** Object:  StoredProcedure [dbo].[DeleteStudent]    Script Date: 9/17/2021 10:57:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[DeleteStudent]
(
@Id int
)
as
delete  Student where Id = @Id;
GO
/****** Object:  StoredProcedure [dbo].[GetAllStudents]    Script Date: 9/17/2021 10:57:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GetAllStudents]
as
select*from Student
GO
/****** Object:  StoredProcedure [dbo].[GetStudentById]    Script Date: 9/17/2021 10:57:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GetStudentById]
(
@Id int
)
as 
select * from Student where Id=@Id;
GO
/****** Object:  StoredProcedure [dbo].[UpdateStudent]    Script Date: 9/17/2021 10:57:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[UpdateStudent]
(
@Id int,
@Name varchar(50),
@Fathername varchar(50),
@Age int,
@City varchar(50),
@ContactNumber bigint,
@Email varchar(50)
)
as
update Student set Name = @Name,FatherName = @Fathername,Age= @Age,City=@City,ContactNumber= @ContactNumber,Email= @Email where Id = @Id
GO
USE [master]
GO
ALTER DATABASE [StudentInformation] SET  READ_WRITE 
GO
