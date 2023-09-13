using BossaBox.VUTTR.Shared.ValueObjects;
using Flunt.Validations;

namespace BossaBox.VUTTR.Domain.ValueObjects
{
    public class Description : ValueObject
    {
        public Description(string text)
        {
            Text = text;

            AddNotifications(
                    new Contract()
                        .Requires()
                        .IsNotNullOrEmpty(Text, "Tool.Description.Text", "Decription is required")
                        .HasMinLen(Text, 10, "Tool.Description.Text", "Description too short. 10 caracteres at least")
                );
        }

        public string Text { get; }
    }
}
