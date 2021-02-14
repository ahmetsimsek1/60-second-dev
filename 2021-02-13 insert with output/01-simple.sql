declare @Teams table (TeamID int not null, TeamName nvarchar(100) not null);

declare @newTeamNames table (TeamName nvarchar(100) not null);

insert @Teams (TeamID, TeamName)
output inserted.TeamName into @newTeamNames
values (1, 'Cardinals'), (2, 'Suns'), (3, 'Coyotes'), (4, 'Diamondbacks');

select * from @newTeamNames;
