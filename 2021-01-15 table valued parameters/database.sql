if object_id('dbo.AddMovies') is not null drop procedure dbo.AddMovies;
if object_id('dbo.Movies') is not null drop table dbo.Movies;
if type_id('dbo.MovieType') is not null drop type dbo.MovieType;
create table dbo.Movies (
    MovieID int not null identity
    ,Title nvarchar(100) not null
    ,ReleaseDate date not null
    ,Rating tinyint null
);
go
create type dbo.MovieType as table (
    Title nvarchar(100) not null
    ,ReleaseDate date not null
    ,Rating tinyint null
);
go
create procedure dbo.AddMovies (
    @Movies dbo.MovieType readonly
)
as
begin
    insert dbo.Movies (Title, ReleaseDate, Rating)
    select Title, ReleaseDate, Rating from @Movies;
end;
go

select * from dbo.Movies;
