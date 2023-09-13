using BossaBox.VUTTR.Shared.ValueObjects;
using Flunt.Validations;

namespace BossaBox.VUTTR.Domain.ValueObjects
{
    public class Title : ValueObject
    {
        public Title(string name)
        {
            Name = name;

            AddNotifications(
                 new Contract()
                    .Requires()
                    .HasMinLen(Name, 5, "Tool.Title.Name", "Name is required")
                );
        }

        public string Name { get; }
    }
}
