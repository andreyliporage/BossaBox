using BossaBox.VUTTR.Shared.Commands;

namespace BossaBox.VUTTR.Shared.Handlers
{
    public interface IHandler<T> where T : ICommand
    {
        ICommandResult Handle(T command);
    }
}
