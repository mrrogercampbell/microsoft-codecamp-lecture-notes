# Chapters 1, 2, and 3 Review
- [Chapters 1, 2, and 3 Review](#chapters-1-2-and-3-review)
  - [Chapter 1: Introduction](#chapter-1-introduction)
    - [Why Learn to Code?](#why-learn-to-code)
    - [Why Learn C Sharp?](#why-learn-c-sharp)
    - [About LaunchCode Programs](#about-launchcode-programs)
      - [Goals:](#goals)
      - [Course Activities:](#course-activities)
    - [Class Platforms](#class-platforms)
      - [Repl.it](#replit)
      - [Create A Repl.it Account](#create-a-replit-account)
  - [Chapter 2: How Programs Work](#chapter-2-how-programs-work)
    - [Algorithms](#algorithms)
    - [Check for Understanding](#check-for-understanding)
    - [Programming Languages](#programming-languages)
      - [Languages](#languages)
      - [How Computers Run Programs](#how-computers-run-programs)
      - [How Many Programming Languages Are There?](#how-many-programming-languages-are-there)
    - [The C# Language](#the-c-language)
    - [Your First Program](#your-first-program)
  - [Chapter 3: How To Write Code](#chapter-3-how-to-write-code)
    - [What is Code?](#what-is-code)
      - [What Code Can Do](#what-code-can-do)
    - [Syntax Rules](#syntax-rules)
    - [Comments](#comments)
    - [Output with Console.WriteLine](#output-with-consolewriteline)
      - [Examples](#examples)
      - [Two Special Characters](#two-special-characters)
    - [Fixing Errors in Your Code](#fixing-errors-in-your-code)
      - [Asking for Help](#asking-for-help)
    - [Welcome, Novice Coder](#welcome-novice-coder)
## Chapter 1: Introduction
### Why Learn to Code?
* Ask students why they think its a good idea to learn to code?
* Give a few quick explanation of why its important to code:
  * Code is used in every part of our daily lives:
    * Cell phones
    * Self-checkouts
    * Cars (Tesla)
    * Smart devices
    * Astronaut suites (NASA Currently using Node in [suites](https://openjsf.org/wp-content/uploads/sites/84/2020/02/Case_Study-Node.js-NASA.pdf))
    * etc.
  * You can make a living wage/finical freedom!
    * There is big money in the industry
  * You are able to create thing from your imagination
    * I always wanted to be an artist but can not draw or pain to save my life; coding allows me to dream up things and bring them to fruition

### Why Learn C Sharp?
* You can use it to build:
  * Web, mobile, and desktop apps
  * Games (Unity)
  * Distributed and cloud apps
    * Which makes it well rounded
* C# is designed to be easy to read and with practice it will be
  * Practice here being the key word
  * The more you build the easier it will be, this also goes for any language you learn; coding or otherwise.
* Remember by choosing engineering as a profession you are choosing a life long pursuit of knowledge
  * "You will never know more than you don't know" - Roger Campbell II

### About LaunchCode Programs
#### Goals:
* Help build your problem solving skills and encourage you to learn how to learn.
  * Learning how to learn will help you continually adapt to the changing needs of your industry
* To get you ready for a career in technology and your first position with Microsoft
* We will be teaching you the skills found in a wide variety of professions and industries:
  * **Professions**: Software Engineering, DevOps, Project Management, etc
  * **Industries**: Information Technology, Automotive, Space exploration, and much much more

#### Course Activities:
1. **Prep Work**: We will allocate time before each lecture for you to individual read the chapter that wil be covered
   * It is vidal that you utilize this time to read the chapter so that you are able to come to each lecture with questions on the material
   * It is recommend that you first just read the chapter then attempt to code any of the examples provided
2. **Exercises**: Small coding problems that will allow you to implement  and reinforce what was covered in the previous lecture
3. **In-class Time**: Will be broken into two sections:
   1. **Large Group Time**: AKA daily lecture(s).
      * This is time allocated for us to meet as an entire cohort and have a lecture with the Lead Instructor (Your truly! Roger Campbell II)
   2. **Small Group Time**: After daily lectures you will be broken into smaller groups which are led by your TAs
      * During this time you will work on coding activities:
        * Studios, exercises, and concept checks
4. **Assignments**: Larger project that demo what you have learned from multiple lessons

### Class Platforms
#### Repl.it
* [Repl.it](https://replit.com/~) is a free online Integrated Development Environment (IDE); ie code editor
  * It provides a practice space where you can hone your programming skills
  * Repl.it serves two purposes:
    1. To provide opportunities to respond to prompts, questions, and “Try It” exercises embedded within the reading. These tasks are neither tracked nor scored.
    2. To hold larger exercises and studios that will be checked for accuracy and tracked for completion.

#### Create A Repl.it Account
* Verify students have created an account
  * If they have not remind them that this was pre-work and they should reference [Chapter 2](https://education.launchcode.org/intro-to-programming-csharp/chapters/how-programs-work/hello-world.html#your-first-program) for instructions on how to create an account
* Repl.it is an online code editor for various languages. Coders collaborate by sharing repl.it URLs.
* Repl.it is used for:
  * Publicly sharing code examples and starter code
  * A place to practice new concepts by writing and running code

## Chapter 2: How Programs Work
### Algorithms
* Ask the students:
  * What is an Algorithm?
    1. An algorithm is like a recipe:
      * A recipe provides a list of ingredients and a series of step-by-step instructions on how to prepare, mix, and prepare the thing you are making
    2. An algorithm can also be thought of as directions from your GPS
      * It provides you instruction on how to get from point A to B and is able to take into account real time traffic to get you there
### Check for Understanding
* Drop the following question in the Slack channel and have students provided the numbers they believe can answer the question
  * Select ALL of the following that can be solved by using an algorithm (More than one answer):
    1. Answering a math problem.
    2. Sorting numbers in decreasing order.
    3. Making a peanut butter and jelly sandwich.
    4. Assigning guests to tables at a wedding reception.
    5. Creating a grocery list.
    6. Suggesting new music for a playlist.
    7. Making cars self-driving.

### Programming Languages
* Contrary to popular belief computers do not understand `human scribbles and or utterances written`
  1. Computers communicate via **binary code**
    * Binary code is a `two-symbol system` (0s and 1s)
    * Each character is assigned a pattern of 8 bits (0s and 1s)

```md
<!-- Human Scribble Converted to Binary -->
Hello World:

01001000 01100101 01101100 01101100 01101111 00100000 01010111 01101111 01110010 01101100 01100100
```
2. Binary data can also be represented as **hexadecimal** values
   * This can make things a bit easier
```md
<!-- Human Scribble Converted to Hexadecimal -->
Hello World:

48 65 6c 6c 6f 20 57 6f 72 6c 64
```
#### Languages
* Since computers are a lot smarter and efficient at communicating than the general human population we had to come up a easier way for people to communicate with computers so we can tell them what to do
  * `Programming Languages` such as C#, Python, JavaScript, Basic, COBOL, C++, Java, and many others were created for this very reason
    * The above listed are considered `high-level languages` can be written and understood by us peons
      * Each has its own characteristics, vocabulary, styles, and syntax

#### How Computers Run Programs
* Walk students through this [diagram](https://education.launchcode.org/intro-to-programming-csharp/_images/csharp-compiler.png)
  * In the example above, the syntax for printing Hello, World! varies between the C#, Python, JavaScript, and Java languages, but the end result is the same.

#### How Many Programming Languages Are There?
* A shit-ton!
* Big thing here: once you learn one you can learn any of them
  * The only difference is syntax but the general logic and principles are fairly similar
  * To display text on the screen:
    * C#: `Console.WriteLine()`
    * Python: `print()`
    * JavaScript: `console.log()`

### The C# Language
* Whereas we have already touched on C# in this review, I want to talk specifically about it within the context of Web Development
  * Ask students some of the following questions:
    * How would you utilize C# within Web Development?
      * To build a code that runs inside the web browser
    * What does it mean to `run code inside the browser`?
      * The code runs at the same time as a web page and can modify the content of the page and or site.
    * What kind of could we write our C# code to change on a web page?
      * Add or remove text, change colors, produce animations, and react to mouse and keyboard clicks
    * What is Front End Development?
      * Front End development is code we write that is present on the users computer
    * What is Back End Development?
      * Involves passing data between web pages and servers
    * Can anyone tell me an example of how the front end and back end work in tandem?
      * When a user fills out a form and submits it the front end displays the form as well as handles the logic of packaging and shipping the entered information to the back end database
      * Show users this [Front End vs. Back End Changes](https://education.launchcode.org/intro-to-programming-csharp/_images/Front-vs-back-end.png) image as an example

### Your First Program
* The main part of this section was to let students get they hands dirty and write some code. Really no reason to review this section per say
  * If you have time Navigate to [Repl.it](https://replit.com/) and walk student through the following prompts:
    1. Print "Hello World"
    2. Change the message that is printed.
    3. Figure out what the parentheses do. Will the code work without them?
    4. Remove one or both quotation marks. Do we need to include both opening and closing quote marks? Is there a difference between using a single or a double quote (' vs. ")?
    5. Remove the semi-colon, ;.
    6. Print a number. (Bonus: Print two numbers added together).
    7. Print multiple messages one after the other.
    8. Print two messages on the same line.
    9. Print a message that contains quote marks, such as Quoth the Raven "Nevermore".
    10. Other. You choose!

## Chapter 3: How To Write Code
### What is Code?
* Computer currently have no way to take into account context or intended meaning, due to this they will do explicitly whatever you tell them
  * Which is not always what you mean for them to do
  * If you tell a computer to do something which complies into an error the computer will most of the time lockup and or stop working or present an error message
#### What Code Can Do
* Ask students to provide you some examples of what task we can have a computer do with code:
  * Interact with users. Through code, we can ask a user questions, store the answers, and respond by changing what is on the screen.
  * Interact with other systems. Through code, we can interact with resources that are outside of our program. For example, we can read data in from a file on our computer, or we can ask a server on the other side of the planet for information.
  * Repeat tedious tasks. Have a few thousand emails to send? Need to spellcheck several thousand words? You can do these things with just a handful of code.
  * Reuse useful code snippets. Rather than copy/paste the same lines of code in multiple places, we can assign a name to that code. This allows us to use it wherever we like by simply referring to its name.
  * Decide what to do based on the current situation. When we write code, we often need to carry out one task under a specific set of circumstances, but another task if the circumstances differ. We can write code to decide which action to take.
* If you do not get a lot of feedback provide your own examples
### Syntax Rules
* Programing languages are a collection of rules that allow us to tell a computer what to do
* Syntax is the structure of a language and the rules about that structure
* C# and other languages will only run a program if it is `syntactically correct`
  * Whereas us humans can infer and read through typos a computer cannot
* Ask students what are some examples of `Syntax Errors` that they can think of?
  * Missing `{}s`
  * Incorrectly spelled keywords
  * Typos
      * _Students may not have an answer for this and that is ok_
### Comments
* Comments allow you to leave messages and or instructions within your code for your human counterparts
* In C#:
  * Single-line comments are denoted by `//`
  * Multi-line comments are denoted by `/*   */`
* If time permits show students this example in [Repl.it](https://repl.it/@launchcode/CSharpCommentsExample01)
  * Big things to show here are:
    1. The single-line and multi-line comments
    2. The code successful runs but does not output the commented code in any shape or form
### Output with Console.WriteLine
* Here we are just diving deeper into the capabilities of `Console.WriteLine`
#### Examples
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
#### Two Special Characters
1. Each time we use `Console.WriteLine` a **newline** is inserted after the printed content
   * This is similar to hitting the `Enter` or `Return` key
   * `Newline` to a computer is a invisible character that tells it to move to the next line
2. You can trigger a `newline` within your code with the `\n` syntax
```C#
Console.WriteLine("Some Programming Languages:");

Console.WriteLine("C#\nPython\nJavaScript\nJava\nSwift");
```
* You can demo this code here: [Repl.it](https://repl.it/@launchcode/ConsoleWriteLineExamples02)

### Fixing Errors in Your Code
* Ask students:
  * What is it called when you are attempting to fix an error within your code?
    * **Debugging** is a vital skill you will always be honing as a Engineer
#### Asking for Help
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