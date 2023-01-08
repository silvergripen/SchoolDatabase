create procedure GetAllGradeWTeach
as
select Student.Fname, Student.Lname, Grade.Dateset, GradeSet.Grade, Subjects.Subject_name, Grade.TeacherSetID
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

