# Chapter 10: Control Flow and Collections
## switch Statements vs. else if
### switch Statements
* The `switch` statement in C# is a selection statement
  * It act somewhat like a `else if` statement
* You are able to provide a `switch` statement multiple `case`s
  * Based on how the `switch`'s expression evaluates it finds a matching `case` and executes it code block
* Let's take a look at the structure of a `switch` statement:
```C#
switch (expression)
{
   case expression_value1:
      Statement
   break;
   case expression_value2:
      Statement
   break;
   case expression_value3:
         Statement
   break;
   default:
      Statement
   break;
}
```
* Let's break it down:
1. We utilize the `switch` `keyword` to denote that we are creating a `switch` statement
2. We provide the `switch` statement a expression to evaluate
3. Based on how the initial expression evaluates the switch statement will then find a matching `case` and execute its code block

* Let's see this in a practical application:
```C#
Console.WriteLine("Enter an integer: ");
string dayString = Console.ReadLine();
int dayNum = int.Parse(dayString);

string day;
switch (dayNum) {
   case 0:
      day = "Sunday";
      break;
   case 1:
      day = "Monday";
      break;
   case 2:
      day = "Tuesday";
      break;
   case 3:
      day = "Wednesday";
      break;
   case 4:
      day = "Thursday";
      break;
   case 5:
      day = "Friday";
      break;
   case 6:
      day = "Saturday";
      break;
   default:
      // in this example, this block runs if none of the above blocks match
      day = "Int does not correspond to a day of the week";
      break;
}
Console.WriteLine(day);
```
* What are we doing above?
1. `Console.WriteLine("Enter an integer: ");`: Prompt the user to provide a integer
2. `string dayString = Console.ReadLine();`: Store the users input in a variable called `dayString`
3. `int dayNum = int.Parse(dayString);`: `Parse` the users input into an `int` and store it in a variable called `dayNum`
4. `string day;`: Declare a `string` variable called `day`
5. `switch (dayNum)`: Declare a `switch` statement and provide it the `users` input as the expression to evaluate
   * You would read this statement as "Is dayNum value true`
   * ie: if the user entered the int 1, you switch statement would evaluated: is 1 true?
6. The `switch` statement then checks to see if any `case`'s `expression value` matches the users input
   * ie: if the users provided the number `1` then the it would match the second `case`'s `expression value`
