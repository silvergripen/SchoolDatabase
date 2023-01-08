use school
go
create procedure dbo.insertPersonel @Fname nvarchar(50), @Lname nvarchar(50), @Bday date, @workid int, @workstart date
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