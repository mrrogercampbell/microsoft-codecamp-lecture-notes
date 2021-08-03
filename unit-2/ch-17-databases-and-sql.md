# Databases and SQL

## Getting Started
### Drop any pre-existing table data
```sql
DROP TABLE li_wedding;
```
### Create a Table from Scratch
```sql
CREATE TABLE li_wedding
(
  guest_id INT,
  last_name varchar(255),
  first_name varchar(255),
  attending BOOL,
  diet varchar
(255)
);
```

### Seeding a Database (li_wedding table)
```sql
INSERT INTO li_wedding
  (guest_id,last_name,first_name,attending,diet)
VALUES
  (100, "Schneider", "Eliana", 1, "vegan"),
  (101, "Ware", "Chester", 1, "vegetarian"),
  (102, "Barnett", "Clinton", 0, "omnivore"),
  (103, "Velasquez", "Yoko", 1, "omnivore"),
  (104, "Newman", "Marsden", 0, "vegetarian"),
  (105, "Bullock", "Christen", 1, "vegan"),
  (106, "Maxwell", "Jaime", 0, "vegan"),
  (107, "Rosario", "Wanda", 0, "vegetarian"),
  (108, "Foster", "Kylynn", 0, "carnivore"),
  (109, "Vincent", "Hamish", 0, "carnivore");
```

### Creating a Table from Another Table
```sql
CREATE TABLE li_vow_renewal
AS
SELECT guest_id, last_name, first_name, attending, diet
FROM li_wedding
WHERE attending = 1;
```

### Adding a FULL Row of data
```sql
INSERT INTO li_vow_renewal
VALUES
  (185, "Johnson", "Eliza", 1, "omnivore");
```

### Adding a Row with missing data
```sql
INSERT INTO li_vow_renewal
  (guest_id, last_name, first_name)
VALUES
  (186, "Lopez", "Felicity");
```

### Adding a column
```sql
ALTER TABLE li_wedding
ADD can_drink boolean;
```

## Reading Data from a Table
### Read all data from a Table
```sql
SELECT *
FROM li_wedding;
```

### Read data from Table based on a condition
```sql
SELECT last_name, first_name
FROM li_wedding
WHERE (attending = 1) AND (diet = "vegetarian");
```

## Update Data
```sql
UPDATE li_vow_renewal
SET diet="vegetarian"
WHERE guest_id=185;
```

### Confirming the update was made
```sql
SELECT *
FROM li_vow_renewal
WHERE guest_id=185;
```

### Updating multiple records at once
```sql
UPDATE li_vow_renewal
SET diet="vegetarian", first_name="Elizabeth"
WHERE guest_id=185;
```
* GOTCHAs:
  * If you do not include a condition with WHERE, all records in the table will be updated!
  * Students might get the following  v. You are using safe update mode and you tried to update a table without a WHERE that uses a KEY column.  To disable safe mode, toggle the option in Preferences -> SQL Editor and reconnect.
    * Students can turn this off for now but let them know this is something you would want to keep on normal to protect your database


## Deleting Data
### Delete a guest based on thier guest_id
```sql
DELETE FROM li_vow_renewal WHERE guest_id=107;
```

* Confirming we deleted the guest
```sql
SELECT *
FROM li_vow_renewal
WHERE guest_id=107
```
## Joins
1. `INNER JOIN`: Returns records that have matching values in both tables
2. `LEFT OUTER JOIN`: Returns all records from the left table, and the matched records from the right table
3. `RIGHT OUTER JOIN`: Returns all records from the right table, and the matched records from the left table
4. `FULL OUTER JOIN`: Returns all records when there is a match in either left or right table

### Inner Join
* Returns which guest are attending the Wedding AND the Vow Renewal
```sql
SELECT li_vow_renewal.last_name, li_vow_renewal.first_name
FROM li_vow_renewal
  INNER JOIN li_wedding
  ON li_vow_renewal.guest_id = li_wedding.guest_id;
```

### Left Outer Join
* The `LEFT JOIN` keyword returns all records from the left table (table1), and the matching records from the right table (table2)
* The result is 0 records from the right side, if there is no match
```sql
SELECT column_name(s)
FROM table1
LEFT JOIN table2
ON table1.column_name = table2.column_name;
```

* This example returns all guest that were invited to the wedding and any guest who was also invited to the vow renewal:
```sql
SELECT li_wedding.last_name, li_wedding.first_name
FROM li_wedding
  LEFT JOIN li_vow_renewal ON li_wedding.guest_id = li_vow_renewal.guest_id;
```
### Right Outer Join
* The `RIGHT JOIN` keyword returns all records from the right table (table2), and the matching records from the left table (table1)
* The result is 0 records from the left side, if there is no match
```sql
SELECT column_name(s)
FROM table1
RIGHT JOIN table2
ON table1.column_name = table2.column_name;
```

* Returns all of the guests that were invited to the vow renewal and any guests who were also invited to the wedding
```sql
SELECT li_wedding.last_name, li_wedding.first_name
FROM li_wedding
  RIGHT JOIN li_vow_renewal
  ON li_wedding.guest_id = li_vow_renewal.guest_id;
```

### Full Outer Join
* The `FULL OUTER JOIN` keyword returns all records when there is a match in left (table1) or right (table2) table records
  * `FULL OUTER JOIN` and `FULL JOIN` are the same.
```sql
SELECT column_name(s)
FROM table1
FULL OUTER JOIN table2
ON table1.column_name = table2.column_name
WHERE condition;
```

```sql
SELECT *
FROM mary_events
  FULL OUTER JOIN leah_events ON mary_events.month = leah_events.month
WHERE mary_events.month = 08;
```
* Gotchas:
  * Full outer joins are important to SQL, but the syntax is not supported in MySQL
  * Instead, to achieve a full outer join, you have to work with a left outer join and a right outer join
  * To show what a full outer join looks like in other types of SQL, we have simulated some possible syntax below



## Resources:
* A lot of the join content came from [W3Schools SQL Joins](https://www.w3schools.com/sql/sql_join.asp) docs

## Common Issue Fixes
* [Can't connect to MySQL server on '127.0.0.1' (10061) (2003)](https://stackoverflow.com/questions/24525736/cant-connect-to-mysql-server-on-127-0-0-1-10061-2003)