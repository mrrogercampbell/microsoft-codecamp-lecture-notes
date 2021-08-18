# Chapter 13: Classes and Objects
- [Chapter 13: Classes and Objects](#chapter-13-classes-and-objects)
  - [What are Objects](#what-are-objects)
    - [Difference Between an Object and a Class](#difference-between-an-object-and-a-class)
    - [Creating a Class](#creating-a-class)
    - [Creating an Object](#creating-an-object)
    - [Accessing an Objects Properties](#accessing-an-objects-properties)
    - [Defining Class Methods](#defining-class-methods)
    - [The self Parameter](#the-self-parameter)
  - [Another Dunder Method](#another-dunder-method)
    - [The __str__ Method](#the-str-method)
  - [Using Objects in Functions](#using-objects-in-functions)
  - [Python Inheritance](#python-inheritance)
## What are Objects
* Two quick points of reference:
  1. A `value`: is a specific piece of data
     * We store `values` inside `variables`:
```python
name = 'Roger'
num = 3
```
  2. A `function` is a reusable code block
     * We use `functions` to a single task

* `Objects` allow us to do both all in one shot:
  * `Methods`: are actions that we define within an `object`
    * ie: `Functions`
  * `Properties`: are data assigned within an `object`
    * ie: `Variables`

### Difference Between an Object and a Class
* A `class` is like a blueprint or template
  * A `class` defines the `properties` and `methods` that an instance can utilize/have access too
* A `object` is an _instance_ or _implementation_ of a `class`

### Creating a Class
* Let's start by looking at the syntax of a `class declaration`:
```python
class ClassName:
    def __init__(self, first_property_value, second_property_value):
        self.first_property_value = first_property_value
        self.second_property_value = second_property_value
```
* Now lets see an actual example:
```python
class Person:
    def __init__(self, name, age):
        self.name = name
        self.age = age
```
* Let's break this down:
  1. We use the `class` keyword to start a `class declaration`
  2. Then we provide the `class` with a name `Person`
  3. We then use the `:` syntax to declare the start of the `classes` scope
  4. We utilize the `__init__()` function
     * This is a `constructor function`
       * It just has a _different naming convention_ than what we are used to in `C#`
     * It allows us to pass any `property values` we would like the class to accept on initialization and where to set said values
     * We can also tell the `__init()__` function to run specific `functions` and or `methods` on initialization
  5. If you notice the fist `parameter` the `__init__()` accepts is `self`
     * `self` allows us to access each _specific instance_ of the class we create
       * `self` is to `Python` class that `this` is to `C#` classes

### Creating an Object
* When we create an `object` we are `instantiating` an _instance_ of a `class`
  * Or more planing put:
    * We are creating a _physical representation_ of our blueprint
* Lets see how we would do this:
```python
class Person:
    def __init__(self, name, age):
        self.name = name
        self.age = age

first_person = Person("Jake", 33)

print(first_person)

# Outputs:
# <__main__.Person object at 0x10ee39430>
```
* Let's break it down:
  1. We create a `variable` called `first_person`
  2. We set `first_person` equals to an `instance` of the _Person_ `class`
     * By writing `Person()` we are `invoking` the `__init()__` function and passing it 3 arguments:
       1. The `instance` itself (this is explicitly done)
       2. The _value_ for the `name` property
       3. The _value_ for the `age` property
  3. Lastly we `print(first_person)` which then _outputs_ the _location in memory_ where the `object` can be found
     * Meaning the _specific_ `instance` that we are working with


* A fun example from class:
```python
class Car:
    def __init__(self, make, model, year):
        self.make = make
        self.model = model
        self.year = year

    def print_details(self):
        # We are grabbing the location of the Object in memory and storing it in a variable
        location = hex(id(self))

        # We are then creating a variable called output that stores a string
            # this string then prints all the values for each prop and the location in memory of the Object
        output = f'{self.make} {self.model} {self.year} is located at {location} within memory'
        return output


# This is grabbing the location of the Car class
car_location = hex(id(Car))

first_car = Car("Honda", "Accord", 1997)

# Here we are printing the location of the car class
print(car_location)

# Here we are explicitly invoking the __str__() by printing the variable that stores the object ie: (an instance of the Car class))
print(first_car)

# This is a custom method we created which show that the __str__() by default grabs the object's location in memory and prints it
    # we did this as a fact-check, see lecture recording for more details
print(first_car.print_details())

# Outputs:
# 0x7fd4ad790be0
# <__main__.Car object at 0x102cc9f10>
# Honda Accord 1997 is located at 0x102cc9f10 within memory
```
### Accessing an Objects Properties
* Now that we know how to _declare_ a `class` and _instantiate an instance_ of an `object`
  * Let's take a look at how we can _access the properties_ of a `object`
* As you already know from before we are able to _access_ a `property` of a `object` with `dot notation`:
```python
class Car:
    def __init__(self, make, model, year):
        self.make = make
        self.model = model
        self.year = year


first_car = Car("Honda", "Accord", 1997)

print(first_car.make)
print(first_car.model)
print(first_car.year)


# Outputs:
# Honda
# Accord
# 1997
```

### Defining Class Methods
* As stated above `classes` can have `method`
  * The terms `methods` and `functions` are used interchangeably but in actuality:
    * `Functions`: are _independent, small, concise, and reusable_ pieces of logic that perform a specific task
    * `Methods`: are `functions` _declared within_ a `class`
* Let's take a look at _declaring_ a `method` within a `class deceleration`:
```python
class Car:
    def __init__(self, make, model, year):
        self.make = make
        self.model = model
        self.year = year

    def drive_car(self):
        print("**Vrooom! Vrooom!! Vrooom!!! **")


first_car = Car("Honda", "Accord", 1997)

first_car.drive_car()
# Outputs:
```
* Let's break it down:
  1. We create a `class deceleration`
     * If this `syntax` is still a bit hazy refer back to the [Creating a Creating](#creating-a-class) section
  2. One additional thing we have done in this `class deceleration` is created an additional `method` named `drive_car()`
     * The `self parameter` _refers to the current instance of the class_ and is a **required parameter**
  3. We _instantiate an instance_ of a `class`
     * If this `syntax` is still a bit hazy refer back to the [Creating an Object](#creating-an-object) section
  4. Finally we invoke the `drive_car` method on the `first_person` `object`: `first_car.drive_car()`

* **Gotcha**:
  * If you did not provide the `self` parameter to the `drive_car` declaration, when invoked it would throw the following error:
    * `TypeError: drive_car() takes 0 positional arguments but 1 was given`
  * This is due to the fact that:
    * The `self parameter` _refers to the current instance of the class_ and is a **required parameter**
    * And is needed in order for the `method` _invocation_ to know which _instance_ of the `class` you are using this `method` on

### The self Parameter
* As stated above: The `self parameter` _refers to the current instance of the class_ and is a **required parameter**
* But with that said the word `self` is just a _naming convention_
  * You can actually use whatever word you would like here
  * Although it is industry standard to just use `self`
* But for that person in the back who want to do it just because they can:
```python
class Student:
    def __init__(something, name, meme_lover):
        something.name = name
        something.meme_lover = meme_lover

    def do_they_love_memes(something):
        loves_memes = 'does' if something.meme_lover == True else 'does not'

        print(f'{something.name} {loves_memes} loves Memes!')


person_one = Student('Dave', True)

person_one.do_they_love_memes()

# Outputs:
# Dave does loves Memes!
```
## Another Dunder Method
### The __str__ Method
* The `__str__()` method performs that same default functionality as `Object.ToString()` in `C#`
  * By default the `__str__()` method will print the location of the object
```python
class Car:
    def __init__(self, make, model, year):
        self.make = make
        self.model = model
        self.year = year


first_car = Car("Honda", "Accord", 1997)

print(first_car.__str__())
print(first_car)

# Outputs:
# <__main__.Car object at 0x10eda8d60>
# <__main__.Car object at 0x10eda8d60>
```
* As you can see the `__str__()` is what is called when an `object` is placed within a `print()`
* With that in mind you are actually able to _override_ the default functionality_ of the `__str__()` so that it will print something meaningful:
```python
class Car:
    def __init__(self, make, model, year):
        self.make = make
        self.model = model
        self.year = year

    def __str__(self):
        output = f'This car is a {self.year} {self.make} {self.model}'

        return output


first_car = Car("Honda", "Accord", 1997)

print(first_car)
print(first_car.__str__())

# Outputs:
# This car is a 1997 Honda Accord
# This car is a 1997 Honda Accord
```

## Using Objects in Functions
* You are able to use `object` within `functions`
  * When you think about it this is really not that foreign of a thought
    * Every time you create a `string`, `int`, `bool`, `list`. `dictionary`, and or any other data type you are creating an _instance_ of a `class`
* But lets take a look at how you would use a custom `object` you created within an `function`:

```python
class Jedi:
    def __init__(self, name, saber_color, skill_level):
        self.name = name
        self.saber_color = saber_color
        self.skill_level = skill_level

    def __str__(self):
        output = f'{self.name} uses a {self.saber_color} lightsaber and has a skill level of {self.skill_level}'

        return output


def force_wielder_duel(first_combatant, second_combatant):
    if first_combatant.skill_level > second_combatant.skill_level:
        print(f'{first_combatant.name} beats {second_combatant.name}')
    else:
        print(f'{second_combatant.name} beats {first_combatant.name}')


first_jedi = Jedi('Mace Windu', "Purple", 2000)
second_jedi = Jedi('Luke Skywalker', "Green", 1000)

force_wielder_duel(first_jedi, second_jedi)

# Outputs:
# Mace Windu beats Luke Skywalker
```

## Python Inheritance
```python
class Jedi:
    def __init__(self, name, saber_color, skill_level):
        self.name = name
        self.saber_color = saber_color
        self.skill_level = skill_level

    def __str__(self):
        output = f'{self.name} uses a {self.saber_color} lightsaber and has a skill level of {self.skill_level}'

        return output

class Sith(Jedi):
    pass


def force_wielder_duel(first_combatant, second_combatant):
    if first_combatant.skill_level > second_combatant.skill_level:
        print(f'{first_combatant.name} beats {second_combatant.name}')
    else:
        print(f'{second_combatant.name} beats {first_combatant.name}')


first_jedi = Jedi('Mace Windu', "Purple", 2000)
first_sith = Sith('Darth Vader', "Red", 100000)

force_wielder_duel(first_jedi, first_sith)

# Outputs:
# Darth Vader beats Mace Windu
```