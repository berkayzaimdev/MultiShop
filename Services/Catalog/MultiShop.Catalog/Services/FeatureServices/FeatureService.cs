using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.FeatureDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.FeatureServices
{
    public class FeatureService : IFeatureService
    {
        private readonly IMongoCollection<Feature> _featureSliderCollection;
        private readonly IMapper _mapper;

        public FeatureService(IDatabaseSettings databaseSettings, IMapper mapper)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _featureSliderCollection = database.GetCollection<Feature>(databaseSettings.FeatureCollectionName);
            _mapper = mapper;
        }

        public async Task<IEnumerable<ResultFeatureDto>> GetFeaturesAsync()
        {
            var values = await _featureSliderCollection.Find(x => true).ToListAsync();
            return _mapper.Map<IEnumerable<ResultFeatureDto>>(values);
        }

        public async Task CreateFeatureAsync(CreateFeatureDto createFeatureDto)
        {
            var value = _mapper.Map<Feature>(createFeatureDto);
            await _featureSliderCollection.InsertOneAsync(value);
        }

        public async Task UpdateFeatureAsync(UpdateFeatureDto updateFeatureDto)
        {
            var value = _mapper.Map<Feature>(updateFeatureDto);
            await _featureSliderCollection.FindOneAndReplaceAsync(x => x.Id == updateFeatureDto.Id, value);
        }

        public async Task DeleteFeatureAsync(string id)
        {
            await _featureSliderCollection.FindOneAndDeleteAsync(x => x.Id == id);
        }

        public async Task<ResultFeatureDto> GetByIdFeatureAsync(string id)
        {
            var value = await _featureSliderCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
            return _mapper.Map<ResultFeatureDto>(value);
        }
    }
}
