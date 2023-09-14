using BossaBox.VUTTR.Domain.Entities;
using BossaBox.VUTTR.Domain.Queries;
using BossaBox.VUTTR.Domain.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace BossaBox.VUTTR.Tests.Queries
{
    [TestClass]
    public class ToolQueriesTests
    {
        private IList<Tool> _tools = new List<Tool>();

        public ToolQueriesTests() 
        {
            for (var i = 0; i <= 10; i++)
            {
                var tool = new Tool(
                        new Title($"Aluno {i}"),
                        new Link($"https://google.com/{i}"),
                        new Description($"Description {i}"));
                tool.AddTag($"Tag {i}");

                _tools.Add(tool);
            }
        }

        [TestMethod]
        public void ShouldReturnEmptyList()
        {
            var exp = ToolQueries.Get("api");
            var tools = _tools.AsQueryable().Where(exp).ToList();

            Assert.AreEqual(0, tools.Count);
        }

        [TestMethod]
        public void ShouldReturnListSizeOne()
        {
            var exp = ToolQueries.Get("Tag 1");
            var tools = _tools.AsQueryable().Where(exp).ToList();

            Assert.AreEqual(1, tools.Count);
        }
    }
}
