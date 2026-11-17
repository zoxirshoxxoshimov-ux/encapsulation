using System;

namespace HomeWork;

public class CinemaShow
{
    // Fields
    private bool[] _seats;

    // Constructor
    public CinemaShow(string title, int seatCount)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            throw new ArgumentException("Movie title cannot be empty.");
        }

        if (seatCount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(seatCount));
        }

        Title = title;

        _seats = new bool[seatCount];
    }

    // Properties
    public string Title { get; }

    public int SeatCount
    {
        get { return _seats.Length; }
    }

    // Methods
    public bool Reserve(int seatNumber)
    {
        if (seatNumber < 1 || seatNumber > SeatCount)
        {
            return false;
        }

        int index = seatNumber - 1;

        if (_seats[index] == true)
        {
            return false;
        }

        _seats[index] = true;
        return true;
    }

    public bool Cancel(int seatNumber)
    {
        if (seatNumber < 1 || seatNumber > SeatCount)
        {
            return false;
        }

        int index = seatNumber - 1;

        if (_seats[index] == false)
        {
            return false;
        }

        _seats[index] = false;
        return true;
    }

    public int GetAvailableSeats()
    {
        int count = 0;

        for (int i = 0; i < SeatCount; i++)
        {
            if (_seats[i] == false)
            {
                count++;
            }
        }

        return count;
    }

    public bool[] GetSeats()
    {
        bool[] copy = new bool[SeatCount];

        for (int i = 0; i < SeatCount; i++)
        {
            copy[i] = _seats[i];
        }

        return copy;
    }
}
