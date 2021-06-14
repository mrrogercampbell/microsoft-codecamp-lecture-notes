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


## <#.5 Subtitles>
### <#.1.1 Subtitle>