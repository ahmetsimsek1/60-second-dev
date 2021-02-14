set nocount on;

if object_id('dbo.Teams') is not null drop table dbo.Teams;
go
create table dbo.Teams (TeamID int not null identity primary key, TeamName nvarchar(100) not null);
go

if object_id('dbo.AddTeam') is not null drop procedure dbo.AddTeam;
go
create procedure dbo.AddTeam (@TeamName nvarchar(100))
as
begin
    -- insert dbo.Teams (TeamName) values (@TeamName);
    -- select scope_identity() [TeamID];
    -- OR
    declare @newTeamID table (TeamID int);
    insert dbo.Teams (TeamName)
    output inserted.TeamID into @newTeamID
    values (@TeamName);
    select TeamID from @newTeamID;
end;
go

exec dbo.AddTeam 'Cardinals';
