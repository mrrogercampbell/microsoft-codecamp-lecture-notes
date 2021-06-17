using System;
using System.Collections.Generic;

class MainClass
{
    public static void Main(string[] args)
    {

        Dictionary<int, string> studentRoster = new Dictionary<int, string>();

        // We want to be able to take user input via the console
        // Then take that input and store it in the Dictionary
        // User should provide key and value via console
        // And both should be stored

        // User input from Console.ReadLine
        // Need two of these based on the key and the value
        // add them to the Dictionary
        // ??Not sure how I want to approach this yet??

        string promptForStudentName = "Please provide the student's name";
        Console.WriteLine(promptForStudentName);
        string studentName = Console.ReadLine();
        // Console.WriteLine(studentName);

        string promptForStudentId = "Please provide the student's id";
        Console.WriteLine(promptForStudentId);
        int studentNumber = Int32.Parse(Console.ReadLine());
        // Console.WriteLine(studentNumber);

        studentRoster.Add(studentNumber, studentName);

        foreach (KeyValuePair<int, string> student in studentRoster)
        {
            Console.WriteLine($"{student.Key}: {student.Value}");
            Console.WriteLine("{0}: {1}", student.Key, student.Value);
        }






    }
}