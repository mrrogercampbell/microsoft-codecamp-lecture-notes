# Chapter 20: Unit Testing

## Why Test Your Code?
* Testing your code is a very important step of the development process
* It allows you to be sure your code is functioning properly based on the user requirements you have be provided
* Up until now we have been testing our programs manually
* Well no more with that mess!
  * If you have to do something more then once, you can probable automate it!

### Finding Regressions
* `Regression`: is a type of software bug where a feature that has worked before stops working
* Say you have a pre-existing app that works properly
  * But then you add a new feature
  * That new feature breaks you old features in some way
  * That is a REGRESSION!!
    * Think of a child you teach them how to act a specific way as a youngling and then they hit pre-teen age and regress back to acting like a toddler

### Testing as Documentation
* `Self-documenting code` is code that clearly expresses its intent to the reader
* One way we can make clear is to utilize unit test
  * By writing unit test for our application based on specific user requirements we are able to create a form of documentation within our codebase that any other engineer can read an know exactly how the code should function adn operate
    * Also said test can let us know wether our code is functioning very quickly and easily
    * So its a win win!!

## Testing in C#
* In C# we can utilize a test framework called MSTest for unit testing
  * Keep in mind this is just one of many testing frameworks available for C#
### Why We Test
#### Refactoring
* `Code refactoring` is  the process of restructuring existing code to optimize its performance and or readability
* Remember what Roger's first instructor taught him about writing code?
  1. Make it Work - Write the code however you need to, to make it functional
     * It can be unD.R.Y.
  2. Make it Pretty
  3. Make it Fast!
     * Each stage after making it work is refactoring your code