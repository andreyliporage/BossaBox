using BossaBox.VUTTR.Shared.ValueObjects;
using Flunt.Validations;

namespace BossaBox.VUTTR.Domain.ValueObjects
{
    public class Tag : ValueObject
    {
        public Tag(string name)
        {
            Name = name;

            AddNotifications(
                    new Contract()
                        .Requires()
                        .HasMinLen(Name, 3, "Tool.Tag.Name", "Tag should have 3 caracteres at least")
                );
        }

        public string Name { get; }
    }
}
