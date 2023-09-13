using BossaBox.VUTTR.Shared.ValueObjects;
using Flunt.Validations;

namespace BossaBox.VUTTR.Domain.ValueObjects
{
    public class Link : ValueObject
    {
        public Link(string url)
        {
            Url = url;

            AddNotifications(
                    new Contract()
                        .Requires()
                        .IsUrl(Url, "Tool.Link.Url", "URL invalid")
                        .IsNotNullOrEmpty(Url, "Tool.Link.Url", "Url is required")
                );
        }   

        public string Url { get; }
    }
}
