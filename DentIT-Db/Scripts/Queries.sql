with U as(
Select ID_Patients, ID_Doctors, StartDateTime,
Rank() over (Partition By ID_Patients order By StartDateTime Desc) Rnk
From Receptions-- Where StartDateTime >= '2015-01-01' and StartDateTime < '2016-01-01'
--ORder BY ID_Patients, StartDateTime
--Group By ID_Patients
)
Select * From U Where Rnk = 1
Order By ID_Patients