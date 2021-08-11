# Chapter 4: Data and Variables
- [Chapter 4: Data and Variables](#chapter-4-data-and-variables)
  - [Values and Data Types](#values-and-data-types)
    - [More on Strings](#more-on-strings)
    - [More on Numbers](#more-on-numbers)
  - [Type Conversion](#type-conversion)
  - [Variables](#variables)
    - [Reassigning Variables](#reassigning-variables)
    - [Naming Python Variables](#naming-python-variables)
    - [Keywords](#keywords)
    - [Cool Tricks (No There Not Just For Kids!)](#cool-tricks-no-there-not-just-for-kids)
  - [Statements and Expressions](#statements-and-expressions)
  - [Operators](#operators)
    - [Math Operators](#math-operators)
    - [The // Operator](#the--operator)
    - [The % Operator](#the--operator-1)
  - [Order of Operations](#order-of-operations)
  - [Other Operators](#other-operators)
    - [Compound Assignment Operators](#compound-assignment-operators)
    - [String Operators](#string-operators)
  - [User Input](#user-input)
    - [Requesting Data](#requesting-data)
    - [Critical input Detail](#critical-input-detail)
## Values and Data Types
* There are many different [data types](https://www.w3schools.com/python/python_datatypes.asp) in `Python`
* For right now we will talk about 3 kinds:
  1. `string` - a text type: `"Hello"` or `'Hello'`
  2. `int` - a numeric type: `2`, `44`
  3. `float` - a numeric type with a decimal: `4.5`, `-9.33`
* You can check the data type of a value by using the `type()` method:
```python
print(type("Hello, Ducklings"))
print(type(27))
print(type(26.58))

# Outputs:
# <class 'str'>
# <class 'int'>
# <class 'float'>
```

### More on Strings
1. Just like in `C#` if you wrap numbers in `""` they will be considered a `string`:
```python
print(type("75"))
print(type("5.5"))

# Outputs:
# <class 'str'>
# <class 'str'>
```

2. In `Python` you can use a few different quotations to make a string:
   1. `Single Quotes`: `''`
   2. `Double Quotes`: `""`
   3. `Triple Quotes`: `'''` or `"""`)
```python
print(type('Single Quote String'))

print(type("Double Quote String"))

print('''Triple Quote String
are used for
multi-line strings''')
```

### More on Numbers
* Do not put `,`s in your numbers: `5,200`
  * python will view this as two separate numbers:
```python
print(5200)
print(5,200)

# Outputs:
# 5200
# 5 200
```

* Fun fact `print` will display any number of types:
```python
print(9, 26, 58)
print('may', 27, 19.90)

# Outputs:
# 9 26 58
# may 27 19.9
```

## Type Conversion
* As in `C#` you can also perform `type conversions`
* `Python` gives you some handle `type conversion` functions out-of-the-box:
  * `int()`: takes a float or a string and turns it into whole number
    * If the number provided has a decimal it just returns the whole number without rounding
  * `float()`: turns an integer or an allowed string into a `float`
  * `str()`: turns it argument into a `string`

```python
print(27, float(27))

print("9.26", float("9.26"))
print(type("9.26"), type(float("9.26")))

print(str(13))
print(str(13), type(str(13)))

# Outputs:
# 27 27.0
# 9.26 9.26
# <class 'str'> <class 'float'>
# 13
# 13 <class 'str'>
```

## Variables
* Unlike `C#`, `Python` is a `dynamically-typed language`
  * Meaning we do not have to declare the `data type` that a variable will store:
```python
name = 'Baby Groot'
age = 3
height = 10.5 #inches


print(name)
print(age)
print(height)

# Outputs:
# Baby Groot
# 3
# 10.5
```

### Reassigning Variables
* With `Python` being a `dynamically-typed language` we are able to reassign variables and values on the fly:
```python
turkey = "Wolfgang Maximilian Costa"
print(turkey)

turkey = 25
print(turkey)

turkey= 5.5
print(turkey)

# Outputs:
# Wolfgang Maximilian Costa
# 25
# 5.5
```

### Naming Python Variables
* There are quite a few `syntax rules` for variables in `Python`:
  1. Variable names MUST begin with a letter or an underscore _.
  2. Variable names CANNOT contain spaces. If you have more than one word in a name, connect the words with underscores (e.g. `price_of_eggs`).
  3. Variable names may only use letters (a-z and A-Z), underscores (_), and numbers (0-9).
  4. Case matters! `animal` and `Animal` are different variable names.
* Then on the other side there are some `conventions` around `Python` variables:
1. Use names that clearly describe their values. For example, if you need to store the price of eggs, call your variable `price_of_eggs` instead of `x`. Similarly, `vowel` makes more sense than `v`.
2. Stick to lowercase letters and underscores in the variable name, unless the value is a constant.
3. Use all UPPERCASE to name constants (e.g. `PI` or `SPEED_OF_LIGHT`).

### Keywords
* As in `C#` there are reserved keywords that you can not use to create variable names
  * One is `print`
* Don't do this:
```python
print = "I want to print this string to the console"

print(print)

# Outputs:
# TypeError: 'str' object is not callable
```
* Want to know all the reserved `Python` keywords?
  * [Here](https://www.programiz.com/python-programming/keyword-list) you go!

### Cool Tricks (No There Not Just For Kids!)
1. You can assign multiple values to multiple variables in the same line
```python
animals, owner, amount = "Chickens", "Blake", 25

print(animals, owner, amount)
# Outputs:
Chickens Blake 25
```
2. You can assign the same value to multiple variables all at once
```python
word_1 = word_2 = "same"

print(word_1, word_2)
# Outputs:
# same same
```

## Statements and Expressions
* In `Python`:
  * `Statements` are a set of instructions
  * `Expressions` are a combination of `values`, `variables`, `operators` and `function evocations`

```python
# Statements:
coach = "Ted Lasso"
print(55)

# An Expression:
2 + 2

# A Statement storing an Expression:
sum = 2 + 2
```

* When we write `sum = 2 + 2`:
  * `sum` does not store the expression `2+ 2`
  * All `expressions` **return a value**
    * Meaning when the line of code `sum = 2 + 2` is complied:
      * `Python` first performs the expression: `2+2` and then stores the value `4` inside the variable `sum`

## Operators
* An `operator` tells `Python` to perform an action on two values
* In `Python` `operators` can be single characters (+), double characters (**), and or `keywords`
* Just as in `C#` the values a `operator` performs work on are called `operands`
  * ie: `5 + 6`:
    * 5 and 6 are `Operands`
    * + is the `Operator`

### Math Operators
* There are many different `Math Operators` in Python:
| Operator        | Description                                                                                                                                  | Example                             |
| --------------- | -------------------------------------------------------------------------------------------------------------------------------------------- | ----------------------------------- |
| +               | Adds two values (operands)                                                                                                                   | 2 + 3 returns 5                     |
| -               | Subtracts the first operand by the second                                                                                                    | 2 - 3 returns -1                    |
| *               | Multiplies two operands                                                                                                                      | 2 * 3 returns 6                     |
| /               | Divides the first operand by the second                                                                                                      | 3 / 2 returns 1.5                   |
| **              | Takes the first operand and raises it to the power of the second. (first value)second value                                                  | 3 ** 2 returns 9 5 ** 3 returns 125 |
| //              | Divides the first operand by the second and rounds down to a whole number. This is called floor division and is discussed immediately below. | 3 // 2 returns 1                    |
| %               | This is called the modulus operator. It returns the remainder after dividing the first operand by the second. It is discussed below.         | 5 % 2 returns 1 10 % 2 returns 0    |
| ContainsValue() | Returns a boolean indicating whether or not the dictionary contains a given value.                                                           |                                     |

### The // Operator
* `Python` is able to perform division with the `/` operator
  * `/` returns a `float`

```python
print(2/5)
print(type(2/3))

# Outputs:
# 0.4
# <class 'float'>

print(10 / 10)
print(type(10 / 10))
# Outputs:
# 1.0
# <class 'float'>
```
* As you can see above event when we perform a `division operation` on two `operands` that results in a whole number, `Python` still returns a `float`
* This is where `Floor Division` can be helpful
* We are able to perform `Floor Division` with `//` operator

```python
print(4/3)
# Outputs:
# 1.3333333333333333

print(4//3)
# Outputs:
# 1
```

### The % Operator
* The `Modulus` operator (`%`) takes two integers, divides them and returns the remainder
```python
print(3 % 2)
print(40 % 2)

# Outputs:
# 1
# 0
```

## Order of Operations
* Jut like in `C#`, `Python` also observes an `order of operations`:

| Level           | Operation Category                                                                                                                           | Examples                            |
| --------------- | -------------------------------------------------------------------------------------------------------------------------------------------- | ----------------------------------- |
| (Highest)       | Parentheses: ()                                                                                                                              | (2 + 3)                             |
|                 | Exponent: ** (first value)second value                                                                                                       | 2**3                                |
|                 | Multiplication and Division: *  /  //  %                                                                                                     | 2 * 3 10 / 5 4 // 2 15 % 3          |
| (Lowest)        | Addition and Subtraction: +  -                                                                                                               | 4 - 5 9 + 1                         |
| **              | Takes the first operand and raises it to the power of the second. (first value)second value                                                  | 3 ** 2 returns 9 5 ** 3 returns 125 |
| //              | Divides the first operand by the second and rounds down to a whole number. This is called floor division and is discussed immediately below. | 3 // 2 returns 1                    |
| %               | This is called the modulus operator. It returns the remainder after dividing the first operand by the second. It is discussed below.         | 5 % 2 returns 1 10 % 2 returns 0    |
| ContainsValue() | Returns a boolean indicating whether or not the dictionary contains a given value.                                                           |                                     |

* If you use two `operators` of the same importance then the `expression` will be solved from _left to right_
* Lets say we want `Python` to solve the following `expression`: `2 + 3 * 4 - 1`:
```python
2 + 3 * 4 - 1  # 1. Evaluate 3 * 4 first.
2 + 12 - 1     # 2. Evaluate 2 + 12 next.
14 - 1         # 3. Evaluate 14 - 1 next.
13             # 4. Final answer.
```

* You can override the default order of operation with the `()` syntax:
```python
(2 + 3) * (4 - 1)    # 1. Evaluate (2 + 3) first.
5 * (4 - 1)          # 2. Evaluate 4 - 1 next.
5 * 3                # 3. Evaluate 5 * 3 next.
15                   # 4. Final answer.
```

## Other Operators
* In `Python` it is common to reassign the value of a variable based on an operation that is performed on its previous value:

```python
num = 25
print(num)

num = num + 75
print(num)

# Outputs:
# 25
# 100
```

### Compound Assignment Operators
| Operator        | Meaning                                                                                                                                      | Examples                            |
| --------------- | -------------------------------------------------------------------------------------------------------------------------------------------- | ----------------------------------- |
| a += b          | a = a + b                                                                                                                                    | (2 + 3)                             |
| a -= b          | a = a - b                                                                                                                                    | 2**3                                |
| a *= b          | a = a * b                                                                                                                                    | 2 * 3 10 / 5 4 // 2 15 % 3          |
| a /= b          | a = a / b                                                                                                                                    | 4 - 5 9 + 1                         |
| **              | Takes the first operand and raises it to the power of the second. (first value)second value                                                  | 3 ** 2 returns 9 5 ** 3 returns 125 |
| //              | Divides the first operand by the second and rounds down to a whole number. This is called floor division and is discussed immediately below. | 3 // 2 returns 1                    |
| %               | This is called the modulus operator. It returns the remainder after dividing the first operand by the second. It is discussed below.         | 5 % 2 returns 1 10 % 2 returns 0    |
| ContainsValue() | Returns a boolean indicating whether or not the dictionary contains a given value.                                                           |                                     |


### String Operators
* We can utilize certain `operators` to perform `operations` on `strings`:

```python
print('27' + '40')

print('Roger That!! '*3)

print('Ducklings' + '!' * 3)

# Outputs:
# 2740
# Roger That!! Roger That!! Roger That!!
# Ducklings!!!
```

## User Input
### Requesting Data
* We can accept `user input` via the console by utilizing the `input()` function:

```python
name = input('What Is Your Designation Organic Bipedal?')

print('Hello ' + name + "!" * 3)

# Outputs: Hello Roger!!!
```

### Critical input Detail
* `Python`'s `input` method returns a string
  * Just like `C#`'s `ReadLine()` method

```python
num_1 = input("Enter a number: ")
num_2 = input("Enter another number: ")

print(num_1 + num_2)

# Outputs: 12
```