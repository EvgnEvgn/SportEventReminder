USE [SportEventReminderDb]
GO

select * from dbo.Match 
where leagueid = 302 

select * from dbo.Leagues where name like '%Premier League%'

select * from dbo.Areas where id = 244


select * from dbo.ExternalSourceIntegrations where objectid = 302

delete from  dbo.Match


select * from dbo.match order by StartDate desc