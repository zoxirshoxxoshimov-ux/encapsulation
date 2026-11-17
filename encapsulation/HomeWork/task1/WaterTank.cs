using System;

namespace HomeWork;

public class WaterTank
{
    // Fields
    private int _capacity;
    private int _water;

    // Constructor
    public WaterTank(int capacity, int initialWater)
    {
        if (capacity > 0 && initialWater >= 0 && initialWater <= capacity)
        {
            _capacity = capacity;
            _water = initialWater;
        }
    }

    // Properties
    public int Capacity
    {
        get { return _capacity; }
    }

    public int Water
    {
        get { return _water; }
    }

    // Methods
    public bool Fill(int amount)
    {
        if (amount > 0 && amount <= Capacity - Water)
        {
            _water += amount;
            return true;
        }

        return false;
    }

    public bool Use(int amount)
    {
        if (amount > 0 && amount <= Water)
        {
            _water -= amount;
            return true;
        }

        return false;
    }

    public int GetFreeCapacity()
    {
        return Capacity - Water;
    }
}
