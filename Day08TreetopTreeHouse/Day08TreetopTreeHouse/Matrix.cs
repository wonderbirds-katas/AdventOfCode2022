namespace Day08TreetopTreeHouse;

public class Matrix<T>
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

    /// <summary>
    /// Creates a matrix from a list of strings.
    /// Each string in the list represents a row of the matrix.
    /// Each character in the string represents a column of the matrix.
    /// </summary>
    /// <param name="list">A list of strings with different length</param>
    /// <returns>A matrix created from the input list</returns>
    /// <returns>0x0 matrix if input list is empty</returns>
    public static Matrix<int> FromList(List<string> list)
    {
        if (list.Count == 0)
        {
            return new Matrix<int>(0, 0);
        }
        int cols = list.Select(x => x.Length).Max();
        int rows = list.Count;

        Matrix<int> matrix = new Matrix<int>(rows, cols);
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                if (col < list[row].Length)
                {
                    matrix.SetValue(row, col, int.Parse(list[row][col].ToString()));
                }
            }
        }

        return matrix;
    }
}
