# Methods Exercise
Please complete the following prompts.

## Part 1: Arithmetic
1. Create a method called Addition that expects two numbers as parameters and returns the sum of the first number added to the second number.
```C#
Addition(2,5);
// Outputs: 7
```
2. Create a method called Subtractions that expects two numbers as parameters and returns the difference of the first number minus to the second number.
```C#
Subtraction(5,3);
// Outputs: 2
```
3. Create a method called Multiplication that expects two numbers as parameters and returns the product of the first number times to the second number.
```C#
Multiplication(10,10);
// Outputs: 100
```
4. Create a method called Division that expects two numbers as parameters and returns the quotient of the first number divided to the second number.
```C#
Division(100,20);
// Outputs: 5
```
5. Create a method called Modulation that expects two numbers as parameters and returns the remainder of the first number modulo to the second number.
```C#
Modulation(50,10);
// Outputs: 0
```
6. Create a method called Exponentiation that expects two numbers as parameters and returns the power of the first number to the power of the second number.
```C#
Exponentiation(35,5);
// Outputs: 52521875
```
# Part 2: Printing Things to The Console
1. Create a method called PrintArray that expects an array of any data type as an argument. It should iterate over the items within the array and print each one to the console.
```C#
    string[] people = {
      "Johnny",
      "Sue",
      "Tyrone",
    };

    PrintStringArray(people);
    // Outputs: Johnny
    // Outputs: Sue
    // Outputs: Tyrone
```
2. Create a method called PrintList that expects a String List as an argument and prints each item within the List to the console.
```C#
    string[] arrOfCharacters =
    {
      "The Tic",
      "Birdman",
      "Batman",
    };

PrintStringList(charList);

// Outputs: The Tic
// Outputs: Birdman
// Outputs: Batman
```
3. Create a method called PrintDict that expects a Dictionary which stores integers as keys and strings as values. Iterate over each key value pair within the dictionary and print each key and value to the console. You must use either String Interpolation or Composite Format Strings to output the Key Value Pairs.
```C#
Dictionary<int, string> operatingSystems = new Dictionary<int, string>
{
 {1, "Mac"},
 {2, "Windows"},
 {3, "Linux"}
};

PrintDict(operatingSystems);
// Outputs: key: 1 | value: Mac
// Outputs: key: 2 | value: Windows
// Outputs: key: 3 | value: Linux
```
## Part 3: Creating Collections
1. Create a method called FillStrArray that expect at least three strings as arguments. FillStrArray should create a new array and print each item within it to the console. It should also return a newly created array with each string passed to it, meaning if you store the method evocation in a variable and print it to the console it should out put System.String[].
```C#
string str1 = "Dude What's Mine Say?!";
string str2 = "Sweet!!!";
string str3 = "What's Mine Say?!";
string str4 = "Dude!!!!";

string[] newStrArr = FillArray(str1, str2, str3, str4);
// Outputs: Dude What's Mine Say?!
// Outputs: Sweet!!!
// Outputs: What's Mine Say?!
// Outputs: Dude!!!!

Console.WriteLine(newStrArr);
// Outputs: System.String[]
```
2. Create a method called FillIntArray that expect at least three strings as arguments. FillIntArray should create a new array and print each item within it to the console. It should also return a newly created array with each string passed to it, meaning if you store the method evocation in a variable and print it to the console it should out put System.Int32[].
```C#
int num1 = 1;
int num2 = 2;
int num3 = 3;
int num4 = 4;

int[] newIntArr = FillIntArray(num1, num2, num3, num4);
// Outputs: 1
// Outputs: 2
// Outputs: 3
// Outputs: 4
Console.WriteLine(newIntArr);
// Outputs: System.Int32[]
```

3. Create a method called FillList that expect an array of strings as arguments. FillList should create a new List and print each item within it to the console. It should also return the newly created List with each string item that was contained within the array argument; meaning if you store the method evocation in a variable and print it to the console it should out put System.String[].
```C#
string[] arrOfCharacters =
{
    "Birdman",
    "Batman",
    "Ed"
};

List<string> charList = FillList(arrOfCharacters);
// Outputs: Birdman
// Outputs: Batman
// Outputs: Ed

Console.WriteLine(charList);
// Outputs: System.Collections.Generic.List`1[System.String]
```
1. Create a method called FillDict that expect an array of integers and an array of strings as arguments. FillDict should create a new Dictionary by iterating over each array and store a key from the int array and a corresponding value from the string array and return the newly created Dictionary. The method should also print each Key Value Pair to the console.
```C#
string[] stringArr = { "Birdman", "Batman", "Ed" };

int[] intArr = { 1, 2, 3 };

Dictionary<int, string> newDict =  FillDict(newIntarr,stringArr);
// Outputs: key: 1 | value: Dude What's Mine Say?!
// Outputs: key: 2 | value: Sweet!!!
// Outputs: key: 3 | value: What's Mine Say?!
// Outputs: key: 4 | value: Dude!!!!

Console.WriteLine(newDict);
// Outputs: System.Collections.Generic.Dictionary`2[System.Int32,System.String]
```
