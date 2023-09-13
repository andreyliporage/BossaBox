using BossaBox.VUTTR.Domain.Entities;

namespace BossaBox.VUTTR.Domain.Repositories
{
    public interface IToolRepository
    {
        IList<Tool> Get();
        IList<Tool> Get(string tag);
        void Post(Tool tool);
        void Delete(Guid id);
    }
}
