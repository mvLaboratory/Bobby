using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NewsBot;
using NewsBot.Commands;

namespace NewsTests
{
    [TestClass]
    public class BotCommandTests
    {
        [TestMethod]
        public void EmptyName()
        {
            var expected = new Help();
            var result = _commandFactory.parseCommand("");

            Assert.IsTrue(expected.Equals(result));
        }

        [TestMethod]
        public void HelpCommand()
        {
            var expected = new Help();
            var result = _commandFactory.parseCommand("help");

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void GreetingsCommand()
        {
            var expected = new Greetings();
            var result = _commandFactory.parseCommand("greetings");

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void NotGreetings()
        {
            var expected = new Help();
            var result = _commandFactory.parseCommand("greetings");

            Assert.AreNotEqual(expected, result);
        }

        [TestMethod]
        public void GreetingsCommandMissspeled()
        {
            var expected = new Help();
            var result = _commandFactory.parseCommand("gretings");

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void GreetingsCommandDiffCases()
        {
            var expected = new Greetings();
            var result = _commandFactory.parseCommand("GreEtInGs");

            Assert.AreEqual(expected, result);
        }

        private ICommandFactory _commandFactory = new CommandFactory();
    }
}
