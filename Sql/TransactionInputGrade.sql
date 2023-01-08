create procedure dbo.InputGrade @SubjectId int, @StudentId int, @GradeSetId int
as
begin try
begin transaction;
Save tran BeforeInput
insert into Grade(
         Subjectid, Studentid, Grade)
		 values(@SubjectId, @StudentId,@GradeSetId)
		 end try
begin catch
   print 'There was an error please try again'
	end catch