using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.SpecialOfferDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.SpecialOfferServices
{
    public class SpecialOfferService : ISpecialOfferService
    {
        private readonly IMongoCollection<SpecialOffer> _featureSliderCollection;
        private readonly IMapper _mapper;

        public SpecialOfferService(IDatabaseSettings databaseSettings, IMapper mapper)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _featureSliderCollection = database.GetCollection<SpecialOffer>(databaseSettings.SpecialOfferCollectionName);
            _mapper = mapper;
        }

        public async Task<IEnumerable<SpecialOfferDto>> GetSpecialOffersAsync()
        {
            var values = await _featureSliderCollection.Find(x => true).ToListAsync();
            return _mapper.Map<IEnumerable<SpecialOfferDto>>(values);
        }

        public async Task CreateSpecialOfferAsync(CreateSpecialOfferDto createSpecialOfferDto)
        {
            var value = _mapper.Map<SpecialOffer>(createSpecialOfferDto);
            await _featureSliderCollection.InsertOneAsync(value);
        }

        public async Task UpdateSpecialOfferAsync(UpdateSpecialOfferDto updateSpecialOfferDto)
        {
            var value = _mapper.Map<SpecialOffer>(updateSpecialOfferDto);
            await _featureSliderCollection.FindOneAndReplaceAsync(x => x.Id == updateSpecialOfferDto.Id, value);
        }

        public async Task DeleteSpecialOfferAsync(string id)
        {
            await _featureSliderCollection.FindOneAndDeleteAsync(x => x.Id == id);
        }

        public async Task<SpecialOfferDto> GetByIdSpecialOfferAsync(string id)
        {
            var value = await _featureSliderCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
            return _mapper.Map<SpecialOfferDto>(value);
        }
    }
}
