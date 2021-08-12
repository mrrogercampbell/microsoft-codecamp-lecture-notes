# Chapter 6: Repeating Things With Loops
- [Chapter 6: Repeating Things With Loops](#chapter-6-repeating-things-with-loops)
  - [for Loop Syntax](#for-loop-syntax)
  - [More on Range](#more-on-range)
    - [Set Start and End Values](#set-start-and-end-values)
    - [Set a Step Value](#set-a-step-value)
    - [Use Variables in range](#use-variables-in-range)
    - [Use Expressions in range](#use-expressions-in-range)
  - [Loop Through a String](#loop-through-a-string)
    - [Characters Another Way](#characters-another-way)
  - [Loops With Conditions](#loops-with-conditions)
    - [Looping if](#looping-if)
  - [The Accumulator Pattern](#the-accumulator-pattern)
    - [Building a String With the Accumulator Pattern](#building-a-string-with-the-accumulator-pattern)
    - [Reverse a String With the Accumulator Pattern](#reverse-a-string-with-the-accumulator-pattern)
    - [Decreasing a Total With the Accumulator Pattern](#decreasing-a-total-with-the-accumulator-pattern)
  - [while Loops](#while-loops)
    - [while Loop Syntax](#while-loop-syntax)
    - [for Loops Rewritten as while Loops](#for-loops-rewritten-as-while-loops)
    - [Input Validation](#input-validation)
  - [Infinite Loops](#infinite-loops)
  - [Ending a Loop With break](#ending-a-loop-with-break)
## for Loop Syntax
* `for loops` in `Python` are structured a little bit differently than `C#`
  * Let's take a look:

```python
for num in range(5):
    print(num)

print("All Done!")
# Outputs:
# 0
# 1
# 2
# 3
# 4
# All Done!
```
* Let's break it down:
  1. We utilize the `for` keyword to declare a `for loops`
  2. We declare a variable `num` which will store a number for each iteration
  3. We use the `in` which in this use case is telling our code to iterate through a sequence of number
  4. We use the `range` function to tell out loop that the sequence we want to iterate over is a serious of numbers
     * The sequence provided by `range` always starts at `0`
## More on Range
### Set Start and End Values
* We are able to provide the `range()` function with a `start` and `end` value: `range(start_value, end_value)`
```python
for num in range(3,7):
    print(num)

# Outputs:
# 3
# 4
# 5
# 6
```
### Set a Step Value
* We can also provide the `range()` function a `step value`: `range(start_value, end_value, step_value)`
  * A `step value` is the number we want to increment or decrement by
```python
# Incrementing
for num in range(2, 10, 2):
    print(num)
# Outputs:
# 2
# 4
# 6
# 8
```

```python
# Decrementing
for num in range(10, 2, -2):
    print(num)
# Outputs:
# 10
# 8
# 6
# 4
```

### Use Variables in range
* You are also free to use variables within your `range()` function:
```python
start_value = int(input("Enter the FIRST number to print: "))
end_value = int(input("Enter the LAST number to print: "))
step_value = int(input("Enter the step value for the loop: "))

for num in range(start_value, end_value, step_value):
    print(num)
```

### Use Expressions in range
* We are also able to use `expressions` in the `range()` function:
```python
message = "Hello"
for num in range(len(message)):
    print(message * num)
# Outputs:
# 
# Hello
# HelloHello
# HelloHelloHello
# HelloHelloHelloHello
```
* **Gotcha**:
  * Can you guess why there is an empty space before the first `Hello` is outputted?
    * Remember `range()` always starts at `0` unless you tell it otherwise

## Loop Through a String
* Yes you can even iterate over a `string` in `Python`
  * In `Python` a `string` is considered a `sequence`
    * It is a `sequence` of `characters`
    * In `Python` a `sequence` is a _generic term for an ordered set_
```python
for char in 'supercalifragilisticexpialidocious':
    print(char)
```
* And we can use variables:
```python
song = 'supercalifragilisticexpialidocious'
for char in song:
    print(char)
```

### Characters Another Way
* We are also able to access a `sequence` via `zero based indices`:

```python
language = 'Python'

print(language)
print(language[0])
print(language[1])
print(language[5])
# Outputs:
# Python
# P
# y
# n
```

## Loops With Conditions
* Yes you can also use `conditionals` in your `loops`:

```python
num = 4

for number in range(num):
  if number%3 == 0:
    print(number, "is divisible by 3.")
  else:
    print(number, "is NOT divisible by 3.")
# Outputs:
# 0 is divisible by 3.
# 1 is NOT divisible by 3.
# 2 is NOT divisible by 3.
# 3 is divisible by 3.
```
* We could also do something like this:
```python
text = 'Ducklings!'
num_vowels = 0

for char in text:
  if char in 'aeiou':
    num_vowels += 1

print(text, "contains", num_vowels, "lowercase vowels.")
# Outputs:
# Ducklings! contains 2 lowercase vowels.
```
### Looping if
* And yes, you can out a `loop` inside an `if statement`:
```python
if condition:
   for var_name in range(value):
      # Loop body
elif other_condition:
   for char in string:
      # Loop body
else:
   for step in range(20):
      print("Python ROCKS!")
# Outputs:
```
## The Accumulator Pattern
* The [Textbook](https://education.launchcode.org/lchs/chapters/loops/accumulator-pattern.html#keeping-a-running-total) gives a great explanation of what an `accumulator pattern` is and an example of one
* Here is the example they give:
  * _Assume you are working at a theater, and your job is to count how many people walk through the front door. To help you keep track of the total, your boss gives you a counting tool. Every time a person walks in, you push a button and CLICK, the total displayed on the tool increases by 1._
* Here is their explanation:
  * _This is an example of the `accumulator pattern`. Every time a particular event occurs, the value of a running total gets updated._
* Let's take a look at an `accumulator pattern`:
```python
num = 6
total = 0

for integer in range(1, num + 1):
   total += integer

print(total)
# Outputs:
# 21
```

### Building a String With the Accumulator Pattern
* You can also use the `Accumulator Pattern` to create a `string`:
```python
only_vowels = ''
message = 'Coding is Great!!!'

for char in message:
    if char in 'aeiou':
        only_vowels += char

        print(only_vowels)
# Outputs:
# o
# oi
# oii
# oiie
# oiiea
```

### Reverse a String With the Accumulator Pattern
```python
string_to_reverse = 'Python'
reversed_string = ''

for char in string_to_reverse:
    reversed_string = char + reversed_string

print(reversed_string)

# Outputs:
# nohtyP
```

### Decreasing a Total With the Accumulator Pattern
```python
total = 1000
decrease_by = 25

for step in range(10):
    total -= decrease_by
    print(total)

print('The final total is: ' + str(total))
# Outputs:
```

## while Loops
### while Loop Syntax
* The `while loop` syntax in `Python` is similar to that of a `while loop` in `C#`:
```python
while boolean expression:
   loop body
```
* Lets look at an actually implementation of one:
```python
total = 0
increase_by = 10

while total < 50:
   total += increase_by
   print(total)
# Outputs:
# 10
# 20
# 30
# 40
# 50
```

### for Loops Rewritten as while Loops
* A `for loop`:
```python
for num in range(5):
    print(num)
# Outputs:
# 0
# 1
# 2
# 3
# 4
```
* The `for loop` above rewritten as a `while loop`:
```python
num = 0

while num < 5:
   print(num)
   num += 1
# Outputs:
# 0
# 1
# 2
# 3
# 4
```
### Input Validation
* You can use `while loops` for input validation:
```python
num_choice = 0

while num_choice <= 0:
    num_choice = int(input('Choose a positive number: '))
    if num_choice <= 0:
        print('That is an invalid number')
    else:
        print('Thank you for entering positive number!')
# Outputs:
```
## Infinite Loops
* Yes they can happen in `Python` so be careful

## Ending a Loop With break
* The `break` keyword also exist in `Python` and you can use it to escape the execution of a `loop`:

```python
for num in range(42):
    print('This is iteration number:', num + 1)

    if num > 4:
        break


print("The loop is done!")
# Outputs:
# This is iteration number: 1
# This is iteration number: 2
# This is iteration number: 3
# This is iteration number: 4
# This is iteration number: 5
# This is iteration number: 6
# The loop is done!
```