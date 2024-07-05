using MultiShop.Catalog.Dtos.OfferDiscountDtos;
using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.OfferDiscountServices
{
    public class OfferDiscountService : IOfferDiscountService
    {
        private readonly IMongoCollection<OfferDiscount> _offerDiscountSliderCollection;
        private readonly IMapper _mapper;

        public OfferDiscountService(IDatabaseSettings databaseSettings, IMapper mapper)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _offerDiscountSliderCollection = database.GetCollection<OfferDiscount>(databaseSettings.OfferDiscountCollectionName);
            _mapper = mapper;
        }

        public async Task<IEnumerable<ResultOfferDiscountDto>> GetOfferDiscountsAsync()
        {
            var values = await _offerDiscountSliderCollection.Find(x => true).ToListAsync();
            return _mapper.Map<IEnumerable<ResultOfferDiscountDto>>(values);
        }

        public async Task CreateOfferDiscountAsync(CreateOfferDiscountDto createOfferDiscountDto)
        {
            var value = _mapper.Map<OfferDiscount>(createOfferDiscountDto);
            await _offerDiscountSliderCollection.InsertOneAsync(value);
        }

        public async Task UpdateOfferDiscountAsync(UpdateOfferDiscountDto updateOfferDiscountDto)
        {
            var value = _mapper.Map<OfferDiscount>(updateOfferDiscountDto);
            await _offerDiscountSliderCollection.FindOneAndReplaceAsync(x => x.Id == updateOfferDiscountDto.Id, value);
        }

        public async Task DeleteOfferDiscountAsync(string id)
        {
            await _offerDiscountSliderCollection.FindOneAndDeleteAsync(x => x.Id == id);
        }

        public async Task<ResultOfferDiscountDto> GetByIdOfferDiscountAsync(string id)
        {
            var value = await _offerDiscountSliderCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
            return _mapper.Map<ResultOfferDiscountDto>(value);
        }
    }
}
