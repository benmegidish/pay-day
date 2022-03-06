select  ((SUM( DATEDIFF(MINUTE ,start_time, End_time)))/60)*35 AS TotalHours
from work_datetime
where user_id=54654654

--SELECT DATEDIFF(hour, start_time, End_time) AS DateDiff
--from work_datetime
--where user_id=4545454

select  SUM(DATEDIFF(MINUTE, start_time, End_time))/60 AS Total from work_datetime where Log_id=33

update mem