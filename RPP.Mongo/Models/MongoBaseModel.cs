using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using RPP.Core.Models;
using System;

namespace RPP.Mongo.Models
{
    public class MongoBaseModel : BaseModel
    {
        [BsonId]
        public ObjectId Id { get; set; }

        public MongoBaseModel()
        {
            Id = ObjectId.GenerateNewId();
        }
    }
}
