create table dbo.Foods (
  FoodID int not null identity primary key
 ,FoodName varchar(100) not null
);
go
insert dbo.Foods (FoodName) values ('Pizza'), ('Chicken'), ('Potatoes'), ('Broccoli');
go


create table dbo.People (
 PersonID int not null identity primary key
 ,FirstName varchar(100) not null
 ,FavoriteFoodID int null
 ,constraint FK_Person_FavoriteFoodID
  foreign key (FavoriteFoodID) references dbo.Foods (FoodID)
);
go
insert dbo.People (FirstName, FavoriteFoodID)
values ('John', 1), ('Mary', 2), ('Pat', null);
go
