using System;
using Xunit;
using IIG.BinaryFlag;

namespace XUnitTestProject1
{
    public class UnitTestLab1
    {
        [Fact]
        public void Constructor_OutOfRange_Exception_oneAndTrue()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new MultipleBinaryFlag(1, true));
        }

        [Fact]
        public void Constructor_OutOfRange_Exception_oneAndFalse()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new MultipleBinaryFlag(1, false));
        }

        [Fact]
        public void Constructor_OutOfRange_Exception_zeroAndTrue()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new MultipleBinaryFlag(0, true));
        }

        [Fact]
        public void Constructor_OutOfRange_Exception_zeroAndFalse()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new MultipleBinaryFlag(0, false));
        }

        [Fact]
        public void Constructor_OutOfRange_Exception_MaxAndFalse()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new MultipleBinaryFlag(17179868704 + 1, false));
        }

        [Fact]
        public void Constructor_OutOfRange_Exception_MaxAndTrue()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new MultipleBinaryFlag(17179868704 + 1, true));
        }

        [Fact]
        public void Constructor_MinLimit()
        {
            MultipleBinaryFlag binaryFlag = new MultipleBinaryFlag(2, true);

            Assert.NotNull(binaryFlag);
        }

        [Fact]
        public void Constructor_OutOfRange_Exception_MinLimit_Minus1()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new MultipleBinaryFlag(2 - 1, true));
        }

        [Fact]
        public void Constructor_Max()
        {
            MultipleBinaryFlag binaryFlag = new MultipleBinaryFlag(17179868704, true);

            Assert.NotNull(binaryFlag);
        }

        [Fact]
        public void Constructor_OutOfRange_Exception_Max_Plus1()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new MultipleBinaryFlag(17179868704 + 1, false));
        }


        [Fact]
         public void Constructor_WithOnlyFirstArgument()
        {
            MultipleBinaryFlag binaryFlag = new MultipleBinaryFlag(4);

            Assert.NotNull(binaryFlag);
        }

        [Fact]
        public void Constructor_ValidArgumentsTrue()
        {
            MultipleBinaryFlag binaryFlag = new MultipleBinaryFlag(4, true);

            Assert.NotNull(binaryFlag);
        }

        [Fact]
        public void Constructor_ValidArgumentsFalse()
        {
            MultipleBinaryFlag binaryFlag = new MultipleBinaryFlag(4, false);

            Assert.NotNull(binaryFlag);
        }

        [Fact]
        public void Constructor_GetFlag_True()
        {
            MultipleBinaryFlag binaryFlag = new MultipleBinaryFlag(4, true);

            Assert.True(binaryFlag.GetFlag());
        }

        [Fact]
        public void Constructor_GetFlag_False()
        {
            MultipleBinaryFlag binaryFlag = new MultipleBinaryFlag(4, false);

            Assert.False(binaryFlag.GetFlag());
        }

        [Fact]
        public void Constructor_GetFlag_Empty()
        {
            MultipleBinaryFlag binaryFlag = new MultipleBinaryFlag(4);

            Assert.True(binaryFlag.GetFlag());
        }

        [Fact]
        public void Dispose_Null()
        {
            MultipleBinaryFlag binaryFlag = new MultipleBinaryFlag(2, true);
            
            binaryFlag.Dispose();
            
            Assert.Null(binaryFlag.GetFlag());
        }

        [Fact]
        public void Dispose_Compare()
        {
            MultipleBinaryFlag binaryFlag = new MultipleBinaryFlag(2, false);

            bool? expectingValue = binaryFlag.GetFlag();

            binaryFlag.Dispose();

            bool? valueAfterDispose = binaryFlag.GetFlag();

            Assert.NotEqual(expectingValue, valueAfterDispose);
        }

        [Fact]
        public void GetFlag_True()
        {
            MultipleBinaryFlag binaryFlag = new MultipleBinaryFlag(2, true);

            bool flag = true;

            Assert.Equal(binaryFlag.GetFlag(), flag);
        }

        [Fact]
        public void GetFlag_False()
        {
            MultipleBinaryFlag binaryFlag = new MultipleBinaryFlag(2, false);

            bool flag = false;

            Assert.Equal(binaryFlag.GetFlag(), flag);
        }

        [Fact]
        public void GetFlag_Nothing_ReturnsTrue()
        {
            MultipleBinaryFlag binaryFlag = new MultipleBinaryFlag(2);

            bool flag = true;

            Assert.Equal(binaryFlag.GetFlag(), flag);
        }

        [Fact]
        public void SetFlag()
        {
            MultipleBinaryFlag binaryFlag = new MultipleBinaryFlag(2, false);

            bool? flagPrev = binaryFlag.GetFlag();

            binaryFlag.SetFlag(0);
            binaryFlag.SetFlag(1);

            bool? flagAfter = binaryFlag.GetFlag();

            Assert.NotEqual(flagPrev, flagAfter);

        }

        [Fact]
        public void SetFlag_PrevTrue()
        {
            MultipleBinaryFlag binaryFlag = new MultipleBinaryFlag(2);

            bool? flagPrev = binaryFlag.GetFlag();

            binaryFlag.SetFlag(0);

            bool? flagAfter = binaryFlag.GetFlag();

            Assert.Equal(flagPrev, flagAfter);
        }

        [Fact]
        public void SetFlag_LastPosition_MaxValue()
        {
            MultipleBinaryFlag binaryFlag = new MultipleBinaryFlag(17179868704, false);

            bool? flagPrev = binaryFlag.GetFlag();

            binaryFlag.SetFlag(17179868703);

            bool? flagAfter = binaryFlag.GetFlag();

            Assert.Equal(flagPrev, flagAfter);

        }

        [Fact]
        public void SetFlag_OutOfMaxValue()
        {
            MultipleBinaryFlag binaryFlag = new MultipleBinaryFlag(17179868704, false);

            Assert.Throws<ArgumentOutOfRangeException>(() => binaryFlag.SetFlag(17179868704));
        }

        [Fact]
        public void ResetFlag()
        {
            MultipleBinaryFlag binaryFlag = new MultipleBinaryFlag(2, true);

            bool? flagPrev = binaryFlag.GetFlag();

            binaryFlag.ResetFlag(0);
            binaryFlag.ResetFlag(1);

            bool? flagAfter = binaryFlag.GetFlag();

            Assert.NotEqual(flagPrev, flagAfter);

        }

        [Fact]
        public void ResetFlag_PrevFalse()
        {
            MultipleBinaryFlag binaryFlag = new MultipleBinaryFlag(2, false);

            bool? flagPrev = binaryFlag.GetFlag();

            binaryFlag.ResetFlag(0);

            bool? flagAfter = binaryFlag.GetFlag();

            Assert.Equal(flagPrev, flagAfter);
        }

        [Fact]
        public void ResetFlag_MaxValue()
        {
            MultipleBinaryFlag binaryFlag = new MultipleBinaryFlag(17179868704, true);

            bool? previousValue = binaryFlag.GetFlag();

            binaryFlag.ResetFlag(17179868703);

            bool? valueAfterSetFlag = binaryFlag.GetFlag();

            Assert.NotEqual(previousValue, valueAfterSetFlag);
        }

        [Fact]
        public void ResetFlag_OutOfMaxValue()
        {
            MultipleBinaryFlag binaryFlag = new MultipleBinaryFlag(2, false);

            Assert.Throws<ArgumentOutOfRangeException>(() => binaryFlag.ResetFlag(17179868704));
        }
    }
}
