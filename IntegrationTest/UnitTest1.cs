

using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace IntegrationTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void SimpleTest1()
        {
            Assert.AreEqual("baby Go go", SimpleTest.ThisIsATest.OrderSomeSomeWords("Go baby, go"));
        }

        [TestMethod]
        public void SimpleTest2()
        {
            Assert.AreEqual("ABC aBc abc CBA CBA cba", SimpleTest.ThisIsATest.OrderSomeSomeWords("CBA, abc aBc ABC cba CBA."));
        }

    }
}