using BossaBox.VUTTR.Domain.ValueObjects;
using BossaBox.VUTTR.Shared.Entities;

namespace BossaBox.VUTTR.Domain.Entities
{
    public class Tool : Entity
    {
        private readonly IList<Tag> _tags;

        public Tool(Title title, Link link, Description description)
        {
            Title = title;
            Link = link;
            Description = description;
            _tags = new List<Tag>();

            AddNotifications(Title, Link, Description);
        }

        public Title Title { get; set; }
        public Link Link { get; set; }
        public Description Description { get; set; }
        public IReadOnlyCollection<Tag> Tags { get { return _tags.ToArray(); } }

        public void AddTag(string tagName)
        {
            var tag = new Tag(tagName);
            
            if (tag.Valid)
                _tags.Add(tag);
        }
    }
}
