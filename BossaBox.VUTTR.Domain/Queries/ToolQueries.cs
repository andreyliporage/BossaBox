using BossaBox.VUTTR.Domain.Entities;

namespace BossaBox.VUTTR.Domain.Queries
{
    public static class ToolQueries
    {
        public static Func<Tool, bool> Get(string tagName)
        {
            return tool =>
            {
                return tool.Tags.All(tag => tag.Name == tagName);
            };
        }
    }
}
