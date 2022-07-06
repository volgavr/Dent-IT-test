--- Приемы ранее 2017 года:
Select ReceptionDate, ID_Doctors, Count(*) N_Receptions
From (
Select ID_Doctors, cast(StartDateTime as Date) as ReceptionDate
From Receptions Where StartDateTime >= '2015-01-01' and StartDateTime < '2016-01-01'
) U
Group By ID_Doctors, ReceptionDate
Order By ReceptionDate, ID_Doctors;


With Receptions_Dated As (
Select ID_Doctors, cast(StartDateTime as Date) as ReceptionDate
From Receptions Where StartDateTime >= '2015-01-01' and StartDateTime < '2016-01-01')
Select ReceptionDate, ID_Doctors, Count(*) N_Receptions
From Receptions_Dated
Group By ID_Doctors, ReceptionDate
Order By ReceptionDate, ID_Doctors;


With U As(
Select ID_Doctors, cast(StartDateTime as Date) as ReceptionDate,
Count(ID_Patients) Over (PARTITION BY ID_Doctors, cast(StartDateTime as Date) ORDER BY ID_Doctors) N_Receptions
From Receptions Where StartDateTime >= '2015-01-01' and StartDateTime < '2016-01-01'
)
Select Distinct ReceptionDate, ID_Doctors, N_Receptions From U
Order By ReceptionDate, ID_Doctors

--- Последний прием по дате:
With U as(
Select ID_Patients, ID_Doctors, StartDateTime,
Rank() over (Partition By ID_Patients order By StartDateTime Desc) Rnk
From Receptions)
Select ID_Patients, ID_Doctors, StartDateTime From U Where Rnk = 1
Order By ID_Patients
