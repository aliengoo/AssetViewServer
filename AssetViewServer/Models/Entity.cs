
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace AssetViewServer.Models
{
    public class Entity
    {
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Icon { get; set; }    

        public EntityClassification Classificiation { get; set; }

        public string Uri { get; set; }

        public IDictionary<string, object> Meta { get; set; }
    }
}