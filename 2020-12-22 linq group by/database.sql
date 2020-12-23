if object_id('dbo.Stores') is not null
    drop table dbo.Stores;
if object_id('dbo.Countries') is not null
    drop table dbo.Countries;

create table dbo.Countries (
    CountryID int not null
    ,constraint PK_Countries primary key (CountryID)

    ,CountryName nvarchar(20)
);
go

insert dbo.Countries (CountryID, CountryName) values (1, 'United States'), (2, 'Canada');

create table Stores (
    StoreID int not null identity
    ,constraint PK_Stores primary key (StoreID)

    ,CountryID int not null
    ,constraint FK_Stores_CountryID
        foreign key (CountryID) references dbo.Countries (CountryID)

    ,RegionName nvarchar(20) not null
    ,StoreName nvarchar(20) not null
);
go

insert dbo.Stores (CountryID, RegionName, StoreName)
values (1, 'West', 'Los Angeles')
       ,(1, 'West', 'Phoenix')
       ,(1, 'West', 'Seattle')
       ,(1, 'West', 'Denver')
       ,(2, 'West', 'Victoria')
       ,(1, 'Southeast', 'Miami')
       ,(1, 'Southeast', 'Atlanta')
       ,(1, 'Midwest', 'Chicago')
       ,(1, 'Northeast', 'New York')
       ,(1, 'Northeast', 'Philadelphia')
       ,(1, 'Northeast', 'Boston')
       ,(2, 'Northeast', 'Ottawa')
       ,(2, 'Northeast', 'Halifax');
