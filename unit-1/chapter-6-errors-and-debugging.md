# Chapter 6: Errors and Debugging
- [Chapter 6: Errors and Debugging](#chapter-6-errors-and-debugging)
  - [What is Debugging](#what-is-debugging)
    - [Beginning Tips For Debugging](#beginning-tips-for-debugging)
  - [Categories of Errors](#categories-of-errors)
    - [Stages of C# Execution](#stages-of-c-execution)
      - [Compilation](#compilation)
      - [Execution](#execution)
    - [Compile-Time Errors, Warnings, and Exceptions](#compile-time-errors-warnings-and-exceptions)
      - [Compiler Errors](#compiler-errors)
      - [Compiler Warnings](#compiler-warnings)
      - [Exceptions](#exceptions)
    - [Logic Errors](#logic-errors)
  - [Diagnosing Error Messages](#diagnosing-error-messages)
    - [Complier Messages 101](#complier-messages-101)
    - [Syntax Highlighting](#syntax-highlighting)
  - [Debugging Logic Errors](#debugging-logic-errors)
    - [Printing Values](#printing-values)
  - [Errors and User Input](#errors-and-user-input)
    - [TryParse](#tryparse)
      - [TryParse and out](#tryparse-and-out)
  - [How to Avoid Debugging](#how-to-avoid-debugging)
    - [Start Small](#start-small)
    - [Keep It Working](#keep-it-working)
  - [Asking Good Questions](#asking-good-questions)
    - [What is the problem with your code?](#what-is-the-problem-with-your-code)
    - [What have you done to try to address the problem?](#what-have-you-done-to-try-to-address-the-problem)
    - [Where have you looked for an answer?](#where-have-you-looked-for-an-answer)
  - [Whats Next](#whats-next)
## What is Debugging
* `Bugs`: are programming errors that prevents a program from working as intended
* `Debugging`: is the process of tracking down `bugs` and correcting them
* There are three types of errors:
  1. `Syntax Errors`
  2. `Runtime Errors`
  3. `Logic Errors`
### Beginning Tips For Debugging
1. Debugging require a detective like mindset
2. 9 times out 10 its an issue with your code not `C#`
3. Think critically about what you have written in your code
   * Ask yourself:
     * What am I trying to do here?
     * What have I told my code to do?
## Categories of Errors
* Be sure to categorize your errors before trying to debug them
* Each bug type manifests itself in a different way
* Once you know the type of bug you can come up with a strategy to squash it
### Stages of C# Execution
* Remember there are two stages of code execution:
  1. Compilation
  2. Execution
#### Compilation
* `Compilation Stage`: is the process of your code being `complied`, `validated`, and `prepared` for `execution` before it is ran
  * Think of it as a `pre-flight` check
* In a nut shell the `compilation stage` verifies the syntax and structure of the code
  * There is a lot that happens during this stage, but for now we will just stick with the understanding that we have defined above

#### Execution
* `Execution Stage`: is when our code logic is actually carried out
  * ie: printing to the console, prompting the user for input, making calculations, etc.
  * Think of it as the plane taking flight

### Compile-Time Errors, Warnings, and Exceptions
* C# will only execute a program if the programs syntax is correct
* `Syntax` is the structure of the language and the rules that govern it
* C#'s `complier` is super dope!
  * When in action it reads each line of your code and performs all coding task
* If the `complier` detects an `bug` in your code it will stop and give you feedback
* Said feedback falls into one of the following:
  1. `Compile Errors`
  2. `Compile Warnings`
  3. `Exceptions`

#### Compiler Errors
* `Compile Errors`: usually a violation of the syntax rules of the language
  * ie: `Syntax Errors`
* `Syntax Errors` are triggered during the `compilation stage`
  * If there is a single `syntax error` C# will quit the program and throw an error
  * Due to this we normally receive `syntax error` before any others
* Example of syntax errors:
```C#
string city = Philly;
Console.WriteLine(city;

// Outputs: error CS1525: Unexpected symbol `;', expecting `)' or `,'
// Outputs: Compilation failed: 1 error(s), 0 warnings
```

#### Compiler Warnings
* `Warning`: are thrown when your code is functional but there is a flaw in the logic or execution of it
  * These `warnings` are normally for things like a variable that has been declared but was never used
```C#
string animal = "Sloth";
string jedi;
Console.WriteLine(animal);
// Outputs: warning CS0168: The variable `jedi' is declared but never used
// Outputs: Compilation succeeded - 1 warning(s)
// Outputs: Sloth
```
* Notice here we are provided a `warning` but out code is still executed
#### Exceptions
* `Exceptions`: occur while the program is running
  * Usually caused by an unanticipated error in your code
* Have you seen an `Unhandled Exception` error message yet?
  * They can be caused by things like:
    * Unanticipated user input
    * Trying to divide by zero
    * etc.
* Talking about `exceptions` is a large topic, one that could take an entire lecture period
  * We will cover more in future lectures
  * If you want to read more checkout:
    * [C# - Exception Handling](https://www.tutorialspoint.com/csharp/csharp_exception_handling.htm)
    * [Exceptions and Exception Handling](https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/exceptions/)

```C#
Console.WriteLine(5/0);
// Outputs: main.cs(6,23): error CS0020: Division by constant zero
// Outputs: Compilation failed: 1 error(s), 0 warnings
```
### Logic Errors
* `Logic Error`: as stated is an error with your `logic` of the code you have written
  * `Logic Errors` at times can be hard to diagnose due to the fact that your code will successfully `compile` and `execute` but it will not function as intended
    * ie: What you wanted the program to do is not what you told it to do
```C#
double weeklyPay = 600;

double dailyEarnings = weeklyPay / 7;
Console.WriteLine(dailyEarnings);

// Outputs: 85.71428571428571
```
* Let's say you wanted to see how much you make in a 5 day work week
* You work 5 days a week
* And are expecting to make $100/day
* Yet according to the code above you make $85.71/day
* _What is the issue?_
  * Well you are dividing by _7 days_ instead of _5 days_
## Diagnosing Error Messages
* **Error Messages are your friend**
### Complier Messages 101
* Let's step through some errors:
```C#=
using System;

class MainClass {
   public static void Main (string[] args) {

      string name = "Julie";
      Console.WriteLine("Hello,  + name);
   }
}

// Outputs: main.cs(7,39): error CS1010: Newline in constant
// Outputs: main.cs(8,2): error CS1525: Unexpected symbol `}', expecting `)' or `,'
// Outputs: main.cs(8,3): error CS1002: ; expected
// Outputs: Compilation failed: 3 error(s), 0 warnings
// Outputs: compiler exit status 1
```
* Things to 
### Syntax Highlighting

## Debugging Logic Errors
### Printing Values

## Errors and User Input
### TryParse
#### TryParse and out

## How to Avoid Debugging
### Start Small
### Keep It Working

## Asking Good Questions
### What is the problem with your code?
### What have you done to try to address the problem?
### Where have you looked for an answer?

## Whats Next
1. First, student will need to complete (In this order):
   1. [Exercises: Debugging](https://education.launchcode.org/intro-to-programming-csharp/chapters/errors-and-debugging/exercises.html)
   2. There is no studio for this chapter
2. Then students should read [7. Stringing Characters Together](https://education.launchcode.org/intro-to-programming-csharp/chapters/strings/index.html)
3. Then students will sit for [Chapter 7 Lecture](./chapter-7-stringing-characters-together.md)