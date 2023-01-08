use School
select Personel.Fname, Personel.Lname, Work.Work, Year(Cast(GetDate() as Date)) - Year(Personel.WorkStart) as 'Years worked' from Personel
left join Work
on Personel.WorkId = Work.Workid;

