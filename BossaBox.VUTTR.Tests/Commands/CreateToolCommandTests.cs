using BossaBox.VUTTR.Domain.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace BossaBox.VUTTR.Tests.Commands
{
    [TestClass]
    public class CreateToolCommandTests
    {
        private const string _title = "json-server";
        private const string _url = "https://google.com";
        private const string _description = "Fake REST API based on a json schema. Useful for mocking and creating APIs for front-end devs to consume in coding challenges.";
        private List<string> _tags = new();

        public CreateToolCommandTests()
        {
            _tags.Add("api");
            _tags.Add("json");
            _tags.Add("schema");
        }

        [TestMethod]
        public void ShouldCommandBeInvalidWhenTitleIsNullOrEmpty()
        {
            var command = new CreateToolCommand("", _url, _description, _tags);
            command.Validate();

            Assert.IsTrue(command.Invalid);
        }

        [TestMethod]
        public void ShouldCommandBeInvalidWhenTitleLengthIsLowerThanFive()
        {
            var command = new CreateToolCommand("API", _url, _description, _tags);
            command.Validate();

            Assert.IsTrue(command.Invalid);
        }

        [TestMethod]
        public void ShouldCommandBeInvalidWhenUrlIsNullOrEmpty()
        {
            var command = new CreateToolCommand(_title, "", _description, _tags);
            command.Validate();

            Assert.IsTrue(command.Invalid);
        }

        [TestMethod]
        public void ShouldCommandBeInvalidWhenUrlIsInvalid()
        {
            var command = new CreateToolCommand(_title, "https:/www.test", _description, _tags);
            command.Validate();

            Assert.IsTrue(command.Invalid);
        }

        [TestMethod]
        public void ShouldCommandBeInvalidWhenDescriptionIsNullOrEmpty()
        {
            var command = new CreateToolCommand(_title, _url, "", _tags);
            command.Validate();

            Assert.IsTrue(command.Invalid);
        }

        [TestMethod]
        public void ShouldCommandBeValid()
        {
            var command = new CreateToolCommand(_title, _url, _description, _tags);
            command.Validate();

            Assert.IsTrue(command.Valid);
        }
    }
}
