/* Data to insert:

Team1Score Team2Score GameDate     AddDate           _StartDateTime
  100        99       2021-02-01   2021-02-01 16:30  2021-02-01 16:30
  85         84       2021-02-02   2021-02-02 18:30  2021-02-02 18:30
*/

alter table dbo.Games set (system_versioning = off);
go

alter table dbo.Games drop period for system_time;
go

insert dbo.Games (
    Team1Score, Team2Score, GameDate, AddDate, _StartDateTime, _EndDateTime
) values (
    100, 99, '2021-02-01', '2021-02-01 16:30', '2021-02-01 16:30', '9999-12-31 23:59:59.9999999'
), (
    85, 84, '2021-02-02', '2021-02-02 18:30', '2021-02-02 18:30', '9999-12-31 23:59:59.9999999'
);
go

alter table dbo.Games add period for system_time (_StartDateTime, _EndDateTime);
go

alter table dbo.Games set (system_versioning = on (history_table = dbo.GamesHistory, data_consistency_check = on));
go
