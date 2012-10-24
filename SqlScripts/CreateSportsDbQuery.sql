USE [master]
GO

/****** Object:  Database [Sportdb]    Script Date: 10/10/2012 16:54:34 ******/
CREATE DATABASE [Sport1db] ON  PRIMARY 
( NAME = N'Sport1db', FILENAME = N'D:\SQL Server\Data\Sport1db.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Sport1db_log', FILENAME = N'D:\SQL Server\Data\Sport1db_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO

ALTER DATABASE [Sport1db] SET COMPATIBILITY_LEVEL = 100
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Sportdb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

USE [Sport1db]
GO

/****** Object:  Table [dbo].[ClassNumbers]    Script Date: 10/10/2012 16:48:18 ******/
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

/****** Object:  Table [dbo].[Classrooms]    Script Date: 10/10/2012 16:48:42 ******/
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

/****** Object:  Table [dbo].[Sections]    Script Date: 10/10/2012 16:49:12 ******/
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

/****** Object:  Table [dbo].[Competitions]    Script Date: 10/10/2012 16:49:49 ******/
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

ALTER TABLE [dbo].[Competitions]  WITH CHECK ADD  CONSTRAINT [FK_Competitions_Sections] FOREIGN KEY([SectionId])
REFERENCES [dbo].[Sections] ([Id])
GO

ALTER TABLE [dbo].[Competitions] CHECK CONSTRAINT [FK_Competitions_Sections]
GO

/****** Object:  Table [dbo].[Courses]    Script Date: 10/10/2012 16:50:21 ******/
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

/****** Object:  Table [dbo].[Faculties]    Script Date: 10/10/2012 16:50:34 ******/
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

/****** Object:  Table [dbo].[Groups]    Script Date: 10/10/2012 16:50:47 ******/
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

/****** Object:  Table [dbo].[Students]    Script Date: 10/10/2012 16:51:12 ******/
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

ALTER TABLE [dbo].[Students]  WITH CHECK ADD  CONSTRAINT [FK_Students_Courses] FOREIGN KEY([Course])
REFERENCES [dbo].[Courses] ([Id])
GO

ALTER TABLE [dbo].[Students] CHECK CONSTRAINT [FK_Students_Courses]
GO

ALTER TABLE [dbo].[Students]  WITH CHECK ADD  CONSTRAINT [FK_Students_Faculties] FOREIGN KEY([Faculty])
REFERENCES [dbo].[Faculties] ([Id])
GO

ALTER TABLE [dbo].[Students] CHECK CONSTRAINT [FK_Students_Faculties]
GO

ALTER TABLE [dbo].[Students]  WITH CHECK ADD  CONSTRAINT [FK_Students_Groups] FOREIGN KEY([GroupId])
REFERENCES [dbo].[Groups] ([Id])
GO

ALTER TABLE [dbo].[Students] CHECK CONSTRAINT [FK_Students_Groups]
GO

/****** Object:  Table [dbo].[CompetitionsStudents]    Script Date: 10/10/2012 16:51:25 ******/
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

ALTER TABLE [dbo].[CompetitionsStudents]  WITH CHECK ADD  CONSTRAINT [FK_CompetitionsStudents_Competitions] FOREIGN KEY([CompetitionId])
REFERENCES [dbo].[Competitions] ([Id])
GO

ALTER TABLE [dbo].[CompetitionsStudents] CHECK CONSTRAINT [FK_CompetitionsStudents_Competitions]
GO

ALTER TABLE [dbo].[CompetitionsStudents]  WITH CHECK ADD  CONSTRAINT [FK_CompetitionsStudents_Students] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Students] ([Id])
GO

ALTER TABLE [dbo].[CompetitionsStudents] CHECK CONSTRAINT [FK_CompetitionsStudents_Students]
GO

/****** Object:  Table [dbo].[DaysOfWeek]    Script Date: 10/10/2012 16:52:04 ******/
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


/****** Object:  Table [dbo].[Teachers]    Script Date: 10/10/2012 16:52:34 ******/
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


/****** Object:  Table [dbo].[SectionsTeachers]    Script Date: 10/10/2012 16:53:24 ******/
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

ALTER TABLE [dbo].[SectionsTeachers]  WITH CHECK ADD  CONSTRAINT [FK_SectionsTeachers_Sections] FOREIGN KEY([SectionId])
REFERENCES [dbo].[Sections] ([Id])
GO

ALTER TABLE [dbo].[SectionsTeachers] CHECK CONSTRAINT [FK_SectionsTeachers_Sections]
GO

ALTER TABLE [dbo].[SectionsTeachers]  WITH CHECK ADD  CONSTRAINT [FK_SectionsTeachers_Teachers] FOREIGN KEY([TeacherId])
REFERENCES [dbo].[Teachers] ([Id])
GO

ALTER TABLE [dbo].[SectionsTeachers] CHECK CONSTRAINT [FK_SectionsTeachers_Teachers]
GO

/****** Object:  Table [dbo].[Scheduler]    Script Date: 10/10/2012 16:53:41 ******/
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

ALTER TABLE [dbo].[Scheduler]  WITH CHECK ADD  CONSTRAINT [FK_Scheduler_ClassNumbers] FOREIGN KEY([ClassNumberId])
REFERENCES [dbo].[ClassNumbers] ([ClassNumber])
GO

ALTER TABLE [dbo].[Scheduler] CHECK CONSTRAINT [FK_Scheduler_ClassNumbers]
GO

ALTER TABLE [dbo].[Scheduler]  WITH CHECK ADD  CONSTRAINT [FK_Scheduler_Classrooms] FOREIGN KEY([ClassroomId])
REFERENCES [dbo].[Classrooms] ([Id])
GO

ALTER TABLE [dbo].[Scheduler] CHECK CONSTRAINT [FK_Scheduler_Classrooms]
GO

ALTER TABLE [dbo].[Scheduler]  WITH CHECK ADD  CONSTRAINT [FK_Scheduler_DaysOfWeek] FOREIGN KEY([DayOfWeek])
REFERENCES [dbo].[DaysOfWeek] ([Day])
GO

ALTER TABLE [dbo].[Scheduler] CHECK CONSTRAINT [FK_Scheduler_DaysOfWeek]
GO

ALTER TABLE [dbo].[Scheduler]  WITH CHECK ADD  CONSTRAINT [FK_Scheduler_Groups] FOREIGN KEY([GroupId])
REFERENCES [dbo].[Groups] ([Id])
GO

ALTER TABLE [dbo].[Scheduler] CHECK CONSTRAINT [FK_Scheduler_Groups]
GO

ALTER TABLE [dbo].[Scheduler]  WITH CHECK ADD  CONSTRAINT [FK_Scheduler_Sections] FOREIGN KEY([SectionId])
REFERENCES [dbo].[Sections] ([Id])
GO

ALTER TABLE [dbo].[Scheduler] CHECK CONSTRAINT [FK_Scheduler_Sections]
GO

ALTER TABLE [dbo].[Scheduler]  WITH CHECK ADD  CONSTRAINT [FK_Scheduler_Teachers] FOREIGN KEY([TeacherId])
REFERENCES [dbo].[Teachers] ([Id])
GO

ALTER TABLE [dbo].[Scheduler] CHECK CONSTRAINT [FK_Scheduler_Teachers]
GO



