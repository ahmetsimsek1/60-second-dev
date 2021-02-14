set nocount on;

if object_id('dbo.Teams') is not null drop table dbo.Teams;
go
create table dbo.Teams (
    TeamID uniqueidentifier not null primary key default (newsequentialid())
    ,TeamName nvarchar(100) not null);
go

if object_id('dbo.AddTeam') is not null drop procedure dbo.AddTeam;
go
create procedure dbo.AddTeam (@TeamName nvarchar(100))
as
begin
    declare @newTeamID table (TeamID uniqueidentifier);
    insert dbo.Teams (TeamName)
    output inserted.TeamID into @newTeamID
    values (@TeamName);
    select TeamID from @newTeamID;
end;
go

exec dbo.AddTeam 'Cardinals';
