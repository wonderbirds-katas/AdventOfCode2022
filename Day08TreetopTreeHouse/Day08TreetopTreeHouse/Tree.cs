namespace Day08TreetopTreeHouse;

internal class Tree
{
    public int Height { get; set;  }
    public bool IsVisible { get; set;  }

    public Tree(int height, bool isVisible)
    {
        Height = height;
        IsVisible = isVisible;
    }
}