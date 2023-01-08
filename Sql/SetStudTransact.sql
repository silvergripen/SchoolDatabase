USE [School]
GO
/****** Object:  StoredProcedure [dbo].[InputGrade]    Script Date: 1/6/2023 2:33:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[InputGrade] @SubjectId int, @StudentId int, @GradeSetId int, @TeacherSetID int
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