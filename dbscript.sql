USE [master]
GO
/****** Object:  Database [bp_custome_authorization]    Script Date: 03-08-2025 22:44:24 ******/
CREATE DATABASE [bp_custome_authorization]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'custome_authorization', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\custome_authorization.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'custome_authorization_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\custome_authorization_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [bp_custome_authorization] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [bp_custome_authorization].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [bp_custome_authorization] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [bp_custome_authorization] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [bp_custome_authorization] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [bp_custome_authorization] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [bp_custome_authorization] SET ARITHABORT OFF 
GO
ALTER DATABASE [bp_custome_authorization] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [bp_custome_authorization] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [bp_custome_authorization] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [bp_custome_authorization] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [bp_custome_authorization] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [bp_custome_authorization] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [bp_custome_authorization] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [bp_custome_authorization] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [bp_custome_authorization] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [bp_custome_authorization] SET  ENABLE_BROKER 
GO
ALTER DATABASE [bp_custome_authorization] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [bp_custome_authorization] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [bp_custome_authorization] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [bp_custome_authorization] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [bp_custome_authorization] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [bp_custome_authorization] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [bp_custome_authorization] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [bp_custome_authorization] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [bp_custome_authorization] SET  MULTI_USER 
GO
ALTER DATABASE [bp_custome_authorization] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [bp_custome_authorization] SET DB_CHAINING OFF 
GO
ALTER DATABASE [bp_custome_authorization] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [bp_custome_authorization] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [bp_custome_authorization] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [bp_custome_authorization] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [bp_custome_authorization] SET QUERY_STORE = OFF
GO
USE [bp_custome_authorization]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 03-08-2025 22:44:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MPermissions]    Script Date: 03-08-2025 22:44:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MPermissions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ModuleName] [nvarchar](max) NOT NULL,
	[ActionName] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[Url] [nvarchar](max) NOT NULL,
	[Icon] [nvarchar](max) NOT NULL,
	[ParentId] [int] NOT NULL,
	[IsMenu] [bit] NOT NULL,
	[SequenceNo] [int] NULL,
 CONSTRAINT [PK_MPermissions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RolePermissons]    Script Date: 03-08-2025 22:44:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RolePermissons](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [int] NOT NULL,
	[PermissionId] [int] NOT NULL,
 CONSTRAINT [PK_RolePermissons] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 03-08-2025 22:44:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 03-08-2025 22:44:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
	[RolesId] [int] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250729100439_new db added', N'8.0.11')
GO
SET IDENTITY_INSERT [dbo].[MPermissions] ON 

INSERT [dbo].[MPermissions] ([Id], [ModuleName], [ActionName], [Description], [Url], [Icon], [ParentId], [IsMenu], [SequenceNo]) VALUES (1, N'User', N'Index', N'Users', N'/User/List', N'na', 0, 1, 1)
INSERT [dbo].[MPermissions] ([Id], [ModuleName], [ActionName], [Description], [Url], [Icon], [ParentId], [IsMenu], [SequenceNo]) VALUES (2, N'User', N'Create', N'Create', N'/User/Create', N'lj', 1, 0, NULL)
INSERT [dbo].[MPermissions] ([Id], [ModuleName], [ActionName], [Description], [Url], [Icon], [ParentId], [IsMenu], [SequenceNo]) VALUES (3, N'User', N'Edit', N'Edit', N'/User/Edit', N'lkj', 1, 0, NULL)
INSERT [dbo].[MPermissions] ([Id], [ModuleName], [ActionName], [Description], [Url], [Icon], [ParentId], [IsMenu], [SequenceNo]) VALUES (4, N'Role', N'Index', N'Roles', N'/User/List', N'na', 0, 1, 2)
INSERT [dbo].[MPermissions] ([Id], [ModuleName], [ActionName], [Description], [Url], [Icon], [ParentId], [IsMenu], [SequenceNo]) VALUES (5, N'Role', N'Create', N'Create', N'/User/Create', N'lj', 4, 0, NULL)
INSERT [dbo].[MPermissions] ([Id], [ModuleName], [ActionName], [Description], [Url], [Icon], [ParentId], [IsMenu], [SequenceNo]) VALUES (6, N'Role', N'Edit', N'Edit', N'/User/Edit', N'lkj', 4, 0, NULL)
INSERT [dbo].[MPermissions] ([Id], [ModuleName], [ActionName], [Description], [Url], [Icon], [ParentId], [IsMenu], [SequenceNo]) VALUES (7, N'Permissions', N'Index', N'Permissions', N'/User/List', N'na', 0, 1, 3)
INSERT [dbo].[MPermissions] ([Id], [ModuleName], [ActionName], [Description], [Url], [Icon], [ParentId], [IsMenu], [SequenceNo]) VALUES (8, N'Permissions', N'Create', N'Create', N'/User/Create', N'lj', 7, 0, NULL)
INSERT [dbo].[MPermissions] ([Id], [ModuleName], [ActionName], [Description], [Url], [Icon], [ParentId], [IsMenu], [SequenceNo]) VALUES (9, N'Permissions', N'Edit', N'Edit', N'/User/Edit', N'lkj', 7, 0, NULL)
SET IDENTITY_INSERT [dbo].[MPermissions] OFF
GO
SET IDENTITY_INSERT [dbo].[RolePermissons] ON 

INSERT [dbo].[RolePermissons] ([Id], [RoleId], [PermissionId]) VALUES (1, 2, 1)
INSERT [dbo].[RolePermissons] ([Id], [RoleId], [PermissionId]) VALUES (2, 2, 22)
INSERT [dbo].[RolePermissons] ([Id], [RoleId], [PermissionId]) VALUES (3, 2, 3)
INSERT [dbo].[RolePermissons] ([Id], [RoleId], [PermissionId]) VALUES (4, 2, 4)
INSERT [dbo].[RolePermissons] ([Id], [RoleId], [PermissionId]) VALUES (5, 2, 5)
INSERT [dbo].[RolePermissons] ([Id], [RoleId], [PermissionId]) VALUES (6, 2, 6)
INSERT [dbo].[RolePermissons] ([Id], [RoleId], [PermissionId]) VALUES (7, 2, 7)
INSERT [dbo].[RolePermissons] ([Id], [RoleId], [PermissionId]) VALUES (8, 2, 8)
INSERT [dbo].[RolePermissons] ([Id], [RoleId], [PermissionId]) VALUES (9, 2, 9)
SET IDENTITY_INSERT [dbo].[RolePermissons] OFF
GO
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([Id], [Title], [Description]) VALUES (1, N'SuperAdmin', N'SuperAdmin')
INSERT [dbo].[Roles] ([Id], [Title], [Description]) VALUES (2, N'Admin', N'Admin')
INSERT [dbo].[Roles] ([Id], [Title], [Description]) VALUES (3, N'Supervisor', N'Supervisor')
INSERT [dbo].[Roles] ([Id], [Title], [Description]) VALUES (4, N'Operator', N'Operator')
INSERT [dbo].[Roles] ([Id], [Title], [Description]) VALUES (5, N'arole9', N'arole descript9')
SET IDENTITY_INSERT [dbo].[Roles] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [FullName], [Email], [Password], [RolesId]) VALUES (1, N'superadmin', N'sa@a.com', N'a', 1)
INSERT [dbo].[Users] ([Id], [FullName], [Email], [Password], [RolesId]) VALUES (2, N'admin', N'a@a.com', N'a', 2)
INSERT [dbo].[Users] ([Id], [FullName], [Email], [Password], [RolesId]) VALUES (3, N'operator', N'o@a.com', N'a', 4)
INSERT [dbo].[Users] ([Id], [FullName], [Email], [Password], [RolesId]) VALUES (4, N'supervisor', N'su@a.com', N'a', 3)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
/****** Object:  Index [IX_Users_RolesId]    Script Date: 03-08-2025 22:44:25 ******/
CREATE NONCLUSTERED INDEX [IX_Users_RolesId] ON [dbo].[Users]
(
	[RolesId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Roles_RolesId] FOREIGN KEY([RolesId])
REFERENCES [dbo].[Roles] ([Id])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Roles_RolesId]
GO
USE [master]
GO
ALTER DATABASE [bp_custome_authorization] SET  READ_WRITE 
GO
