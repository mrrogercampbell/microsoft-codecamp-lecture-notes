# Chapter 11: Python Modules
- [Chapter 11: Python Modules](#chapter-11-python-modules)
  - [What are Modules?](#what-are-modules)
    - [Why Use Modules?](#why-use-modules)
  - [Importing Modules](#importing-modules)
    - [The import Keyword](#the-import-keyword)
    - [Find the Names of Modules Items](#find-the-names-of-modules-items)
    - [The from Keyword](#the-from-keyword)
    - [The as Keyword](#the-as-keyword)
  - [The random Module](#the-random-module)
  - [Generate a Random Number](#generate-a-random-number)
    - [Select an Item from a Collection](#select-an-item-from-a-collection)
  - [Creating Modules](#creating-modules)
    - [File Locations](#file-locations)
  - [The main() Event](#the-main-event)
    - [The __name__ Dunder Method](#the-name-dunder-method)
    - [Running Python File as a Script](#running-python-file-as-a-script)
    - [Running Python File as a Module](#running-python-file-as-a-module)
    - [Using if Conditional with __name__](#using-if-conditional-with-name)

## What are Modules?
* A `module` in `Python` is a file that contains `variables`, `functions`, and other code logic that we would like to use within other `Python` programs
  * You are able to use `modules` in one and or many different programs

### Why Use Modules?
* `Module` are super handy and allow you to:
  * Keep your code `D.R.Y.` (Do Not Repeat Yourself)
  * `Modules` allow you write a piece of logic in one place reuse it in many other parts of your program and or another program
  * `Modules` enable you to write strong code that can be updated in place that does not affect its many implementations

## Importing Modules
### The import Keyword
* The `import` keyword is very similar to the `using` keyword on `C#`
  * It allows you to tell `Python` where to find a `module` we would like to use in our program
* The syntax of utilizing the `import` keyword is as follows:
```python
import module_name
```
* You should put all your `import` statements at the top of your code
* You are able access logic stored within a `module` with `dot notation`:
```python
module_name.variable_name
module_name.function_name(arguments)
```
* Here is an actual example:
```python
import string
print(string.ascii_lowercase)

# Outputs:
# abcdefghijklmnopqrstuvwxyz
```

### Find the Names of Modules Items
* You can find the names on `modules items` by utilizing the `dir()` function:
```python
import string

print(dir(string))

# Outputs:
# ['Formatter', 'Template', '_ChainMap', '_TemplateMetaclass', '__all__', '__builtins__', '__cached__', '__doc__', '__file__', '__loader__', '__name__', '__package__', '__spec__', '_re', '_sentinel_dict', '_string', 'ascii_letters', 'ascii_lowercase', 'ascii_uppercase', 'capwords', 'digits', 'hexdigits', 'octdigits', 'printable', 'punctuation', 'whitespace']
```
* You can make this more readable by utilizing a loop:
```python
import string

for item in dir(string):
  print(item)

# Outputs:
# Formatter
# Template
# _ChainMap
# ...
# punctuation
# whitespace
```

### The from Keyword
* Where as we can utilize the `import` keyword by itself this can be a bit bulky and heavy handed
  * When we use the `import` keyword by itself it imports the entire module which could be very large
* With that in mind we are able to specify the exact thing we want from a particular `module` by using the `from` keyword:
```python
from module_name import item_name
```
* `item_name` is the exact item we would like to pull from the `module`
  * Let's see this in action:
```python
# When we just use the import keyword:

import string

print(string.punctuation)
print(string.ascii_letters)
# Outputs:
# !"#$%&'()*+,-./:;<=>?@[\]^_`{|}~
# abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ
```

```python
# When we use the from keyword
from string import punctuation

print(punctuation)
print(ascii_letters)

# Outputs:
# !"#$%&'()*+,-./:;<=>?@[\]^_`{|}~
# NameError: name 'ascii_letters' is not defined
```

* As you can see in the second example we are not able to use `ascii_letters` due to us only specifying that we want `punctuation` from the `string module`

### The as Keyword
* The `as` keyword allows us to rename the item(s) we are importing:
```python
import module_name as new_name
from module_name import item_name as new_name
```

```python
import random
# from random import randint
# from random import randint as rad

import math

for turn in range(3):
  random_integer = random.randint(10, 50)
  print("Here is a random integer (10 - 50):", random_integer)

num = 400
print("The square root of {0} is {1}.".format(num, math.sqrt(num)))
# Outputs:
```

## The random Module
## Generate a Random Number
```python
import random

for number in range(5):
  random_value = random.random()
  print(random_value)

# Outputs:
# 5 random numbers
```
* `random()` returns a float value in the range 0.0 - 1.0
  * Including 0.0 but not 1.0
  * If we want a a larger `float` we can divide the result by the top number
```python
import random

for number in range(5):
  random_value = random.random()
  print(random_value)

# Outputs:
# 5 random numbers
```

### Select an Item from a Collection
* `Python` give you a provides a function called `choice()` which is defined within the `random module`
```python
import random

word = "Abbreviation"
numbers = [1, 3, 5, 7, 9, 111, 222, 333]

for turn in range(5):
  character_choice = random.choice(word)

  number_choice = random.choice(numbers)

  print(f'The character is {character_choice}, and the number is {number_choice}.')
# Outputs:
```

## Creating Modules
1. Create a file called `main.py`
   * This will be the main file where we will use our `module`
2. Create another file called `working_with_names.py`
   * This will be our module file
3. Inside that file add the following code:
```python
def list_the_people(list_of_people):
    for person in list_of_people:
        print(person)
```
4. Next inside the `main.py` add the following code:
```python
import working_with_names

siblings = ["Kodra", "Jordan", "Devon", "Tavon", "Roger", "Kiandra", "Sabrina"]

working_with_names.list_the_people(siblings)

# Outputs:
# Kodra
# Jordan
# Devon
# Tavon
# Roger
# Kiandra
# Sabrina
```

### File Locations
* So `Python` has some default logic for how it goes about finding `module`:
1. First `Python` checks to see if the module is one of the built-in Python files
2. If `Python` is unable to find a built in `module` that matches it looks within the _current_ directory for the the `module`
   * _Current directory_ meaning the `directory` which houses the `main.py` file
3. If `Python` is unable to find the `module` in either of those two places it goes through a separate set of steps which we will not cover right now
   * In this case you would have to do some more configurations for `Python` to properly find the `custom module`

## The main() Event
* Traditionally the `main()` is the `execution` point for a program file
  * But `Python` is structured a bit differently then most other programming languages so n turn it utilizes the `main()` a bit differently

### The __name__ Dunder Method
* The `__name__` Dunder method is a special builtin `Python` variable that shows the name of the current `module`
  * It has different values depending on where you run your `Python` files

### Running Python File as a Script
1. Lets start by creating a file called `helloworld.py`
```python
# helloworld.py
print(__name__)
```
2. Then in the terminal run the following command:
```shell
python helloworld.py

# outputs:
# __main__
```
* When we run our `Python` program as a `script` (meaning via the terminal) the `__name__` is set to `__main__`

### Running Python File as a Module
* We are also able to run our `Python` file as a `module`
  * Meaning we have imported it into another `Python` file:

1. Lets create another file called `main.py` and import out `helloworld` `module`:
```python
# main.py
import helloworld
```
2. Now lets run this file in the terminal:
```shell
python main.py

# outputs:
# helloworld
```
* The reason for this output is due to the fact that when we `import` `helloworld` into `main.py` we then run the `main.py` file the `helloworld` module is also ran
* Lets look at this another way; try adding a `print statement` after the `import` in `main.py` and then run the program:
```python
# main.py
import helloworld

print(2 + 2)
```
```shell
python main.py

# outputs:
# helloworld
# 4
```
* See you are actually running the `Python` file as a program within your terminal
  * When `Python` compiles the `import helloworld` syntax it in turn runs the `helloworld.py` file as a `module` which then causes the `print(__name__)` statement to evaluate differently then if you ran the `helloworld.py` file as a Script


### Using if Conditional with __name__
* With the last two sections in mind we can now dictate some basic logic depending on how our `Python` file is being ran
* Change the `helloworld.py` file to have the following code:
```python
# helloworld.py
def main():
    print("Hello World")

if __name__ == "__main__":
    main()
```
* Next run the file as a script:

```shell
python helloworld.py

# Outputs:
# Hello World
```

* Now try running the file as a `module`:
```shell
python main.py

# Outputs:
# 4
```

* So by adding this logic we are able to tell the file to execute depending on the environment in which it is being run in and or how the file is being executed