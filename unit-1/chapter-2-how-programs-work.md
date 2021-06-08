# Chapter 2: How Programs Work
- [Chapter 2: How Programs Work](#chapter-2-how-programs-work)
  - [Algorithms](#algorithms)
    - [Check for Understanding](#check-for-understanding)
  - [Programming Languages](#programming-languages)
    - [Languages](#languages)
      - [How Computers Run Programs](#how-computers-run-programs)
      - [How Many Programming Languages Are There?](#how-many-programming-languages-are-there)
  - [The C# Language](#the-c-language)
  - [Your First Program](#your-first-program)
  - [Whats Next](#whats-next)
## Algorithms
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

## Programming Languages
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
### Languages
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

## The C# Language
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

## Your First Program
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
* If students have not created an account for repl.it you can provide this link to [Create a Repl.it Account](https://education.launchcode.org/intro-to-programming-csharp/chapters/how-programs-work/hello-world.html#create-a-repl-it-account)

## Whats Next
* Next we will jump into [Chapter 3: How To Write Code](./chapter-3-how-to-write-code.md)
