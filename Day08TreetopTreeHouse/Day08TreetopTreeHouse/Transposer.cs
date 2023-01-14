namespace Day08TreetopTreeHouse;

public static class Transposer
{
    /// <summary>
    /// Transpose matrix - rotate it by 90 degrees.
    /// </summary>
    /// <seealso href="https://stackoverflow.com/questions/5039617/turning-an-ienumerableienumerablet-90-degrees">
    /// Implementation of the algorithm presented by Jeff Mercado
    /// </seealso>
    public static IEnumerable<IEnumerable<char>> Transpose(IEnumerable<IEnumerable<char>> matrix)
    {
        var enumerators = matrix.Select(row => row.GetEnumerator()).ToArray();
        if (!enumerators.Any()) yield break;
        
        try
        {
            while (enumerators.All(x => x.MoveNext()))
            {
                var transposedRow = enumerators.Select(x => x.Current);
                
                // ToArray is required to ensure that the elements are not null
                // after the enumerator is disposed
                yield return transposedRow.ToArray();
            }
        }
        finally
        {
            foreach (var enumerator in enumerators)
            {
                enumerator.Dispose();
            }
        }
    }
}