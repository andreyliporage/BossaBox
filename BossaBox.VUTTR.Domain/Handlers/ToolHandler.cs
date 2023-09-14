using BossaBox.VUTTR.Domain.Commands;
using BossaBox.VUTTR.Domain.Entities;
using BossaBox.VUTTR.Domain.Repositories;
using BossaBox.VUTTR.Domain.ValueObjects;
using BossaBox.VUTTR.Shared.Commands;
using BossaBox.VUTTR.Shared.Handlers;
using Flunt.Notifications;

namespace BossaBox.VUTTR.Domain.Handlers
{
    public class ToolHandler : Notifiable,
        IHandler<CreateToolCommand>
    {
        private readonly IToolRepository _repository;

        public ToolHandler(IToolRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(CreateToolCommand command)
        {
            command.Validate();
            if (command.Invalid)
            {
                AddNotifications(command);
                return new CommandResult(false, "Não foi possível criar a Tool");
            }

            var title = new Title(command.Title);
            var link = new Link(command.Url);
            var description = new Description(command.Description);

            var tool = new Tool(title, link, description);

            command.Tags.ForEach(tag => tool.AddTag(tag));

            AddNotifications(title, link, description, tool);

            if (Invalid)
                return new CommandResult(false, "Não foi possível criar a Tool", Notifications);

            _repository.Post(tool);

            return new CommandResult(true, "Tool criada com sucesso", tool);
        }
    }
}
