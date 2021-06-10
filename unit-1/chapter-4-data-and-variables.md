# Chapter 4: Data and Variables
- [Chapter 4: Data and Variables](#chapter-4-data-and-variables)
  - [Values and Data Types](#values-and-data-types)
      - [More On Strings](#more-on-strings)
    - [More On Numbers](#more-on-numbers)
      - [Type Systems](#type-systems)
  - [More On Data Types](#more-on-data-types)
    - [Static vs. Dynamic Typing](#static-vs-dynamic-typing)
    - [Built-In Types](#built-in-types)
    - [Primitive Types](#primitive-types)
    - [Non-primitive Types](#non-primitive-types)
    - [Reference and Value Types](#reference-and-value-types)
    - [Boxing](#boxing)
  - [Type Conversion](#type-conversion)
  - [Variables](#variables)
    - [Declaring and Initializing Variables](#declaring-and-initializing-variables)
    - [Evaluating Variables](#evaluating-variables)
    - [Reassigning Variables](#reassigning-variables)
  - [More On Variables](#more-on-variables)
    - [Creating Constant with const](#creating-constant-with-const)
    - [Naming Variables](#naming-variables)
      - [Valid Variable Names](#valid-variable-names)
      - [Good Variables Names](#good-variables-names)
      - [Camel Case Variable Name](#camel-case-variable-name)
      - [Keywords](#keywords)
  - [Expressions and Evaluations](#expressions-and-evaluations)
  - [Operations](#operations)
    - [Operators and Operands](#operators-and-operands)
      - [Arithmetic Operators](#arithmetic-operators)
      - [More on the Modulus](#more-on-the-modulus)
      - [More on Exponentiation](#more-on-exponentiation)
      - [Order of Operations](#order-of-operations)
    - [Other Operators](#other-operators)
      - [The String Operator +](#the-string-operator-)
      - [Compound Assignment Operators](#compound-assignment-operators)
    - [Input with ReadLine](#input-with-readline)
      - [Requesting Data](#requesting-data)
      - [Critical Input Detail](#critical-input-detail)
  - [Whats Next](#whats-next)
## Values and Data Types
* Programs may be thought of as being made up of two things:
  1. Data
  2. Operations that manipulate data
* Data is stored in many ways:
  * A `value` is a specific piece of data; a word or number
* Each value is categorized by `data types`
  * The first three we will look at are:
  1. `int` - Whole numbers such as 27, 100, 20000
  2. `double` - Are any number with a decimal point: 27.90, 5.988
  3. `strings` - characters enclosed in **double quotes**
     * In C# you **must** use `double quotes`
* You can use the `GetType` method to tell you the data type a `value` belongs to:
```C#
Console.WriteLine(("Hello, World!").GetType());
// Output: System.Sting

Console.WriteLine(17.GetType());
// Output: System.Int32

Console.WriteLine(3.14.GetType());
// Output: System.Double
```
#### More On Strings
* Anything you wrap in `" "` will be considered a `string`
  * ie: `"27"` and `"99.88"` are both strings
```C#
Console.WriteLine(("27").GetType());
// Output: System.Sting

Console.WriteLine(("99.88").GetType());
// Output: System.Sting
```

### More On Numbers
* When typing large numbers do not add a `,`; ie: `100,000` is not a legal integer in C#
```C#
Console.WriteLine(42000);
// Output: 42000

Console.WriteLine(42,000);
// Output: error CS1502: ...`System.Console.WriteLine(string, object)' has some invalid arguments
```
#### Type Systems
* Ask students the following:
  * What is a type system?
  * Do you know any examples of different type systems in other languages?
    * JS only has the `number` type where as C# has `init` and `double` among others
* Every programming language has a **type system**
* Each language will define its own set of `types`, what values those types will consist of, and other aspect
  * More on this at a later time

## More On Data Types
### Static vs. Dynamic Typing
1. Ask students:
  * Can anyone explain what it mean for a language to be **Dynamic typed**?
  * When writing code in programming languages such as JS or Python a variable can refer to a value of any type at any time.
    * ie: When creating a variable you **do not** need to define the type
      * The language is able to figure it out on its own
2. `Dynamically Typed`: You **do not** have to define the data type when declaring a variable
  * [Example](https://replit.com/@rc1336/Dynamic-Typing)
```js
let dynamicVariable = "Doc"
console.log(typeof dynamicVariable)
// Output: string

dynamicVariable = 31
console.log(typeof dynamicVariable)
// Output: number
```
  * Key Takeaway:
    * In JS you are able to define the variable `dynamicVariable` and initially set its value to a `string` data type
      * Then you are able to reassign its value to a `number` data type
1. `Statically typed`: You **must** define the variable's data type when you declare it
   * [Example](https://replit.com/@rc1336/Static-Typing)
```C#
string staticVariable = "dog";
staticVariable = 42;
// Output: error CS0029: Cannot implicitly convert type `int' to `string'
```
  * Key Takeaways:
    * In C#, once you set a variables data type it can not be changed
      * Well at least with there current understanding of C#
    * In a Statically typed language you must declare the type of every variable **before** its name

### Built-In Types
* In C#, all basic data types are objects
  * More on this later
* A list of a common types and their official .NET class name

![List of Common Built in Types](./assets/ch-4/c-sharp-built-in-types.png)

  * The built in data types have short names that differ from typical class name conventions
    * Generally we will use the short names for each

### Primitive Types
* Are basic building block of a program
* Primitive types can be assigned a value directly.
* The value assigned is stored on the stack as opposed to the heap.
  * All of the types listed in the previous image were `primitive types`
    * **Gotcha**: Strings are not primitive types in C#
  * They allow us to build more complex data structures
  * Great article: [C# Variables: Primitive and Non-primitive Types](https://www.jeremyshanks.com/c-variables-primitive-nonprimitive-types/)

![primitive types](./assets/ch-4/primitive-types.png)

### Non-primitive Types
* Non-primitive types are also called reference types due to the fact that the identifer references the location of the value stored in the variable
  * The reason for this is that non-primitive types are from the `object class` and not predefined in C#.
    * More on `classes` later
### Reference and Value Types
* Types in C# are grouped into two categories:
  * **Value Types**: directly store the `data` within itself
    * ie: it stores the actually value within itself
  * Examples of `Value type` `data types`:
    * bool
    * char
    * init
    * float
```C#
int number = 1;
string name = "Johnny";
```
  * **Reference Types**: stores a the address where the value i being stored
    * ie: points to the memory location that store the data
      * [Example](https://www.tutorialsteacher.com/Content/images/csharp/raference-type-memory-allocation.png)
        * The system selects a random location in memory (0x803200) for the variable s.
        * The value of a variable s is 0x600000, which is the memory address of the actual data value.
        * Thus, reference type stores the address of the location where the actual value is stored instead of the value itself
    * Example of `Reference type` `data types`:
      * String
      * Array (even if their elements are value types)
      * Class

### Boxing
* **Boxing**: is the process of converting a `value type` to a `reference type`
* **Unboxing**: is the process of converting a `reference type` to a `value` type
* C# is known as a `unified type` system because it implicitly boxes values types to be treated as objects
* [Boxing Example](https://replit.com/@rc1336/boxing-example#main.cs):
```C#
int i = 123;     // This is a value type.
object o = i;    // Boxing the value type into a reference type.
int j = (int)o;  // Unboxing the reference type back into a value type.
```
## Type Conversion
* Type conversion is just what the name suggest
  * When you convert one data type to another
* Ask students:
  * What is an instance where you would want to perform `type conversion`?
    * When a program accepts user input and we need to convert it store the data properly within a Database
* C# provides `Type conversion functions`
  * These allow us to convert values to different data types.
  * `Int32.Parse` - will attempt to convert its argument into a `init`
  * `Double.Parse` -  will attempt to convert its arguments into a double
```C#
Console.WriteLine(Int32.Parse("2345"));
// Output: 2345

Console.WriteLine((Int32.Parse("2345")).GetType());
// Output: System.Int32

Console.WriteLine(Double.Parse("17"));
// Output: 17

Console.WriteLine((Double.Parse("17.8")).GetType());
// Output: System.Double
```
## Variables
* A `variable` is a name that refers a value for later use
  * That value maybe stored within the variable or be a reference to where the value is stored in memory

### Declaring and Initializing Variables
* When you create a variable it is called `Variable declaration` or `declaration`
  * To `declare` (create) a variable you must:
    1. Define the data type that will be store/referenced by the variable
    2. Create a name for the variable
```C#
string coolestPersonAlive;
```
* Once you declare a variable you can then `assign` it a value
  * When you utilize the `=` sign after the `variable declaration` you are using an `assignment statement`
* The act of assigning a variable a value for the first time is called `initialization`
```C#
// Variable Declaration
string coolestPersonAlive;

// Variable Initialization with a assignment statement
coolestPersonAlive = "Doc";
```
* How you really want to do this:
```C#
// This is D.R.Y.
string coolestPersonAlive = "Doc";
```

* In C# you are able to declare a variable without specifying a type
  * I wouldn't recommend this, it is frowned upon
  * But just incase you are that person that wants to do it heres an example:
```C#
var animal = "My little brother"
```
  * When you do this `C#` will infer the data type
    * If later in your code you attempt to reassign the value of the variable to a different data type your program will throw an error
* Do not confuse the `assignment operator` `=` with the `equality operator` `===`
  * More on the `equality operator` later

### Evaluating Variables
* Once you declare and assign a variable a value you can use it anywhere in your program

```C#
string inspiration = "The greatest teacher, failure is.";

Console.WriteLine(inspiration);
```
* When we refer (ie: use a variable), we are `evaluating` it
### Reassigning Variables
* Variables allow us to make our program remembers important pieces of data that we would like to reuse
  * The super cool part about variables is that we can change their values as need (most of the time, more on this later)
```C#
string inspiration = "The greatest teacher, failure is.";

Console.WriteLine(inspiration);

inspiration = "Do or do not. There is no try."
Console.WriteLine(inspiration)
```
  * Take note that we only use the `data type` when declaring a variable

## More On Variables
### Creating Constant with const
* Ok so remember how I said you can always change a variable's value...
  * I lied...
  * Let's say you want to keep a variables value static for some reason
  * You are able to utilize the `const` keyword to define a `constant` variable
```C#
const string name = "Sir Roger Campbell of the land of the Sun";
name = "Roger the loser";
// Output: error CS0128: A local variable named `appName' is already defined in this scope
```
* "Ha ha ha! No one can make fun of me anymore. Why didn't I know this life hack back in high school?!"

### Naming Variables
#### Valid Variable Names
* There are some basic [guidelines](https://docs.microsoft.com/en-us/dotnet/standard/design-guidelines/naming-guidelines) that C# enforces:
  1. Use only the characters 0-9, a-z, A-Z, and underscore. In other words, do not use special characters or whitespace (space, tab, and so on).
  2. Do not start a variable name with a number.
  3. Avoid starting a variable name with an underscore. Doing so is a convention used by some C# developers to mean something very specific about the variable, and should be avoided.
  4. Do not use keywords, which are words reserved by C# for use by the language itself. We’ll discuss these in detail in a moment.
#### Good Variables Names
* Basic concept here is that you should use descriptive variable names so that someone else is able to infer what you code is doing.
* Don't be this person:
```C#
double x = 5.75;
const double y = 3.14;
double z = y * Math.Pow(x, 2);
Console.WriteLine(z);
```
* Be this person:
```C#
double radiusOfCircle = 5.75;
const double pi = 3.14;
double areaOfCircle = pi * Math.Pow(radiusOfCircle, 2);
Console.WriteLine(areaOfCircle);
```
#### Camel Case Variable Name
* This is a convention that is used in a lot of programming languages
  * Conventions are not formal rules, but your peers will most likely be expecting you to use them
* It allows you to write multiple words for a variable name without needing spacing between each word
* Examples:
```C#
string bestDogInTheWorld = "Doc";
string bestInstructorOnTheNet = "Roger";
bool isHeReallyThatFullOfHimSelf = true;
```
* Basic stipulations of camel case:
  * Variable names:
    1. are joined together to omit spaces,
    2. start with a lowercase letter, and
    3. capitalize each internal word.

#### Keywords
* **Keywords**: are a collection of words that are reserved for the use of the C# language
  * ie: `Keywords` or `Reserved Words`
  * These are words that are a formal part of the C# language
    * ie: `const`, `string`, `int`, `bool`
  * **Gotchas**:
    * Console and Console.WriteLine may seem like keywords, they are actually slightly different things.
    * They are entities (an system and a method, respectively) that are available by default in most C# environments.
* If you attempt to use a `keyword` for anything other than its actually purpose you will receive an error:
```C#
int const = "Will this work?!";

/*
Outputs:
error CS1525: Unexpected symbol `const'
error CS1525: Unexpected symbol `='
*/
```
## Expressions and Evaluations
* An `expression` is a combination of values, variables, operators, and calls to methods.
  * An expression can be thought of as a formula that is made up of multiple pieces
* The `evaluation` of an `expression` produces a value, known as the return value.
  * We say: `"An expression returns a value."`
```C#
Console.WriteLine(1 + 1);
// Output: 2
```
* `Expression` can be placed on the right-hand side of a `assignment statement`
```C#
int multiple = 1 * 2;
Console.WriteLine(multiple);
// Output: 2
```
## Operations
### Operators and Operands
* **Operators**: are one or more character that represent a computation
  * ie: Like when we add, subtract, multiply, and or divide something
* **Operands**: are the values an `operator` work on
* Example:
```C#
2000 * 5000
// Operator = *
// Operands = 2000 and 5000
```
* You can use variables in the place of an `operand` and your code will still work:
```C#
double minutes = 645;
double hours = minutes / 60;
Console.WriteLine(hours);
// Output: 10.75
```

#### Arithmetic Operators
* These are some of the most commonly-used operators
* They perform the most basic math function we all know and long
  * But hate to do in our head... Or at least I do
* `%` or modules is one you might not know
  * This is similar to the `remainder operator`
    * It returns the integer remainder of dividing the two operands.

![Arithmetic Operators](./assets/ch-4/arithmetic-operators.png)

#### More on the Modulus
* The `modulus operator` (%) is common in programming
  * But what the hell does it do??!!
  * `%` operator returns the remainder obtained by carrying out integer division of the first operand by the second operand
  * ie:
    * 12 % 4 is 0
      * 4 divides 12 evenly (that is, there is no remainder)
    * 13 % 7 is 6
    * 6 % 2 is 0
    * 7 % 2 is 1

```C#
Console.WriteLine(12 % 4);
Console.WriteLine(13 % 7);
Console.WriteLine(6 % 2);
Console.WriteLine(7 % 2);
```

#### More on Exponentiation
* The `Math.Pow()` method is needed to do these types of calculations
  * It can only use `double` `data types`!
* For cleaner code be sure when you store the `Math.Pow()`method inside of a variable so that you do not have a bunch of parentheses all over the place
* **Do this**:
```C#
/*
creating a variable for the exponentiation
which will be called in the Console.WriteLine
*/

double numPower = Math.Pow(num1, num2);
Console.WriteLine(numPower);
```
* **Not this**:
```C#
/*
using the variables in the Math.Pow() method and
perfroming the exponentiation in the Console.WriteLine
*/

double num1 = 4;
double num2 = 3;
Console.WriteLine(Math.Pow(num1, num2)); // This is hard to read
```

#### Order of Operations
* C# follows the same precedence rules for its arithmetic operators that mathematics does
* Remember the acronym PEMDAS can be used to remember order of operations:
  * P = parentheses - have the highest precedence and can be used to force an expression to evaluate in the order you want
  * E = exponentiation - has the next highest precedence
  * M = multiplication - has the same precedence as `division` and `modulus`
  * D = division - has the same precedence as `multiplication` and `modulus`
  * A = addition - Same precedence as `subtraction`
  * S = subtraction - Same precedence as `addition`
    * `Operators` with the same precedence are evaluated from left-to-right
* **Gotchas**:
  * Operators, such as + and *, are type-dependent.
    * Meaning both of these work but within the context of what we are doing:
      * `2 + 2 = 4`
      * `string fullName = "Doc " + "Martin"`

### Other Operators
#### The String Operator +
* The `+ operator` can be used with `string` operands to `concatenate`, or `join together two strings`

```C#
Console.WriteLine(1 + 1);
// Outputs: 2

Console.WriteLine("1" + "1");
// Outputs: 11
```

#### Compound Assignment Operators
* It is common to have to update the value of a variable in reference to itself
```C#
int x = 1;
x = x + 1;

Console.WriteLine(x);
// Outputs: 2
```
* You can speed this up by performing the following
```C#
int x = 1;
x += 1;

Console.WriteLine(x);
// Outputs: 2
```
* More compound assignment operators
![compound assignment operators](./assets/ch-4/compound-assignment-operators.png)

### Input with ReadLine
#### Requesting Data
* Let's say we want to prompt the user to provide us their name
* We can utilize the `Console.ReadLine` method
* You are able to set this up with the following algorithm:
```C#
// Here we are providing a prompt
Console.WriteLine("Enter your name");

// Here we are telling the program to wait for the user input
// And then telling it to store said input in the variable name
string name = Console.ReadLine();

// Here we are outputting a concated string with the user's input
Console.WriteLine("Your name is " + name);
```

#### Critical Input Detail
* Have student mess with this code for a few minutes and then bring them back to discuss
```C#
Console.WriteLine("Enter a number");
string num1 = Console.ReadLine();


Console.WriteLine("Enter a number");
string num2 = Console.ReadLine();


Console.WriteLine(num1 + num2);
```
* **Gotcha**:
  * In C#, `ReadLine` entries must be `strings`!

## Whats Next
1. First, student will need to complete (In this order):
   1. [Exercises: Data and Variables](https://education.launchcode.org/intro-to-programming-csharp/chapters/data-and-variables/exercises.html)
   2. [Studio: Data and Variables](https://education.launchcode.org/intro-to-programming-csharp/chapters/data-and-variables/studio.html)
2. Then students should read [Chapter 5: Making Decisions With Conditionals](https://education.launchcode.org/intro-to-programming-csharp/chapters/booleans-and-conditionals/index.html)
3. Then students will sit for [Chapter 5's Lecture](./chapter-5-making-decisions-with-conditionals.md)