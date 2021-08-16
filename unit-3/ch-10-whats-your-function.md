# Chapter 10: What's Your Function
- [Chapter 10: What's Your Function](#chapter-10-whats-your-function)
  - [Defining Our Own Functions](#defining-our-own-functions)
  - [Function Syntax](#function-syntax)
    - [Naming Functions](#naming-functions)
    - [Function Code](#function-code)
    - [Defining vs. Calling](#defining-vs-calling)
  - [Function Input](#function-input)
    - [Arguments and Parameters](#arguments-and-parameters)
    - [Mismatched Arguments and Parameters](#mismatched-arguments-and-parameters)
    - [Default Parameter Values](#default-parameter-values)
  - [Function Output](#function-output)
    - [Return Statements](#return-statements)
    - [No return Value](#no-return-value)
    - [return Stops a Function](#return-stops-a-function)
  - [Boolean Functions](#boolean-functions)
  - [Parameters and Variables](#parameters-and-variables)
    - [Variable Shadowing](#variable-shadowing)

## Defining Our Own Functions
* Function in `Python` are structured a bit differently than methods in `C#`
  * **Side Note**:
    * The terms `Method` and `Function` are at times used interchangeably in programming
      * But the in actuality:
        * A `function` is a piece of code that can be called by its own name
        * Whereas a `method` is a piece of code that is normally stored in an `object`; ie: a class
    * Unlike `C#` where everything is a class that we create; in `Python` we are able to write free standing `functions` within our code and or create classes that contain methods
      * We will learn more about `classes` in `Python` later
    * The main point I am attempting to make here is that in `Python` you can create both `functions` and `methods`
      * And whereas the terms can be interchangeable they are actually a bit different
## Function Syntax
* `Functions` in `Python` are denoted by the keyword `def`
* We then proceed the keyword `def` with the name of our function
  * We then use the `()` to define a parameter list
  * Finally we use the `:` syntax to denote the beginning of the functions codeblock/scope
```python
def function_name(parameters):
    # Code block goes here
```

### Naming Functions
* There are some rules when it comes to naming `functions` in `Python`:
  1. Names **Cannot** be the same as any `Python` keywords:
     * ie: `print`, `for`, `in`, `def`, etc.
  2. _Only use lowercase letters_ when naming `functions`
  3. Names should be descriptive and give a clear idea of what the `function` does
  4. `Functions` names that contain multiple words should be separated by `_`s:
     * `remove_duplicate_numbers_from_list`

### Function Code
* Let's take a look at an actually `Python` `function`
```python
numbers = [0, 1, 2, 3, 4, 5, 100]

def find_largest_number_in_a_list(list_of_numbers):
    return max(list_of_numbers)

print(find_largest_number_in_a_list(numbers))

# Outputs:
# 100
```

### Defining vs. Calling
* `Defining` a `function` is when we write out its logic:
```python
def print_message(message):
    print(message)
# Outputs:
```

* `Calling` (or `Evoking`) a `function` is when we actually use it:
```python
the_message = "Hey lets invoke a function!"

print_message(the_message)

# Outputs:
# Hey lets invoke a function!
```

## Function Input
### Arguments and Parameters
* Let's start by looking at an example:
```python
def print_each_item_in_a_list(the_list):
    for element in the_list:
        print(element)

names = ["Jack", "Jill", "Rover", "Author"]

print_each_item_in_a_list(names)

# Outputs:
# Jack
# Jill
# Rover
# Author
```

* In the example above:
  * `the_list` is a parameter
  * `name`: is the argument

### Mismatched Arguments and Parameters
* Do not try and `invoke` a `function` with either to many or not enough `arguments`:
```python
def add_two_numbers(first_number, second_number):
    return first_number + second_number

add_two_numbers()
# Outputs:
# TypeError: add_two_numbers() missing 2 required positional arguments: 'first_number' and 'second_number'
```
```python
def add_two_numbers(first_number, second_number):
    return first_number + second_number

add_two_numbers(2,3,4)
# Outputs:
# TypeError: add_two_numbers() takes 2 positional arguments but 3 were given
```

* As you can see if you attempt to `invoke` a `function` with to many or to not enough `arguments`it will result in a `TypeError`

### Default Parameter Values
* As in `C#` we can define `default parameters` in `Python`:
```python
def function_name(parameter_name = default_value):
```

```python
def add_two_numbers(first_number = 4, second_number = 9):
    return first_number + second_number

add_two_numbers()

# Outputs:
# 13
```
* As you can see by providing the `function declaration` with two `default values` we are now able to `invoke` the `function` with out providing any `arguments`

## Function Output
### Return Statements
* Unlike `C#` we do not have to specify `void` and or a `data type` when `declaring` a `function`
* All we have to do is provide our function with a `return` and whatever data we would like it to return
```python
def multiple_two_numbers(number_one, number_two):
    return number_one * number_two
```

###  No return Value
* We can also declare a `function` that does not `return` any data:

```python
def print_names_in_uppercase(list_of_names):
    for name in list_of_names:
        print(name.upper())

names = ["harry", "ginny", "ron", "hermione"]

print_names_in_uppercase(names)

# Outputs:
# HARRY
# GINNY
# RON
# HERMIONE
```

### return Stops a Function
* A `return statement` stops a function in its tracks:

```python
def print_names_in_uppercase(list_of_names):
    return None
    for name in list_of_names:
        print(name.upper())

names = ["harry", "ginny", "ron", "hermione"]

print_names_in_uppercase(names)

# Outputs:
#
```
* The function above will never run the `for loop` due to the fact that it is _placed below_ our `return statement`

## Boolean Functions
* `Functions` that `return` `True` or `False` are known as `boolean functions`

```python
def is_it_a_string(testable_argument):
    return True if type(testable_argument) == str else False

is_it_a_string("Hello")
is_it_a_string(4)
# Outputs:
# True
# False
```

* As you can see above we created a `function` that test to see if the `argument` provided is a `string` or not
  * Also we utilized a `Python Ternary Operator`
    * `Ternary Operators` in `Python` are structured a bit differently than `C#`:
    * `return_value_if_condition_is_true if condition else return_value_if_false`

## Parameters and Variables
* As in `C#` and all programming languages we have the concept of `scope`
* `Variables` and `functions` have `scope`
  * In regards to `variables` `scope` is refers to where it is usable with in our program:

```python
name = "Roger"

def print_my_name(my_name):
    last_name = "Campbell"
    print(f'{name} {last_name}')

print_my_name(name)
# Outputs:
# Roger Campbell


print(f'{name} {last_name}')

# Outputs:
# NameError: name 'last_name' is not defined
```

* As you can see above when we `invoke` `print_my_name()` we are able to print both the argument provided (name) and the variable `last_name`
* Whereas when we attempt to just `print(f'{name} {last_name}')` we receive a `TypeError`
  * This is due to the fact that `last_name` is `locally scoped` to the `print_my_name` function

### Variable Shadowing
* So the long and short of this section is:
  * If you declare a `variable` inside a `function` that has the same exact name as a `variable` outside of the `function`, you are actually creating two completely different `variables` with the same exact name

```python
def print_my_number():
    my_number = 2658

    print(my_number)

my_number = 823

print_my_number()

print(my_number)

# Outputs:
# 2658
# 823
```
