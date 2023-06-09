USE [master]
GO
/****** Object:  Database [English_center]    Script Date: 4/24/2023 2:03:58 AM ******/
CREATE DATABASE [English_center]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'English_center', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\English_center.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'English_center_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\English_center_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [English_center] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [English_center].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [English_center] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [English_center] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [English_center] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [English_center] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [English_center] SET ARITHABORT OFF 
GO
ALTER DATABASE [English_center] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [English_center] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [English_center] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [English_center] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [English_center] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [English_center] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [English_center] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [English_center] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [English_center] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [English_center] SET  DISABLE_BROKER 
GO
ALTER DATABASE [English_center] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [English_center] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [English_center] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [English_center] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [English_center] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [English_center] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [English_center] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [English_center] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [English_center] SET  MULTI_USER 
GO
ALTER DATABASE [English_center] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [English_center] SET DB_CHAINING OFF 
GO
ALTER DATABASE [English_center] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [English_center] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [English_center] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [English_center] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [English_center] SET QUERY_STORE = OFF
GO
USE [English_center]
GO
/****** Object:  Table [dbo].[Classes]    Script Date: 4/24/2023 2:03:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Classes](
	[id] [varchar](255) NOT NULL,
	[CourseName] [varchar](255) NULL,
	[Status] [varchar](255) NULL,
	[Teacher_Name] [varchar](255) NULL,
 CONSTRAINT [PK_Class] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Courses]    Script Date: 4/24/2023 2:03:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Courses](
	[id] [varchar](255) NOT NULL,
	[CourseName] [varchar](255) NULL,
	[Duration] [varchar](255) NULL,
	[StartDay] [smalldatetime] NULL,
	[EndDay] [smalldatetime] NULL,
	[Description] [varchar](255) NULL,
	[Language] [varchar](255) NULL,
	[NameTeacher] [varchar](255) NULL,
	[Price] [varchar](255) NULL,
	[Level] [varchar](255) NULL,
	[Teachinghours] [varchar](255) NULL,
	[Status] [varchar](255) NULL,
 CONSTRAINT [PK_Courses] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payments]    Script Date: 4/24/2023 2:03:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payments](
	[id] [varchar](255) NOT NULL,
	[PaymentDate] [smalldatetime] NULL,
	[Paymentmethod] [varchar](255) NULL,
	[CourseName] [varchar](255) NULL,
	[Name] [varchar](255) NULL,
	[Price] [varchar](255) NULL,
	[Paymentinfo] [varchar](255) NULL,
	[DueDate] [smalldatetime] NULL,
	[Status] [varchar](255) NULL,
	[Debt] [varchar](255) NULL,
	[Paid] [varchar](255) NULL,
 CONSTRAINT [PK_Payment] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Staffs]    Script Date: 4/24/2023 2:03:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Staffs](
	[id] [varchar](255) NOT NULL,
	[Name] [varchar](255) NULL,
	[Phone] [varchar](255) NULL,
	[Dateofbirth] [smalldatetime] NULL,
	[Address] [varchar](255) NULL,
	[Sex] [varchar](255) NULL,
	[Position] [varchar](255) NULL,
	[Class_Name] [varchar](255) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Students]    Script Date: 4/24/2023 2:03:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Students](
	[id] [nvarchar](255) NOT NULL,
	[Fullname] [nvarchar](255) NULL,
	[Sex] [nchar](10) NULL,
	[dateofbirth] [smalldatetime] NULL,
	[phone] [nvarchar](255) NULL,
	[Class_Name] [nvarchar](255) NULL,
	[Address] [nvarchar](255) NULL,
 CONSTRAINT [PK_Students] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 4/24/2023 2:03:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[id] [varchar](255) NOT NULL,
	[username] [varchar](255) NOT NULL,
	[fullname] [varchar](255) NULL,
	[phone] [varchar](255) NULL,
	[dateofbirth] [date] NULL,
	[password] [varchar](255) NULL,
	[position] [varchar](255) NULL,
	[sex] [varchar](255) NULL,
	[address] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC,
	[username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [English_center] SET  READ_WRITE 
GO
