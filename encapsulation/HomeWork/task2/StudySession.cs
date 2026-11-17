using System;

namespace HomeWork;

public class StudySession
{
    // Fields
    private int _plannedMinutes;
    private int _spentMinutes;

    // Constructor
    public StudySession(string topic, int plannedMinutes)
    {
        if (string.IsNullOrWhiteSpace(topic))
        {
            throw new ArgumentException("Topic cannot be empty.");
        }

        Topic = topic;
        PlannedMinutes = plannedMinutes;
        _spentMinutes = 0;
    }

    // Properties
    public string Topic { get; }

    public int SpentMinutes
    {
        get { return _spentMinutes; }
    }

    public int PlannedMinutes
    {
        get { return _plannedMinutes; }
        set
        {
            if (value < 10 || value > 120 || value < SpentMinutes)
            {
                throw new ArgumentOutOfRangeException(nameof(value));
            }

            _plannedMinutes = value;
        }
    }

    // Methods
    public bool RecordMinutes(int minutes)
    {
        if (minutes <= 0 || minutes > PlannedMinutes - SpentMinutes)
        {
            return false;
        }

        _spentMinutes += minutes;
        return true;
    }

    public int GetRemainingMinutes()
    {
        return PlannedMinutes - SpentMinutes;
    }
}
