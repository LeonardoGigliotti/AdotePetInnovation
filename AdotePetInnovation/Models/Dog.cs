using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace AdotePetInnovation.Models
{
    [Table("dogs")]
    [BsonIgnoreExtraElements]
    public class Dog
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("name")]
        [JsonPropertyName("Name")]
        public string Name { get; set; }

        [BsonElement("email")]
        [JsonPropertyName("Email")]
        public string Email { get; set; }

        [BsonElement("password")]
        [JsonPropertyName("Password")]
        public string Password { get; set; }

    }
}
