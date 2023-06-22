using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
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
        public string? Id { get; set; }

        [BsonElement("name")]
        [JsonPropertyName("Name")]
        public string? Name { get; set; }

        [BsonElement("idade")]
        [JsonPropertyName("Idade")]
        public string? Idade { get; set; }

        [BsonElement("raca")]
        [JsonPropertyName("Raca")]
        public string? Raca { get; set; }

        [BsonElement("porte")]
        [JsonPropertyName("Porte")]
        public string? Porte { get; set; }

        [BsonElement("foto")]
        [JsonPropertyName("Foto")]
        public string? Foto { get; set; }

        [BsonElement("foto1")]
        [JsonPropertyName("Foto1")]
        public string? Foto1 { get; set; }

        [BsonElement("foto2")]
        [JsonPropertyName("Foto2")]
        public string? Foto2 { get; set; }

        [BsonElement("foto3")]
        [JsonPropertyName("Foto3")]
        public string? Foto3 { get; set; }

        [BsonElement("cidade")]
        [JsonPropertyName("Cidade")]
        public string? Cidade { get; set; }

        [BsonElement("estado")]
        [JsonPropertyName("Estado")]
        public string? Estado { get; set; }

        [BsonElement("celular")]
        [JsonPropertyName("Celular")]
        public string? Celular { get; set; }
    }
}
