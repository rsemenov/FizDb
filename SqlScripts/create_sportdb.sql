USE [master]
GO
/****** Object:  Database [Sportdb]    Script Date: 10/11/2012 19:33:40 ******/
CREATE DATABASE [Sportdb] 
GO
ALTER DATABASE [Sportdb] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Sportdb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Sportdb] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [Sportdb] SET ANSI_NULLS OFF
GO
ALTER DATABASE [Sportdb] SET ANSI_PADDING OFF
GO
ALTER DATABASE [Sportdb] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [Sportdb] SET ARITHABORT OFF
GO
ALTER DATABASE [Sportdb] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [Sportdb] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [Sportdb] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [Sportdb] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [Sportdb] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [Sportdb] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [Sportdb] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [Sportdb] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [Sportdb] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [Sportdb] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [Sportdb] SET  DISABLE_BROKER
GO
ALTER DATABASE [Sportdb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [Sportdb] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [Sportdb] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [Sportdb] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [Sportdb] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [Sportdb] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [Sportdb] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [Sportdb] SET  READ_WRITE
GO
ALTER DATABASE [Sportdb] SET RECOVERY FULL
GO
ALTER DATABASE [Sportdb] SET  MULTI_USER
GO
ALTER DATABASE [Sportdb] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [Sportdb] SET DB_CHAINING OFF
GO
EXEC sys.sp_db_vardecimal_storage_format N'Sportdb', N'ON'
GO
USE [Sportdb]
GO
/****** Object:  User [NT AUTHORITY\SYSTEM]    Script Date: 10/11/2012 19:33:40 ******/
CREATE USER [NT AUTHORITY\SYSTEM] FOR LOGIN [NT AUTHORITY\SYSTEM] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[Groups]    Script Date: 10/11/2012 19:33:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Groups](
	[Id] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[Title] [nvarchar](500) NOT NULL,
	[Webpage] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_Groups] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Groups] ON
