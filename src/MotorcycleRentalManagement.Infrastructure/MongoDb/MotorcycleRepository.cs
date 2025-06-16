using MongoDB.Driver;
using MotorcycleRentalManagement.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MotorcycleRentalManagement.Infrastructure.MongoDb
{
    public class MotorcycleRepository
    {
        private readonly IMongoCollection<Motorcycle> _motorcycles;

        public MotorcycleRepository(IMongoDatabase database)
        {
            _motorcycles = database.GetCollection<Motorcycle>("Motorcycles");
        }

        public async Task AddMotorcycle(Motorcycle motorcycle)
        {
            await _motorcycles.InsertOneAsync(motorcycle);
        }

        public async Task<List<Motorcycle>> GetMotorcycles()
        {
            return await _motorcycles.Find(m => true).ToListAsync();
        }

        public async Task<Motorcycle> GetMotorcycleById(string id)
        {
            return await _motorcycles.Find<Motorcycle>(m => m.Id == id).FirstOrDefaultAsync();
        }

        public async Task UpdateMotorcycle(Motorcycle motorcycle)
        {
            await _motorcycles.ReplaceOneAsync(m => m.Id == motorcycle.Id, motorcycle);
        }

        public async Task DeleteMotorcycle(string id)
        {
            await _motorcycles.DeleteOneAsync(m => m.Id == id);
        }
    }
}