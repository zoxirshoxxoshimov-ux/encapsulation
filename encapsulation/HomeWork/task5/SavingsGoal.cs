using System;

namespace HomeWork;

public class SavingsGoal
{
    // Fields
    private decimal _target;
    private decimal _saved;

    // Constructor
    public SavingsGoal(string name, decimal target, decimal initialSaved)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Name cannot be empty.");
        }

        if (target <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(target));
        }

        if (initialSaved < 0 || initialSaved > target)
        {
            throw new ArgumentOutOfRangeException(nameof(initialSaved));
        }

        Name = name;
        _target = target;
        _saved = initialSaved;
    }

    // Properties
    public string Name { get; }

    public decimal Target
    {
        get { return _target; }
    }

    public decimal Saved
    {
        get { return _saved; }
    }

    // Methods
    public bool TryAdd(decimal amount)
    {
        if (amount <= 0 || amount > Target - Saved)
        {
            return false;
        }

        _saved += amount;
        return true;
    }

    public bool TryWithdraw(decimal amount)
    {
        if (amount <= 0 || amount > Saved)
        {
            return false;
        }

        _saved -= amount;
        return true;
    }

    public decimal GetRemaining()
    {
        return Target - Saved;
    }

    public bool IsReached()
    {
        return Saved == Target;
    }
}
