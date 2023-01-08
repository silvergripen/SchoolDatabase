create procedure dbo.SetGradestud (@Subjectid int, 
                                @Studentid int, 
								@Dateset date, 
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