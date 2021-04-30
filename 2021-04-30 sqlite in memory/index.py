import sqlite3
import datetime

from faker import Faker
fake = Faker()

con = sqlite3.connect(":memory:")
cur = con.cursor()
cur.execute("CREATE TABLE Items (ItemName TEXT, CreateDate BIGINT);")
cur.execute("CREATE VIEW VItems AS SELECT ROWID, ItemName, CreateDate FROM Items;")

for i in range(10000):
    name = fake.name()
    date = fake.date_time_between(start_date="-30d", end_date="+30d").timestamp()
    cur.execute("INSERT INTO Items (ItemName, CreateDate) VALUES (?, ?);", (name, date));

con.commit()

query = "SELECT * FROM VItems WHERE ROWID % 5 = 0 ORDER BY ItemName;"
for row in cur.execute(query):
    print(row)

con.close()
