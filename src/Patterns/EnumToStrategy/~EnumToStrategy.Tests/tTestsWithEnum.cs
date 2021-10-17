namespace EnumToStrategy.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TheClasses;
    using TheClasses.Enum;

    [TestClass]
    public class tTestsWithEnum
    {
        [TestMethod]
        public void CanAdd()
        {
            // arrange
            EnumSwitch tool = new EnumSwitch();

            // act
            int result = tool.Mathelate(Activity.Add, 9, 3);

            // assert
            Assert.AreEqual(12, result);
        }

        [TestMethod]
        public void CanDivide()
        {
            // arrange
            EnumSwitch tool = new EnumSwitch();

            // act
            int result = tool.Mathelate(Activity.Divide, 9, 3);

            // assert
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void CanMultiple()
        {
            // arrange
            EnumSwitch tool = new EnumSwitch();

            // act
            int result = tool.Mathelate(Activity.Multiply, 9, 3);

            // assert
            Assert.AreEqual(27, result);
        }

        [TestMethod]
        public void CanSubtract()
        {
            // arrange
            EnumSwitch tool = new EnumSwitch();

            // act
            int result = tool.Mathelate(Activity.Subtract, 9, 3);

            // assert
            Assert.AreEqual(6, result);
        }

        //[TestMethod]
        //public void CanRaise()
        //{
        //    // arrange
        //    EnumSwitch tool = new EnumSwitch();

        //    // act 
        //    int result = tool.Mathelate(Activity.Raise, 9, 3);

        //    // assert 
        //    Assert.AreEqual(1, result);

        //}
    }
}