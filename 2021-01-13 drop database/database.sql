if exists (select 1 from sys.databases where [name] = 'PolkaJukebox')
begin
    use master;
    alter database PolkaJukebox set single_user with rollback immediate;
    drop database PolkaJukebox;
end;
go

create database PolkaJukebox;
go
use PolkaJukebox;
go
create table dbo.Songs (SongID int not null primary key identity, SongTitle nvarchar(50) not null);
go
create procedure dbo.AddSong(@SongTitle nvarchar(50)) as insert dbo.Songs (SongTitle) values (@SongTitle);
go
exec dbo.AddSong 'Pennsylvania Polka';
exec dbo.AddSong 'Five Card Draw Polka';
go
