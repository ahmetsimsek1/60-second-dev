declare @People table (PersonID int not null identity, PersonName nvarchar(100));
insert @People (PersonName) values ('John'), ('Pat'), ('Jane');

declare @JPeople table (PersonID int not null, PersonName nvarchar(100));
declare @insertedJIDs table (PersonID int);

insert @JPeople (PersonID, PersonName)
output inserted.PersonID into @insertedJIDs
select PersonID, PersonName from @People where PersonName like 'J%';

select * from @insertedJIDs;
