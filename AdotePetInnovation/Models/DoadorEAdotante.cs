using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace AdotePetInnovation.Models
{
    [Table("DoadoreEAdotantes")]
    [BsonIgnoreExtraElements]
    public class DoadorEAdotante
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("name")]
        [JsonPropertyName("Name")]
        public string? Name { get; set; }

        [BsonElement("email")]
        [JsonPropertyName("Email")]
        public string? Email { get; set; }

        [BsonElement("rg")]
        [JsonPropertyName("Rg")]
        public string? Rg { get; set; }

        [BsonElement("cpf")]
        [JsonPropertyName("Cpf")]
        public string? Cpf { get; set; }

        [BsonElement("celular")]
        [JsonPropertyName("Celular")]
        public string? Celular { get; set; }

        [BsonElement("cidade")]
        [JsonPropertyName("Cidade")]
        public string? Cidade { get; set; }

        [BsonElement("estado")]
        [JsonPropertyName("Estado")]
        public string? Estado { get; set; }

        [BsonElement("cep")]
        [JsonPropertyName("Cep")]
        public string? Cep { get; set; }
    }
}
