# Chapter 19 Classes and Objects Part 2
- [Chapter 19 Classes and Objects Part 2](#chapter-19-classes-and-objects-part-2)
  - [Customizing Fields](#customizing-fields)
    - [Readonly Fields](#readonly-fields)
    - [Static Fields](#static-fields)
  - [Constants](#constants)
  - [Instance and Static Methods](#instance-and-static-methods)
    - [Quick Method Review](#quick-method-review)
  - [Instance Methods](#instance-methods)
    - [ToString](#tostring)
## Customizing Fields
### Readonly Fields
* A `readonly field` is one that cannot be changed once it is initialized.
* We declare fields as readonly by using the `readonly` keyword
* `Value Fields`: We can not change the value of a readonly value field
  * ie: int, double, char, etc
* `Reference Fields`: We can not assign a new object to a readonly reference after initialization
  * Yet we can change the values of fields within the object

```csharp
// Program.cs
FinalFields demo = new FinalFields();

//These are not allowed:

demo.intValue = 6;
demo.doubleValue = 42.0;
demo.doubleValue = 6.0;
demo.objectValue = new FortyTwo();

// However, this is allowed: Why is that?
Console.WriteLine(demo.objectValue.intValue);

demo.objectValue.intValue = 6;

Console.WriteLine(demo.objectValue.intValue);

```

### Static Fields
* Static Fields are shared by all instances of a class
```csharp
// Program.cs
Static InstanceOfTheStaticClass = new Static();

Console.WriteLine($"Non-Static ID: {InstanceOfTheStaticClass.nonStaticId}");
Console.WriteLine($"Non-Static ID: {InstanceOfTheStaticClass.ToString()}");
Console.WriteLine($"Static ID: {Static.staticId}");

```

```csharp
// Static.cs

using System;
namespace ch_19_prep
{
    public class Static
    {
        public static int staticId = 0;
        public int nonStaticId = 1;

        public Static()
        {
        }
    }
}
```


## Constants
* Two things to remember:
  1. There is no strong reason to make constants *private*, since restricting access would force us to re-declare the same values in different classes. We’ll generally make our constants *public*.
  2. We must declare and initialize a constant at the same time.
     * If we do not declare and initialize the constant in the same statement, we cannot assign it a value later. The constant’s value remains empty.

```csharp
public class Temperature {

	private double fahrenheit;

	public const double ABSOLUTE_ZERO_FAHRENHEIT = -459.67;
   
	/* rest of the class... */

}
```


## Instance and Static Methods
### Quick Method Review
* Methods belong to a class and encapsulate reusable functionality
* Methods must be a part of a class
* We use `dot notation` to call a method on a object
```csharp
objectName.MethodName(arugments);

Console.WriteLine("Hello");
```
* We can use access modifiers on methods

## Instance Methods
*  `Instance methods ` define the behaviors that are /unique/ or /specialized/ to each class.
* Same principles apply here as with fields
```csharp
// Program.cs
Static InstanceOfTheStaticClass = new Static();

Static.GetStaticID();
InstanceOfTheStaticClass.GetNonStaticID();
```

```csharp
// Static.cs

using System;
namespace ch_19_prep
{
    public class Static
    {
        public static int staticId = 0;
        public int nonStaticId = 1;

        public Static()
        {
        }

        // Why am I using Static here?
        public static void GetStaticID()
        {
            // Why doesn't this work?
            //Console.WriteLine(this.staticId);

            // Where as this works?
            Console.WriteLine(staticId);
        }

        // But I am not using static here?
        public void GetNonStaticID()
        {
            Console.WriteLine(this.nonStaticId);
        }
    }
}
```


### ToString
* The `ToString` Method returns a string representation of a class