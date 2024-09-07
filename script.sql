USE [master]
GO
/****** Object:  Database [AjedrezBD]    Script Date: 23/11/2023 14:22:43 ******/
CREATE DATABASE [AjedrezBD]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'AjedrezBD', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\AjedrezBD.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'AjedrezBD_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\AjedrezBD_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [AjedrezBD] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [AjedrezBD].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [AjedrezBD] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [AjedrezBD] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [AjedrezBD] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [AjedrezBD] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [AjedrezBD] SET ARITHABORT OFF 
GO
ALTER DATABASE [AjedrezBD] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [AjedrezBD] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [AjedrezBD] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [AjedrezBD] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [AjedrezBD] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [AjedrezBD] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [AjedrezBD] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [AjedrezBD] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [AjedrezBD] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [AjedrezBD] SET  DISABLE_BROKER 
GO
ALTER DATABASE [AjedrezBD] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [AjedrezBD] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [AjedrezBD] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [AjedrezBD] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [AjedrezBD] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [AjedrezBD] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [AjedrezBD] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [AjedrezBD] SET RECOVERY FULL 
GO
ALTER DATABASE [AjedrezBD] SET  MULTI_USER 
GO
ALTER DATABASE [AjedrezBD] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [AjedrezBD] SET DB_CHAINING OFF 
GO
ALTER DATABASE [AjedrezBD] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [AjedrezBD] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [AjedrezBD] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [AjedrezBD] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'AjedrezBD', N'ON'
GO
ALTER DATABASE [AjedrezBD] SET QUERY_STORE = ON
GO
ALTER DATABASE [AjedrezBD] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [AjedrezBD]
GO
/****** Object:  Table [dbo].[JUGADOR]    Script Date: 23/11/2023 14:22:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JUGADOR](
	[Id_Jugador] [varchar](50) NOT NULL,
	[Nombre_Jugador] [varchar](50) NOT NULL,
	[Contraseña] [varchar](50) NOT NULL,
	[Victorias] [int] NULL,
	[Derrotas] [int] NULL,
	[Promedio] [decimal](18, 8) NULL,
	[Horas] [decimal](18, 8) NULL,
	[Empates] [int] NULL
) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [AjedrezBD] SET  READ_WRITE 
GO
