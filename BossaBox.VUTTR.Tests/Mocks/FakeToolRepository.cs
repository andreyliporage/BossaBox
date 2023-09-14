using BossaBox.VUTTR.Domain.Entities;
using BossaBox.VUTTR.Domain.Repositories;
using BossaBox.VUTTR.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BossaBox.VUTTR.Tests.Mocks
{
    public class FakeToolRepository : IToolRepository
    {
        private readonly IList<Tool> _tools;

        public FakeToolRepository()
        {
            var toolWithTags = new Tool(new Title("json-server"), new Link("https://github.com/typicode/json-server"), new Description("Fake REST API based on a json schema. Useful for mocking and creating APIs for front-end devs to consume in coding challenges."));
            toolWithTags.AddTag("web");
            toolWithTags.AddTag("framework");
            toolWithTags.AddTag("node");
            toolWithTags.AddTag("http2");

            _tools = new List<Tool>
            {
                toolWithTags,
                new Tool(new Title("Notion"), new Link("https://www.fastify.io/"), new Description("All in one tool to organize teams and ideas. Write, plan, collaborate, and get organized.")),
                new Tool(new Title("fastify"), new Link("https://github.com/typicode/json-server"), new Description("Extremely fast and simple, low-overhead web framework for NodeJS. Supports HTTP2."))
            };
        }

        public void Delete(Guid id)
        {}

        public IList<Tool> Get()
        {
            return _tools;
        }

        public IList<Tool> Get(string tag)
        {
            return _tools.Where(t => t.Tags.All(x => x.Name == tag)).ToList();
        }

        public void Post(Tool tool)
        {}
    }
}
