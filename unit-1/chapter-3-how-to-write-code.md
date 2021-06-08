# Chapter 3: How To Write Code
## What is Code?
* Computer currently have no way to take into account context or intended meaning, due to this they will do explicitly whatever you tell them
  * Which is not always what you mean for them to do
  * If you tell a computer to do something which complies into an error the computer will most of the time lockup and or stop working or present an error message
### What Code Can Do
* Ask students to provide you some examples of what task we can have a computer do with code:
  * Interact with users. Through code, we can ask a user questions, store the answers, and respond by changing what is on the screen.
  * Interact with other systems. Through code, we can interact with resources that are outside of our program. For example, we can read data in from a file on our computer, or we can ask a server on the other side of the planet for information.
  * Repeat tedious tasks. Have a few thousand emails to send? Need to spellcheck several thousand words? You can do these things with just a handful of code.
  * Reuse useful code snippets. Rather than copy/paste the same lines of code in multiple places, we can assign a name to that code. This allows us to use it wherever we like by simply referring to its name.
  * Decide what to do based on the current situation. When we write code, we often need to carry out one task under a specific set of circumstances, but another task if the circumstances differ. We can write code to decide which action to take.
* If you do not get a lot of feedback provide your own examples
## Syntax Rules
* Programing languages are a collection of rules that allow us to tell a computer what to do
* Syntax is the structure of a language and the rules about that structure
* C# and other languages will only run a program if it is `syntactically correct`
  * Whereas us humans can infer and read through typos a computer cannot
* Ask students what are some examples of `Syntax Errors` that they can think of?
  * Missing `{}s`
  * Incorrectly spelled keywords
  * Typos
      * _Students may not have an answer for this and that is ok_
## Comments
* Comments allow you to leave messages and or instructions within your code for your human counterparts
* In C#:
  * Single-line comments are denoted by `//`
  * Multi-line comments are denoted by `/*   */`
* If time permits show students this example in [Repl.it](https://repl.it/@launchcode/CSharpCommentsExample01)
  * Big things to show here are:
    1. The single-line and multi-line comments
    2. The code successful runs but does not output the commented code in any shape or form

## Output with Console.WriteLine
* Here we are just diving deeper into the capabilities of `Console.WriteLine`

### Examples
  * Navigate to the following [Repl.it](https://repl.it/@launchcode/ConsoleWriteLineExamples01) and step through the following examples:
```C#
Console.WriteLine("Hello, C#.");
Console.WriteLine(2001);
Console.WriteLine("What","do","commas","do?");
Console.WriteLine("What" + "does" + "+" + "do?");
Console.WriteLine("How " + "can" + " you" + "add   " + "spaces?");
Console.WriteLine("LaunchCode was founded in" +  2013);
```
  * Line by line explanation:
1. In the line 1, we print some text, which is surrounded by quotes.
2. In the line 2, we print a number. Note the absence of quote marks.
3. In line 3, we use four words, separated by commas, all within the same set of parentheses (). When this statement prints, we only see the first word.
4. The code in line 4 prints all of the words using the +, but where are the spaces?
5. Line 5 also prints all of the words including the spaces added to each word within the double quotation marks.
6. Line 6 prints text and a number without a space in between.
### Two Special Characters
1. Each time we use `Console.WriteLine` a **newline** is inserted after the printed content
   * This is similar to hitting the `Enter` or `Return` key
   * `Newline` to a computer is a invisible character that tells it to move to the next line
2. You can trigger a `newline` within your code with the `\n` syntax
```C#
Console.WriteLine("Some Programming Languages:");

Console.WriteLine("C#\nPython\nJavaScript\nJava\nSwift");
```
* You can demo this code here: [Repl.it](https://repl.it/@launchcode/ConsoleWriteLineExamples02)

## Fixing Errors in Your Code
* Ask students:
  * What is it called when you are attempting to fix an error within your code?
    * **Debugging** is a vital skill you will always be honing as a Engineer

### Asking for Help
* This section is all about **how to properly ask for help**.
* Asking for help within your code is a extremely part of your growth and development as an engineer, but whereas asking for help is highly encouraged and supported there is also a balance.
  * Be sure before you ask for help you have attempted the following:
    1. Ask Google for help first.
       * Google your error message
         * You may find the answer right away!
         * Try reading forms (StackOverFlow)
    2. Make sure to document everything, this will help you if you are asking for help on a form.
       * The steps you took before you encountered the problem,
       * Screenshots of what the error message is
       * What your application should be able to do
    3. When asking your question, make sure that the person knows what documentation you have. If you took a screenshot or saved Google results related to the error message, inform the person who is helping you before you all start working together on the issue.

### Welcome, Novice Coder
* Yup! You're a coder now!
* Remember you will never know more than you don't know, so buckle up and never stop learning!

## Whats Next
1. After this students should read [4. Data and Variables](https://education.launchcode.org/intro-to-programming-csharp/chapters/data-and-variables/index.html)
2. Then should sit for [Chapter 4 Lecture](./chapter-4-data-and-variables.md)