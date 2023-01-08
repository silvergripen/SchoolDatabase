USE [School]
GO
/****** Object:  StoredProcedure [dbo].[InsertStudent]    Script Date: 1/1/2023 2:25:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[InsertStudent] @Fname nvarchar(50), @Lname nvarchar(50), @Bday varchar(10), @Adress nvarchar(50), @County nvarchar(50)
as
begin
insert into Adress(Adress, County) values( @Adress, @County)
declare @id int
select @id = SCOPE_IDENTITY()
insert into Student(Adressid, Fname, Lname, Bday) values(@id, @Fname, @Lname, @Bday)

end