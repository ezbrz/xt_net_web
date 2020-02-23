USE [master]
GO
/****** Object:  Database [Users]    Script Date: 23.02.2020 17:11:32 ******/
CREATE DATABASE [Users]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Users', FILENAME = N'D:\Program Files (x86)\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\Users.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Users_log', FILENAME = N'D:\Program Files (x86)\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\Users_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Users] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Users].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Users] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Users] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Users] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Users] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Users] SET ARITHABORT OFF 
GO
ALTER DATABASE [Users] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Users] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Users] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Users] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Users] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Users] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Users] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Users] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Users] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Users] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Users] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Users] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Users] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Users] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Users] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Users] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Users] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Users] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Users] SET  MULTI_USER 
GO
ALTER DATABASE [Users] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Users] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Users] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Users] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Users] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Users] SET QUERY_STORE = OFF
GO
USE [Users]
GO
/****** Object:  Table [dbo].[Awards]    Script Date: 23.02.2020 17:11:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Awards](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[image] [varbinary](max) NULL,
 CONSTRAINT [PK_Awards] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 23.02.2020 17:11:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[birthdate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[users_awards]    Script Date: 23.02.2020 17:11:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[users_awards](
	[id_user] [int] NOT NULL,
	[id_award] [int] NOT NULL,
 CONSTRAINT [PK_users_awards] PRIMARY KEY CLUSTERED 
(
	[id_user] ASC,
	[id_award] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Awards] ON 

INSERT [dbo].[Awards] ([id], [name], [image]) VALUES (2, N'TESTNEWAWARD', NULL)
INSERT [dbo].[Awards] ([id], [name], [image]) VALUES (3, N'SuperTestAward', NULL)
INSERT [dbo].[Awards] ([id], [name], [image]) VALUES (4, N'Best score', NULL)
INSERT [dbo].[Awards] ([id], [name], [image]) VALUES (5, N'Best SUPER award', NULL)
INSERT [dbo].[Awards] ([id], [name], [image]) VALUES (7, N'SuperAward', NULL)
SET IDENTITY_INSERT [dbo].[Awards] OFF
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([id], [name], [birthdate]) VALUES (1, N'Alexey', CAST(N'2001-01-14T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Users] ([id], [name], [birthdate]) VALUES (2, N'Sergey', CAST(N'2008-12-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Users] ([id], [name], [birthdate]) VALUES (3, N'Vasiliy', CAST(N'1987-11-14T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Users] ([id], [name], [birthdate]) VALUES (4, N'Roman', CAST(N'1975-11-07T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Users] ([id], [name], [birthdate]) VALUES (5, N'Artem', CAST(N'2011-11-11T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Users] ([id], [name], [birthdate]) VALUES (6, N'Alexander', CAST(N'1990-06-16T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Users] ([id], [name], [birthdate]) VALUES (8, N'Igor', CAST(N'2011-11-11T00:00:00.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Users] OFF
INSERT [dbo].[users_awards] ([id_user], [id_award]) VALUES (1, 3)
INSERT [dbo].[users_awards] ([id_user], [id_award]) VALUES (1, 5)
INSERT [dbo].[users_awards] ([id_user], [id_award]) VALUES (2, 2)
INSERT [dbo].[users_awards] ([id_user], [id_award]) VALUES (3, 4)
INSERT [dbo].[users_awards] ([id_user], [id_award]) VALUES (3, 5)
INSERT [dbo].[users_awards] ([id_user], [id_award]) VALUES (6, 2)
INSERT [dbo].[users_awards] ([id_user], [id_award]) VALUES (6, 3)
INSERT [dbo].[users_awards] ([id_user], [id_award]) VALUES (6, 4)
INSERT [dbo].[users_awards] ([id_user], [id_award]) VALUES (6, 5)
INSERT [dbo].[users_awards] ([id_user], [id_award]) VALUES (6, 7)
INSERT [dbo].[users_awards] ([id_user], [id_award]) VALUES (8, 2)
INSERT [dbo].[users_awards] ([id_user], [id_award]) VALUES (8, 3)
ALTER TABLE [dbo].[users_awards]  WITH CHECK ADD  CONSTRAINT [FK_users_awards_Awards] FOREIGN KEY([id_award])
REFERENCES [dbo].[Awards] ([id])
GO
ALTER TABLE [dbo].[users_awards] CHECK CONSTRAINT [FK_users_awards_Awards]
GO
ALTER TABLE [dbo].[users_awards]  WITH CHECK ADD  CONSTRAINT [FK_users_awards_Users] FOREIGN KEY([id_user])
REFERENCES [dbo].[Users] ([id])
GO
ALTER TABLE [dbo].[users_awards] CHECK CONSTRAINT [FK_users_awards_Users]
GO
/****** Object:  StoredProcedure [dbo].[AddAward]    Script Date: 23.02.2020 17:11:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AddAward]
	@name NVARCHAR(50),
	@id INT OUTPUT
AS
BEGIN
		INSERT INTO Awards(name)
		Values (@name)

		set @id = SCOPE_IDENTITY()

END
GO
/****** Object:  StoredProcedure [dbo].[AddUser]    Script Date: 23.02.2020 17:11:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AddUser]
	@name NVARCHAR(50),
	@Datebirth DATETIME2(7),
	@id INT OUTPUT
AS
BEGIN
		INSERT INTO Users (name, birthdate)
		Values (@name, @datebirth)

		set @id = SCOPE_IDENTITY()
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteAward]    Script Date: 23.02.2020 17:11:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DeleteAward]
@awardId INT
AS
BEGIN
	DELETE users_awards where id_award=@awardId
	DELETE Awards where id=@awardId
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteUser]    Script Date: 23.02.2020 17:11:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DeleteUser]
@userId INT
AS
BEGIN
	DELETE users_awards where id_user=@userId
	DELETE Users where id=@userId
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteUserAward]    Script Date: 23.02.2020 17:11:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DeleteUserAward]
@userId INT, @awardId INT
AS
BEGIN
	DELETE users_awards where (id_user=@userId AND id_award=@awardId)

END
GO
/****** Object:  StoredProcedure [dbo].[GetAwards]    Script Date: 23.02.2020 17:11:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetAwards]

AS
BEGIN
SELECT [id]
      ,[name]
      ,[image]
  FROM [Users].[dbo].[Awards]
END
GO
/****** Object:  StoredProcedure [dbo].[GetUsers]    Script Date: 23.02.2020 17:11:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetUsers]

AS
BEGIN
SELECT [id]
      ,[name]
      ,[birthdate]
  FROM [Users].[dbo].[Users]
END
GO
/****** Object:  StoredProcedure [dbo].[GrantAward]    Script Date: 23.02.2020 17:11:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GrantAward]
	@userId INT,
	@awardId INT
AS
BEGIN
		INSERT INTO users_awards (id_user, id_award)
		Values (@userId, @awardId)

END
GO
/****** Object:  StoredProcedure [dbo].[UpdateAward]    Script Date: 23.02.2020 17:11:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UpdateAward]
@awardId INT, @newName NVARCHAR(50)
AS
BEGIN
	UPDATE Awards SET name=@newName WHERE id=@awardId
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateUser]    Script Date: 23.02.2020 17:11:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UpdateUser]
@userId INT, @newName NVARCHAR(50), @newBirthdate DATETIME2(7)
AS
BEGIN
	UPDATE users SET name=@newName, birthdate=@newBirthdate WHERE id=@userId
	DELETE users_awards WHERE id_user=@userId
END
GO
/****** Object:  StoredProcedure [dbo].[UserAwards]    Script Date: 23.02.2020 17:11:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UserAwards]

AS
BEGIN
SELECT [id_user], [id_award]
  FROM [Users].[dbo].[users_awards]
END
GO
USE [master]
GO
ALTER DATABASE [Users] SET  READ_WRITE 
GO
