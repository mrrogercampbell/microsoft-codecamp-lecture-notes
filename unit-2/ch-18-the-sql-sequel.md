# Chapter 18: The SQL Sequel
- [Chapter 18: The SQL Sequel](#chapter-18-the-sql-sequel)
  - [Table Relations](#table-relations)
    - [Relating Data](#relating-data)
    - [Adding a Primary Key](#adding-a-primary-key)
    - [Adding a Foreign Key](#adding-a-foreign-key)
  - [Database Management](#database-management)
    - [Clean Up Pre-Existing DB](#clean-up-pre-existing-db)
    - [Setup](#setup)
    - [Create the writing_supply Table](#create-the-writing_supply-table)
    - [Create the pen_drawer Table](#create-the-pen_drawer-table)
    - [Import Data](#import-data)
  - [Complex Queries](#complex-queries)
    - [Inner Join](#inner-join)
    - [Left/Right Join](#leftright-join)
      - [LEFT JOIN writing_supply and pen_drawer](#left-join-writing_supply-and-pen_drawer)
      - [LEFT JOIN writing_supply and pen_drawer refactored](#left-join-writing_supply-and-pen_drawer-refactored)
      - [RIGHT JOIN writing_supply and pen_drawer](#right-join-writing_supply-and-pen_drawer)
      - [RIGHT JOIN writing_supply and pen_drawer refactored](#right-join-writing_supply-and-pen_drawer-refactored)
    - [Multiple Joins](#multiple-joins)
    - [Subqueries](#subqueries)
  - [Resources](#resources)
## Table Relations
### Relating Data
* As we start to learn more about Databases and Database management we must begin to look at the importance how we relate our data
* As we start to design program and thin pof the data we want to store it we have to think of a meaningful and tangible way for the data to be housed
* With in mind we can begin to relate our data based on different types of relationships:
  * [One-To-One](https://www.databaseprimer.com/pages/relationship_1to1/): each row in one database table is linked to 1 and only 1 other row in another table
  * [One-To-Many](https://www.databaseprimer.com/pages/relationship_1tox/): each row in the related to table can be related to many rows in the relating table
  * [Many-To-Many](https://www.databaseprimer.com/pages/relationship_xtox/): one or more rows in a table can be related to 0, 1 or many rows in another table

### Adding a Primary Key
* The syntax for creating a `primary key`:
```sql
column_name INTEGER PRIMARY KEY AUTO_INCREMENT
```
* Example of how you would add a `primary key` to a table:
```sql
CREATE TABLE courses (
   course_id INTEGER PRIMARY KEY AUTO_INCREMENT,
   course_title VARCHAR(40),
   course_minutes INTEGER,
   course_description TEXT,
   credits INTEGER
);
```
### Adding a Foreign Key
* The syntax for creating a `foreign key`:
```sql
column_name INTEGER,
FOREIGN KEY (column_name) REFERENCES other_table(primary_key_column)
```
* Example of how you would add a `foreign key` to a table:
```sql
CREATE TABLE teachers (
   teacher_id INTEGER PRIMARY KEY AUTO_INCREMENT,
   first_name VARCHAR(40),
   last_name VARCHAR(40),
   email VARCHAR(80),
   hire_date DATE,
   course_id INTEGER,
   FOREIGN KEY (course_id) REFERENCES courses(course_id)
);
```
## Database Management
### Clean Up Pre-Existing DB
* If you already walked through this be sure to drop your pre-existing tables and data:
```sql
DROP TABLE IF EXISTS writing_supply, pencil_drawer, pen_drawer;
```
### Setup
1. Open a connection in MySQL Workbench
2. Click `Create New Schema` and call the model storage
3. Click `Apply`
4. `Accept` all of the default options when prompted

### Create the writing_supply Table
* Use the following code snippet:
```sql
CREATE TABLE writing_supply (
   supply_id INTEGER PRIMARY KEY AUTO_INCREMENT,
   utensil_type ENUM ("Pencil", "Pen"),
   num_drawers INTEGER
);
```

### Create the pen_drawer Table
* Use the following code snippet:
```sql
CREATE TABLE pen_drawer(
drawer_id INTEGER PRIMARY KEY AUTO_INCREMENT,
color ENUM ("Black", "Blue", "Red", "Green", "Purple"),
quantity INTEGER,
refill BOOL,
supply_id INTEGER,
FOREIGN KEY (supply_id) REFERENCES writing_supply(supply_id)
);
```

### Import Data
* Import the data for each table
  * Fork and Clone [this repo](https://github.com/LaunchCodeEducation/sql-starter-data) for the sample data
* Follow the steps listed [here](https://github.com/LaunchCodeEducation/sql-starter-data) for how to import the data
* Test to make sure the data has been imported properly:

```sql
SELECT * FROM writing_supply ;
SELECT * FROM pencil_drawer ;
SELECT * FROM pen_drawer ;
```

* You can find a visual representation of the tables [here](https://docs.google.com/spreadsheets/d/1hnvEOj3i8Pyx1hpjtr4lRnfPo4ZUDvks9qK9B1WWm_g/edit?usp=sharing)

## Complex Queries
### Inner Join
* To return a result set that contains information that appears in both the writing_supply and pencil_drawer tables, we use an INNER JOIN.
```sql
SELECT *
FROM writing_supply
INNER JOIN pencil_drawer ON writing_supply.supply_id = pencil_drawer.supply_id;
```

* To reduce the size of the result set, we can request specific fields and add conditions to the query:
```sql
SELECT writing_supply.supply_id, pencil_type, drawer_id, quantity
FROM writing_supply
INNER JOIN pencil_drawer ON writing_supply.supply_id = pencil_drawer.supply_id
WHERE refill = true AND pencil_type = "Mechanical";
```

### Left/Right Join
* We can use a LEFT or RIGHT join to retain all of the records from one table and pull in overlapping data from another.

#### LEFT JOIN writing_supply and pen_drawer
```sql
SELECT writing_supply.supply_id, utensil_type, drawer_id, color
FROM writing_supply
LEFT JOIN pen_drawer ON writing_supply.supply_id = pen_drawer.supply_id;
```

#### LEFT JOIN writing_supply and pen_drawer refactored
```sql
SELECT writing_supply.supply_id, utensil_type, drawer_id, color
FROM writing_supply
LEFT JOIN pen_drawer ON writing_supply.supply_id = pen_drawer.supply_id
WHERE refill = true;
```
#### RIGHT JOIN writing_supply and pen_drawer
```sql
SELECT writing_supply.supply_id, utensil_type, drawer_id, color
FROM writing_supply
RIGHT JOIN pen_drawer ON writing_supply.supply_id = pen_drawer.supply_id;
```

#### RIGHT JOIN writing_supply and pen_drawer refactored
```sql
SELECT writing_supply.supply_id, utensil_type, drawer_id, color
FROM writing_supply
RIGHT JOIN pen_drawer ON writing_supply.supply_id = pen_drawer.supply_id
WHERE refill = true;
```
### Multiple Joins
The UNION keyword allows us to combine the results of separate SELECT commands. Run each of the following queries individually and examine the two result sets. Next, run the queries with UNION.

```sql
SELECT writing_supply.supply_id, utensil_type, drawer_id, quantity
FROM writing_supply
LEFT JOIN pencil_drawer ON writing_supply.supply_id = pencil_drawer.supply_id
WHERE refill = true

UNION

SELECT writing_supply.supply_id, utensil_type, drawer_id, quantity
FROM writing_supply
RIGHT JOIN pen_drawer ON writing_supply.supply_id = pen_drawer.supply_id
WHERE refill = true
ORDER BY supply_id;
```

### Subqueries
* Consider the following situations:
  * Retrieve the supply_id values for any writing_supply containers that hold pens.
  * Using the supply_id values, retrieve the ID and color values for any drawers in the last container that hold 60 or more pens.
* We can accomplish these actions by using two simple SQL queries:
```sql
SELECT supply_id FROM writing_supply
WHERE utensil_type = "Pen";
/* First result set contains the supply_id values 1, 2, and 5. */

SELECT drawer_id, color FROM pen_drawer
WHERE quantity >= 60 AND supply_id = 5;
```

* Instead we can use subqueries:
* Take One:
```sql
SELECT drawer_id,
       color
FROM   pen_drawer
WHERE  supply_id IN (SELECT supply_id
                     FROM   writing_supply
                     WHERE  utensil_type = "pen");
```
* Take Two:
```sql
SELECT drawer_id,
       color,
       quantity
FROM   pen_drawer
WHERE  supply_id IN (SELECT supply_id
                     FROM   writing_supply
                     WHERE  utensil_type = "pen")
       AND quantity >= 60;
```

* Take Three:
```sql
SELECT drawer_id,
       color,
       quantity
FROM   pen_drawer
WHERE  supply_id = (SELECT MAX(supply_id)
                     FROM   writing_supply
                     WHERE  utensil_type = "pen")
       AND quantity >= 60; 
```

## Resources
* [Crow’s Foot Notation](https://vertabelo.com/blog/crow-s-foot-notation/)
* [One-to Many Relationships in ER Diagram](https://stackoverflow.com/questions/15896699/one-to-many-relationships-in-er-diagram)
* [Instant SQL Formatter](https://www.dpriver.com/pp/sqlformat.htm)
* [SQL Tutorial](https://www.w3schools.com/sql/default.asp)
* [GenerateData.com](https://www.generatedata.com/)