using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace RPP.Mongo.Models
{
    public class MongoBaseModel
    {
        [BsonId]
        public ObjectId Id { get; set; }

        public MongoBaseModel()
        {
            Id = ObjectId.GenerateNewId();
        }
    }
}