INSERT [dbo].[Groups] ([Id], [Title], [Webpage]) VALUES (2, N'Маг1Інф', N'www.')
SET IDENTITY_INSERT [dbo].[Groups] OFF
/****** Object:  Table [dbo].[Faculties]    Script Date: 10/11/2012 19:33:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Faculties](
	[Id] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[DeanName] [nvarchar](500) NOT NULL,
	[Address] [nvarchar](500) NULL,
	[Phone] [nvarchar](500) NULL,
 CONSTRAINT [PK_Faculties] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Faculties] ON
INSERT [dbo].[Faculties] ([Id], [Name], [DeanName], [Address], [Phone]) VALUES (1, N'Кібернетика', N'Анісімов А.В.', N'вул. Глушкова 2', NULL)
INSERT [dbo].[Faculties] ([Id], [Name], [DeanName], [Address], [Phone]) VALUES (2, N'Соціологія', N'Хтось', NULL, NULL)
SET IDENTITY_INSERT [dbo].[Faculties] OFF
/****** Object:  Table [dbo].[DaysOfWeek]    Script Date: 10/11/2012 19:33:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DaysOfWeek](
	[Day] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_DaysOfWeek] PRIMARY KEY CLUSTERED 
(
	[Day] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[DaysOfWeek] ([Day]) VALUES (N'ВТ')
INSERT [dbo].[DaysOfWeek] ([Day]) VALUES (N'НД')
INSERT [dbo].[DaysOfWeek] ([Day]) VALUES (N'ПН')
INSERT [dbo].[DaysOfWeek] ([Day]) VALUES (N'ПТ')
INSERT [dbo].[DaysOfWeek] ([Day]) VALUES (N'СБ')
INSERT [dbo].[DaysOfWeek] ([Day]) VALUES (N'СР')
INSERT [dbo].[DaysOfWeek] ([Day]) VALUES (N'ЧТ')
/****** Object:  Table [dbo].[Courses]    Script Date: 10/11/2012 19:33:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Courses](
	[Id] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[Title] [nvarchar](500) NOT NULL,
 CONSTRAINT [PK_Courses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Classrooms]    Script Date: 10/11/2012 19:33:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Classrooms](
	[Id] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[Number] [nvarchar](50) NOT NULL,
	[MaxPeople] [nvarchar](50) NOT NULL,
	[BuildingAddress] [nvarchar](500) NULL,
 CONSTRAINT [PK_Classrooms] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ClassNumbers]    Script Date: 10/11/2012 19:33:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClassNumbers](
	[ClassNumber] [int] NOT NULL,
	[StartTime] [time](7) NOT NULL,
	[FinishTime] [time](7) NOT NULL,
 CONSTRAINT [PK_ClassNumbers] PRIMARY KEY CLUSTERED 
(
	[ClassNumber] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[ClassNumbers] ([ClassNumber], [StartTime], [FinishTime]) VALUES (1, CAST(0x070030A6A4480000 AS Time), CAST(0x07002A1DEA550000 AS Time))
INSERT [dbo].[ClassNumbers] ([ClassNumber], [StartTime], [FinishTime]) VALUES (2, CAST(0x0700A25EB5580000 AS Time), CAST(0x07009CD5FA650000 AS Time))
INSERT [dbo].[ClassNumbers] ([ClassNumber], [StartTime], [FinishTime]) VALUES (3, CAST(0x0700587660670000 AS Time), CAST(0x070052EDA5740000 AS Time))
/****** Object:  Table [dbo].[Sections]    Script Date: 10/11/2012 19:33:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sections](
	[Id] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_Sections] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Sections] ON
INSERT [dbo].[Sections] ([Id], [Name], [Description]) VALUES (1, N'Плавання', NULL)
INSERT [dbo].[Sections] ([Id], [Name], [Description]) VALUES (2, N'Біг', NULL)
SET IDENTITY_INSERT [dbo].[Sections] OFF
/****** Object:  Table [dbo].[Teachers]    Script Date: 10/11/2012 19:33:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teachers](
	[Id] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[Name] [nvarchar](500) NOT NULL,
	[DateOfBirth] [datetime] NOT NULL,
	[Degree] [int] NOT NULL,
	[WorkFrom] [datetime] NULL,
	[Address] [nvarchar](500) NULL,
	[Phone] [nvarchar](500) NULL,
 CONSTRAINT [PK_Teachers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Competitions]    Script Date: 10/11/2012 19:33:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Competitions](
	[Id] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[Name] [nvarchar](500) NOT NULL,
	[SectionId] [int] NOT NULL,
	[StartDateTime] [datetime] NOT NULL,
	[Address] [nvarchar](500) NULL,
 CONSTRAINT [PK_Competitions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Competitions] ON
INSERT [dbo].[Competitions] ([Id], [Name], [SectionId], [StartDateTime], [Address]) VALUES (1, N'Змагання з плавання', 1, CAST(0x0000A12500000000 AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[Competitions] OFF
/****** Object:  Table [dbo].[Students]    Script Date: 10/11/2012 19:33:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Students](
	[Id] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[Name] [nvarchar](500) NOT NULL,
	[Faculty] [int] NOT NULL,
	[Course] [int] NOT NULL,
	[GroupId] [int] NOT NULL,
	[Address] [nvarchar](500) NULL,
	[Phone] [nvarchar](500) NULL,
 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SectionsTeachers]    Script Date: 10/11/2012 19:33:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SectionsTeachers](
	[Id] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[SectionId] [int] NOT NULL,
	[TeacherId] [int] NOT NULL,
 CONSTRAINT [PK_SectionsTeachers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Scheduler]    Script Date: 10/11/2012 19:33:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Scheduler](
	[Id] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[SectionId] [int] NOT NULL,
	[TeacherId] [int] NOT NULL,
	[ClassroomId] [int] NOT NULL,
	[GroupId] [int] NOT NULL,
	[DayOfWeek] [nvarchar](50) NOT NULL,
	[ClassNumberId] [int] NOT NULL,
 CONSTRAINT [PK_Scheduler] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CompetitionsStudents]    Script Date: 10/11/2012 19:33:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CompetitionsStudents](
	[Id] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[CompetitionId] [int] NOT NULL,
	[StudentId] [int] NOT NULL,
	[Result] [nvarchar](500) NULL,
	[Additional] [nvarchar](500) NULL,
 CONSTRAINT [PK_CompetitionsStudents] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  DdlTrigger [tr_MStran_alterschemaonly]    Script Date: 10/11/2012 19:33:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create trigger [tr_MStran_alterschemaonly] on database for ALTER_FUNCTION, ALTER_PROCEDURE as 

							set ANSI_NULLS ON
							set ANSI_PADDING ON
							set ANSI_WARNINGS ON
							set ARITHABORT ON
							set CONCAT_NULL_YIELDS_NULL ON
							set NUMERIC_ROUNDABORT OFF
							set QUOTED_IDENTIFIER ON

							declare @EventData xml
							set @EventData=EventData()    
							exec sys.sp_MStran_ddlrepl @EventData, 3
GO
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
DISABLE TRIGGER [tr_MStran_alterschemaonly] ON DATABASE
GO
/****** Object:  DdlTrigger [tr_MStran_altertable]    Script Date: 10/11/2012 19:33:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create trigger [tr_MStran_altertable] on database for ALTER_TABLE as 

							set ANSI_NULLS ON
							set ANSI_PADDING ON
							set ANSI_WARNINGS ON
							set ARITHABORT ON
							set CONCAT_NULL_YIELDS_NULL ON
							set NUMERIC_ROUNDABORT OFF
							set QUOTED_IDENTIFIER ON

							declare @EventData xml
							set @EventData=EventData()    
							exec sys.sp_MStran_ddlrepl @EventData, 1
GO
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
DISABLE TRIGGER [tr_MStran_altertable] ON DATABASE
GO
/****** Object:  DdlTrigger [tr_MStran_altertrigger]    Script Date: 10/11/2012 19:33:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create trigger [tr_MStran_altertrigger] on database for ALTER_TRIGGER as 

							set ANSI_NULLS ON
							set ANSI_PADDING ON
							set ANSI_WARNINGS ON
							set ARITHABORT ON
							set CONCAT_NULL_YIELDS_NULL ON
							set NUMERIC_ROUNDABORT OFF
							set QUOTED_IDENTIFIER ON

							declare @EventData xml
							set @EventData=EventData()    
							exec sys.sp_MStran_ddlrepl @EventData, 4
GO
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
DISABLE TRIGGER [tr_MStran_altertrigger] ON DATABASE
GO
/****** Object:  DdlTrigger [tr_MStran_alterview]    Script Date: 10/11/2012 19:33:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create trigger [tr_MStran_alterview] on database for ALTER_VIEW as 

							set ANSI_NULLS ON
							set ANSI_PADDING ON
							set ANSI_WARNINGS ON
							set ARITHABORT ON
							set CONCAT_NULL_YIELDS_NULL ON
							set NUMERIC_ROUNDABORT OFF
							set QUOTED_IDENTIFIER ON

							declare @EventData xml
							set @EventData=EventData()    
							exec sys.sp_MStran_ddlrepl @EventData, 2
GO
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
DISABLE TRIGGER [tr_MStran_alterview] ON DATABASE
GO
/****** Object:  ForeignKey [FK_Competitions_Sections]    Script Date: 10/11/2012 19:33:41 ******/
ALTER TABLE [dbo].[Competitions]  WITH CHECK ADD  CONSTRAINT [FK_Competitions_Sections] FOREIGN KEY([SectionId])
REFERENCES [dbo].[Sections] ([Id])
GO
ALTER TABLE [dbo].[Competitions] CHECK CONSTRAINT [FK_Competitions_Sections]
GO
/****** Object:  ForeignKey [FK_Students_Courses]    Script Date: 10/11/2012 19:33:41 ******/
ALTER TABLE [dbo].[Students]  WITH CHECK ADD  CONSTRAINT [FK_Students_Courses] FOREIGN KEY([Course])
REFERENCES [dbo].[Courses] ([Id])
GO
ALTER TABLE [dbo].[Students] CHECK CONSTRAINT [FK_Students_Courses]
GO
/****** Object:  ForeignKey [FK_Students_Faculties]    Script Date: 10/11/2012 19:33:41 ******/
ALTER TABLE [dbo].[Students]  WITH CHECK ADD  CONSTRAINT [FK_Students_Faculties] FOREIGN KEY([Faculty])
REFERENCES [dbo].[Faculties] ([Id])
GO
ALTER TABLE [dbo].[Students] CHECK CONSTRAINT [FK_Students_Faculties]
GO
/****** Object:  ForeignKey [FK_Students_Groups]    Script Date: 10/11/2012 19:33:41 ******/
ALTER TABLE [dbo].[Students]  WITH CHECK ADD  CONSTRAINT [FK_Students_Groups] FOREIGN KEY([GroupId])
REFERENCES [dbo].[Groups] ([Id])
GO
ALTER TABLE [dbo].[Students] CHECK CONSTRAINT [FK_Students_Groups]
GO
/****** Object:  ForeignKey [FK_SectionsTeachers_Sections]    Script Date: 10/11/2012 19:33:41 ******/
ALTER TABLE [dbo].[SectionsTeachers]  WITH CHECK ADD  CONSTRAINT [FK_SectionsTeachers_Sections] FOREIGN KEY([SectionId])
REFERENCES [dbo].[Sections] ([Id])
GO
ALTER TABLE [dbo].[SectionsTeachers] CHECK CONSTRAINT [FK_SectionsTeachers_Sections]
GO
/****** Object:  ForeignKey [FK_SectionsTeachers_Teachers]    Script Date: 10/11/2012 19:33:41 ******/
ALTER TABLE [dbo].[SectionsTeachers]  WITH CHECK ADD  CONSTRAINT [FK_SectionsTeachers_Teachers] FOREIGN KEY([TeacherId])
REFERENCES [dbo].[Teachers] ([Id])
GO
ALTER TABLE [dbo].[SectionsTeachers] CHECK CONSTRAINT [FK_SectionsTeachers_Teachers]
GO
/****** Object:  ForeignKey [FK_Scheduler_ClassNumbers]    Script Date: 10/11/2012 19:33:41 ******/
ALTER TABLE [dbo].[Scheduler]  WITH CHECK ADD  CONSTRAINT [FK_Scheduler_ClassNumbers] FOREIGN KEY([ClassNumberId])
REFERENCES [dbo].[ClassNumbers] ([ClassNumber])
GO
ALTER TABLE [dbo].[Scheduler] CHECK CONSTRAINT [FK_Scheduler_ClassNumbers]
GO
/****** Object:  ForeignKey [FK_Scheduler_Classrooms]    Script Date: 10/11/2012 19:33:41 ******/
ALTER TABLE [dbo].[Scheduler]  WITH CHECK ADD  CONSTRAINT [FK_Scheduler_Classrooms] FOREIGN KEY([ClassroomId])
REFERENCES [dbo].[Classrooms] ([Id])
GO
ALTER TABLE [dbo].[Scheduler] CHECK CONSTRAINT [FK_Scheduler_Classrooms]
GO
/****** Object:  ForeignKey [FK_Scheduler_DaysOfWeek]    Script Date: 10/11/2012 19:33:41 ******/
ALTER TABLE [dbo].[Scheduler]  WITH CHECK ADD  CONSTRAINT [FK_Scheduler_DaysOfWeek] FOREIGN KEY([DayOfWeek])
REFERENCES [dbo].[DaysOfWeek] ([Day])
GO
ALTER TABLE [dbo].[Scheduler] CHECK CONSTRAINT [FK_Scheduler_DaysOfWeek]
GO
/****** Object:  ForeignKey [FK_Scheduler_Groups]    Script Date: 10/11/2012 19:33:41 ******/
ALTER TABLE [dbo].[Scheduler]  WITH CHECK ADD  CONSTRAINT [FK_Scheduler_Groups] FOREIGN KEY([GroupId])
REFERENCES [dbo].[Groups] ([Id])
GO
ALTER TABLE [dbo].[Scheduler] CHECK CONSTRAINT [FK_Scheduler_Groups]
GO
/****** Object:  ForeignKey [FK_Scheduler_Sections]    Script Date: 10/11/2012 19:33:41 ******/
ALTER TABLE [dbo].[Scheduler]  WITH CHECK ADD  CONSTRAINT [FK_Scheduler_Sections] FOREIGN KEY([SectionId])
REFERENCES [dbo].[Sections] ([Id])
GO
ALTER TABLE [dbo].[Scheduler] CHECK CONSTRAINT [FK_Scheduler_Sections]
GO
/****** Object:  ForeignKey [FK_Scheduler_Teachers]    Script Date: 10/11/2012 19:33:41 ******/
ALTER TABLE [dbo].[Scheduler]  WITH CHECK ADD  CONSTRAINT [FK_Scheduler_Teachers] FOREIGN KEY([TeacherId])
REFERENCES [dbo].[Teachers] ([Id])
GO
ALTER TABLE [dbo].[Scheduler] CHECK CONSTRAINT [FK_Scheduler_Teachers]
GO
/****** Object:  ForeignKey [FK_CompetitionsStudents_Competitions]    Script Date: 10/11/2012 19:33:41 ******/
ALTER TABLE [dbo].[CompetitionsStudents]  WITH CHECK ADD  CONSTRAINT [FK_CompetitionsStudents_Competitions] FOREIGN KEY([CompetitionId])
REFERENCES [dbo].[Competitions] ([Id])
GO
ALTER TABLE [dbo].[CompetitionsStudents] CHECK CONSTRAINT [FK_CompetitionsStudents_Competitions]
GO
/****** Object:  ForeignKey [FK_CompetitionsStudents_Students]    Script Date: 10/11/2012 19:33:41 ******/
ALTER TABLE [dbo].[CompetitionsStudents]  WITH CHECK ADD  CONSTRAINT [FK_CompetitionsStudents_Students] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Students] ([Id])
GO
ALTER TABLE [dbo].[CompetitionsStudents] CHECK CONSTRAINT [FK_CompetitionsStudents_Students]
GO
/****** Object:  DdlTrigger [tr_MStran_alterschemaonly]    Script Date: 10/11/2012 19:33:42 ******/
Enable Trigger [tr_MStran_alterschemaonly] ON Database
GO
/****** Object:  DdlTrigger [tr_MStran_altertable]    Script Date: 10/11/2012 19:33:42 ******/
Enable Trigger [tr_MStran_altertable] ON Database
GO
/****** Object:  DdlTrigger [tr_MStran_altertrigger]    Script Date: 10/11/2012 19:33:42 ******/
Enable Trigger [tr_MStran_altertrigger] ON Database
GO
/****** Object:  DdlTrigger [tr_MStran_alterview]    Script Date: 10/11/2012 19:33:42 ******/
Enable Trigger [tr_MStran_alterview] ON Database
GO
