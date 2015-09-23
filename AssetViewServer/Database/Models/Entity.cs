namespace AssetViewServer.Database.Models
{
	using System.Collections.Generic;

	using MongoDB.Bson.Serialization.Attributes;
	using MongoDB.Bson.Serialization.IdGenerators;

	public class Entity : IDocument
    {
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        public string Id { get; set; }

		[BsonRequired]
		public string Name { get; set; }

		[BsonRequired]
		public string Description { get; set; }

        public string Icon { get; set; }

		public List<string> Labels { get; set; }

		[BsonRequired]
		public EntityClassification Classificiation { get; set; }

        public string Uri { get; set; }

        public IDictionary<string, object> Meta { get; set; }
    }
}