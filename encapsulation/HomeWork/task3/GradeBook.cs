using System;

namespace HomeWork;

public class GradeBook
{
    // Fields
    private int[] _grades;

    // Constructor
    public GradeBook(string studentName, int[] grades)
    {
        if (string.IsNullOrWhiteSpace(studentName))
        {
            throw new ArgumentException("Student name cannot be empty.");
        }

        if (grades == null)
        {
            throw new ArgumentException("Grades cannot be null.");
        }

        for (int i = 0; i < grades.Length; i++)
        {
            if (grades[i] < 0 || grades[i] > 100)
            {
                throw new ArgumentOutOfRangeException(nameof(grades));
            }
        }

        StudentName = studentName;

        _grades = new int[grades.Length];

        for (int i = 0; i < grades.Length; i++)
        {
            _grades[i] = grades[i];
        }
    }

    // Properties
    public string StudentName { get; }

    public int Count
    {
        get { return _grades.Length; }
    }

    // Methods
    public bool TryUpdateGrade(int index, int grade)
    {
        if (index < 0 || index >= Count)
        {
            return false;
        }

        if (grade < 0 || grade > 100)
        {
            return false;
        }

        _grades[index] = grade;
        return true;
    }

    public int[] GetGrades()
    {
        int[] copy = new int[_grades.Length];

        for (int i = 0; i < _grades.Length; i++)
        {
            copy[i] = _grades[i];
        }

        return copy;
    }

    public int GetAverage()
    {
        if (Count == 0)
        {
            return 0;
        }

        int sum = 0;

        for (int i = 0; i < Count; i++)
        {
            sum += _grades[i];
        }

        return sum / Count;
    }
}
