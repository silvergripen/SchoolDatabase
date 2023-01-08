Create procedure dbo.AvgSalary
as
select work.Work, floor(avg(Personel.Salary)) as 'Avg Salary' from Personel
inner join Work on Personel.WorkId = Work.Workid

group by Work.Work;
