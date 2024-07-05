using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.FeatureSliderDtos;
using MultiShop.Catalog.Dtos.FeatureSliderDtos.Common;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.FeatureSliderServices
{
    public class FeatureSliderService : IFeatureSliderService
    {
        private readonly IMongoCollection<FeatureSlider> _featureSliderCollection;
        private readonly IMapper _mapper;

        public FeatureSliderService(IDatabaseSettings databaseSettings, IMapper mapper)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _featureSliderCollection = database.GetCollection<FeatureSlider>(databaseSettings.CategoryCollectionName);
            _mapper = mapper;
        }

        public async Task<IEnumerable<FeatureSliderDto>> GetFeatureSlidersAsync()
        {
            var values = await _featureSliderCollection.Find(x => true).ToListAsync();
            return _mapper.Map<IEnumerable<FeatureSliderDto>>(values);
        }

        public async Task CreateFeatureSliderAsync(CreateFeatureSliderDto createFeatureSliderDto)
        {
            var value = _mapper.Map<FeatureSlider>(createFeatureSliderDto);
            await _featureSliderCollection.InsertOneAsync(value);
        }

        public async Task UpdateFeatureSliderAsync(UpdateFeatureSliderDto updateFeatureSliderDto)
        {
            var value = _mapper.Map<FeatureSlider>(updateFeatureSliderDto);
            await _featureSliderCollection.FindOneAndReplaceAsync(x => x.Id == updateFeatureSliderDto.Id, value);
        }

        public async Task DeleteFeatureSliderAsync(string id)
        {
            await _featureSliderCollection.FindOneAndDeleteAsync(x => x.Id == id);
        }

        public async Task<FeatureSliderDto> GetByIdFeatureSliderAsync(string id)
        {
            var value = await _featureSliderCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
            return _mapper.Map<FeatureSliderDto>(value);
        }

        public async Task ChangeStatusAsync(string id, bool status)
        {
            var value = await _featureSliderCollection.Find(x => x.Id == id).FirstAsync();
            value.Status = status;
            await _featureSliderCollection.FindOneAndReplaceAsync(x => x.Id == value.Id, value);
        }
    }
}
