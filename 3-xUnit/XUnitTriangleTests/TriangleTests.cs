using _3_xUnit;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XUnitTriangleTests
{
    public class TrinagleTest
    {
        [Fact]
        public void TriangleInequalityEquilateralTest()
        {
            Assert.True(new Triangle().TriangleInequality(5, 5, 5));
        }

        [Fact]
        public void TriangleInequalityZeroTest()
        {
            Assert.False(new Triangle().TriangleInequality(0, 0, 0));
        }
        [Fact]
        public void TriangleInequalityExistTest()
        {
            Assert.True(new Triangle().TriangleInequality(3, 4, 5));
        }
        [Fact]
        public void TriangleInequalityNotExist()
        {
            Assert.False(new Triangle().TriangleInequality(1, 1, 10));
        }
        [Fact]
        public void TriangleInequalityIsosceles()
        {
            Assert.True(new Triangle().TriangleInequality(4, 2, 2));
        }
        [Fact]
        public void TriangleInequalityOneBadSideTest()
        {
            Assert.False(new Triangle().TriangleInequality(-3, 4, 5));
        }
        [Fact]
        public void TriangleInequalityTwoBadSidesTest()
        {
            Assert.False(new Triangle().TriangleInequality(-3, -4, 5));
        }
        [Fact]
        public void TriangleInequalityThreeBadSidesTest()
        {
            Assert.False(new Triangle().TriangleInequality(-11, -4, -5));
        }
        [Fact]
        public void TriangleInequalityDoubleValuesTest()
        {
            Assert.True(new Triangle().TriangleInequality(3.5, 4.1, 5.3));
        }
        [Fact]
        public void TriangleInequalityOneLeftZeroTest()
        {
            Assert.False(new Triangle().TriangleInequality(0, 4, 6));
        }
    }
}
