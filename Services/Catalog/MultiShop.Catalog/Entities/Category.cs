using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MultiShop.Catalog.Entities
{
    public class Category
    {
        [BsonId] // MongoDB için ID tanımlaması
        [BsonRepresentation(BsonType.ObjectId)] // ID için enum kullandık
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
