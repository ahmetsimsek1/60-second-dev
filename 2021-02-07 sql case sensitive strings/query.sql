select serverproperty('collation');

if object_id('tempdb..#foo') is not null drop table #foo;
create table #foo (
    s1 nvarchar(100)
    ,s2 nvarchar(100) collate SQL_Latin1_General_CP1_CS_AS
);
go
insert #foo (s1, s2) values ('hello', 'goodbye');

if exists (select 1 from #foo where s1 = 'HELLO') print 'HELLO exists';
if exists (select 1 from #foo where s2 = 'GOODBYE') print 'GOODBYE exists';
if exists (select 1 from #foo where s2 = 'goodbye') print 'goodbye exists';
