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

        [BsonElement("idade")]
        [JsonPropertyName("Idade")]
        public string Idade { get; set; }

        [BsonElement("raca")]
        [JsonPropertyName("Raca")]
        public string Raca { get; set; }

        [BsonElement("porte")]
        [JsonPropertyName("Porte")]
        public string Porte { get; set; }

        [BsonElement("celular")]
        [JsonPropertyName("Celular")]
        public string Celular { get; set; }

    }
}
