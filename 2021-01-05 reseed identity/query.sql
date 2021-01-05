set nocount on;
if object_id('dbo.Something') is not null drop table dbo.Something;
go
create table dbo.Something (id int identity primary key, val nvarchar(10));
go
-------------------------------------------------
insert dbo.Something (val) values ('a'), ('b'); -- ids 1 and 2

declare @newseed int;
select @newseed = ident_current('dbo.Something'); -- newseed = 2

set identity_insert dbo.Something on;
-- insert dbo.Something (id, val) values (4,'d');
-- insert dbo.Something (id, val) values (400000,'d');
-- insert dbo.Something (id, val) values (-4,'d');
set identity_insert dbo.Something off;

--dbcc checkident('dbo.Something', reseed, @newseed);

insert dbo.Something (val) values ('c');

select * from dbo.Something;

insert dbo.Something (val) values ('e');

select * from dbo.Something;
