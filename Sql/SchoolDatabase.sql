USE [master]
GO
/****** Object:  Database [School]    Script Date: 1/8/2023 1:32:07 PM ******/
CREATE DATABASE [School]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'School', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\School.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'School_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\School_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [School] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [School].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [School] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [School] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [School] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [School] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [School] SET ARITHABORT OFF 
GO
ALTER DATABASE [School] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [School] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [School] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [School] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [School] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [School] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [School] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [School] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [School] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [School] SET  DISABLE_BROKER 
GO
ALTER DATABASE [School] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [School] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [School] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [School] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [School] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [School] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [School] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [School] SET RECOVERY FULL 
GO
ALTER DATABASE [School] SET  MULTI_USER 
GO
ALTER DATABASE [School] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [School] SET DB_CHAINING OFF 
GO
ALTER DATABASE [School] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [School] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [School] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [School] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'School', N'ON'
GO
ALTER DATABASE [School] SET QUERY_STORE = OFF
GO
USE [School]
GO
/****** Object:  Table [dbo].[Personel]    Script Date: 1/8/2023 1:32:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Personel](
	[Jobid] [int] IDENTITY(1,1) NOT NULL,
	[Fname] [nvarchar](50) NOT NULL,
	[Lname] [nvarchar](50) NOT NULL,
	[Bday] [date] NOT NULL,
	[WorkId] [int] NULL,
	[Adressid] [int] NULL,
	[WorkStart] [date] NULL,
	[Salary] [int] NULL,
 CONSTRAINT [PK_Personel] PRIMARY KEY CLUSTERED 
(
	[Jobid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Work]    Script Date: 1/8/2023 1:32:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Work](
	[Workid] [int] IDENTITY(1,1) NOT NULL,
	[Work] [nvarchar](50) NULL,
	[Base Salary] [int] NULL,
 CONSTRAINT [PK_Work] PRIMARY KEY CLUSTERED 
(
	[Workid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[AverageSalary]    Script Date: 1/8/2023 1:32:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[AverageSalary]
as
select work.Work, floor(avg(Personel.Salary)) as 'Avg Salary' from Personel
inner join Work on Personel.WorkId = Work.Workid

group by Work.Work;
GO
/****** Object:  View [dbo].[sumSalary]    Script Date: 1/8/2023 1:32:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create view [dbo].[sumSalary]
as
select work.Work, floor(sum(Personel.Salary)) as 'Avg Salary' from Personel
inner join Work on Personel.WorkId = Work.Workid

group by Work.Work;
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 1/8/2023 1:32:07 PM ******/
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
/****** Object:  Table [dbo].[Adress]    Script Date: 1/8/2023 1:32:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Adress](
	[Adressid] [int] IDENTITY(1,1) NOT NULL,
	[Adress] [nvarchar](50) NOT NULL,
	[County] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Adress] PRIMARY KEY CLUSTERED 
(
	[Adressid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Classes]    Script Date: 1/8/2023 1:32:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Classes](
	[Classid] [int] IDENTITY(1,1) NOT NULL,
	[Subjectid] [int] NOT NULL,
	[StudClassid] [int] NULL,
 CONSTRAINT [PK_Classes] PRIMARY KEY CLUSTERED 
(
	[Classid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Grade]    Script Date: 1/8/2023 1:32:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Grade](
	[GradeId] [int] IDENTITY(1,1) NOT NULL,
	[Subjectid] [int] NULL,
	[Studentid] [int] NULL,
	[Dateset] [date] NULL,
	[Grade] [int] NULL,
	[TeacherSetID] [int] NULL,
 CONSTRAINT [PK_Grade] PRIMARY KEY CLUSTERED 
(
	[GradeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GradeSet]    Script Date: 1/8/2023 1:32:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GradeSet](
	[GradeSetId] [int] IDENTITY(1,1) NOT NULL,
	[Grade] [nchar](10) NULL,
 CONSTRAINT [PK_GradeSet] PRIMARY KEY CLUSTERED 
(
	[GradeSetId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PersonelClasses]    Script Date: 1/8/2023 1:32:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PersonelClasses](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Personelid] [int] NULL,
	[Classid] [int] NULL,
 CONSTRAINT [PK_PersonelClasses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Schedule]    Script Date: 1/8/2023 1:32:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Schedule](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[DayofWeek] [nvarchar](50) NULL,
	[TimeofDay] [time](0) NULL,
	[Classid] [int] NULL,
 CONSTRAINT [PK_Schedule] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Student]    Script Date: 1/8/2023 1:32:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[StudentID] [int] IDENTITY(1,1) NOT NULL,
	[Fname] [nvarchar](50) NOT NULL,
	[Lname] [nvarchar](50) NOT NULL,
	[Bday] [date] NULL,
	[Klassid] [int] NULL,
	[Adressid] [int] NULL,
 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED 
(
	[StudentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StudentClass]    Script Date: 1/8/2023 1:32:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentClass](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClassId] [int] NULL,
	[StudentClassName] [nvarchar](50) NULL,
 CONSTRAINT [PK_StudentClass] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StudentSubject]    Script Date: 1/8/2023 1:32:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentSubject](
	[StudentSubjectId] [int] IDENTITY(1,1) NOT NULL,
	[studentid] [int] NULL,
	[Subjectid] [int] NULL,
 CONSTRAINT [PK_StudentSubject] PRIMARY KEY CLUSTERED 
(
	[StudentSubjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Subjects]    Script Date: 1/8/2023 1:32:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subjects](
	[Subjectid] [int] IDENTITY(1,1) NOT NULL,
	[Subject_name] [nvarchar](50) NOT NULL,
	[Classid] [int] NULL,
	[PersonelId] [int] NULL,
 CONSTRAINT [PK_Subject] PRIMARY KEY CLUSTERED 
(
	[Subjectid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Classes]  WITH CHECK ADD  CONSTRAINT [FK_Classes_StudentClass] FOREIGN KEY([StudClassid])
REFERENCES [dbo].[StudentClass] ([Id])
GO
ALTER TABLE [dbo].[Classes] CHECK CONSTRAINT [FK_Classes_StudentClass]
GO
ALTER TABLE [dbo].[Classes]  WITH CHECK ADD  CONSTRAINT [FK_Classes_Subject] FOREIGN KEY([Subjectid])
REFERENCES [dbo].[Subjects] ([Subjectid])
GO
ALTER TABLE [dbo].[Classes] CHECK CONSTRAINT [FK_Classes_Subject]
GO
ALTER TABLE [dbo].[Grade]  WITH CHECK ADD  CONSTRAINT [FK_Grade_GradeSet] FOREIGN KEY([Grade])
REFERENCES [dbo].[GradeSet] ([GradeSetId])
GO
ALTER TABLE [dbo].[Grade] CHECK CONSTRAINT [FK_Grade_GradeSet]
GO
ALTER TABLE [dbo].[Grade]  WITH CHECK ADD  CONSTRAINT [FK_Grade_Personel] FOREIGN KEY([TeacherSetID])
REFERENCES [dbo].[Personel] ([Jobid])
GO
ALTER TABLE [dbo].[Grade] CHECK CONSTRAINT [FK_Grade_Personel]
GO
ALTER TABLE [dbo].[Grade]  WITH CHECK ADD  CONSTRAINT [FK_Grade_Student] FOREIGN KEY([Studentid])
REFERENCES [dbo].[Student] ([StudentID])
GO
ALTER TABLE [dbo].[Grade] CHECK CONSTRAINT [FK_Grade_Student]
GO
ALTER TABLE [dbo].[Grade]  WITH CHECK ADD  CONSTRAINT [FK_Grade_Subject1] FOREIGN KEY([Subjectid])
REFERENCES [dbo].[Subjects] ([Subjectid])
GO
ALTER TABLE [dbo].[Grade] CHECK CONSTRAINT [FK_Grade_Subject1]
GO
ALTER TABLE [dbo].[Personel]  WITH CHECK ADD  CONSTRAINT [FK_Personel_Adress] FOREIGN KEY([Adressid])
REFERENCES [dbo].[Adress] ([Adressid])
GO
ALTER TABLE [dbo].[Personel] CHECK CONSTRAINT [FK_Personel_Adress]
GO
ALTER TABLE [dbo].[Personel]  WITH CHECK ADD  CONSTRAINT [FK_Personel_Work] FOREIGN KEY([WorkId])
REFERENCES [dbo].[Work] ([Workid])
GO
ALTER TABLE [dbo].[Personel] CHECK CONSTRAINT [FK_Personel_Work]
GO
ALTER TABLE [dbo].[PersonelClasses]  WITH CHECK ADD  CONSTRAINT [FK_PersonelClasses_Classes] FOREIGN KEY([Classid])
REFERENCES [dbo].[Classes] ([Classid])
GO
ALTER TABLE [dbo].[PersonelClasses] CHECK CONSTRAINT [FK_PersonelClasses_Classes]
GO
ALTER TABLE [dbo].[PersonelClasses]  WITH CHECK ADD  CONSTRAINT [FK_PersonelClasses_Personel] FOREIGN KEY([Id])
REFERENCES [dbo].[Personel] ([Jobid])
GO
ALTER TABLE [dbo].[PersonelClasses] CHECK CONSTRAINT [FK_PersonelClasses_Personel]
GO
ALTER TABLE [dbo].[Schedule]  WITH CHECK ADD  CONSTRAINT [FK_Schedule_Classes] FOREIGN KEY([Classid])
REFERENCES [dbo].[Classes] ([Classid])
GO
ALTER TABLE [dbo].[Schedule] CHECK CONSTRAINT [FK_Schedule_Classes]
GO
ALTER TABLE [dbo].[Student]  WITH CHECK ADD  CONSTRAINT [FK_Student_Adress1] FOREIGN KEY([Adressid])
REFERENCES [dbo].[Adress] ([Adressid])
GO
ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [FK_Student_Adress1]
GO
ALTER TABLE [dbo].[Student]  WITH CHECK ADD  CONSTRAINT [FK_Student_StudentClass] FOREIGN KEY([Klassid])
REFERENCES [dbo].[StudentClass] ([Id])
GO
ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [FK_Student_StudentClass]
GO
ALTER TABLE [dbo].[StudentSubject]  WITH CHECK ADD  CONSTRAINT [FK_StudentSubject_Student] FOREIGN KEY([studentid])
REFERENCES [dbo].[Student] ([StudentID])
GO
ALTER TABLE [dbo].[StudentSubject] CHECK CONSTRAINT [FK_StudentSubject_Student]
GO
ALTER TABLE [dbo].[StudentSubject]  WITH CHECK ADD  CONSTRAINT [FK_StudentSubject_Subjects] FOREIGN KEY([Subjectid])
REFERENCES [dbo].[Subjects] ([Subjectid])
GO
ALTER TABLE [dbo].[StudentSubject] CHECK CONSTRAINT [FK_StudentSubject_Subjects]
GO
ALTER TABLE [dbo].[Subjects]  WITH CHECK ADD  CONSTRAINT [FK_Subjects_Personel] FOREIGN KEY([PersonelId])
REFERENCES [dbo].[Personel] ([Jobid])
GO
ALTER TABLE [dbo].[Subjects] CHECK CONSTRAINT [FK_Subjects_Personel]
GO
/****** Object:  StoredProcedure [dbo].[AvgSalary]    Script Date: 1/8/2023 1:32:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[AvgSalary]
as
select work.Work, floor(avg(Personel.Salary)) as 'Avg Salary' from Personel
inner join Work on Personel.WorkId = Work.Workid

group by Work.Work;
GO
/****** Object:  StoredProcedure [dbo].[GetAllGradeWTeach]    Script Date: 1/8/2023 1:32:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GetAllGradeWTeach]
as
select Student.Fname, Student.Lname, Grade.Dateset, GradeSet.Grade, Subjects.Subject_name, Personel.Fname, Personel.Lname
from Grade
inner join Subjects
on Grade.Subjectid  = Subjects.Subjectid
inner join Student
on Grade.Studentid = Student.StudentID
inner join GradeSet
on Grade.Grade = GradeSet.GradeSetId
inner join Personel
on Grade.TeacherSetID = Personel.Jobid
order by Student.Fname

GO
/****** Object:  StoredProcedure [dbo].[GetPersonel]    Script Date: 1/8/2023 1:32:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[GetPersonel]
as
Select Personel.Fname, Personel.Lname, Work.Work
From Personel
Inner Join Work
on Personel.WorkId = Work.Workid;
GO
/****** Object:  StoredProcedure [dbo].[GetpersonelYearsWorked]    Script Date: 1/8/2023 1:32:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[GetpersonelYearsWorked]
as
select Personel.Fname, Personel.Lname, Work.Work, Year(Cast(GetDate() as Date)) - Year(Personel.WorkStart) as 'Years worked' from Personel
left join Work
on Personel.WorkId = Work.Workid;

GO
/****** Object:  StoredProcedure [dbo].[GetSpecificStudent]    Script Date: 1/8/2023 1:32:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[GetSpecificStudent] @Id int
as
begin
select Student.StudentID, Student.Fname, Student.Lname, Student.Bday, Adress.Adress, Adress.County, Grade.Dateset, GradeSet.Grade, Subjects.Subject_name
from Student
join Adress on Student.Adressid = Adress.Adressid
join Grade on Student.StudentID = Grade.Studentid
join GradeSet on Grade.Grade = GradeSet.GradeSetId
join Subjects on Grade.Subjectid = Subjects.Subjectid
where Student.StudentID = @Id
end
GO
/****** Object:  StoredProcedure [dbo].[GetTeachers]    Script Date: 1/8/2023 1:32:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GetTeachers]
as
Select Personel.Jobid, Personel.Fname, Personel.Lname, Work.Work
From Personel
Inner Join Work
on Personel.WorkId = Work.Workid
Where Work = 'Teacher';
GO
/****** Object:  StoredProcedure [dbo].[GradeAvgLowHi]    Script Date: 1/8/2023 1:32:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[GradeAvgLowHi]
as
select Student.Fname, Student.Lname, Grade.Dateset, GradeSet.Grade, Subjects.Subject_name
from Grade
inner join Subjects
on Grade.Subjectid  = Subjects.Subjectid
inner join Student
on Grade.Studentid = Student.StudentID
inner join GradeSet
on Grade.Grade = GradeSet.GradeSetId
where Grade.Grade = (select AVG(GradeSet.GradeSetId) from GradeSet) 
or Grade.Grade = (select MAX(GradeSet.GradeSetId) from GradeSet) 
or Grade.Grade = (select Min(GradeSet.GradeSetId) from GradeSet);
GO
/****** Object:  StoredProcedure [dbo].[GradeDateMonth]    Script Date: 1/8/2023 1:32:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[GradeDateMonth]
as
select Student.Fname, Student.Lname, GradeSet.Grade, Grade.Dateset, Subjects.Subject_name
from Grade
inner join Subjects
on Grade.Subjectid  = Subjects.Subjectid
inner join Student
on Grade.Studentid = Student.StudentID
inner join GradeSet
on Grade.Grade = GradeSet.GradeSetId
where Dateset > Dateadd(Month, -1, Current_timestamp)
GO
/****** Object:  StoredProcedure [dbo].[InputGrade]    Script Date: 1/8/2023 1:32:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[InputGrade] @SubjectId int, @StudentId int, @GradeSetId int, @TeacherSetID int
as
begin try
begin transaction;
declare @dt date = getDate()
Save tran BeforeInput
insert into Grade(
         Subjectid, Studentid, Grade, Dateset, TeacherSetID)
		 values(@SubjectId, @StudentId,@GradeSetId, @dt, @TeacherSetID)
		 end try
begin catch
   print 'There was an error please try again'
	end catch
GO
/****** Object:  StoredProcedure [dbo].[insertPersonel]    Script Date: 1/8/2023 1:32:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[insertPersonel] @Fname nvarchar(50), @Lname nvarchar(50), @Bday varchar(10), @workid int, @workstart varchar(10)
as
begin
    insert into Personel (
	   Fname,
	   Lname,
	   Bday,
	   WorkId,
	   WorkStart)
	   values(@Fname, @Lname, @Bday, @workid, @workstart)
	   end
GO
/****** Object:  StoredProcedure [dbo].[InsertStudent]    Script Date: 1/8/2023 1:32:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[InsertStudent] @Fname nvarchar(50), @Lname nvarchar(50), @Bday varchar(10), @Adress nvarchar(50), @County nvarchar(50)
as
begin
insert into Adress(Adress, County) values( @Adress, @County)
declare @id int
select @id = SCOPE_IDENTITY()
insert into Student(Adressid, Fname, Lname, Bday) values(@id, @Fname, @Lname, @Bday)

end
GO
/****** Object:  StoredProcedure [dbo].[SetGradestud]    Script Date: 1/8/2023 1:32:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SetGradestud] (@Subjectid int, 
                                @Studentid int, 
								@Dateset nvarchar(10), 
								@Grade int, 
								@TeacherSetID int)
as
 begin
     insert into Grade
	            (Subjectid,
				Studentid,
				Dateset,
				Grade,
				TeacherSetID)
	values     (@Subjectid,
	            @Studentid,
				@Dateset,
				@Grade,
				@TeacherSetID);
	end
GO
/****** Object:  StoredProcedure [dbo].[SumarSalary]    Script Date: 1/8/2023 1:32:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[SumarSalary]
as
select work.Work, floor(sum(Personel.Salary)) as 'Avg Salary' from Personel
inner join Work on Personel.WorkId = Work.Workid

group by Work.Work;
GO
USE [master]
GO
ALTER DATABASE [School] SET  READ_WRITE 
GO
