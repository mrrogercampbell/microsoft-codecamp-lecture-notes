# Chapter 7: Stringing Characters Together
- [Chapter 7: Stringing Characters Together](#chapter-7-stringing-characters-together)
  - [Strings as Collections](#strings-as-collections)
  - [Collection Data Types](#collection-data-types)
    - [Order Collections](#order-collections)
    - [Collection length](#collection-length)
    - [The Empty string](#the-empty-string)
  - [Bracket Notation](#bracket-notation)
    - [Expression for index](#expression-for-index)
  - [Taking a Slice](#taking-a-slice)
  - [String Immutability](#string-immutability)
  - [String Methods](#string-methods)
  - [Strings are Immutable](#strings-are-immutable)
  - [Special Characters](#special-characters)
    - [Newline and Tab](#newline-and-tab)
  - [Other Characters](#other-characters)
  - [Template Literals](#template-literals)
    - [The format() Method](#the-format-method)
    - [f-Strings](#f-strings)
  - [Iteration With Strings](#iteration-with-strings)
    - [Iterate by Index or Item](#iterate-by-index-or-item)
  - [Checking Strings](#checking-strings)
    - [Comparing Strings](#comparing-strings)
  - [Checking with in and not in](#checking-with-in-and-not-in)
    - [Checking Case](#checking-case)
## Strings as Collections
## Collection Data Types
* `Strings` can be considered a `collection data type`
  * Under the hood `strings` are arrays of bytes representing unicode characters
  * But keep in mind `Python` does not have a `character` data type
    * So in actuality in `Python`:
      * A `string` is an array (or ordered collection) of `strings` (which we will call a `character-string` for this example)
      * Each `character-string` within a `string` has a length of `1`
```python
word = 'string'
print("word[1]'s current value is:", word[1])
print("<--->")

print("word[1]'s type is:", type(word[1]))
print("<--->")

print("word[1]'s length is: ", len(word[1]))
print("<--->")
# Outputs:
# word[1]'s current value is: t
# <--->
# word[1]'s type is: <class 'str'>
# <--->
# word[1]'s length is:  1
# <--->
```
### Order Collections
* `string`s are can be considered an `ordered collection`
* This just means the when you create a `string` it will keep the order of characters that you specify on creation

### Collection length
* The `len()` function will return the `length` of a string

### The Empty string
* As I stated above a `string` is a collection of `strings`
  * So with that in mind even an `empty string` will have a length of 1:
```python
empty_string = ""
print(len(empty_string))

# Outputs:
# 0
```
## Bracket Notation
* `Strings` are `0 based arrays`
  * So with that in mind you can access a `string` with `bracket notation`:
```python
word = 'Hello'

print(word[0])
print(word[1])

# Outputs:
# H
# e
```

### Expression for index
* You can use an expression to access a `string`
  * Say you want to access the last letter within a string you could do this:
```python
students = "Ducklings"

print(students[len(students) -1])

# Outputs:
# s
```

* `Python` allows you to access a `string` based on a negative number
  * The negative indices always start at the last letter of the string which is considers index `-1`

| String | D   | u   | c   | k   | l   | i   | n   | g   | s   |
| ------ | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| index  | 0   | 1   | 2   | 3   | 4   | 5   | 6   | 7   | 8   |
| index  | -9  | -8  | -7  | -6  | -5  | -4  | -3  | -2  | -1  |

## Taking a Slice
* You can also use `bracket notation` to return multiple letters from a `string`, which is called a `substring`

```python
name = "Wolfgang"
substring = name[4:7]

print(substring)
# Outputs:
```

* When you create a `substring` you pass the `brackets` a `start_index` and an `end_index`:
  * `name[start_index : end_index]`
  * Keep in mind the `end index` value is **NOT INCLUDED**

## String Immutability
* In `Python` _strings are immutable_
  * Which means once a `string` is created you can not change it's value

```python
movie = "The Avengers"

movie[1] = "H"

# Outputs:
# TypeError: 'str' object does not support item assignment
```
* When we create a variable that stores a `string` we are creating an instance of a `string` class and storing that within the variable
* If we want to update the value that our variable is storing, we have to reassign the value of the variable to a new instance of a string

```python
movie = "The Avengers"

movie = "THe Avengers"
```

## String Methods
* The `str` data type has `method` that we can utilize to perform actions on our `strings`
  * There are many different `str` method which can be found [here](https://www.w3schools.com/python/python_ref_string.asp)
  * Here are just a few:

| Method         | Syntax                                     | Description                                                                                                                 | c   | k   | l   | i   | n   | g   | s   |
| -------------- | ------------------------------------------ | --------------------------------------------------------------------------------------------------------------------------- | --- | --- | --- | --- | --- | --- | --- |
| count          | string_name.count(search_string)           | Returns the number of times search_string occurs in string_name.                                                            | 2   | 3   | 4   | 5   | 6   | 7   | 8   |
| find           | string_name.find(a_string)                 | Returns the index of the first occurrence of a_string in string_name. The method returns -1 if a_string is not found.       | -7  | -6  | -5  | -4  | -3  | -2  | -1  |
| index          | string_name.index(a_string)                | Returns the index of the first occurrence of a_string in string_name. If a_string is not found, the method throws an error. |     |     |     |     |     |     |     |
| lower          | string_name.lower()                        | Returns a copy of the given string, with all uppercase letters converted to lowercase.                                      |     |     |     |     |     |     |     |
| replace        | string_name.replace(a_string, replacement) | Returns a copy of string_name with every occurrence of a_string replaced by the replacement string.                         |     |     |     |     |     |     |     |
| split and list | string_name.split('character')             | Splits the string at each occurrence of character, and returns a list of smaller strings.                                   |     |     |     |     |     |     |     |
| strip          | string_name.strip('characters')            | Returns a copy of the given string with leading and trailing characters strings removed. By default, characters is a space. |     |     |     |     |     |     |     |
| upper          | string_name.upper()                        | Returns a copy of the given string, with all lowercase letters converted to uppercase.                                      |     |     |     |     |     |     |     |

## Strings are Immutable
* As stated before `strings` are `immutable`
* With this in mind all `str methods` **return a new string**
  * Meaning they do not mutate the original `string`

```python
coach = "Ted Lasso"
lowercase_coach = coach.lower()
replace_coach = coach.replace('s', '')

print(coach)
print(lowercase_coach)
print(replace_coach)
# Outputs:
```

## Special Characters
* Outside of  `letters`, `numbers`, and `symbols`, there is another class of characters we can use in `strings`, known as `special characters`

### Newline and Tab
*  Now you can create `multiline strings` with the `'''` or `"""` quotations

*  `\n` also allows you to create `newline`

```python
print("A message,\nbroken across lines.")
# Outputs:
# A message,
# broken across lines
```
* `\t` allows you to `tab` or indent part of your `string` with

```python
print("\tAn indented message")
# Outputs:
#   An indented message
```

## Other Characters
* You can also use `Unicode Character`, which are characters that do not appear on all keyboards:

```python
print('\u25E8     \u26BD     \u26A1')
# Outputs:
```

## Template Literals
* YAY!! No more concatenation!!
* `Template literals` allow for the automatic insertion of expressions and variable values into strings.

### The format() Method
* The syntax for `format()` is:
  * `string_with_braces.format(value_1, value_2, etc.)`

```python
name = 'Doc'
current_age = 1
output = "Next year, {} will be {}."

print(output)
print(output.format(name, current_age + 1))

# Outputs:
# Next year, {} will be {}.
# Next year, Doc will be 2.
```

### f-Strings
* So the `format()` is a bit messy..
* `f-Strings` to the rescue!

```python
name = 'Doc'
current_age = 1
output = f"Next year, {name} will be {current_age + 1}."

print(output)
# Outputs:
```

## Iteration With Strings
### Iterate by Index or Item
* So this form of iteration we have look at a few times already
* We are able to use a `for loop` to iterate over a `string` by each `index`:

```python
wizard = "Harry Potter"

for char in wizard:
    print(char)
# Outputs:
```

* Well we can also iterate over a string by its `items`:

```python
wizard = "Harry Potter"
cloned_wizard = ""

for char in wizard:
    cloned_wizard += char
    print(char, cloned_wizard)
# Outputs:
```
* So what we are doing here is:
  1. We iterate over each `letter` in the `string` _Harry Potter_
  2. As we iterate over each `letter` we append that letter to the end of a newly created string

## Checking Strings
* We are able to use `conditional statements` to check and see if a variable actually contains a string:

```python
variable = 42

if type(variable) == str:
  print(f"The value {variable} is a string.")
else:
  print(f"The value {variable} is NOT a string.")
# Outputs:
```

### Comparing Strings
* You are able to use `comparison operators` `==`, `!=`, `<`, `>`, `<=`, `>=` on `strings`

```python
my_pet = 'dog'
your_pet = 'cat'
other_pet = 'crow'

print(my_pet == your_pet) # Evaluates if the strings are identical

print(your_pet[0] == other_pet[0]) # Evaluates if the first characters are the same

print(my_pet < your_pet) 
# Evaluates if each character's Unicode value
# String that comes earlier in the alphabet is considered less than a string that comes later.
# Since 'dog' follows 'cat' alphabetically, the expression 'dog' < 'cat' evaluates to False

# Outputs:
# False
# True
# False
```
## Checking with in and not in
* Say we want to check to see if a letter is inside a string
* We could use a `for loop`:
```python
title = 'The Hunger Games'
search_character = 'e'

for char in title:
   if char == search_character:
      print(f"{search_character} is in {title}")
```
* The problem with this is the `loop` keeps running even after we find the letter
* The better approach would be to use the `in` operator with a conditional statement:

```python
title = 'The Hunger Games'
search_character = 'e'

if search_character in title:
   print(f"{search_character} is in {title}")
```

* Or the `not in`:
```python
title = 'The Hunger Games'
search_character = 'z'

if search_character not in title:
   print(f"{search_character} is in {title}")
```

### Checking Case
* We can also check the case of a string:

```python
character = 'a'
word = "yep!"
non_letters = '$10.75'

print(character.isupper())
print(word.islower())
print(non_letters.isupper())
# Outputs:
# False
# True
# False
```