using System;
using System.Collections.Generic;

public class Person
{
    public string Name { get; set; }
    public string City { get; set; }

    public Person(string name, string city)
    {
        Name = name;
        City = city;
    }

    public override string ToString()
    {
        return $"Name: {Name}, City: {City}";
    }
}

public static class ArrayOperations
{
    public static Dictionary<string, int> CountPeopleInCity(Person[] people)
    {
        Dictionary<string, int> cityCount = new Dictionary<string, int>();

        foreach (Person person in people)
        {
            if (cityCount.ContainsKey(person.City))
            {
                cityCount[person.City]++;
            }
            else
            {
                cityCount[person.City] = 1;
            }
        }

        return cityCount;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Person[] people = new Person[]
        {
            new Person("Alice", "Moscow"),
            new Person("Bob", "London"),
            new Person("Charlie", "Moscow"),
            new Person("David", "Paris"),
            new Person("Eve", "London"),
            new Person("Frank", "Moscow")
        };

        Console.WriteLine("Список людей:");
        foreach (Person person in people)
        {
            Console.WriteLine(person);
        }

        Dictionary<string, int> result = ArrayOperations.CountPeopleInCity(people);

        Console.WriteLine("\nКоличество людей в каждом городе:");
        foreach (var pair in result)
        {
            Console.WriteLine($"{pair.Key}: {pair.Value}");
        }
    }
}