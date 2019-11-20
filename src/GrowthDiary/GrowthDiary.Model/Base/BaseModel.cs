using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GrowthDiary.Model
{
    public class BaseModel
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }
    }
}
