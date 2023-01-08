USE [School]
GO
/****** Object:  StoredProcedure [dbo].[InputGrade]    Script Date: 1/5/2023 11:23:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[InputGrade] @SubjectId int, @StudentId int, @GradeSetId int
as
begin try
begin transaction;
declare @dt date = getDate()
Save tran BeforeInput
insert into Grade(
         Subjectid, Studentid, Grade, Dateset)
		 values(@SubjectId, @StudentId,@GradeSetId, @dt)
		 end try
begin catch
   print 'There was an error please try again'
	end catch