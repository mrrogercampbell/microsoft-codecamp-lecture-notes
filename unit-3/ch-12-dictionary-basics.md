# Chapter 12: Dictionary Basics

## Dictionary Facts
1. `Dictionaries` are `unordered collections`
   * They _do NOT_ use index values (0, 1, 2, …) to organize the data
2. `Dictionaries` are `mutable`
   * We can `add`, `remove`, or `modify` the data in the `collection`
3. `Dictionaries` store data using sets of `key/value pairs`
4. `Dictionaries` store as many `key/value pairs` as needed, and each `value` needs a `key`
   * Without a `key`, the value cannot be accessed or modified.
5. The values in a `dictionary` may be of _any_ `data type`
   * Including `lists` and other `dictionaries`
6. The `keys` should be an `int` or `str` data type
   * Using `strings` is the better choice

### Why Use Keys?
* Using `string` as the name for our `keys` makes it easier to remember how to access the data stored in each `key-value pair`

### Creating a New Dictionary
* Every `dictionary` has three things:
  1. A `variable` which the `dictionary`  it is stored inside of
  2. A set of `keys`
  3. `Values` for each corresponding `key

```python
person = {
    'name': "George",
    'date_of_birth': "May 14, 1944",
    'age': 77,
    'home_town': "Modesto, CA",
    'prequel_sage': ["The Phantom Menace", "Attack of The Clones", "Revenge of The Sith"],
    'original_saga': [ "A New Hope", "The Empire Strikes Back", "Return of The Jedi"]
}
```

### Accessing Values
* We still utilize `bracket notation` to access a `dictionary` but just like in `C#` we must use the name of the `key` we would like to access:
```python
person = {
    'name': "George",
    'date_of_birth': "May 14, 1944",
    'age': 77,
    'home_town': "Modesto, CA",
    'prequel_sage': ["The Phantom Menace", "Attack of The Clones", "Revenge of The Sith"],
    'original_saga': [ "A New Hope", "The Empire Strikes Back", "Return of The Jedi"]
}

print(person['name'])

# Outputs:
# George Lucas
```

## Working with Dictionaries
* `Dictionaries` are `mutable`
  * Meaning we can:
    * Change the values assigned to a `key`
    * Add new `key-value pairs`
    * Remove `key-value pairs`
* Due to `dictionaries` being `unordered list` there is no way to sort or rearrange the `key-value pairs`

### Change One Value
* We are able to update a single `value` within a `dictionary` by accessing it via it's `key`:
```python
dictionary_name[key_name] = new_value
```
* Let's see this in action:
```python
person = {
    'name': "George",
    'date_of_birth': "May 14, 1944",
    'age': 77,
    'home_town': "Modesto, CA",
    'prequel_sage': ["The Phantom Menace", "Attack of The Clones", "Revenge of The Sith"],
    'original_saga': [ "A New Hope", "The Empire Strikes Back", "Return of The Jedi"]
}

person['name'] += " Lucas"

print(person['name'])

# Outputs:
# George Lucas
```

### Add a New Key-Value Pair
* Once a `dictionary` is defined you are able to add a new `key-value pair` with `bracket notation`:
```python
person = {
    'name': "George",
    'date_of_birth': "May 14, 1944",
    'age': 77,
    'home_town': "Modesto, CA",
    'prequel_sage': ["The Phantom Menace", "Attack of The Clones", "Revenge of The Sith"],
    'original_saga': [ "A New Hope", "The Empire Strikes Back", "Return of The Jedi"]
}

person['omitted_saga'] = ["The Force Awakens", "The Last Jedi", "The Rise of Skywalker"]

print(person['omitted_saga'])

# Outputs:
['The Force Awakens', 'The Last Jedi', 'The Rise of Skywalker']
```

### Remove a Key-Value Pair
* Yes, you can even remove a `key-value pair`:
```python
del dictionary_name[key]
```

```python
person = {
    'name': "George",
    'date_of_birth': "May 14, 1944",
    'age': 77,
    'home_town': "Modesto, CA",
    'prequel_sage': ["The Phantom Menace", "Attack of The Clones", "Revenge of The Sith"],
    'original_saga': [ "A New Hope", "The Empire Strikes Back", "Return of The Jedi"],
    'omitted_saga': ["The Force Awakens", "The Last Jedi", "The Rise of Skywalker"]
}

del person['omitted_saga']

print(person)

# Outputs:
# {'name': 'George', 'date_of_birth': 'May 14, 1944', 'age': 77, 'home_town': 'Modesto, CA', 'prequel_sage': ['The Phantom Menace', 'Attack of The Clones', 'Revenge of The Sith'], 'original_saga': ['A New Hope', 'The Empire Strikes Back', 'Return of The Jedi']}
```
* Phew... That was a close one I thought that mess was here to stay.....

