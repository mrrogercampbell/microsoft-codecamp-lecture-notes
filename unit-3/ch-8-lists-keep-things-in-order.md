# Chapter 8: Lists Keep Things in Order
- [Chapter 8: Lists Keep Things in Order](#chapter-8-lists-keep-things-in-order)
  - [List Basics](#list-basics)
    - [Create a New List](#create-a-new-list)
    - [Accessing Elements](#accessing-elements)
  - [List Are Like Strings](#list-are-like-strings)
    - [List Length](#list-length)
    - [Combining List](#combining-list)
    - [in and not in](#in-and-not-in)
    - [List Slices](#list-slices)
  - [Working with List](#working-with-list)
    - [Removing Elements Pt. 1](#removing-elements-pt-1)
    - [The Slice Operator](#the-slice-operator)
    - [Inserting New Elements](#inserting-new-elements)
    - [Replacing Elements](#replacing-elements)
    - [Removing Elements Pt. 2](#removing-elements-pt-2)
  - [List Methods](#list-methods)
    - [Common List Methods](#common-list-methods)
      - [Methods That Return Information About A List](#methods-that-return-information-about-a-list)
      - [Methods That Rearrange The Entries In The list](#methods-that-rearrange-the-entries-in-the-list)
      - [Methods That Add Or Remove Entries From A List](#methods-that-add-or-remove-entries-from-a-list)
      - [Methods That Create New Lists](#methods-that-create-new-lists)
  - [Iterating Through Lists](#iterating-through-lists)
    - [Loop by Element](#loop-by-element)
    - [Loop by Index](#loop-by-index)
  - [Common Task](#common-task)
    - [Switching Two Elements](#switching-two-elements)
    - [Accumulating List Elements](#accumulating-list-elements)
    - [Multiple List Options](#multiple-list-options)
    - [Finding Max and Min](#finding-max-and-min)
  - [Cloning Lists](#cloning-lists)
    - [Creating an Independent Copy](#creating-an-independent-copy)
  - [split and join](#split-and-join)
## List Basics
* In `Python` a `List` is another `ordered collection`
* The data stored within a `List` are called `elements`
  * You can store any `data type` in a `List`

### Create a New List
* There many ways to make a `List`
  * The simplest way is with brackets `[]`:
```python
number_list = [5, 27, 90, 9, 26, 58]

string_list = ["One", "Duck", "Two", "Turkeys", "Three", "Cats", "Four", "Dogs"]

mix_data_list = [1, "Two", 3.5, [4, "Five"] ]

empty_list = []
```
* You can store any data type in a `List`:

### Accessing Elements
* We are able to access a `List` via `bracket notation`:

```python
mix_data_list = [1, "Two", 3.5, [4, "Five"] ]

print(mix_data_list[0])

# Outputs:
# 1
```

## List Are Like Strings
### List Length
* You are able to use the `len()` function on `List`
  * It returns the total number of `elements` that are stored in a `List`

```python
string_list = ["One", "Duck", "Two", "Turkeys", "Three", "Cats", "Four", "Dogs"]

print(len(string_list))

# Outputs:
# 8
```

* Unlike `C#` you are able to `print` an actual `List` to the `console` and see its `elements`:

```python
string_list = ["One", "Duck", "Two", "Turkeys", "Three", "Cats", "Four", "Dogs"]

print(len(string_list))

# Outputs:
# ['One', 'Duck', 'Two', 'Turkeys', 'Three', 'Cats', 'Four', 'Dogs']
```
### Combining List
* We are able to use the `+` and `*` operators on `List`
* `+` allows us to concatenate `List` together
```python
front_end = ["HTML", "CSS", "JavaScript"]
back_end = ["Node.js", "C#", "Django"]

full_stack = front_end + back_end

print(full_stack)

# Outputs:
# ['HTML', 'CSS', 'JavaScript', 'Node.js', 'C#', 'Django']
```
* `*` allows us to cause repetition of `List`:
```python
favorite_movies = ["Avatar", "The Notebook", "The Terminator", "The Little Mermaid"]


print(favorite_movies*2)

# Outputs:
# ['Avatar', 'The Notebook', 'The Terminator', 'The Little Mermaid', 'Avatar', 'The Notebook', 'The Terminator', 'The Little Mermaid']
```

### in and not in
* We are able to use the `in` and `not in` `operators` to check the `elements` of a `List`
  * Remember both of these `operators` return either `True` or `False`

```python
favorite_movies = ["Avatar", "The Notebook", "The Terminator", "The Little Mermaid", 'Dune']

print('Avatar' in favorite_movies)

print('Mrs. Doubtfire' in favorite_movies )

print('The Notebook' not in favorite_movies)

print('Beetlejuice' not in favorite_movies)

# Outputs:
# True
# False
# False
# True
```

### List Slices
* You are able to use the `slice notation` on `List`:
  * `list_name[start_index : end_index]`

```python
original_list = [0, 1, 2, 3, 4, 5]
new_list = original_list[1:4]

print(new_list)

# Outputs:
# [1, 2, 3]
```

## Working with List
* `List` in `Python` are `mutable`

```python
favorite_movies = ["Avatar", "The Notebook", "The Terminator", "The Little Mermaid", 'Dune']

favorite_movies[2] = "You've Got Mail"
favorite_movies[-1] = "Star Wars"

print(favorite_movies)

# Outputs:
# ['Avatar', 'The Notebook', "You've Got Mail", 'The Little Mermaid', 'Star Wars']
```

### Removing Elements Pt. 1
* The keyword `del` allows you to remove `elements` from a `List`
* You are able to remove `elements` in one of two ways:
  1. By `index`: `del list_name[index]`
```python
favorite_movies = ["Avatar", "The Notebook", "The Terminator", "The Little Mermaid", 'Dune']

del favorite_movies[2]
print(favorite_movies)

# Outputs:
# ['Avatar', 'The Notebook', 'The Little Mermaid', 'Dune']
```

  2. With the `slice` syntax: `del list_name[start : end]`

```python
favorite_movies = ["Avatar", "The Notebook", "The Terminator", "The Little Mermaid", 'Dune']

del favorite_movies[2:4]

print(favorite_movies)

# Outputs:
# ['Avatar', 'The Notebook', 'Dune']
```

### The Slice Operator
* The `Slice operator` functions differently depending on what side of a `=` you put it:
  * `Right Side`: returns a smaller portion of a `List`: `my_list = `old_list[start : end]`
  * `Left Side`: will either _insert, replace, or remove_ `elements`: `ist_name[start : end] = [new values...]`

### Inserting New Elements
* By using the `slice operator` and places the same value for the `start` and `end` will `insert` the newly provided `elements` in the `List` at that point and push all proceeding `elements` down:
```python
favorite_movies = ["Avatar", "The Notebook", "The Terminator", "The Little Mermaid", 'Dune']

favorite_movies[2:2] = ['Interview With a Vampire', 'Queen of the Damned']

print(favorite_movies)

# Outputs:
# ['Avatar', 'The Notebook', 'Interview With a Vampire', 'Queen of the Damned', 'The Terminator', 'The Little Mermaid', 'Dune']
```

### Replacing Elements
* By using the `slice operator` and places the different value for the `start` and `end` replace all values except the `end` value

```python
favorite_movies = ["Avatar", "The Notebook", "The Terminator", "The Little Mermaid", 'Dune']

favorite_movies[2:4] = ['Interview With a Vampire', 'Queen of the Damned']

print(favorite_movies)

# Outputs:
# ['Avatar', 'The Notebook', 'Interview With a Vampire', 'Queen of the Damned', 'Dune']
```

### Removing Elements Pt. 2
* You can also remove `elements` by using the `slice` operator and setting the value to an `empty List`
```python
favorite_movies = ["Avatar", "The Notebook", "The Terminator", "The Little Mermaid", 'Dune']

favorite_movies[2:4] = []

print(favorite_movies)

# Outputs:
# ['Avatar', 'The Notebook', 'Dune']
```

## List Methods
### Common List Methods
* You can find all the `List Methods` on the InterWeb:
  * [W3Schools](https://www.w3schools.com/python/python_ref_list.asp)
  * [Python.org](https://docs.python.org/3/tutorial/datastructures.html)

#### Methods That Return Information About A List

| Method | Syntax                 | Description                                                                                                              |
| ------ | ---------------------- | ------------------------------------------------------------------------------------------------------------------------ |
| count  | list_name.count(value) | Returns the number of elements in the list that match value.                                                             |
| index  | list_name.index(value) | Returns the index of the FIRST occurrence of value in the list. If the value is not in the list, Python throws an error. |

#### Methods That Rearrange The Entries In The list

| Method  | Syntax              | Description                                                          |
| ------- | ------------------- | -------------------------------------------------------------------- |
| reverse | list_name.reverse() | Reverses the order of the elements in a list.                        |
| sort    | list_name.sort()    | Arranges the elements of a list into increasing or decreasing order. |

#### Methods That Add Or Remove Entries From A List

| Method | Syntax                         | Description                                                                                                                   |
| ------ | ------------------------------ | ----------------------------------------------------------------------------------------------------------------------------- |
| append | list_name.append(value)        | Adds value to the end of the list.                                                                                            |
| clear  | list_name.clear()              | Removes all elements from a list.                                                                                             |
| insert | list_name.insert(index, value) | Adds value at the specified index in the list. This pushes existing elements further down the list.                           |
| pop    | list_name.pop(index)           | Removes and returns the element at the given index value. If no index is provided, the last element in the list gets removed. |
| remove | list_name.remove(value)        | Removes the FIRST element in a list that matches value.                                                                       |

#### Methods That Create New Lists
| Method | Syntax                      | Description                                                                                                                                                                                          |
| ------ | --------------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| join   | 'connecter'.join(list_name) | Combines all the elements of a list into a string.                                                                                                                                                   |
| split  | 'string'.split('delimiter') | Divides a string into smaller pieces, which are stored as separate elements in a new list.                                                                                                           |
| list   | list(collection)            | This is a function rather than a method, and it behaves similarly to data conversion functions like int() and str(). The list() function tries to convert the whatever is inside the () into a list. |

## Iterating Through Lists
* You are able to iterate over a `List` by `element` or `index`
### Loop by Element
```python
animals = ["Cat", "Dog", "Wolf", "Elephant", "Kiandra"]

for element in animals:
  print(element)

# Outputs:
# Cat
# Dog
# Wolf
# Elephant
# Kiandra
```

### Loop by Index
```python
animals = ["Cat", "Dog", "Wolf", "Elephant", "Kiandra"]

for index in range(len(animals)):
    print(f'{index}) {animals[index]}')

# Outputs:
# 0) Cat
# 1) Dog
# 2) Wolf
# 3) Elephant
# 4) Kiandra
```

## Common Task
### Switching Two Elements
* Keep in mind there are the `sort` and `reverse` methods that will help you do some of this
  * But there are times when you might just want to swap two elements in a `List`
* You could do this the long way:
```python
my_list = ['r', 'a', 't']

temp_value = my_list[0]

my_list[0] = my_list[2]

my_list[2] = temp_value

print(my_list)

# Outputs:
# ['t', 'a', 'r']
```

* But `Python` give you a shorthand to pull this off:
```python
my_list = ['r', 'a', 't']

my_list[0], my_list[2] = my_list[2], my_list[0]

print(my_list)

# Outputs:
# ['t', 'a', 'r']
```

### Accumulating List Elements
* You are able to use the `accumulator pattern` to add items to a list
  * We will use the `append()` method because it only adds one `element` at a time, combine that with a `loop` and we have a very powerful tag team:

```python
evens = []

for num in range(0, 21, 2):
   evens.append(num)

print(evens)

# Outputs:
# [0, 2, 4, 6, 8, 10, 12, 14, 16, 18, 20]
```

* We can also combine a `loop`, `conditional statement`, and the `append()` method to make our logic more complex

```python
words = ['It', 'was', 'a', 'bright', 'cold', 'night', 'in', 'April', 'and', 'all', 'the', 'clocks', 'were', 'striking', 'thirteen']
a_words = []

for word in words:
   if word[0].lower() == 'a':
      a_words.append(word)

print(a_words)

# Outputs:
# ['a', 'April', 'and', 'all']
```

### Multiple List Options
* We can also use `conditionals` to filter `elements` from one `List` to different `Lists`:

```python
mixed_types = [5, 7, 3.14, 'rutabaga', 'integer', True]
integers = []
strings = []

for item in mixed_types:
   if type(item) == str:      # Check if item is a string data type.
      strings.append(item)
   elif type(item) == int:    # Check if item is an int data type.
      integers.append(item)

print(mixed_types)
print(integers)
print(strings)

# Outputs:
# [5, 7, 3.14, 'rutabaga', 'integer', True]
# [5, 7]
# ['rutabaga', 'integer']
```

### Finding Max and Min
* We are able to find the largest and smallest values in a `List` in two different ways:
1. We can use the `sort()`:
```python
numbers = [42, 27, 30, 46, -36, 30, -28, 53, 53, 32]

numbers.sort()

output = f'Minimum = {numbers[0]}, Maximum = {numbers[-1]}'

print(numbers)
print(output)

# Outputs:
[-36, -28, 27, 30, 30, 32, 42, 46, 53, 53]
Minimum = -36, Maximum = 53
```

2. We can also use the `max()` and `min()` methods:
```python
numbers = [42, 27, 30, 46, -36, 30, -28, 53, 53, 32]

largest = max(numbers)
smallest = min(numbers)

output = f'Minimum = {largest}, Maximum = {smallest}'

print(numbers)
print(output.format(smallest, largest))

# Outputs:
# [42, 27, 30, 46, -36, 30, -28, 53, 53, 32]
# Minimum = 53, Maximum = -36
```

## Cloning Lists
```python
first_var = 10
other_var = first_var
print(f'first_var: {first_var} | other_var: {other_var}')

first_var = 'hello'
print(f'first_var: {first_var} | other_var: {other_var}')

# Outputs:
# 10 10
# hello 10
```
* Even though we set `other_var = first_var`, each `variable` points to a different location in memory.

```python
list_a = [10, 33, 8, -2]
list_b = list_a
print(list_a, list_b)

list_a.sort()
print(list_a, list_b)

list_b.append('hello')
print(list_a, list_b)

# Outputs:
# [10, 33, 8, -2]   [10, 33, 8, -2]
# [-2, 8, 10, 33]   [-2, 8, 10, 33]
# [-2, 8, 10, 33, 'hello']   [-2, 8, 10, 33, 'hello']
```

* `Python` is similar to `C#` in the fact that there are `reference data types` and `value data types`
  * But for the int, str, bool, and float data types, setting other_var = first_var creates separate values in two memory locations, one for each variable.
  * For lists, list_b = list_a creates two variables that point to the SAME memory location. The same list has two different names.
    * Because the same list has two different names, we say that it is `aliased`. Changes made with one alias affect the other.


### Creating an Independent Copy
* Whereas we can `alias` a `List` this is not a good practice
* We are able to create `independent copies` of `List` by utilizing the `copy()`:
  * `list_clone = original_list.copy()`
  * `list_clone = original_list[ : ]`


## split and join
