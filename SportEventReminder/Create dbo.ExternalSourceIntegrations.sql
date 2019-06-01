USE [SportEventReminderDb]
GO

select * from dbo.Match 
where leagueid = 302 

select * from dbo.Leagues 

select * from dbo.Areas where id = 244


select * from dbo.ExternalSourceIntegrations where objectid = 302

delete from  dbo.Match


select * from dbo.match where status = 1 order by StartDate

select * from dbo.Leagues where id in (308, 191, 260, 284, 311, 187)
select distinct LeagueId  from dbo.match

delete from dbo.Areas
delete from dbo.ExternalSourceIntegrations
delete from dbo.Leagues
delete from dbo.Teams
delete from dbo.Match
delete from dbo.Seasons

SELECT      sys.databases.name,  
            CONVERT(VARCHAR,SUM(size)*8/1024)+' MB' AS [Total disk space]  
FROM        sys.databases   
JOIN        sys.master_files  
ON          sys.databases.database_id=sys.master_files.database_id  
GROUP BY    sys.databases.name  
ORDER BY    sys.databases.name 

exec sp_spaceused  