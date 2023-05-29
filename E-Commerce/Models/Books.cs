using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace E_Commerce.Models
{
	public class Books
	{
		public Books()
		{
		}
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("name")]
        public string BookName { get; set; } = null!;

        public decimal Price { get; set; }

        public string Category { get; set; } = null!; // null forgiving operator (Non-Nullable - Can not be null.)

        public string Author { get; set; } = null!;
    }
}

