namespace Day03RucksackReorganization;

public readonly record struct Item(char Type)
{
    public int Priority
    {
        get
        {
            if (Type < 'a') return Type - 'A' + 27;
            return Type - 'a' + 1;
        }
    }
}
