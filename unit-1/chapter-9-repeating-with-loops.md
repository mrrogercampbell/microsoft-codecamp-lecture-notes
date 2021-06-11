# Repeating With Loops

## Iteration
* `Iteration`: is a sequence of instructions that is continually repeated
* There are `3` different types of iterations:
  1. `Iterate` until a certain condition is reached
  2. `Iterate` a certain number of times
  3. `Iterate` through `elements` (or items) in a `list` or `array`
* Lets say we want to count from `0 to 100` with the tools we currently have we would have to do the following:
```C#
Console.WriteLine(0);
Console.WriteLine(1);
Console.WriteLine(2);
Console.WriteLine(3);
Console.WriteLine(4);
Console.WriteLine(5);
Console.WriteLine(6);
// keep going...
Console.WriteLine(100);
```
* Well I'll tell you one thing that sure as heck isn't D.R.Y.!
* So how could we go about performing this task without having to write so much redundant code?
* Entering from this corner your new best friend... The `for loop`!
  * Let's see them in action!!
```C#
for (int i = 0; i < 100; i++)
{
   Console.WriteLine(i);
   // Try running this to see the output
}
```
* Now that is what I call D.R.Y.

# for Loops
* Whereas there are many types of `loops` a `for loop` is the first one you should know and understand
* `for loops` are typically used for `definite iteration`
* Above we saw the syntax for a `for loop` but lets peel back the layer and see what is going on with this onion:
```C#
for (initializer; condition; iterator)
{
  // code block to be executed
}
```
* First off; we have to realize that 5 things are going on in the above code:
  1. The `for` `keyword` tells C# we want to create a `for loop`
     * A for loop has three statements: `initialization`, `condition` and `iterator`
  2. The `initializer` is the `initial expression` that is executed at the onset of the loop and only once
     * It `declares` and `initializes` a `variable`
     * It is common convention is to use the letter `i`
  3. The `condition` is a boolean expression that either returns `true` or `false`
        * For as long as the expression returns true the loop will continue to run
        * ie: `iterate`
  4. The `code block execution` perform a task every time the `condition`'s expression evaluates as true
  5. The `iterator` either `increment` or `decrements` the initialized variable each time the the `execution block` runs
     * `Increment` mean to increase
     * `Decrements` means to decrease

* Let's see this in action again and step through it:
```C#
for (int i = 0; i < 4; i++)
{
   Console.WriteLine(i);
}
// Outputs: 0
// Outputs: 1
// Outputs: 2
// Outputs: 3
```
* Ok here we go:
  1. `for keyword`: Tells C# that we are starting a for loop
  2. `int i = 0`: we are creating a variable `i` and setting its value to `0`
  3. `i < 4`: is our condition which states `for as long as i's value is less than 4` run our code block
  4. Next the `code block` performs its work: `Console.WriteLine(i);`
     * On our first iteration `i = 0` and `0` is printed to the console
  5. Then our `iterator` increments `i` by one
     * `i++` is the same as saying `i = i + 1`
  6.  Finally our condition runs again and evaluates `i < 4` once more
          * is `i less than 4`?
          * Yes! Which means the loop iterates again and runs back through steps 1-6 again until the condition evaluates false

* Can you figure out what this `for loop` is doing?
```C#
    for (int i = 100; i > 0; i--)
    {
        Console.WriteLine(i);
    }
```
* It is counting down from 100!
  * This is an example of `decrementing`

* Here is a great image that showcases the logic of a `for loop`:

![Execution of a for loop](./assets/ch-9/execution-of-a-for-loop.png)

## Iterating Over Collections
* So if you like really?! That's it I can now count faster...
* Slow your roll ducklings lets take this up a notch

### Iterating Over Strings
* Ok ok so we have looked at utilizing a `for loop` for counting now let see how we utilize it for working with `strings`

