CREATE TABLE Animals (Name TEXT);
INSERT INTO Animals (Name) VALUES ('Dog'), ('Cat');
SELECT * FROM Animals;

/*
Dog
Cat
*/

SELECT ROWID, Name FROM Animals;

/*
1|Dog
2|Cat
*/

DELETE FROM Animals WHERE Name = 'Cat';
INSERT INTO Animals (Name) VALUES ('Frog');
SELECT ROWID, Name FROM Animals;

/*
1|Dog
2|Frog
*/

CREATE TABLE Places (ID INTEGER NOT NULL PRIMARY KEY, Name TEXT);
INSERT INTO Places (Name) VALUES ('Home'), ('Work');
SELECT ROWID, ID, Name FROM Places;

/*
1|1|Home
2|2|Work
*/

DELETE FROM Places WHERE Name = 'Work';
INSERT INTO Places (Name) VALUES ('Restaurant');
SELECT ROWID, ID, Name FROM Places;

/*
1|1|Home
2|2|Restaurant
*/

CREATE TABLE Products (ID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, Name TEXT);
INSERT INTO Products (Name) VALUES ('PC'), ('Phone');
SELECT * FROM Products;

/*
1|PC
2|Phone
*/

DELETE FROM Products WHERE Name = 'Phone';
INSERT INTO Products (Name) VALUES ('Tablet');
SELECT * FROM Products;

/*
1|PC
3|Tablet
*/