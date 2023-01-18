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

    public static Matrix<int> FromList(List<string> list)
    {
        if (list.Count == 0)
        {
            throw new ArgumentException("List cannot be empty");
        }

        int length = list[0].Length;
        if (list.Any(x => x.Length != length))
        {
            throw new ArgumentException("All strings in the list must have the same length");
        }

        Matrix<int> matrix = new Matrix<int>(length, list.Count);
        for (int row = 0; row < list.Count; row++)
        {
            for (int col = 0; col < length; col++)
            {
                matrix.SetValue(col,row, int.Parse(list[row][col].ToString()));
            }
        }

        return matrix;
    }
}