## Dictionary Methods
* As with most `collections` a `dictionary` comes with some default `methods`
* All of these `methods` either:
  * _Change_ an existing `dictionary`
  * _Return_ information about the `dictionary`
  * _Create and return_ a new `dictionary`

## Dictionary Methods
* As always here are a few links on where you can find a more comprehensive list of `Methods`:
  * [W3Schools](https://www.w3schools.com/python/python_ref_dictionary.asp)
  * [Tutorials Teacher](https://www.tutorialsteacher.com/python/dictionary-methods)

### Common Dictionary Methods
| Method | Syntax                   | Description                                                                                |
| ------ | ------------------------ | ------------------------------------------------------------------------------------------ |
| clear  | dictionary_name.clear()  | Removes all key/value pairs from a dictionary.                                             |
| copy   | dictionary_name.copy()   | Returns an independent copy of a dictionary. This is also called cloning.                  |
| pop    | dictionary_name.pop(key) | Removes the selected key/value pair from the dictionary and returns the value.             |
| keys   | dictionary_name.keys()   | Returns all of the key names in the dictionary, which can then be moved into a list.       |
| values | dictionary_name.values() | Returns all of the values in the dictionary, which can then be moved into a list.          |
| items  | dictionary_name.items()  | Returns all of the key/value pairs in the dictionary, which can then be moved into a list. |

### max, min, and len
* The following `functions`also work on `dictionaries`:
  * `max()`: by _default returns the largest_ `key` in the `dictionary`
  * `min()`: by _default returns the smallest `key` in the `dictionary`
    * * When working with `strings`:
      * `max()` and `min()` return values based on their position in the alphabet
      * _Capital letters coming before lowercase_
  * `len()`: returns the number of items in a dictionary
    * Each `key-value pair` counts as a _single item_

```python
max(dictionary_name.keys())

min(dictionary_name.keys())

max(dictionary_name.values())

min(dictionary_name.values())

len(dictionary_name)
```
* `max()`:
```python
num_animals = {
    'sloths': 3,
    'dogs': 2,
    'wolves': 8,
    'loth_cats': 3000
}

max_animals_keys = max(num_animals)
max_animals_values = max(num_animals.values())

print(max_animals_keys)
print(max_animals_values)

# Outputs:
# wolves
# 3000
```
* `min()`:
```python
num_animals = {
    'sloths': 3,
    'dogs': 2,
    'wolves': 8,
    'loth_cats': 3000
}

min_animals_keys = min(num_animals)
min_animals_values = min(num_animals.values())

print(min_animals_keys)
print(min_animals_values)

# Outputs:
# dogs
# 2
```
* `len()`:
```python
num_animals = {
    'sloths': 3,
    'dogs': 2,
    'wolves': 8,
    'loth_cats': 3000
}

length_of_animals = len(num_animals)
print(length_of_animals)

# Outputs:
# 4
```

## Iterating Through Dictionaries
### Loop by Keys or Values
* We are able to use `loops` to iterate over a `dictionary` but you must iterate over it by utilize either the `keys()` or `values()` method
```python
for key in dictionary_name.keys():
    # Do something...

for value in dictionary_name.values():
    # Do something...
```
* Let's see it in action:
```python
num_animals = {
    'sloths': 3,
    'dogs': 2,
    'wolves': 8,
    'loth_cats': 3000
}

for key in num_animals.keys():
    print(key)

print("<------------->")

for value in num_animals.values():
    print(value)

# Outputs:
# sloths
# dogs
# wolves
# loth_cats
# <------------->
# 3
# 2
# 8
# 3000
```

### Loop by Key-Value Pairs
* The `items()` method returns each `key-value pair` in a `dictionary`
  * Using this `method` in conjunction with a `for loop` allows us to define a `variable` for the `(key, value)`:
```python
num_animals = {
    'sloths': 3,
    'dogs': 2,
    'wolves': 8,
    'loth_cats': 3000
}

for (key, value) in num_animals.items():
    print(key, value)
# Outputs:
# sloths 3
# dogs 2
# wolves 8
# loth_cats 3000
```