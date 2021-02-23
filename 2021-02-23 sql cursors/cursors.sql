declare @ComicID int;
declare @cur cursor;
set @cur = cursor local fast_forward for
select ComicID from dbo.Comics;

open @cur;

while 1=1
begin
  fetch next from @cur into @ComicID;
  if @@fetch_status <> 0 break;

  print @ComicID;
end;

close @cur;
deallocate @cur;
