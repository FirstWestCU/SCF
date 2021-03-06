USE [master]
GO
/****** Object:  Database [CreditUnionCOOP]    Script Date: 07/24/2014 16:12:28 ******/
CREATE DATABASE [CreditUnionCOOP] ON  PRIMARY 
( NAME = N'CreditUnionCOOP', FILENAME = N'D:\MSSQL\DATA\CreditUnionCOOP.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'CreditUnionCOOP_log', FILENAME = N'E:\MSSQL\Data\CreditUnionCOOP_log.ldf' , SIZE = 4672KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
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
USE [CreditUnionCOOP]
GO
/****** Object:  User [creditunioncoopuser]    Script Date: 07/24/2014 16:12:28 ******/
CREATE USER [creditunioncoopuser] FOR LOGIN [coopuser] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [AAFCU\solarwindsadmin]    Script Date: 07/24/2014 16:12:28 ******/
CREATE USER [AAFCU\solarwindsadmin] FOR LOGIN [AAFCU\solarwindsadmin] WITH DEFAULT_SCHEMA=[AAFCU\solarwindsadmin]
GO
/****** Object:  Schema [AAFCU\solarwindsadmin]    Script Date: 07/24/2014 16:12:28 ******/
CREATE SCHEMA [AAFCU\solarwindsadmin] AUTHORIZATION [AAFCU\solarwindsadmin]
GO
/****** Object:  Table [dbo].[CreditUnions]    Script Date: 07/24/2014 16:12:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CreditUnions](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Abbr] [varchar](10) NULL,
	[Website] [nvarchar](50) NULL,
	[Latitude] [float] NOT NULL,
	[Longitude] [float] NOT NULL,
 CONSTRAINT [PK_CreditUnion] PRIMARY KEY CLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_CreditUnion] ON [dbo].[CreditUnions] 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CreditUnionDonations]    Script Date: 07/24/2014 16:12:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CreditUnionDonations](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CreditUnionID] [int] NOT NULL,
	[Title] [varchar](50) NOT NULL,
	[CategoryID] [int] NOT NULL,
	[OnClockHours] [int] NULL,
	[OffClockHours] [int] NULL,
	[Dollars] [int] NULL,
	[Latitude] [float] NOT NULL,
	[Longitude] [float] NOT NULL,
	[AdditionalInfo] [varchar](max) NULL,
	[DonationDate] [date] NOT NULL,
	[DateAdded] [datetime] NOT NULL,
	[UserID] [int] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CreditUnionBranches]    Script Date: 07/24/2014 16:12:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CreditUnionBranches](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CreditUnionID] [int] NOT NULL,
	[BranchName] [varchar](100) NOT NULL,
	[Latitude] [float] NOT NULL,
	[Longitude] [float] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[COOPProjectUpdates]    Script Date: 07/24/2014 16:12:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[COOPProjectUpdates](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ProjectID] [int] NOT NULL,
	[Message] [varchar](max) NOT NULL,
	[UpdateDate] [datetime] NOT NULL,
	[UserID] [int] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[COOPProjects]    Script Date: 07/24/2014 16:12:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[COOPProjects](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](150) NOT NULL,
	[Description] [varchar](max) NOT NULL,
	[Website] [varchar](200) NULL,
	[CategoryID] [int] NOT NULL,
	[CreditUnionID] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[COOPProjectImages]    Script Date: 07/24/2014 16:12:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[COOPProjectImages](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ProjectID] [int] NOT NULL,
	[COOPImage] [image] NOT NULL,
	[ContentType] [varchar](20) NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[COOPProjectFAQ]    Script Date: 07/24/2014 16:12:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[COOPProjectFAQ](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ProjectID] [int] NOT NULL,
	[Question] [varchar](max) NOT NULL,
	[Answer] [varchar](max) NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[COOPProjectActivation]    Script Date: 07/24/2014 16:12:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[COOPProjectActivation](
	[ProjectID] [int] NOT NULL,
	[DateActivated] [datetime] NOT NULL,
	[DateDeactivated] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[COOPCategories]    Script Date: 07/24/2014 16:12:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[COOPCategories](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](50) NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Members]    Script Date: 07/24/2014 16:12:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Members](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Hash] [varchar](200) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Email] [varchar](150) NOT NULL,
	[CreditUnionID] [int] NOT NULL,
	[HomeBranch] [int] NULL,
	[Latitude] [float] NOT NULL,
	[Longitude] [float] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MemberAccessHistory]    Script Date: 07/24/2014 16:12:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MemberAccessHistory](
	[MemberID] [int] NOT NULL,
	[Latitude] [float] NOT NULL,
	[Longitude] [float] NOT NULL,
	[DateTimeStamp] [datetime] NOT NULL,
	[IP] [varchar](50) NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_MemberAccessHistory] ON [dbo].[MemberAccessHistory] 
(
	[MemberID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VotingWindow]    Script Date: 07/24/2014 16:12:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VotingWindow](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Votes]    Script Date: 07/24/2014 16:12:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Votes](
	[VotingWindowID] [int] NOT NULL,
	[ProjectID] [int] NOT NULL,
	[MemberID] [int] NOT NULL,
 CONSTRAINT [PK_Votes] PRIMARY KEY CLUSTERED 
(
	[VotingWindowID] ASC,
	[MemberID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 07/24/2014 16:12:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Users](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Hash] [varchar](200) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Pass] [varchar](max) NOT NULL,
	[CreditUnionID] [int] NOT NULL,
	[AccessLevel] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[FailedMemberAccess]    Script Date: 07/24/2014 16:12:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FailedMemberAccess](
	[Latitude] [float] NOT NULL,
	[Longitude] [float] NOT NULL,
	[DateTimeStamp] [datetime] NOT NULL,
	[IP] [varchar](50) NOT NULL,
	[RequestedHash] [varchar](200) NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AccessLevel]    Script Date: 07/24/2014 16:12:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AccessLevel](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[UpdateFailedMemberAccess]    Script Date: 07/24/2014 16:12:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Kevin Anderson
-- Create date: 14 July 2014
-- Description:	Updates the Failed Member Access
-- table with a new entry
-- =============================================
CREATE PROCEDURE [dbo].[UpdateFailedMemberAccess]
	-- Add the parameters for the stored procedure here
	@Latitude float,
	@Longitude float,
	@IP varchar(50),
	@RequestedHash varchar(200)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO UpdateFailedMemberAccess
	(
		Latitude,
		Longitude,
		DateTimeStamp,
		IP,
		RequestedHash
	)
	VALUES
	(
		@Latitude,
		@Longitude,
		GETDATE(),
		@IP,
		@RequestedHash
	)
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateDonation]    Script Date: 07/24/2014 16:12:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Kevin Anderson
-- Create date: 16 July 2014
-- Description:	Updates an existing donation
-- =============================================
CREATE PROCEDURE [dbo].[UpdateDonation]
	-- Add the parameters for the stored procedure here
	@ID int,
	@CreditUnionID int,
	@Title varchar(50),
	@CategoryID int,
	@OnClockHours int,
	@OffClockHours int,
	@Dollars int,
	@Latitude float,
	@Longitude float,
	@AdditionalInfo varchar(MAX),
	@DonationDate datetime,
	@UserID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE CreditUnionDonations
	SET CreditUnionID = @CreditUnionID,
		Title = @Title,
		CategoryID = @CategoryID,
		OnClockHours = @OnClockHours,
		OffClockHours = @OffClockHours,
		Dollars = @Dollars,
		Latitude = @Latitude,
		Longitude = @Longitude,
		AdditionalInfo = @AdditionalInfo,
		DonationDate = @DonationDate,
		UserID = @UserID
	WHERE ID = @ID
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateCreditUnion]    Script Date: 07/24/2014 16:12:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Kevin Anderson
-- Create date: 15 July 2014
-- Description:	Updates the specified Credit Union
-- =============================================
CREATE PROCEDURE [dbo].[UpdateCreditUnion] 
	-- Add the parameters for the stored procedure here
	@ID int,
	@Name varchar(100),
	@Abbr varchar(10),
	@Website varchar(50),
	@Latitude float,
	@Longitude float
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE CreditUnions
	SET Name = @Name,
		Abbr = @Abbr,
		Website = @Website,
		Latitude = @Latitude,
		Longitude = @Longitude
	WHERE ID = @ID
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteProjectUpdate]    Script Date: 07/24/2014 16:12:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Kevin Anderson
-- Create date: 15 July 2014
-- Description: Deletes a Project FAQ
-- =============================================
CREATE PROCEDURE [dbo].[DeleteProjectUpdate]
	-- Add the parameters for the stored procedure here
	@ID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM COOPProjectUpdates
	WHERE ID = @ID
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteProjectFAQ]    Script Date: 07/24/2014 16:12:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Kevin Anderson
-- Create date: 15 July 2014
-- Description: Deletes a Project FAQ
-- =============================================
CREATE PROCEDURE [dbo].[DeleteProjectFAQ] 
	-- Add the parameters for the stored procedure here
	@ID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM COOPProjectFAQ
	WHERE ID = @ID
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteProject]    Script Date: 07/24/2014 16:12:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Kevin Anderson
-- Create date: 15 July 2014
-- Description:	Deletes a project from the database
-- =============================================
CREATE PROCEDURE [dbo].[DeleteProject]
	-- Add the parameters for the stored procedure here
	@ID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM COOPProjects
	WHERE ID = @ID

	DELETE FROM COOPProjectUpdates
	WHERE ProjectID = @ID

	DELETE FROM COOPProjectFAQ
	WHERE ProjectID = @ID

	DELETE FROM COOPProjectImages
	WHERE ProjectID = @ID
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteDonation]    Script Date: 07/24/2014 16:12:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Kevin Anderson
-- Create date: 16 July 2014
-- Description: Deletes a donation from the database
-- =============================================
CREATE PROCEDURE [dbo].[DeleteDonation]
	-- Add the parameters for the stored procedure here
	@ID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM CreditUnionDonations
	WHERE ID = @ID
END
GO
/****** Object:  StoredProcedure [dbo].[DeactivateProject]    Script Date: 07/24/2014 16:12:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Kevin Anderson
-- Create date: 16 July 2014
-- Description:	Activates a project
-- =============================================
CREATE PROCEDURE [dbo].[DeactivateProject]
	-- Add the parameters for the stored procedure here
	@ID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE COOPProjectActivation
	SET DateDeactivated = GETDATE()
	WHERE ProjectID = @ID AND DateDeactivated IS NULL
END
GO
/****** Object:  StoredProcedure [dbo].[UpsertVote]    Script Date: 07/24/2014 16:12:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Kevin Anderson
-- Create date: 11 July 2014
-- Description:	Updates a members vote for the
-- current voting window. If the member has not
-- voted yet, inserts a new vote for the member
-- =============================================
CREATE PROCEDURE [dbo].[UpsertVote]
	-- Add the parameters for the stored procedure here
	@VotingWindowID int,
	@ProjectID int,
	@MemberID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE Votes
	SET ProjectID = @ProjectID
	WHERE VotingWindowID = @VotingWindowID AND MemberID = @MemberID

	IF @@ROWCOUNT = 0
	BEGIN
		INSERT INTO Votes
		(
			VotingWindowID,
			ProjectID,
			MemberID
		)
		VALUES
		(
			@VotingWindowID,
			@ProjectID,
			@MemberID
		)
	END
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateVotingWindow]    Script Date: 07/24/2014 16:12:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Nathan Welch>
-- Create date: <7/16/2014>
-- Description:	<Update voting window by ID. Takes 3 parameters: @ID(int),@StartDate(datetime),@EndDate(datetime)>
-- =============================================
CREATE PROCEDURE [dbo].[UpdateVotingWindow] 
	-- Add the parameters for the stored procedure here
	@ID int,
	@StartDate datetime,
	@EndDate datetime
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE VotingWindow
	SET StartDate = @StartDate, EndDate = @EndDate
	WHERE ID = @ID
	
	SELECT *
	FROM VotingWindow
	WHERE ID = @ID
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateUserAccessLevel]    Script Date: 07/24/2014 16:12:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Kevin Anderson
-- Create date: 14 July 2014
-- Description:	Updates a user's access level in
-- the database
-- =============================================
CREATE PROCEDURE [dbo].[UpdateUserAccessLevel]
	-- Add the parameters for the stored procedure here
	@ID int,
	@AccessLevel int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE Users
	SET AccessLevel = @AccessLevel
	WHERE ID = @ID
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateProject]    Script Date: 07/24/2014 16:12:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Kevin Anderson
-- Create date: 15 July 2014
-- Description:	Updates a project in the database
-- =============================================
CREATE PROCEDURE [dbo].[UpdateProject]
	-- Add the parameters for the stored procedure here
	@ID int,
	@Name varchar(150),
	@Description varchar(MAX),
	@Website varchar(200),
	@CategoryID int,
	@CreditUnionID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE COOPProjects
	SET Name = @Name,
		Description = @Description,
		Website = @Website,
		CategoryID = @CategoryID,
		CreditUnionID = @CreditUnionID
	WHERE ID = @ID
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateMemberAccessHistory]    Script Date: 07/24/2014 16:12:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Kevin Anderson
-- Create date: 14 July 2014
-- Description:	Updates the MemberAccessHistory
-- table with a new entry for the specified
-- member
-- =============================================
CREATE PROCEDURE [dbo].[UpdateMemberAccessHistory] 
	-- Add the parameters for the stored procedure here
	@MemberID int,
	@Latitude float,
	@Longitude float,
	@IP varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO MemberAccessHistory
	(
		MemberID,
		Latitude,
		Longitude,
		DateTimeStamp,
		IP
	)
	VALUES
	(
		@MemberID,
		@Latitude,
		@Longitude,
		GETDATE(),
		@IP
	)
END
GO
/****** Object:  View [dbo].[Master]    Script Date: 07/24/2014 16:12:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[Master]
AS
SELECT     dbo.CreditUnions.ID, dbo.CreditUnions.Name, dbo.CreditUnions.Abbr, dbo.CreditUnions.Website
FROM         dbo.COOPProjectUpdates INNER JOIN
                      dbo.COOPProjectFAQ INNER JOIN
                      dbo.COOPProjectActivation ON dbo.COOPProjectFAQ.ProjectID = dbo.COOPProjectActivation.ProjectID INNER JOIN
                      dbo.COOPProjectImages ON dbo.COOPProjectFAQ.ProjectID = dbo.COOPProjectImages.ProjectID ON 
                      dbo.COOPProjectUpdates.ProjectID = dbo.COOPProjectImages.ProjectID INNER JOIN
                      dbo.AccessLevel INNER JOIN
                      dbo.MemberAccessHistory INNER JOIN
                      dbo.Users INNER JOIN
                      dbo.CreditUnionBranches INNER JOIN
                      dbo.CreditUnionDonations ON dbo.CreditUnionBranches.CreditUnionID = dbo.CreditUnionDonations.CreditUnionID ON 
                      dbo.Users.ID = dbo.CreditUnionDonations.UserID INNER JOIN
                      dbo.COOPCategories ON dbo.CreditUnionDonations.CategoryID = dbo.COOPCategories.ID INNER JOIN
                      dbo.COOPProjects INNER JOIN
                      dbo.Members INNER JOIN
                      dbo.VotingWindow INNER JOIN
                      dbo.Votes ON dbo.VotingWindow.ID = dbo.Votes.VotingWindowID ON dbo.Members.ID = dbo.Votes.MemberID ON dbo.COOPProjects.ID = dbo.Votes.ID INNER JOIN
                      dbo.CreditUnions ON dbo.Members.CreditUnionID = dbo.CreditUnions.ID ON dbo.COOPCategories.ID = dbo.COOPProjects.CategoryID ON 
                      dbo.MemberAccessHistory.ID = dbo.Members.ID ON dbo.AccessLevel.ID = dbo.Users.AccessLevel ON 
                      dbo.COOPProjectActivation.ProjectID = dbo.COOPProjects.ID INNER JOIN
                      dbo.CreditUnionBranches AS CreditUnionBranches_1 ON dbo.CreditUnions.ID = CreditUnionBranches_1.CreditUnionID AND 
                      dbo.Users.CreditUnionID = CreditUnionBranches_1.CreditUnionID
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[66] 4[15] 2[11] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "AccessLevel"
            Begin Extent = 
               Top = 624
               Left = 1241
               Bottom = 721
               Right = 1401
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "COOPCategories"
            Begin Extent = 
               Top = 224
               Left = 502
               Bottom = 317
               Right = 662
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "COOPProjectActivation"
            Begin Extent = 
               Top = 22
               Left = 535
               Bottom = 128
               Right = 705
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "COOPProjectFAQ"
            Begin Extent = 
               Top = 8
               Left = 802
               Bottom = 127
               Right = 962
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "COOPProjectImages"
            Begin Extent = 
               Top = 8
               Left = 1066
               Bottom = 127
               Right = 1226
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "COOPProjects"
            Begin Extent = 
               Top = 23
               Left = 270
               Bottom = 174
               Right = 430
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "COOPProjectUpdates"
            Begin Extent = 
               Top = 9
               Left = 1301
               Bottom = 145
              ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Master'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N' Right = 1461
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "CreditUnionBranches"
            Begin Extent = 
               Top = 216
               Left = 960
               Bottom = 352
               Right = 1120
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "CreditUnionDonations"
            Begin Extent = 
               Top = 195
               Left = 736
               Bottom = 448
               Right = 896
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "MemberAccessHistory"
            Begin Extent = 
               Top = 489
               Left = 536
               Bottom = 640
               Right = 752
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Members"
            Begin Extent = 
               Top = 633
               Left = 265
               Bottom = 760
               Right = 425
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Users"
            Begin Extent = 
               Top = 537
               Left = 960
               Bottom = 698
               Right = 1120
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Votes"
            Begin Extent = 
               Top = 183
               Left = 0
               Bottom = 302
               Right = 168
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "VotingWindow"
            Begin Extent = 
               Top = 340
               Left = 281
               Bottom = 444
               Right = 441
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "CreditUnions"
            Begin Extent = 
               Top = 698
               Left = 500
               Bottom = 817
               Right = 660
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "CreditUnionBranches_1"
            Begin Extent = 
               Top = 688
               Left = 704
               Bottom = 825
               Right = 864
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Master'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Master'
GO
/****** Object:  StoredProcedure [dbo].[InsertVotingWindow]    Script Date: 07/24/2014 16:12:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Nathan Welch>
-- Create date: <7/16/2014>
-- Description:	<Sets a voting window timefram based on start and end>
-- =============================================
CREATE PROCEDURE [dbo].[InsertVotingWindow] 
	-- Add the parameters for the stored procedure here
	@StartDate datetime,
	@EndDate datetime
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO VotingWindow
	(
		StartDate,
		EndDate
	)
	VALUES
	(
		@StartDate,
		@EndDate
	)
	SELECT *
	FROM VotingWindow
	WHERE ID = @@IDENTITY
END
GO
/****** Object:  StoredProcedure [dbo].[InsertUser]    Script Date: 07/24/2014 16:12:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Kevin Anderson
-- Create date: 11 July 2014
-- Description:	Creates a new user with a null
-- access level
-- =============================================
CREATE PROCEDURE [dbo].[InsertUser]
	-- Add the parameters for the stored procedure here
	@Hash varchar(200),
	@Name varchar(50),
	@Email varchar(50),
	@Pass varchar(MAX),
	@CreditUnionID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO Users
	(
		Hash,
		Name,
		Email,
		Pass,
		CreditUnionID
	)
	VALUES
	(
		@Hash,
		@Name,
		@Email,
		@Pass,
		@CreditUnionID
	)
	SELECT @@IDENTITY
END
GO
/****** Object:  StoredProcedure [dbo].[InsertProjectUpdate]    Script Date: 07/24/2014 16:12:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Kevin Anderson
-- Create date: 15 July 2014
-- Description:	Adds a new update to a project
-- =============================================
CREATE PROCEDURE [dbo].[InsertProjectUpdate]
	-- Add the parameters for the stored procedure here
	@ProjectID int,
	@Message varchar(MAX),
	@UserID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO COOPProjectUpdates
	(
		ProjectID,
		Message,
		UpdateDate,
		UserID
	)
	VALUES
	(
		@ProjectID,
		@Message,
		GETDATE(),
		@UserID
	)


	SELECT @@IDENTITY
END
GO
/****** Object:  StoredProcedure [dbo].[InsertProjectFAQ]    Script Date: 07/24/2014 16:12:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Kevin Anderson
-- Create date: 15 July 2014
-- Description:	Adds a new FAQ to a project
-- =============================================
CREATE PROCEDURE [dbo].[InsertProjectFAQ]
	-- Add the parameters for the stored procedure here
	@ProjectID int,
	@Question varchar(MAX),
	@Answer varchar(MAX)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO COOPProjectFAQ
	(
		ProjectID,
		Question,
		Answer
	)
	VALUES
	(
		@ProjectID,
		@Question,
		@Answer
	)


	SELECT @@IDENTITY
END
GO
/****** Object:  StoredProcedure [dbo].[InsertProject]    Script Date: 07/24/2014 16:12:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Kevin Anderson
-- Create date: 15 July 2014
-- Description:	Inserts a new project into the
-- database
-- =============================================
CREATE PROCEDURE [dbo].[InsertProject]
	-- Add the parameters for the stored procedure here
	@Name varchar(150),
	@Description varchar(MAX),
	@Website varchar(200),
	@CategoryID int,
	@CreditUnionID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO COOPProjects
	(
		Name,
		Description,
		Website,
		CategoryID,
		CreditUnionID
	)
	VALUES
	(
		@Name,
		@Description,
		@Website,
		@CategoryID,
		@CreditUnionID
	)
END
GO
/****** Object:  StoredProcedure [dbo].[InsertMember]    Script Date: 07/24/2014 16:12:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Kevin Anderson
-- Create date: 11 July 2014
-- Description:	Inserts a new Member
-- =============================================
CREATE PROCEDURE [dbo].[InsertMember]
	-- Add the parameters for the stored procedure here
	@Hash varchar(200),
	@Name varchar(50),
	@Email varchar(150),
	@CreditUnionID int,
	@HomeBranch int = NULL,
	@Latitude float,
	@Longitude float
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO Members
	(
		[Hash],
		Name,
		Email,
		CreditUnionID,
		HomeBranch,
		Latitude,
		Longitude
	)
	VALUES
	(
		@Hash,
		@Name,
		@Email,
		@CreditUnionID,
		@HomeBranch,
		@Latitude,
		@Longitude
	)

	SELECT @@IDENTITY
END
GO
/****** Object:  StoredProcedure [dbo].[InsertDonation]    Script Date: 07/24/2014 16:12:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Kevin Anderson
-- Create date: 16 July 2014
-- Description:	Inserts a new donation
-- =============================================
CREATE PROCEDURE [dbo].[InsertDonation]
	-- Add the parameters for the stored procedure here
	@CreditUnionID int,
	@Title varchar(50),
	@CategoryID int,
	@OnClockHours int,
	@OffClockHours int,
	@Dollars int,
	@Latitude float,
	@Longitude float,
	@AdditionalInfo varchar(MAX),
	@DonationDate datetime,
	@UserID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO CreditUnionDonations
	(
		CreditUnionID,
		Title,
		CategoryID,
		OnClockHours,
		OffClockHours,
		Dollars,
		Latitude,
		Longitude,
		AdditionalInfo,
		DonationDate,
		DateAdded,
		UserID
	)
	VALUES
	(
		@CreditUnionID,
		@Title,
		@CategoryID,
		@OnClockHours,
		@OffClockHours,
		@Dollars,
		@Latitude,
		@Longitude,
		@AdditionalInfo,
		@DonationDate,
		GETDATE(),
		@UserID
	)

	SELECT @@IDENTITY
END
GO
/****** Object:  StoredProcedure [dbo].[InsertCreditUnion]    Script Date: 07/24/2014 16:12:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Kevin Anderson
-- Create date: 15 July 2014
-- Description:	Updates the specified Credit Union
-- =============================================
CREATE PROCEDURE [dbo].[InsertCreditUnion] 
	-- Add the parameters for the stored procedure here
	@Name varchar(100),
	@Abbr varchar(10),
	@Website varchar(50),
	@Latitude float,
	@Longitude float
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO CreditUnions
	(
		Name,
		Abbr,
		Website,
		Latitude,
		Longitude
	)
	VALUES
	(
		@Name,
		@Abbr,
		@Website,
		@Latitude,
		@Longitude
	)

	SELECT @@IDENTITY
END
GO
/****** Object:  StoredProcedure [dbo].[GetUserIDAndPass]    Script Date: 07/24/2014 16:12:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Kevin Anderson
-- Create date: 14 July 2014
-- Description:	Returns the user ID and hashed
-- password value for the specified user. Used
-- to validate credentials
-- =============================================
CREATE PROCEDURE [dbo].[GetUserIDAndPass]
	-- Add the parameters for the stored procedure here
	@Email varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT ID, Pass
	FROM Users
	WHERE Email = @Email
END
GO
/****** Object:  StoredProcedure [dbo].[GetUserDetails]    Script Date: 07/24/2014 16:12:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Kevin Anderson
-- Create date: 11 July 2014
-- Description:	Gets user information for the
-- given user ID
-- =============================================
CREATE PROCEDURE [dbo].[GetUserDetails]
	-- Add the parameters for the stored procedure here
	@ID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT Hash,
		   Name,
		   Email,
		   CreditUnionID,
		   AccessLevel
	FROM Users
	WHERE ID = @ID
END
GO
/****** Object:  StoredProcedure [dbo].[GetProjectVoteCounts]    Script Date: 07/24/2014 16:12:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Kevin Anderson
-- Create date: 11 July 2014	
-- Description:	Gets a list of projects sorted
-- in increasing order by the number of votes
-- in the given voting window
-- =============================================
CREATE PROCEDURE [dbo].[GetProjectVoteCounts]
	-- Add the parameters for the stored procedure here
	@VotingWindowID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT ProjectID, COUNT(ProjectID) AS 'Count'
	FROM Votes
	WHERE VotingWindowID = @VotingWindowID
	GROUP BY ProjectID
	ORDER BY 'Count' DESC
END
GO
/****** Object:  StoredProcedure [dbo].[GetProjectUpdates]    Script Date: 07/24/2014 16:12:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Kevin Anderson
-- Create date: 15 July 2014
-- Description:	Returns a Projects Updates
-- =============================================
CREATE PROCEDURE [dbo].[GetProjectUpdates]
	-- Add the parameters for the stored procedure here
	@ProjectID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT ID,
		   Message,
		   UpdateDate,
		   UserID
	FROM COOPProjectUpdates
	WHERE ProjectID = @ProjectID
	ORDER BY UpdateDate DESC
END
GO
/****** Object:  StoredProcedure [dbo].[GetProjectsByCategory]    Script Date: 07/24/2014 16:12:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Kevin Anderson
-- Create date: 15 July 2014
-- Description:	Gets all projects that belong
-- to the given category
-- =============================================
CREATE PROCEDURE [dbo].[GetProjectsByCategory] 
	-- Add the parameters for the stored procedure here
	@CategoryID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT ID
	FROM COOPProjects
	WHERE CategoryID = @CategoryID
	ORDER BY Name ASC
END
GO
/****** Object:  StoredProcedure [dbo].[GetProjectImage]    Script Date: 07/24/2014 16:12:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Kevin Anderson
-- Create date: 15 July 2014
-- Description:	Gets a COOP Project Image
-- =============================================
CREATE PROCEDURE [dbo].[GetProjectImage]
	-- Add the parameters for the stored procedure here
	@ProjectID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT TOP(1) COOPImage, ContentType
	FROM COOPProjectImages
	WHERE ProjectID = @ProjectID
END
GO
/****** Object:  StoredProcedure [dbo].[GetProjectFAQ]    Script Date: 07/24/2014 16:12:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Kevin Anderson
-- Create date: 15 July 2014
-- Description:	Returns a Projects FAQs
-- =============================================
CREATE PROCEDURE [dbo].[GetProjectFAQ]
	-- Add the parameters for the stored procedure here
	@ProjectID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT ID,
		   Question,
		   Answer
	FROM COOPProjectFAQ
	WHERE ProjectID = @ProjectID
	ORDER BY Question ASC
END
GO
/****** Object:  StoredProcedure [dbo].[GetProjectDetails]    Script Date: 07/24/2014 16:12:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Kevin Anderson
-- Create date: 15 July 2014
-- Description:	Gets details for the specified
-- project
-- =============================================
CREATE PROCEDURE [dbo].[GetProjectDetails]
	-- Add the parameters for the stored procedure here
	@ID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT Name,
		   Description,
		   Website,
		   CategoryID,
		   CreditUnionID
	FROM COOPProjects
	WHERE ID = @ID
END
GO
/****** Object:  StoredProcedure [dbo].[GetMemberID]    Script Date: 07/24/2014 16:12:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Kevin Anderson
-- Create date: 14 July 2014
-- Description:	Gets a member's ID from the
-- specified hash value
-- =============================================
CREATE PROCEDURE [dbo].[GetMemberID]
	-- Add the parameters for the stored procedure here
	@Hash varchar(200)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT ID FROM Members WHERE Hash = @Hash
END
GO
/****** Object:  StoredProcedure [dbo].[GetMemberDetails]    Script Date: 07/24/2014 16:12:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Kevin Anderson
-- Create date: 14 July 2014
-- Description:	Returns member details for the
-- specified user ID
-- =============================================
CREATE PROCEDURE [dbo].[GetMemberDetails]
	-- Add the parameters for the stored procedure here
	@ID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT Hash,
		   Name,
		   CreditUnionID,
		   Latitude,
		   Longitude
	FROM Members
	WHERE ID = @ID
END
GO
/****** Object:  StoredProcedure [dbo].[GetDonationsByDate]    Script Date: 07/24/2014 16:12:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Kevin Anderson
-- Create date: 16 July 2014
-- Description: Gets donations within a Date Range
-- =============================================
CREATE PROCEDURE [dbo].[GetDonationsByDate]
	-- Add the parameters for the stored procedure here
	@StartDate datetime,
	@EndDate datetime
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT ID FROM CreditUnionDonations
	WHERE DonationDate >= @StartDate AND DonationDate <= @EndDate
	ORDER BY DonationDate DESC
END
GO
/****** Object:  StoredProcedure [dbo].[GetDonationsByCreditUnion]    Script Date: 07/24/2014 16:12:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Kevin Anderson
-- Create date: 16 July 2014
-- Description: Gets donations by a given Credit
-- Union
-- =============================================
CREATE PROCEDURE [dbo].[GetDonationsByCreditUnion]
	-- Add the parameters for the stored procedure here
	@CreditUnionID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT ID FROM CreditUnionDonations
	WHERE CreditUnionID = @CreditUnionID
	ORDER BY DonationDate DESC
END
GO
/****** Object:  StoredProcedure [dbo].[GetDonationsByCategory]    Script Date: 07/24/2014 16:12:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Kevin Anderson
-- Create date: 16 July 2014
-- Description: Gets donations by a given category
-- =============================================
CREATE PROCEDURE [dbo].[GetDonationsByCategory]
	-- Add the parameters for the stored procedure here
	@CategoryID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT ID FROM CreditUnionDonations
	WHERE CategoryID = @CategoryID
	ORDER BY DonationDate DESC
END
GO
/****** Object:  StoredProcedure [dbo].[GetDonationDetails]    Script Date: 07/24/2014 16:12:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Kevin Anderson
-- Create date: 15 July 2014
-- Description:	Gets donation details
-- =============================================
CREATE PROCEDURE [dbo].[GetDonationDetails]
	-- Add the parameters for the stored procedure here
	@ID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT CreditUnionID,
		   Title,
		   CategoryID,
		   OnClockHours,
		   OffClockHours,
		   Dollars,
		   Latitude,
		   Longitude,
		   AdditionalInfo,
		   DonationDate,
		   DateAdded,
		   UserID
	FROM CreditUnionDonations
	WHERE ID = @ID
END
GO
/****** Object:  StoredProcedure [dbo].[GetCurrentVotingWindow]    Script Date: 07/24/2014 16:12:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Nathan Welch>
-- Create date: <7/16/2014>
-- Description:	<Gets current voting window based on current datetime.>
-- =============================================
CREATE PROCEDURE [dbo].[GetCurrentVotingWindow] 
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT *
	FROM VotingWindow
	WHERE CURRENT_TIMESTAMP > StartDate AND CURRENT_TIMESTAMP < EndDate
END
GO
/****** Object:  StoredProcedure [dbo].[GetCreditUnionsByName]    Script Date: 07/24/2014 16:12:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Kevin Anderson
-- Create date: 15 July 2014
-- Description:	Returns Credit Unions that partly
-- match the name or abbreviation provided
-- =============================================
CREATE PROCEDURE [dbo].[GetCreditUnionsByName]
	-- Add the parameters for the stored procedure here
	@Name varchar(100)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT ID
	FROM CreditUnions
	WHERE Name LIKE @Name + '%' OR Abbr LIKE @Name + '%'
	ORDER BY Name ASC
END
GO
/****** Object:  StoredProcedure [dbo].[GetCreditUnionDetails]    Script Date: 07/24/2014 16:12:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Kevin Anderson
-- Create date: 11 July 2014
-- Description:	Gets details for a Credit Union
-- given the specified Credit Union ID
-- =============================================
CREATE PROCEDURE [dbo].[GetCreditUnionDetails]
	-- Add the parameters for the stored procedure here
	@ID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT Name,
		   Abbr,
		   Website,
		   Latitude,
		   Longitude
	FROM CreditUnions
	WHERE ID = @ID
END
GO
/****** Object:  StoredProcedure [dbo].[GetCategoryID]    Script Date: 07/24/2014 16:12:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Kevin Anderson
-- Create date: 16 July 2014
-- Description: Gets a category ID
-- =============================================
CREATE PROCEDURE [dbo].[GetCategoryID]
	-- Add the parameters for the stored procedure here
	@Description varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT ID
	FROM COOPCategories
	WHERE Description = @Description
END
GO
/****** Object:  StoredProcedure [dbo].[GetCategoryDescription]    Script Date: 07/24/2014 16:12:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Kevin Anderson
-- Create date: 16 July 2014
-- Description: Gets a category description
-- =============================================
CREATE PROCEDURE [dbo].[GetCategoryDescription]
	-- Add the parameters for the stored procedure here
	@ID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT Description
	FROM COOPCategories
	WHERE ID = @ID
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllProjects]    Script Date: 07/24/2014 16:12:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Kevin Anderson
-- Create date: 15 July 2014
-- Description:	Selects all Projects
-- =============================================
CREATE PROCEDURE [dbo].[GetAllProjects]
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT ID
	FROM COOPProjects
	ORDER BY Name ASC
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllCreditUnions]    Script Date: 07/24/2014 16:12:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Kevin Anderson
-- Create date: 15 July 2014
-- Description:	Returns all Credit Unions
-- =============================================
CREATE PROCEDURE [dbo].[GetAllCreditUnions] 
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT ID
	FROM CreditUnions
	ORDER BY Name ASC
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllCategories]    Script Date: 07/24/2014 16:12:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Kevin Anderson
-- Create date: 16 July 2014
-- Description: All Categories
-- =============================================
CREATE PROCEDURE [dbo].[GetAllCategories]
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT ID, Description
	FROM COOPCategories
	ORDER BY Description ASC
END
GO
/****** Object:  StoredProcedure [dbo].[GetActiveProjects]    Script Date: 07/24/2014 16:12:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Kevin Anderson
-- Create date: 15 July 2014
-- Description:	Gets the list of active projects
-- =============================================
CREATE PROCEDURE [dbo].[GetActiveProjects]
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT DISTINCT ID
	FROM COOPProjects
	INNER JOIN COOPProjectActivation
	ON ProjectID = ID
	WHERE DateActivated < GETDATE() AND DateDeactivated IS NULL
END
GO
/****** Object:  StoredProcedure [dbo].[ActivateProject]    Script Date: 07/24/2014 16:12:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Kevin Anderson
-- Create date: 16 July 2014
-- Description:	Activates a project
-- =============================================
CREATE PROCEDURE [dbo].[ActivateProject]
	-- Add the parameters for the stored procedure here
	@ID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT ProjectID FROM COOPProjectActivation
	WHERE ProjectID = ProjectID AND DateDeactivated IS NULL

	IF @@ROWCOUNT = 0
	BEGIN
		INSERT INTO COOPProjectActivation
		(
			ProjectID,
			DateActivated
		)
		VALUES
		(
			@ID,
			GETDATE()
		)
	END
END
GO
