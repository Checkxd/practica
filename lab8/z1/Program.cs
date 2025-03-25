using System;
using System.Collections.Generic;

public class InvalidGradeException : Exception
{
    public InvalidGradeException() : base() { }
    public InvalidGradeException(string message) : base(message) { }
    public InvalidGradeException(string message, Exception innerException) : base(message, innerException) { }
}

public class StudentGrade
{
    public double CalculateAverage(List<int> grades)
    {
        if (grades == null || grades.Count == 0)
            throw new InvalidGradeException("Список оценок пуст или null");

        double sum = 0;
        foreach (int grade in grades)
        {
            if (grade < 0 || grade > 100)
                throw new InvalidGradeException($"Недопустимая оценка: {grade}. Должна быть в диапазоне 0-100");
            sum += grade;
        }
        return sum / grades.Count;
    }
}

class Program
{
    static void Main(string[] args)
    {
      
        StudentGrade student = new StudentGrade();
        try
        {
            List<int> grades = new List<int> { 85, 90, 150, 75 };
            double average = student.CalculateAverage(grades);
            Console.WriteLine($"Средний балл: {average}");
        }
        catch (InvalidGradeException ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }
}