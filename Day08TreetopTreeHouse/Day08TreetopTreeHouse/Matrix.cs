namespace Day08TreetopTreeHouse;

class Matrix<T>
{
    private T[,] _matrix;

    public Matrix(int rows, int cols)
    {
        _matrix = new T[rows, cols];
    }

    public T GetValue(int row, int col)
    {
        return _matrix[row, col];
    }

    public void SetValue(int row, int col, T value)
    {
        _matrix[row, col] = value;
    }

    public int Rows
    {
        get { return _matrix.GetLength(0); }
    }

    public int Cols
    {
        get { return _matrix.GetLength(1); }
    }
}
