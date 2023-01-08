create procedure SumarSalary
as
select work.Work, floor(sum(Personel.Salary)) as 'Avg Salary' from Personel
inner join Work on Personel.WorkId = Work.Workid

group by Work.Work;