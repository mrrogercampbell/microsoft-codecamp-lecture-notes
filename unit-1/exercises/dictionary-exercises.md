# Dictionary Exercises
Complete the following prompts:

1. Create a dictionary called books utilize the following syntaxes:
   * Its `keys` should be integers id
   * It's `values` should be strings of book title
   * example:
     * key = `1`
     * value = "to kill a mockingbird"
```C#
Dictionary<TKey, TValue> newDictionary = new Dictionary<TKey, TValue>
{
   {key1, value1},
   {key2, value2},
   {key3, value3}
};
```
1. Write a two Console.WriteLine statements:
   1. Prints the first item in the dictionary key to the console.
   2. Prints the first item in the dictionary value to the console
2. Write another Console.WriteLine statement that uses String Interpolation to print the second item in the dictionary key and value in one string
3. Use the `Add()` Method