7. Based on the `case` that matches the users input the `day` variable is set to its corresponding value and that is returned
8. The `break` keyword is triggered and the `switch` statement is terminated
9. `Console.WriteLine(day);`: The `day` variable's value is printed to the console
* Let's say you wanted to refactor the above code into a `else if` statement:
```C#
Console.WriteLine("Enter an integer: ");
string dayString = Console.ReadLine;
int dayNum = int.Parse(dayString);

string day;
if (dayNum == 0)
{
   day = "Sunday";
}
else if (dayNum == 1)
{
   day = "Monday";
}
else if (dayNum == 2)
{
   day = "Tuesday";
}
else if (dayNum == 3)
{
   day = "Wednesday";
}
else if (dayNum == 4)
{
   day = "Thursday";
}
else if (dayNum == 5)
{
   day = "Friday";
}
else if (dayNum == 6)
{
   day = "Saturday";
}
else
{
   day = "Int does not correspond to a day of the week";
}
Console.WriteLine(day);
```
* **Gotchas**:
  * The point of which is better (`switch` vs. `else if) can be debated, I leave it up to you to make a decision if one should be made at all
  * I personally feel it is helpful to know you have it as a possibly tool in your tool belt
  * More on `switch` and `else if` conditional statements can be found here:
    * [Using Conditional Statements Like If and Switch in C#](https://www.pluralsight.com/guides/using-conditional-statements-if-switch-in-c)
    * [C# Switch Statements](https://www.w3schools.com/CS/cs_switch.php)
    * [Learn Everything About C# Switch Statement](https://www.c-sharpcorner.com/article/c-sharp-switch-statement/)

* ### Fallthrough
* In a nutshell `fallthrough` is when you do not put a `break` statement at the end of a `case` code block
* `Fallthrough` as a behavior in C# is when you omit a `break` statement in a `case` code block and inturn allows you to group multiple cases to return the same data
* Let's see this in action:
```C#
Console.WriteLine("Enter an integer: ");
string dayString = Console.ReadLine;
int dayNum = int.Parse(dayString);

string weekZone;
switch (dayNum) {
   case 0:
      weekZone = "Weekend";
      break;
   case 1:
   case 2:
   case 3:
   case 4:
   case 5:
      weekZone = "Week Day";
      break;
   case 6:
      weekZone = "Weekend";
      break;
   default:
      // in this example, this block runs if none of the above blocks match
      weekZone = "Int does not correspond to a day of the week";
      break;
}
Console.WriteLine(day);
```
* In the code above we are able to test to see if the user provides a range of numbers that match for with a `Week Day` or a `Weekend Day`:
  * ie:
    * Weekdays are represented by 1-5
    * Weekends are represented by 0 and 6
* If the end user was to provide a number 1-5 their corresponding cases would all set to the same value: `Week Day`
  * `Fallthrough` is the process of the cases `1-4` falling through to `case 5`
## More Loops and Break Statements
* So in our last lesson we learned the power of the `for` loo
  * But sometime you do not want to write that much code just to iterate over a collection (`string`, `array`, etc) of data
  * Times like this is when a `foreach` loop comes in handy
### foreach Loop
* The `foreach Loop` is used to iterate over elements withing a collection
* Let's look at the logic of a `foreach Loop` then look at a practical application of it:
```C#
foreach(data_type var_name in collection_variable)
{
     // statements to be executed
}
```
* The breakdown:
1. We utilize the `foreach` key word to denote the creation of the loop
2. We declare a variable that will store each individual value within the collection per iteration
   * The variable must be the same type of the base type of the collection we are iterating over:
   * ie:
     * if we iterate over a `string` we would declare a `char` variable
     * if we iterate over a `array` of `string`s we would declare a `string` variable
     * etc.
3. We utilize the `in` keyword which causes arguments to be passed as a readonly reference and ensures the argument is not modified
4. We reference the `collection` that will be iterated over
5. We define a code block where we state what code we would like executed each iteration
* Let's see this in action:
```C#
      string name = "Loki";
      foreach(char letter in name)
      {
        Console.WriteLine(letter);
      }
      // Outputs: L
      // Outputs: o
      // Outputs: k
      // Outputs: i
```
* You know the drill, lets break it down:
1. `string name = "Loki";`: We declare the collection we want to iterate over
2. `foreach(char letter in name)`:
   * `foreach`: We denote the keyword to create the loop
   * `char letter`: we declare a `char` variable which will store each letter of our `string` as we iterate over it
   * `in`: Just read this as `foreach char in name`
   * `name` is the reference to our `string`
3. We define a code block which dictates on execution we print the current `letter` being iterated over to the Console
4. Rinse and repeat
* **Gotcha**: It is not required to use the `ToCharArray` to iterate over a `string`

* Lets look at a few other example of how we could use a `foreach` loop:
1. Iterating over an `array` of `string`s:
```C#
      string[] theBadBatch = {"Hunter", "Wrecker", "Tech", "Crosshair", "Echo", "Omega"};

      foreach(string clone in theBadBatch)
      {
        Console.WriteLine(clone);
      }
      // Outputs: Hunter
      // Outputs: Wrecker
      // Outputs: Tech
      // Outputs: Crosshair
      // Outputs: Echo
      // Outputs: Omega
```
2. Iterating over an `array` of `int`s:
```C#
      int[] decades = {1970, 1980, 1990, 2000, 2010, 2020};

      foreach(int decade in decades)
      {
        Console.WriteLine(decade);
      }
      // Outputs: 1970
      // Outputs: 1980
      // Outputs: 1990
      // Outputs: 2000
      // Outputs: 2010
      // Outputs: 2020
```
### do-while Loop
* The `do-while` look is similar to the `while` loop
* Yet a `do-while` loop evaluates it condition after it executed it's code block
  * Whereas a `while` loop evaluates its condition before it executes its code block
* The main thing to keep in mind when utilizing a `do-while` loop is that regardless of how your `while` condition evaluates the loops code block will be executed at least once
```C#
do
{
    //code block


} while(condition);
```
* The breakdown:
1. Utilize the `do` keyword to denote a `do-while` loop
2. Declare a code block and provide the code that you would like executed
3. Utilize the `while` keyword and provide a condition to be evaluated
4. If the condition evaluates as true then the loop iterates again
  * Take note that we have to put a `;` at the end of the `while` condition
    * Don't be like Roger... Remember your `;`!
5. If not the loop terminates

* Let's see a non-practical application to understand the logic of this:
```C#
      do
      {
        Console.WriteLine("Ha I ran once!!");
      } while (false);
      // Outputs: Ha I ran once!!
```
* Let's see a practical application:
```C#
      int i = 0;

      do
      {
          Console.WriteLine($"i = {i}");
          i++;

      } while (i < 5);
      // Outputs: i = 0
      // Outputs: i = 1
      // Outputs: i = 2
      // Outputs: i = 3
      // Outputs: i = 4
```
### Break Statements in Loops
* There may be times when you want to terminate a loop based on a separate condition
  * At times like this you can employ the `break` statement with conditional logic:
```C#
      string[] theBadBatch = {"Hunter", "Wrecker", "Tech", "Crosshair", "Echo", "Omega"};

      string jerk = "Crosshair";

      foreach(string clone in theBadBatch)
      {

        if(clone == jerk)
        {
          Console.WriteLine($"Found the jerk!\nIts {clone}!");
          break;
        }

        Console.WriteLine($"Whew! {clone} is not the jerk.");
      }
    //   Outputs: Whew! Hunter is not the jerk..
    //   Outputs: Whew! Wrecker is not the jerk..
    //   Outputs: Whew! Tech is not the jerk..
    //   Outputs: Found the jerk!
    //            Its Crosshair!
```
* In the code above we are searching The Bad Batch for the Clone that is a jerk
1. We declare 2 variables `theBadBatch` and `jerk`
   * `theBadBatch` is the array we want to iterate over
   * `jerk` is the string value we are searching for
2. We declare a `foreach` loop which will iterate over each clone in the `theBadBatch` array
3. Within the code block of the `foreach` loop we have a `if` statement that performs an operation that checks to see if the current `clone` being `iterated` over is the `jerk`
   * If the clone is the jerk the condition will evaluate as true and the loop will terminate
   * If the condition does not evaluate as true the if statement ends and the `foreach` resumes it's code block and prints the current clone to the console and the loop continues to iterate
## Collections
* In C# when it comes to creating and grouping related objects you have two options:
1. Creating `array`s of `object`s
2. Creating `collection`s of `object`s
* `Array`s are most useful for working with data types that will have fixed numbers of object
* Where as `collection`s provide us a more flexible `data structure` to group our `object`s
* `Collection`s allow us to dynamically grow and shrink our group objects based on the needs of our application(s)
## Data Structures
* In very simple terms a `data structure` is a structure that allows us to hold multiple pieces of data in on place
* There are many different data structures that exist and every language has its own types and or variations

### C# Collections Namespace
* `Namespaces` are a major concept within C#, one in which we will cover more in depth as we progress within this course
* `Namespaces` are utilized with in C# in two ways:
1. `.NET` uses `namespaces` to organize the slew of classes that it has available
    * Currently we have worked with just the `System` `namespace`
      * `Console` is a class that is defined within the `System` `namespace
2. You are able to declare your own `namespaces` so that you can create custom classes
   * We will learn more about this later
* For the remainder of this lesson we will focus on focus on two collections called `List` and `Dictionary` which are housed within the `System.Collections.Generic` namespace
### using
* So up until now you have been briefly aware of the `using` statement
  * Its the blue highlighted keyword up there on line 1
* What you haven't realized (or maybe you have) is that this powerful statement enables you to access classes, method, and data stored in different namespaces (ie: files)
  * When you write `Console.WriteLine()` the complier actually accesses the `System` namespace and locates the `Console` class and in turn then finds `WriteLine` method
  * Oh you don't believe me?!
  * Try this out, open `repl.it` and remove the `using System` from line 1 and then inside the `MainClass` write `System.Console.WriteLine("Wait What?! That's what it was doing??");`
```C#
class MainClass {
  public static void Main (string[] args) {

    System.Console.WriteLine("Wait What?! That's what it was doing??");

  }
}
```
* **Gotchas**:
  * The `using` statement doesn't actually load the class into memory, that job is left up to the `assembly`
  * The `assembly` is the unit of complied code created by the compiler
  * The `using` statement communicates to the compiler that we have utilized a shorthand version of the class's name

### using System.Collections.Generic
* The `System` `namespace` enables our program to utilize `primitive data types`
  * But now my ducklings its time to spread those wings some and splash around a different part of the pond
* Now we will begin using the `System.Collections.Generic` namespace and in turn will add a new line of code to line 2:
```C#
using System;
using System.Collections.Generic;  //add this line
```
## Lists
* In C# we have a class called `List`
* A `List` is similar to an `Array` in the sense that it is `mutable`
* Yet unlike an `Array` you are able to declare a `List` without a specif size
* `List` have methods available to them that allow you to modify their size

### List Initialization
* Same as with `arrays` there are multiple ways to initialize a `list`:
1. We can initialize by providing some element when we initialize the list:
```C#
// This syntax you will see in documentation as a template for how to create specific collections
// Do not add this to you code
List<T> newList = new List<T> {element1, element2, element3};

    List<string> troopers = new List<string>
    {
      "Johnny Rico",
      "Carmen Ibanez",
      "Dizzy Flores",
      "Sugar Watkins",
      "Sgt. Charles Zim"
    };

    foreach(string trooper in troopers)
    {
      Console.WriteLine(trooper);
    }

    // Outputs: Johnny Rico
    // Outputs: Carmen Ibanez
    // Outputs: Dizzy Flores
    // Outputs: Sugar Watkins
    // Outputs: Sgt. Charles Zim
```
* `List<T> newList = new List<T> {element1, element2, element3};` - is a template syntax you will see in documentation for how to create specific collections:
  * `<T>` represent a placeholder for `data type`
    * In our example we create a `list` of `string`s so we replace the `T` with `string`
  * `{element1, element2, element3}` - is a template for the elements (items) you could add to the `list`
    * In our example we replaced `element1` with `Johnny Rico`
2. We can `declare` a `list` and `initialize` it with the `Add()` method:
```C#
// This syntax you will see in documentation as a template for how to create specific collections
// Do not add this to you code
List<T> newList = new List<T>();
   newList.Add(element1);
   newList.Add(element2);
   newList.Add(element3);
   newList.Add(element4);

    List<string> troopers = new List<string>();
      troopers.Add("Johnny Rico");
      troopers.Add("Carmen Ibanez");
      troopers.Add("Sugar Watkins");
      troopers.Add("Dizzy Flores");
      troopers.Add("Sgt. Charles Zim");

    foreach(string trooper in troopers)
    {
      Console.WriteLine(trooper);
    }

    // Outputs: Johnny Rico
    // Outputs: Carmen Ibanez
    // Outputs: Dizzy Flores
    // Outputs: Sugar Watkins
    // Outputs: Sgt. Charles Zim
```
3. The final way is to pull elements from an `array` into a `list`
```C#
type[] demoArray = {element1, element2, element3};
List<T> demoList = new List<T>(demoArray);

    string[] troopersArray =
    {
      "Johnny Rico",
      "Carmen Ibanez",
      "Dizzy Flores",
      "Sugar Watkins",
      "Sgt. Charles Zim"
    };

    List<string> listOfTroopers = new List<string>(troopersArray);

    foreach(string trooper in listOfTroopers)
    {
      Console.WriteLine(trooper);
    }
    // Outputs: Johnny Rico
    // Outputs: Carmen Ibanez
    // Outputs: Dizzy Flores
    // Outputs: Sugar Watkins
    // Outputs: Sgt. Charles Zim
```

* **Gotcha**:
  * "There is no wrong way to code, except the way that doesn't work" - Roger Campbell II
    * ie: Don't worry about which of the above is the "best" way to do this
    * Pick one that works well for you and or your use case and keep on hacking!!

### List Methods
* So as you can probably imagine since `List` are a class they have... `Method`s!
  * We have already messed around with one above which was the `Add()` method
* Checkout the list below for more commonly used `List` `method`s
  * Also feel free to checkout the [Microsoft Docs](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1?view=netframework-4.8#methods)

| C# Syntax  | Description                                                                                                           |
| ---------- | --------------------------------------------------------------------------------------------------------------------- |
| Add()      | Adds an item to the List                                                                                              |
| Contains() | Checks to see if the List contains a given item, returning a Boolean                                                  |
| IndexOf()  | Looks for an item in a List, returns the index of the first occurrence of the item if it exists, returns -1 otherwise |
| Reverse()  | Reverses the elements of a List                                                                                       |
| Sort()     | Rearranges the elements of an List into ascending order.                                                              |
| Remove()   | Removes first occurrence of a specified object                                                                        |
| ToArray()  | Returns an Array containing the elements of the List                                                                  |

## List Gradebook
* Let's step through this code:
```C#
using System;
using System.Collections.Generic;

class MainClass
{
   static void Main(string[] args)
   {
      List<string> students = new List<string>();
      List<double> grades = new List<double>();
      string newStudent;
      string input;

      Console.WriteLine("Enter your students (or ENTER to finish):");

      // Get student names
      do
      {
         input = Console.ReadLine();
         newStudent = input;

         if (!Equals(newStudent, "")) {
            students.Add(newStudent);
         }

      } while(!Equals(newStudent, ""));

      // Get student grades
      foreach (string student in students) {
         Console.WriteLine("Grade for " + student + ": ");
         input = Console.ReadLine();
         double grade = double.Parse(input);
         grades.Add(grade);
      }

      // Print class roster
      Console.WriteLine("\nClass roster:");
      double sum = 0.0;

      for (int i = 0; i < students.Count; i++) {
         Console.WriteLine(students[i] + " (" + grades[i] + ")");
         sum += grades[i];
      }

      double avg = sum / students.Count;
      Console.WriteLine("Average grade: " + avg);
   }
}
```
### List Iteration
#### do-while Loop
```C#
// Get student names
do
{
   newStudent = Console.ReadLine();

   if (!Equals(newStudent, "")) {
      students.Add(newStudent);
   }

} while(!Equals(newStudent, ""));
```
1. We initialize a `do-while` loop with the `do` statement
2. The loop's code block will execute at least one due to the fact that it is a `do-while` loop and then the condition will be evaluation
3. We take the users input and evaluate if `newStudent` is not equal to an empty string
    * _Side note_: The `Equal()` function test to see if two provided `objects` are equal to each other
      * ie:
        * `Console.WriteLine(Equals("", ""));` would return `True`
        * `Console.WriteLine(Equals("t", ""));` would return `False`
#### foreach
```C#
// Get student grades
foreach (string student in students) {
   Console.WriteLine("Grade for " + student + ": ");
   string input = Console.ReadLine();
   double grade = double.Parse(input);
   grades.add(grade);
}
```
* This snippet is just demonstrating to you that you are able to iterate over a `list` with a `foreach` loop

#### for
```C#
// Print class roster
Console.WriteLine("\nClass roster:");
double sum = 0.0;

for (int i = 0; i < students.Count; i++) {
   Console.WriteLine(students[i] + " (" + grades[i] + ")");
   sum += grades[i];
}
```
* Here we are able to see that each instance of a `list` has `properties` that will provide you more information about it:
  * The `Count` property is very similar to a `String`'s `Length` property in the fact that it returns the total number of items stored within a `list`

## Array
* Let's talk through some comparisons between `List`s and `Array`s:
1. `Array`s are one of C#'s most basic `data structures`
2. In regards to performance `Array`s generally operate faster than `List`
3. Yet `array`'s are limited by a fixed sized
   * Meaning once you initialize an `array` it is difficult to add new indices to it
4. Where as a `List` has the `Add()` method which easily allows you to add new items to it
   * There are also `method` that can be used to remove items from `list`
5. There are many other difference between the two as always I personally would not say one is better than the other I feel it just comes down to your particular use case

## Dictionary
* So where a `List` give us more control over data than an `Array`, `Dictionaries` add a new way of being able to group data
* When utilizing a `Dictionary` we are able to pair our data
  * This paradigm of paring data is referred to as a `key/value pair`
    * The `key` is a reference that we provide to stored data
      * ie: if we wanted to store a student's grades we could provide a student id or their name as the `key`
    * The `value` is the data we would like to be stored with in that reference

### Dictionary Initialization
* So I bet you are seeing a pattern here...
* There are a few ways to `initialize` a `dictionary`:

1. Like this:
```C#
// This syntax you will see in documentation as a template for how to create specific collections

// Dictionary<TKey, TValue> newDictionary = new Dictionary<TKey, TValue>
// {
//    {key1, value1},
//    {key2, value2},
//    {key3, value3}
// };

     Dictionary<string, string> creators = new Dictionary<string, string>
     {
       {"Star Trek", "Eugene Wesley Roddenberry"},
       {"Star Wars", "George Walton Lucas Jr."},
       {"Stargate", "Brad Wright"}
     };
```
2. We can utilize `index initialization`:
```C#
// This syntax you will see in documentation as a template for how to create specific collections

// Dictionary<TKey, TValue> demoDictionary = new Dictionary<KeyT, ValueT>
// {
//    [key1] = value1,
//    [key2] = value2,
//    [key3] = value3
// };

     Dictionary<string, string> creators = new Dictionary<string, string>
     {
       ["Star Trek"] = "Eugene Wesley Roddenberry",
       ["Star Wars"] = "George Walton Lucas Jr.",
       ["Stargate"] = "Brad Wright"
     };
```
3. We can also declare a `dictionary` and use the `Add()` Method:
```C#
// This syntax you will see in documentation as a template for how to create specific collections
//    Dictionary<TKey, TValue> methodDictionary = new Dictionary<TKeym TValue>();
//    methodDictionary.Add(key1, value1);
//    methodDictionary.Add(key2, value2);
//    methodDictionary.Add(key3, value3);

     Dictionary<string, string> creators = new Dictionary<string, string>();

       creators.Add("Star Trek", "Eugene Wesley Roddenberry");
       creators.Add("Star Wars", "George Walton Lucas Jr.");
       creators.Add("Stargate", "Brad Wright");
```
4. You can also declare the `dictionary` and initialize its value later

```C#
    Dictionary<string, string> creators;

    creators = new Dictionary<string, string>
    {
      {"Star Trek", "Eugene Wesley Roddenberry"},
      {"Star Wars", "Star War"},
      {"Stargate", "Brad Wright"}
    };
```
* As always the choice is yours!

### Accessing Dictionary Elements
* You are able to access a `dictionary` via the `bracket notation`:
  * This is also consider the `indexer` when talking about `dictionaries`
```C#
     Dictionary<string, string> creators = new Dictionary<string, string>();

       creators.Add("Star Trek", "Eugene Wesley Roddenberry");
       creators.Add("Star Wars", "George Walton Lucas Jr.");
       creators.Add("Stargate", "Brad Wright");

     Console.WriteLine(creators["Star Trek"]);

     // Outputs: Eugene Wesley Roddenberry
```
* Now let's say you want to store an `array` as a value within a `dictionary`
```C#
    string[] originalTrilogy = {"A New Hope","The Empire Strikes Back", "Return of the Jedi"};

    Dictionary<string, string[]> starWarsTrilogies;

    starWarsTrilogies = new Dictionary<string, string[]>
    {
      {"originalTrilogy", originalTrilogy}
    };

    foreach(KeyValuePair<string, string[]> kvp  in starWarsTrilogies)
    {
      Console.WriteLine($"In the outer loop you can get the key: {kvp.Key}");
      Console.WriteLine("<----------------------->");

      foreach(var film in kvp.Value)
      {
      Console.WriteLine($"In the Inner Loop you can get the value: {film}");
      }
    }
```
* In order to make this work you must utilize the [KeyValuePair<TKey,TValue> Struct](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.keyvaluepair-2?view=net-5.0)

### Dictionary Methods
* As always there are methods that you can use with the `Dictionary` class
* See this list below for some commonly used ones

| C# Syntax       | Description                                                                                                                                                                             |
| --------------- | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| Count           | Returns the number of items in the dictionary, as an int.                                                                                                                               |
| Key             | Returns a collection containing all keys in the dictionary. This collection may be used in a foreach loop just as lists are, but the dictionary may not be modified within such a loop. |
| Value           | Returns a collection containing all values in the dictionary. This collection may be used in a foreach loop just as lists are.                                                          |
| Add()           | Add a key/value pair to a dictionary.                                                                                                                                                   |
| Remove()        | Removes a key/value pair to a dictionary using key as a reference.                                                                                                                      |
| ContainsKey()   | Returns a boolean indicating whether or not the dictionary contains a given key.                                                                                                        |
| ContainsValue() | Returns a boolean indicating whether or not the dictionary contains a given value.                                                                                                      |