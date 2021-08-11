# Chapter 5: Making Decisions With Conditionals
## Decision Making
* Ok, so lets get 2 things straight...
  1. In `Python` you do not use `{}` do denote the scope of an object; scope is denoted based on indentations
  2. We do not use `;` to say when a line of code ends
     * One of these makes Roger very happy, I will leave up to you to guess which of the two that is

* So lets look at the syntax for an `if` statement in `Python`:
```python
if condition_is_true:
   # Run this code
else:
   # Run this other code
```

## Data Types for True/False
* Long and short for this section is:
  1. In `Python` Boolean values are denote as `True` and `False`
  2. You can use `Boolean Operators` in `Python` to see if an expression evaluates `True` or `False`
     * `Boolean Operators` in `Python` are pretty much the same as `C#`

## Boolean Expressions
* As in `C#` we can create `boolean expressions` which will evaluate to `True` or `False`

### Testing for Equality
* `Equality operator` `==`, will compare two values and returns `True` or `False` if the values are identical
```python
num_one = 55
num_two = 66

print(27 == 27)
print("Hello" == "Goodbye")
print(num_one == num_two)

# Outputs:
# True
# False
# False
```

### Comparison Operators
| Operator                   | Description                                                                                                                                                 | Examples Returning True                   | Examples Returning False                                    |
| -------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------- | ----------------------------------------------------------- |
| Equal (==)                 | Returns True if two compared values (operands) are equal, and False otherwise.                                                                              | 7 == 3 + 4 'ab' == 'a'+'b' "dog" == "dog" | 7 == 5 'dog' == 'cat' 'cat' == 'Cat'                        |
| Not equal (!=)             | Returns True if two values (operands) are NOT equal, and False otherwise.                                                                                   | 7 != 5 "dog" != "cat"                     | 7 != 7 "dog" != "dog"                                       |
| Greater than (>)           | Returns True if the left-hand value (operand) is greater than the right-hand operand, and False otherwise.                                                  | 7 > 5 'b' > 'a'                           | 7 > 7 'a' > 'b'                                             |
| Less than (<)              | Returns True if the left-hand operand is less than the right-hand operand, and False otherwise.                                                             | 5 < 7 'a' < 'b'                           | 15 < 15 'b' < 'a'                                           |
| Greater than or equal (>=) | Returns True if the left-hand operand is greater than or equal to the right-hand operand, and False otherwise.                                              | 7 >= 5 7 >= 7 'b' >= 'a' 'b' >= 'b'       | 5 >= 7 'a' >= 'b'                                           |
| Less than or equal (<=)    | Returns True if the left-hand value is less than or equal to the right-hand value, and False otherwise.                                                     | 5 <= 7 5 <= 5 'a' <= 'b' 'a' <= 'a'       | 7 <= 5 'b' <= 'a'                                           |
| in                         | Returns True if the left-hand value is found inside the right-hand value, and False otherwise. This operator does NOT work for the int or float data types. | 'a' in 'Happy' 'stop' in 'unstoppable'    | 'A' in 'apple' (case matters) 'oy' in 'you' (order matters) |
| ContainsValue()            | Returns a boolean indicating whether or not the dictionary contains a given value.                                                                          |                                           |                                                             |

## Can We Do Math with Boolean Values?
* Fun fact, in `Python` you can **technically** do math with `Boolean` Values
```python
print(True*5)
print(False*2)
print(True + False)
print(True * False)
# Outputs:
# 5
# 0
# 1
# 0
```
* But here's the thing, just because you can do this doesn't mean you should ever do it
  * So what I am saying is do not do this

## Conditionals
* Ok so, `if statements` are pretty straight forward in `Python`
  * Well that is once you get over the fact that there are no `()`s and `{}`
    * Oh yea and remember we don't need those pesky `;` either! HAHA

```python
username = input('Please enter a username: ')

if len(username) >= 8:
   print("Welcome, " + username + "!")
else:
   print("Invalid username.")
```
* The `len()` function returns the number of characters on a string
* Syntax:
  * If you notice the `print()` statement after the `if` is indented
    * Remember how I said in `Python` we do not use `{}`
    * Well this is what I meant, in `Python` the scope of an object is defined by `:` and `indentations`

## Logical Operators
* We are able to use `logical operators` to create more complicated comparisons
  * ie: `Compound Boolean Expressions`: is a `boolean` expression which is built out of smaller `boolean` expressions
* In `Python` there are three different `logical operators`:
  1. and
  2. or
  3. not

### Logical and
```python
name = input("Please provide a name")

if len(name) > 2 and len(name) < 20:
   print("The name is greater than 2 characters but less than 20")
else:
   print('A name must be between 2 and 20 characters long')
# Outputs:
```

### Logical or
```python
num = int(input('Please provide a number!'))

if num > 5 or num < 20:
    print('The number:', num, 'meets at least one or both conditions')
else:
    print('The number: ', num, 'must be between 5 and 20')
```
### Logical not
* The logical `not` operator takes a single operand and flips it boolean value
```python
print(not True)
print(not False)

print(not(3>7))

print(not(3<7))
# Outputs:
# False
# True
# True
# False
```

