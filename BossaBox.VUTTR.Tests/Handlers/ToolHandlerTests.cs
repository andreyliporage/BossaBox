using BossaBox.VUTTR.Domain.Commands;
using BossaBox.VUTTR.Domain.Handlers;
using BossaBox.VUTTR.Tests.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace BossaBox.VUTTR.Tests.Handlers
{
    [TestClass]
    public class ToolHandlerTests
    {
        [TestMethod]
        public void ShouldReturnErrorWhenTitleIsInvalid()
        {
            var handler = new ToolHandler(new FakeToolRepository());
            var command = new CreateToolCommand("js", "https://github.com/typicode/json-server", "Fake REST API based on a json schema. Useful for mocking and creating APIs for front-end devs to consume in coding challenges.", new List<string> { "web", "framework" });

            handler.Handle(command);
            Assert.IsTrue(handler.Invalid);
        }

        [TestMethod]
        public void ShouldReturnSuccess()
        {
            var handler = new ToolHandler(new FakeToolRepository());
            var command = new CreateToolCommand("json-server", "https://github.com/typicode/json-server", "Fake REST API based on a json schema. Useful for mocking and creating APIs for front-end devs to consume in coding challenges.", new List<string> { "web", "framework" });

            handler.Handle(command);
            Assert.IsTrue(handler.Valid);
        }
    }
}
