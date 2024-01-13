USE [master]
GO
/****** Object:  Database [Smart_School]    Script Date: 1/2/2024 1:33:39 PM ******/
CREATE DATABASE [Smart_School]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Smart_School', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER01\MSSQL\DATA\Smart_School.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Smart_School_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER01\MSSQL\DATA\Smart_School_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [Smart_School] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Smart_School].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Smart_School] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Smart_School] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Smart_School] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Smart_School] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Smart_School] SET ARITHABORT OFF 
GO
ALTER DATABASE [Smart_School] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Smart_School] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Smart_School] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Smart_School] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Smart_School] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Smart_School] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Smart_School] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Smart_School] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Smart_School] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Smart_School] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Smart_School] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Smart_School] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Smart_School] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Smart_School] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Smart_School] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Smart_School] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Smart_School] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Smart_School] SET RECOVERY FULL 
GO
ALTER DATABASE [Smart_School] SET  MULTI_USER 
GO
ALTER DATABASE [Smart_School] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Smart_School] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Smart_School] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Smart_School] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Smart_School] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Smart_School] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Smart_School', N'ON'
GO
ALTER DATABASE [Smart_School] SET QUERY_STORE = ON
GO
ALTER DATABASE [Smart_School] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [Smart_School]
GO
/****** Object:  Table [dbo].[Smart_Class]    Script Date: 1/2/2024 1:33:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Smart_Class](
	[Smart_Class_Id] [int] IDENTITY(1,1) NOT NULL,
	[Smart_Class_Name] [nvarchar](200) NULL,
	[Smart_Class_Location] [nvarchar](50) NULL,
 CONSTRAINT [PK_Smart_Class] PRIMARY KEY CLUSTERED 
(
	[Smart_Class_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Smart_ClassSubjects]    Script Date: 1/2/2024 1:33:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Smart_ClassSubjects](
	[Smart_Class_Id] [int] NOT NULL,
	[Smart_Subject_id] [int] NOT NULL,
 CONSTRAINT [PK_Smart_ClassSubjects] PRIMARY KEY CLUSTERED 
(
	[Smart_Class_Id] ASC,
	[Smart_Subject_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Smart_Student]    Script Date: 1/2/2024 1:33:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Smart_Student](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
	[FatherName] [nvarchar](100) NULL,
	[DOB] [date] NULL,
	[Gender] [nvarchar](50) NULL,
	[ContactNo] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Class_Id] [int] NULL,
 CONSTRAINT [PK_Smart_Student] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Smart_Subject]    Script Date: 1/2/2024 1:33:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Smart_Subject](
	[Smart_Subject_Id] [int] IDENTITY(1,1) NOT NULL,
	[Smart_Subject_Name] [nvarchar](200) NULL,
	[Smart_Subject_Book] [nvarchar](50) NULL,
	[Smart_Subject_Teacher_Id] [int] NULL,
 CONSTRAINT [PK_Smart_Subject] PRIMARY KEY CLUSTERED 
(
	[Smart_Subject_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Smart_Teacher]    Script Date: 1/2/2024 1:33:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Smart_Teacher](
	[Smart_Teacher_Id] [int] IDENTITY(1,1) NOT NULL,
	[Smart_Teacher_Name] [nvarchar](200) NULL,
	[Smart_Teacher_Qualification] [nvarchar](50) NULL,
	[Smart_Teacher_Email] [nvarchar](50) NULL,
	[Smart_Teacher_ContactNo] [nvarchar](50) NULL,
 CONSTRAINT [PK_Smart_Teacher] PRIMARY KEY CLUSTERED 
(
	[Smart_Teacher_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Smart_ClassSubjects]  WITH CHECK ADD  CONSTRAINT [FK_Smart_ClassSubjects_Smart_Class] FOREIGN KEY([Smart_Class_Id])
REFERENCES [dbo].[Smart_Class] ([Smart_Class_Id])
GO
ALTER TABLE [dbo].[Smart_ClassSubjects] CHECK CONSTRAINT [FK_Smart_ClassSubjects_Smart_Class]
GO
ALTER TABLE [dbo].[Smart_ClassSubjects]  WITH CHECK ADD  CONSTRAINT [FK_Smart_ClassSubjects_Smart_Subject] FOREIGN KEY([Smart_Subject_id])
REFERENCES [dbo].[Smart_Subject] ([Smart_Subject_Id])
GO
ALTER TABLE [dbo].[Smart_ClassSubjects] CHECK CONSTRAINT [FK_Smart_ClassSubjects_Smart_Subject]
GO
ALTER TABLE [dbo].[Smart_Student]  WITH CHECK ADD  CONSTRAINT [FK_Smart_Student_Smart_Class] FOREIGN KEY([Class_Id])
REFERENCES [dbo].[Smart_Class] ([Smart_Class_Id])
GO
ALTER TABLE [dbo].[Smart_Student] CHECK CONSTRAINT [FK_Smart_Student_Smart_Class]
GO
ALTER TABLE [dbo].[Smart_Subject]  WITH CHECK ADD  CONSTRAINT [FK_Smart_Subject_Smart_Teacher] FOREIGN KEY([Smart_Subject_Teacher_Id])
REFERENCES [dbo].[Smart_Teacher] ([Smart_Teacher_Id])
GO
ALTER TABLE [dbo].[Smart_Subject] CHECK CONSTRAINT [FK_Smart_Subject_Smart_Teacher]
GO
USE [master]
GO
ALTER DATABASE [Smart_School] SET  READ_WRITE 
GO
