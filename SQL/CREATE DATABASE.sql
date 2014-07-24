USE [master]
GO

/****** Object:  Database [CreditUnionCOOP]    Script Date: 07/24/2014 16:01:50 ******/
CREATE DATABASE [CreditUnionCOOP] ON  PRIMARY 
( NAME = N'CreditUnionCOOP', FILENAME = N'C:\MSSQL\DATA\CreditUnionCOOP.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'CreditUnionCOOP_log', FILENAME = N'C:\MSSQL\Data\CreditUnionCOOP_log.ldf' , SIZE = 4672KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO

ALTER DATABASE [CreditUnionCOOP] SET COMPATIBILITY_LEVEL = 100
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CreditUnionCOOP].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [CreditUnionCOOP] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [CreditUnionCOOP] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [CreditUnionCOOP] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [CreditUnionCOOP] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [CreditUnionCOOP] SET ARITHABORT OFF 
GO

ALTER DATABASE [CreditUnionCOOP] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [CreditUnionCOOP] SET AUTO_CREATE_STATISTICS ON 
GO

ALTER DATABASE [CreditUnionCOOP] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [CreditUnionCOOP] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [CreditUnionCOOP] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [CreditUnionCOOP] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [CreditUnionCOOP] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [CreditUnionCOOP] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [CreditUnionCOOP] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [CreditUnionCOOP] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [CreditUnionCOOP] SET  DISABLE_BROKER 
GO

ALTER DATABASE [CreditUnionCOOP] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [CreditUnionCOOP] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [CreditUnionCOOP] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [CreditUnionCOOP] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [CreditUnionCOOP] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [CreditUnionCOOP] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [CreditUnionCOOP] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [CreditUnionCOOP] SET  READ_WRITE 
GO

ALTER DATABASE [CreditUnionCOOP] SET RECOVERY FULL 
GO

ALTER DATABASE [CreditUnionCOOP] SET  MULTI_USER 
GO

ALTER DATABASE [CreditUnionCOOP] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [CreditUnionCOOP] SET DB_CHAINING OFF 
GO


