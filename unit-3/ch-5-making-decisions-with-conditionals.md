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

## 5.4. Can We Do Math with Boolean Values?