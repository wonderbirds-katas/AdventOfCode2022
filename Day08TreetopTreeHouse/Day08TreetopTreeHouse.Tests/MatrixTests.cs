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
            var list = new List<string>() { "1234", "5678", "9012" };
            var matrix = Matrix<int>.FromList(list);
            Assert.Equal(4, matrix.Rows);
            Assert.Equal(3, matrix.Cols);
            Assert.Equal(1, matrix.GetValue(0,0));
            Assert.Equal(2, matrix.GetValue(1,0));
            Assert.Equal(8, matrix.GetValue(2,1));
            Assert.Equal(9, matrix.GetValue(3,2));
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
            var list = new List<string>() { "1234", "5678", "901" };
            Assert.Throws<ArgumentException>(() => Matrix<int>.FromList(list));
        }
    }
}
