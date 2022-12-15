namespace Day03RucksackReorganization;

public record struct Item(char Type)
{
    public int Priority => 1;
}