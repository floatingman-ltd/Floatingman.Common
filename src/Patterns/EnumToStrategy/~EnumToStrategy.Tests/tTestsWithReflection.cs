namespace EnumToStrategy.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Reflection;
    using TheClasses.Reflection;

    [TestClass]
    public class tTestsWithReflection
    {
        [TestMethod]
        public void CanAdd()
        {
            // arrange
            Assembly assembly = Assembly.LoadFrom(".\\TheClasses.dll");
            IReflectionBase tool = (IReflectionBase)assembly.CreateInstance("TheClasses.Reflection.Adder");

            // act
            int result = tool.Mathelate(9, 3);

            // assert
            Assert.AreEqual(12, result);
        }

        [TestMethod]
        public void CanDivide()
        {
            // arrange
            Assembly assembly = Assembly.LoadFrom(".\\TheClasses.dll");
            IReflectionBase tool = (IReflectionBase)assembly.CreateInstance("TheClasses.Reflection.Divider");

            // act
            int result = tool.Mathelate(9, 3);

            // assert
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void CanMultiple()
        {
            // arrange
            Assembly assembly = Assembly.LoadFrom(".\\TheClasses.dll");
            IReflectionBase tool = (IReflectionBase)assembly.CreateInstance("TheClasses.Reflection.Multiplier");

            // act
            int result = tool.Mathelate(9, 3);

            // assert
            Assert.AreEqual(27, result);
        }

        [TestMethod]
        public void CanSubtract()
        {
            // arrange
            Assembly assembly = Assembly.LoadFrom(".\\TheClasses.dll");
            IReflectionBase tool = (IReflectionBase) assembly.CreateInstance("TheClasses.Reflection.Subtracter");

            // act
            int result = tool.Mathelate(9, 3);

            // assert
            Assert.AreEqual(6, result);
        }

        [TestMethod]
        public void CanRaise()
        {
            // arrange
            Assembly assembly = Assembly.LoadFrom(".\\TheOtherClasses.dll");
            ReflectionBase tool = (ReflectionBase)assembly.CreateInstance("TheClasses.Reflection.Raiser");

            // act
            int result = tool.Mathelate(9, 3);

            // assert
            Assert.AreEqual(729, result);
        }
    }
}