```C#
    string name = "The Wheel on the bus!";

    for (int index = 0; index < name.Length; index++)
    {
      Console.WriteLine(name[index]);
    }
```
* The `for loop` allows us to `iterate` over the string and print each individual `char` that it contains!
* This is a game changer!!
* Let's add some context here:
  * It you look we changed the variable from `i` to `index`
    * `i` is an abbreviation for `index`
    * What we are able to do with the variable `index` is substitute a `static index` for our dynamic which in turn allows us to `iterate` over each `index` within our `string`
      * ie:
        * Up until now when we wanted to access a `string`'s index we would do this: `Console.WriteLine(name[0]);` which would output `T`
        * But now we can use `i` and access every index!
* Let see what happens if we switch up or logic and `decrement` instead of `increment`

```C#
    string name = "The Wheel on the bus!";
    Console.WriteLine(name.Length-1);

    for (int index = (name.Length - 1); index > 0; index--)
    {
      Console.WriteLine(name[index]);
    }
```
* Here we are able to iterate over the `string` from right to left!

### Iterating Over Arrays
* Ok so with what we just saw with `iterating` over an `string` think about the possibilities for working with `arrays`!
* Let's jump right in!

```C#
    string[] teas = { "black tea", "green tea", "white tea", "oolong tea", "purple tea", "herbal infusions"};

    for (int index = 0; index < teas.Length; index++)
    {
      Console.WriteLine(teas[index]);
    }
```
## Breaking Down the for Statement
### for Loop Anatomy
* The important thing here is to remember that there are three separate statements that work in tandem within a `for loop`:
  1. Initial Expression
  2. Loop Condition
  3. Update Expression (The iterator)
#### Initial Expression
* As stated above the `initial expression` is executed once before the any iterations happen
* You have the freedom to utilize any expression
  * Even an empty one
  * Although that is not a normal scenario,
    * Normally you will declare and initialize a variable
      * But hey _you are an Engineer do what you want!_
* The long and short of it is you can start off with any value you would like:
```C#
    for (int i = 50; i < 100; i++)
    {
      Console.WriteLine(i);
    }
```
* In the above example we set the value of our `initial expression` to `50`
```C#
    string[] jediRanks = { "Youngling", "Padawan", "Jedi Service Corps", "Jedi Knight", "Jedi Consular", "Jedi Guardian"};

    for (int index = 3; index < jediRanks.Length; index++)
    {
      Console.WriteLine(jediRanks[index]);
    }
```
* In this example we are able to set the value of our `initial expression` to 3
* The main take away here is you are able to set this value however you would like

#### Loop Condition
* The `loop condition` is a boolean expression that either returns `true` or `false`
  * It executes before each `loop iteration`
  * It will always be a `boolean expression`
    * ie: will evaluate to:
      * `true`: which means the loops code block executes and the loop `iterates` again
      * `false` means the loop execution stops and there are no more `iterations`
```C#
    string school = "Hogwarts";

    for (int i = -3; i > 1; i++)
    {
      Console.WriteLine(school[i]);
    }
```
* The above `loop's code block` will never run execution due to the `condition` never evaluating as `true`

```C#
    string school = "Hogwarts";

    for (int i = 0; i > -1; i++)
    {
      Console.WriteLine(school);
    }
```
* Make sure you pay attention to your `conditional logic`
* There is a disasterist phenomena
  * Yea, yea I know that might not be a word but you try running that code and see what happens...
  * I dare you...
  * Go ahead...
  * You're an Engineer.. Do whatever you want!

#### Update Expression
* The `iterator` or also known as the `update expression`:
  * Executes after _every_ `iteration` of a loop
  * This expression can be technically be anything
    * But there are rare instances where you might use it for anything other than updating the value of the `initial expression`
* The main thing to take away is that we use the `iterator` to increment or decrement the `initial expressions` value
```C#
    for (int i = 0; i < 51; i = i + 2)
    {
      Console.WriteLine(i);
    }
```

## The Accumulator Pattern
* A `pattern` is a general repeatable solution to a commonly occurring problem in software design

### Adding 1..n
