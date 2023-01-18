using Xunit;
using System.Linq;
using System.Collections.Generic;

namespace Day08TreetopTreeHouse.Tests
{
    public class MatrixTests
    {
        [Fact]
        public void Test_Matrix_Initialization()
        {
            var matrix = new Matrix<int>(2, 3);
            Assert.Equal(2, matrix.Rows);
            Assert.Equal(3, matrix.Cols);
        }

        [Fact]
        public void Test_Matrix_FromList_Method()
        {
            var list = new List<string>() { "123", "456", "789" };
            var matrix = Matrix<int>.FromList(list);
            Assert.Equal(1, matrix.GetValue(0,0));
            Assert.Equal(5, matrix.GetValue(1,1));
            Assert.Equal(9, matrix.GetValue(2,2));
        }

        [Fact]
        public void Test_Matrix_FromList_Method_Cols_Rows_Interpreted_Correctly()
        {
            var list = new List<string>() { "123", "456", "78" };
            var matrix = Matrix<int>.FromList(list);
            Assert.Equal(3, matrix.Rows);
            Assert.Equal(3, matrix.Cols);
        }

        [Fact]
        public void Test_Matrix_FromList_Method_EmptyList()
        {
            var list = new List<string>();
            var matrix = Matrix<int>.FromList(list);
            Assert.Equal(0, matrix.Rows);
            Assert.Equal(0, matrix.Cols);
        }

        [Fact]
        public void Test_Matrix_FromList_Method_Different_String_Length()
        {
            var list = new List<string>() { "123", "456", "78" };
            var matrix = Matrix<int>.FromList(list);
            Assert.Equal(3, matrix.Rows);
            Assert.Equal(3, matrix.Cols);
            Assert.Equal(1, matrix.GetValue(0, 0));
            Assert.Equal(2, matrix.GetValue(0, 1));
            Assert.Equal(3, matrix.GetValue(0, 2));
            Assert.Equal(4, matrix.GetValue(1, 0));
            Assert.Equal(5, matrix.GetValue(1, 1));
            Assert.Equal(6, matrix.GetValue(1, 2));
            Assert.Equal(7, matrix.GetValue(2, 0));
            Assert.Equal(8, matrix.GetValue(2, 1));
        }
    }
}
