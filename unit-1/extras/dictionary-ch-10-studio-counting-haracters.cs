// Prompt: 
/*
In this studio, you will write a program to count the number of times each character occurs in a string and then print the results to the console.
<-------------------------->
Sample Input:
Feel free to prompt the user for a string. However, for the sake of simplicity, you might want to start by hard-coding some text and storing it in a variable. For your convenience, here is some lorem ipsum text:

Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc accumsan sem ut ligula scelerisque sollicitudin. Ut at sagittis augue. Praesent quis rhoncus justo. Aliquam erat volutpat. Donec sit amet suscipit metus, non lobortis massa. Vestibulum augue ex, dapibus ac suscipit vel, volutpat eget massa. Donec nec velit non ligula efficitur luctus.
<-------------------------->
Sample Output:
For the example string above, your output should look something like:

L: 1
o: 15
r: 9
e: 26
m: 11
 : 50
i: 27
p: 7
s: 29
u: 28
d: 4
l: 17
t: 29
a: 22
,: 4
c: 17
n: 14
g: 7
.: 8
N: 1
q: 3
U: 1
P: 1
h: 1
j: 1
A: 1
v: 4
D: 2
b: 3
V: 1
x: 1
f: 2

*/

using System;
using System.Collections.Generic;

public class MainClass
{
    public static void Main(string[] args)
    {
        string testString = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc accumsan sem ut ligula scelerisque sollicitudin. Ut at sagittis augue. Praesent quis rhoncus justo. Aliquam erat volutpat. Donec sit amet suscipit metus, non lobortis massa. Vestibulum augue ex, dapibus ac suscipit vel, volutpat eget massa. Donec nec velit non ligula efficitur luctus.";

        Dictionary<char, int> alphabet = new Dictionary<char, int>();

        foreach (char letter in testString)
        {
            //if we don't have that letter in our dictionary yet, we will add it.
            Console.WriteLine(letter);
            if (!alphabet.ContainsKey(letter))
            {
                alphabet.Add(letter, 1);
            }
            //if the letter is in the dictionary, we don't add it, but we increase the value by one
            else
            {
                alphabet[letter]++;
                Console.WriteLine(alphabet[letter]);
            }
        }

        foreach (KeyValuePair<char, int> entry in alphabet)
        {
            Console.WriteLine($"{entry.Key} : {entry.Value}");
        }
    }
}