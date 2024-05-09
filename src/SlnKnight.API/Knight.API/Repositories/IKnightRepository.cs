using Knight.API.Models;

namespace Knight.API.Repositories
{
    public interface IKnightRepository
    {
        Task<IEnumerable<Knights>> GetAll();
        Task<Knights> GetById(string id);
        Task Create(Knights knight);
        Task Update(string id, Knights knight);
        Task Delete(string id);
    }
}
