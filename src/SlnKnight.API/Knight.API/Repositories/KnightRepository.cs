using MongoDB.Driver;
using Knight.API.Models;

namespace Knight.API.Repositories
{
    public class KnightRepository : IKnightRepository
    {
        private readonly IMongoCollection<Knights> _knights;

        public KnightRepository(IMongoDatabase database)
        {
            _knights = database.GetCollection<Knights>("knights");
        }

        public async Task<IEnumerable<Knights>> GetAll()
        {
            return await _knights.Find(knight => true).ToListAsync();
        }

        public async Task<Knights> GetById(string id)
        {
            return await _knights.Find(knight => knight._id == id).FirstOrDefaultAsync();
        }

        public async Task Create(Knights knight)
        {
            await _knights.InsertOneAsync(knight);
        }

        public async Task Update(string id, Knights knight)
        {
            await _knights.ReplaceOneAsync(k => k._id == id, knight);
        }

        public async Task Delete(string id)
        {
            await _knights.DeleteOneAsync(knight => knight._id == id);
        }
    }
}
