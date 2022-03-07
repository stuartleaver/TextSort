

using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace IntegrationTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void SimpleTest1()
        {
            Assert.AreEqual("baby Go go", SimpleTest.MyTest.SomeNoddyTest("Go baby, go"));
        }

        [TestMethod]
        public void SimpleTest2()
        {
            Assert.AreEqual("ABC aBc abc CBA CBA cba", SimpleTest.MyTest.SomeNoddyTest("CBA, abc aBc ABC cba CBA."));
        }

    }
}