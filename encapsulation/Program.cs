using System;
using HomeWork;

internal class Program
{
    private static void Main(string[] args)
    {
        WaterTankTask_1();
        StudySessionTask_2();
        GradeBookTask_3();
        CinemaShowTask_4();
        SavingsGoalTask_5();
    }

    static void WaterTankTask_1()
    {
        Console.WriteLine("\n==================");

        var tank1 = new WaterTank(100, 40);

        Console.WriteLine($"Fill(30): {tank1.Fill(30)}; water: {tank1.Water}");
        Console.WriteLine($"Use(20): {tank1.Use(20)}; water: {tank1.Water}");
        Console.WriteLine($"Fill(60): {tank1.Fill(60)}; water: {tank1.Water}");
        Console.WriteLine($"Use(0): {tank1.Use(0)}; water: {tank1.Water}");

        Console.WriteLine($"Free capacity: {tank1.GetFreeCapacity()}");

        var tank2 = new WaterTank(50, 10);
        Console.WriteLine($"Second tank water: {tank2.Water}");

        try
        {
            var invalidTank = new WaterTank(100, 101);
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("Invalid tank was rejected.");
        }
    }

    static void StudySessionTask_2()
    {
        Console.WriteLine("\n===============================");

        var session = new StudySession("C#", 40);

        Console.WriteLine($"RecordMinutes(25): {session.RecordMinutes(25)}");
        Console.WriteLine($"Spent: {session.SpentMinutes}");

        Console.WriteLine($"RecordMinutes(20): {session.RecordMinutes(20)}");
        Console.WriteLine($"Spent: {session.SpentMinutes}");

        session.PlannedMinutes = 60;

        Console.WriteLine($"New plan: {session.PlannedMinutes}");
        Console.WriteLine($"Remaining: {session.GetRemainingMinutes()}");

        try
        {
            session.PlannedMinutes = 20;
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("Invalid plan was rejected.");
        }

        Console.WriteLine($"Plan after exception: {session.PlannedMinutes}");

        Console.WriteLine($"RecordMinutes(35): {session.RecordMinutes(35)}");
        Console.WriteLine($"Remaining: {session.GetRemainingMinutes()}");
    }

    static void GradeBookTask_3()
    {
        Console.WriteLine("\n=======================");

        int[] grades = { 70, 80, 90 };

        var book = new GradeBook("Ali", grades);

        grades[0] = 0;

        int[] returnedGrades = book.GetGrades();
        returnedGrades[1] = 0;

        Console.WriteLine($"Grades after external changes: {string.Join(", ", book.GetGrades())}");

        Console.WriteLine($"TryUpdateGrade(1, 100): {book.TryUpdateGrade(1, 100)}");
        Console.WriteLine($"Grades: {string.Join(", ", book.GetGrades())}");

        Console.WriteLine($"TryUpdateGrade(3, 50): {book.TryUpdateGrade(3, 50)}");
        Console.WriteLine($"TryUpdateGrade(0, 101): {book.TryUpdateGrade(0, 101)}");

        Console.WriteLine($"Count: {book.Count}");
        Console.WriteLine($"Average: {book.GetAverage()}");

        var emptyBook = new GradeBook("Ali", new int[0]);
        Console.WriteLine($"Empty book average: {emptyBook.GetAverage()}");
    }

    static void CinemaShowTask_4()
    {
        Console.WriteLine("\n===========================");

        var show = new CinemaShow("Adventure", 4);

        Console.WriteLine($"Reserve(1): {show.Reserve(1)}");
        Console.WriteLine($"Reserve(3): {show.Reserve(3)}");
        Console.WriteLine($"Reserve(3): {show.Reserve(3)}");
        Console.WriteLine($"Reserve(5): {show.Reserve(5)}");

        Console.WriteLine($"Cancel(1): {show.Cancel(1)}");
        Console.WriteLine($"Cancel(2): {show.Cancel(2)}");

        bool[] seats = show.GetSeats();
        seats[0] = true;

        Console.WriteLine($"Seat states: {string.Join(", ", show.GetSeats())}");
        Console.WriteLine($"Available seats: {show.GetAvailableSeats()}");

        var secondShow = new CinemaShow("Comedy", 4);
        Console.WriteLine($"Second show available seats: {secondShow.GetAvailableSeats()}");
    }

    static void SavingsGoalTask_5()
    {
        Console.WriteLine("\n===============================");

        var goal = new SavingsGoal("Laptop", 1000m, 200m);

        Console.WriteLine($"TryAdd(500): {goal.TryAdd(500m)}");
        Console.WriteLine($"Saved: {goal.Saved}");

        Console.WriteLine($"TryWithdraw(100): {goal.TryWithdraw(100m)}");
        Console.WriteLine($"Saved: {goal.Saved}");

        Console.WriteLine($"TryAdd(500): {goal.TryAdd(500m)}");
        Console.WriteLine($"Saved: {goal.Saved}");

        Console.WriteLine($"TryWithdraw(0): {goal.TryWithdraw(0m)}");
        Console.WriteLine($"Saved: {goal.Saved}");

        Console.WriteLine($"TryAdd(400): {goal.TryAdd(400m)}");
        Console.WriteLine($"Saved: {goal.Saved}");

        Console.WriteLine($"Remaining: {goal.GetRemaining()}");
        Console.WriteLine($"Is reached: {goal.IsReached()}");

        goal.TryWithdraw(100m);
        Console.WriteLine($"After withdrawal, Is reached: {goal.IsReached()}");
    }
}
