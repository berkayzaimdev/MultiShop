using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.AboutDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.AboutServices
{
    public class AboutService : IAboutService
    {
        private readonly IMongoCollection<About> _aboutCollection;
        private readonly IMapper _mapper;

        public AboutService(IDatabaseSettings databaseSettings, IMapper mapper)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _aboutCollection = database.GetCollection<About>(databaseSettings.AboutCollectionName);
            _mapper = mapper;
        }

        public async Task<IEnumerable<ResultAboutDto>> GetAboutsAsync()
        {
            var values = await _aboutCollection.Find(x => true).ToListAsync();
            return _mapper.Map<IEnumerable<ResultAboutDto>>(values);
        }

        public async Task CreateAboutAsync(CreateAboutDto createAboutDto)
        {
            var value = _mapper.Map<About>(createAboutDto);
            await _aboutCollection.InsertOneAsync(value);
        }

        public async Task UpdateAboutAsync(UpdateAboutDto updateAboutDto)
        {
            var value = _mapper.Map<About>(updateAboutDto);
            await _aboutCollection.FindOneAndReplaceAsync(x => x.Id == updateAboutDto.Id, value);
        }

        public async Task DeleteAboutAsync(string id)
        {
            await _aboutCollection.FindOneAndDeleteAsync(x => x.Id == id);
        }

        public async Task<ResultAboutDto> GetByIdAboutAsync(string id)
        {
            var value = await _aboutCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
            return _mapper.Map<ResultAboutDto>(value);
        }
    }
}