### Longer Combinations
* We can use the operators to combine as many expressions as we want:
```python
print('Welcome to Club Rog!')

want_to_enter = input('Do you want to enter Club Rog?!')
name = input("What is your name?")
age = int(input("What is your age?"))

if (want_to_enter == 'yes' or want_to_enter == 'y') and (len(name) > 2) and (age > 21):
    print('ok you can come in')
else:
    print('nope you cant come in')
# Outputs:
```

## Truth Table
* `Truth Tables` allow you to see how all the possible return values of a `logical operator`
### and Truth Table
| A     | B     | A and B |
| ----- | ----- | ------- |
| True  | True  | True    |
| True  | False | False   |
| False | True  | False   |
| False | False | False   |

* This table just shows how an `expression` would evaluate based on two `operands`:
  * Keep in mind this is a hypothetical expression:
```python
a = True
b = True

if a == True and b == True:
    print(True)
else:
   print(False)

# Outputs:
#  True
```

### or Truth Table
| A     | B     | A or B |
| ----- | ----- | ------ |
| True  | True  | True   |
| True  | False | True   |
| False | True  | True   |
| False | False | False  |

```python
a = True
b = True

if a == True or b == True:
    print(True)
else:
   print(False)
# Outputs:
#  True
```

### Table of Operation Order
| Level     | Category                    | Operators              |
| --------- | --------------------------- | ---------------------- |
| (Highest) | Parentheses                 | ()                     |
|           | Exponent                    | ** (For example: 2**3) |
|           | Multiplication and Division | *  /  //  %            |
|           | Addition and subtraction    | +  -                   |
|           | Comparison                  | ==  !=  <=  >=  >  <   |
|           | Logical                     | not                    |
|           | Logical                     | and                    |
| (Lowest)  | Logical                     | or                     |

## Nested Conditionals
```python
entry = int(input('Enter a whole number: '))

if entry%2 == 0 :
  print("EVEN!")

  if entry > 0:
    print("POSITIVE")
# Outputs:
```

### Nested Within An else
```python
word = input('Please enter a word: ')

if len(word) == 4:
  print("What did your mom tell you about using 4-letter words?")
else:
  if len(word) < 4:
    print("You can think of a longer word than that!")
  else:
    print("Excellent word!")
# Outputs:
```

## Chained Conditionals
* `Chained conditionals` are when you have multiple checks that run concurrently
  * If one of the statements evaluates as `True` then the following checks are ignored
  * Else the checks are continued until either one of the statements evaluates `True` or you run out of statements:

```python
num = 10
other_num = 20

if num > other_num:
   print(num, "is greater than", other_num)
elif num < other_num:
   print(num, "is less than", other_num)
else:
   print(num, "is equal to", other_num)
# Outputs:
# 10 is less than 20
```
* No that is not a typo!
  * although I don't blame you for thinking I made one...
* In `Python` we use `elif` to say `else if`

### Multiple elif Statements
* Just like `else if`s in `C#`; you can have many `elif` in a `Python` statement:
```python
character = 'P'
lowercase = 'abcdefghijklmnopqrstuvwxyz'
uppercase = 'ABCDEFGHIJKLMNOPQRSTUVWXYZ'
digits = '0123456789'

if character in lowercase:
   print(character, 'is a lowercase letter.')
elif character in uppercase:
   print(character, 'is an UPPERCASE letter.')
elif character in digits:
   print(character, 'is a number.')
else:
   print('&**%#!', character, 'is a punctuation mark or a space.')
# Outputs:
# P is an UPPERCASE letter.
```
* The `in` keyword has two usecases:
* The in keyword has two purposes:
  1. To check if the provided value is present in a sequence
     * ie: list, range, string, etc.
```python
languages = ["C#", "Python", "JavaScript"]
language = 'Python'

if language in languages:
  print('Yup! ' + language + ' is in the list!')
# Outputs:
# Yup! Python is in the list!
```
  2. To iterate through a sequence in a for loop
```python
languages = ["C#", "Python", "JavaScript"]

for language in languages:
  print(language)
# Outputs:
# C#
# Python
# JavaScript
```
### Nested vs. Chained Conditionals
* Both of the following `Conditional Statements` do the same thing; which do you think is cleaner?
```python
# Nested Conditional
word = "Conditional Statements"

if len(word) == 4:
   print("The word has 4 letters")
else:
   if len(word) < 4:
      print("The word has less than 4 letters ")
   else:
      print("Excellent word!")

# Outputs: Excellent word!
```

```python
# Chained Conditional
word = "Conditional Statements"

word = "Conditional Statements"

if len(word) == 4:
   print("The word has 4 letters")
elif len(word) < 4:
      print("The word has less than 4 letters ")
else:
    print("Excellent word!")

# Outputs: Excellent word!
```