create procedure dbo.GetSpecificStudent @Id int
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