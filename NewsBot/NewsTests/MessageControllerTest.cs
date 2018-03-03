using System;
using FakeItEasy;
using Microsoft.Bot.Connector;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NewsTests
{
    [TestClass]
    public class MessageControllerTest
    {
        [TestMethod]
        public void BasicTest()
        {
            var activity = A.Fake<Activity>();
                //Isolate.Fake.Instance<Activity>();
            var a = 1;
        }
    }
}
