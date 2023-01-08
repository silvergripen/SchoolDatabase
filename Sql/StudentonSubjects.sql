select Student.Fname, Student.Lname, Subjects.Subject_name from StudentSubject
left join Subjects on StudentSubject.Subjectid = Subjects.Subjectid
left join Student on StudentSubject.studentid = Student.StudentID

