using BossaBox.VUTTR.Domain.Entities;
using BossaBox.VUTTR.Domain.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace BossaBox.VUTTR.Tests.Entities
{
    [TestClass]
    public class ToolTests
    {
        private readonly Title _title;
        private readonly Link _link;
        private readonly Description _description;
        private readonly List<Tag> _tags;

        public ToolTests() 
        {
            _title = new Title("Notion");
            _link = new Link("https://notion.so");
            _description = new Description("All in one tool to organize teams and ideas. Write, plan, collaborate, and get organized.");
            _tags = new List<Tag>
            {
                new Tag("organization"),
                new Tag("planning"),
                new Tag("collaboration")
            };
        }

        [TestMethod]
        public void ShouldReturnErrorWhenTitleIsNotValid()
        {
            var tool = new Tool(new Title(""), _link, _description);
            Assert.IsTrue(tool.Invalid);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenLinkIsNotValid()
        {
            var tool = new Tool(_title, new Link(""), _description);
            Assert.IsTrue(tool.Invalid);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenDescriptionIsNotValid()
        {
            var tool = new Tool(_title, _link, new Description(""));
            Assert.IsTrue(tool.Invalid);
        }

        [TestMethod]
        public void ShouldNotAddTagWhenIsInvalid()
        {
            var tool = new Tool(_title, _link, _description);
            tool.AddTag("");
            Assert.AreEqual(0, tool.Tags.Count);
        }

        [TestMethod]
        public void ShouldAddTagWhenValid()
        {
            var tool = new Tool(_title, _link, _description);
            tool.AddTag("Notion");
            Assert.AreEqual(1, tool.Tags.Count);
        }
    }
}
