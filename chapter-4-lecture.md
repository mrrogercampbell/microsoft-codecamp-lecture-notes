# Chapter 4: Data and Variables
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


## Exercises: Data and Variables - Solution
```C#
using System;

class MainClass {
  public static void Main (string[] args) {
    // FORK this starter file and save it to your own Repl.it account.
    
    // Declare and assign the variables here:
    string shuttleName = "Determination";
    int shuttleSpeed = 17500;
    int distanceToMarsKm = 225000000;
    int distanceToMoonKm = 384400;
    double milesPerKilometer = 0.621;


    // Code your solution to exercises B and C here:

    // B | A:
      // Create and assign a miles to Mars variable. 
      // You can get the miles to Mars by multiplying the distance to Mars in kilometers by the miles per kilometer.
    double distanceToMarsMiles = distanceToMarsKm * milesPerKilometer;
    Console.WriteLine(distanceToMarsMiles);
      // Gotcha:
        // If attempt to assign the distanceToMarsMiles varaibale the int type you will throw an error because milesPerKilometer is a double and can not be covered back to a int


    // B | B: 
      // Next, we need a variable to hold the hours it would take to get to Mars. 
      // To get the hours, you need to divide the miles to Mars by the shuttle’s speed.
    double hoursToMars = distanceToMarsMiles / shuttleSpeed;
    Console.WriteLine(hoursToMars);
        // Gotcha:
            // If attempt to assign the hoursToMars varaibale the int type you will throw an error because the result of your equation is a double


      // B | C:
        // Finally, declare a variable and assign it the value of days to Mars. 
        // In order to get the days it will take to reach Mars, you need to divide the hours it will take to reach Mars by 24.
      double daysToMars = hoursToMars / 24;
      Console.WriteLine(daysToMars);

      // C:
      Console.WriteLine(shuttleName + " will take " + daysToMars + " days to reach Mars.");
        // Gotchas:
          // You must add `+ signs` to concat each variable to the sentence
          // In order to get proper spacing you must add extra space to the end and beingin of each string

    // Code your solution to exercise D here:

    double distanceToTheMoonMiles = distanceToMoonKm * milesPerKilometer;
    Console.WriteLine(distanceToTheMoonMiles);

    double hoursToTheMoon = distanceToTheMoonMiles / shuttleSpeed;
    Console.WriteLine(hoursToTheMoon);

    double daysToTheMoon = hoursToTheMoon / 24;
    Console.WriteLine(daysToTheMoon);

      Console.WriteLine(shuttleName + " will take " + daysToTheMoon + " days to reach the Moon.");

    
  }
}
```