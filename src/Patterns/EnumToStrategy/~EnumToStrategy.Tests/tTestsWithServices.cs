namespace EnumToStrategy.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.ServiceModel;

    [TestClass]
    public class tTestsWithServices
    {
        [TestMethod]
        public void CanAdd()
        {
            // arrange
            WSHttpBinding binding = new WSHttpBinding(); //WsHttpS HttpSecurityMode.None);
            EndpointAddress epa = new EndpointAddress("http://localhost:9001/MathelatorService/Adder");

            MathelatorProxy tool = new MathelatorProxy(binding, epa);

            // act
            int result = tool.Mathelate(9, 3);

            // assert
            Assert.AreEqual(12, result);
        }

        [TestMethod]
        public void CanDivide()
        {
            // arrange
            WSHttpBinding binding = new WSHttpBinding(); //WsHttpS HttpSecurityMode.None);
            EndpointAddress epa = new EndpointAddress("http://localhost:9001/MathelatorService/Divider");

            MathelatorProxy tool = new MathelatorProxy(binding, epa);

            // act
            int result = tool.Mathelate(9, 3);

            // assert
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void CanMultiple()
        {
            // arrange
            WSHttpBinding binding = new WSHttpBinding(); //WsHttpS HttpSecurityMode.None);
            EndpointAddress epa = new EndpointAddress("http://localhost:9001/MathelatorService/Multiplier");

            MathelatorProxy tool = new MathelatorProxy(binding, epa);

            // act
            int result = tool.Mathelate(9, 3);

            // assert
            Assert.AreEqual(27, result);
        }

        [TestMethod]
        public void CanRaise()
        {
            // arrange
            WSHttpBinding binding = new WSHttpBinding(); //WsHttpS HttpSecurityMode.None);
            EndpointAddress epa = new EndpointAddress("http://localhost:9001/MathelatorService/Raiser");

            MathelatorProxy tool = new MathelatorProxy(binding, epa);

            // act
            int result = tool.Mathelate(9, 3);

            // assert
            Assert.AreEqual(729, result);
        }

        [TestMethod]
        public void CanSubtract()
        {
            // arrange
            WSHttpBinding binding = new WSHttpBinding(); //WsHttpS HttpSecurityMode.None);
            EndpointAddress epa = new EndpointAddress("http://localhost:9001/MathelatorService/Subtracter");

            MathelatorProxy tool = new MathelatorProxy(binding, epa);

            // act
            int result = tool.Mathelate(9, 3);

            // assert
            Assert.AreEqual(6, result);
        }
    }
}