using BossaBox.VUTTR.Shared.Commands;
using Flunt.Notifications;
using Flunt.Validations;

namespace BossaBox.VUTTR.Domain.Commands
{
    public class CreateToolCommand : Notifiable, ICommand
    {
        public CreateToolCommand(string title, string url, string description, List<string> tags)
        {
            Title = title;
            Url = url;
            Description = description;
            Tags = tags;
        }

        public string Title { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public List<string> Tags { get; set; }

        public void Validate()
        {
            AddNotifications(
                    new Contract()
                        .Requires()
                        .HasMinLen(Title, 5, "Title", "Title is required")
                        .IsUrl(Url, "Url", "URL invalid")
                        .IsNotNullOrEmpty(Url, "Url", "Url is required")
                        .IsNotNullOrEmpty(Description, "Description", "Decription is required")
                        .HasMinLen(Description, 10, "Description", "Description too short. 10 caracteres at least")
                );
        }
    }
}
