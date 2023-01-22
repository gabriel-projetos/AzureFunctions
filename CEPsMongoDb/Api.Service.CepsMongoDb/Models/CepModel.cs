using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Api.Service.CepsMongoDb.Interfaces;
using Newtonsoft.Json;

namespace Api.Service.CepsMongoDb.Models
{
    public class CepModel : ICep
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [JsonProperty("id")]
        public string Id { get; set; }

        [BsonElement("cep")]
        [JsonProperty("cep")]
        public string Cep { get; set; }

        [JsonProperty("logradouro")]
        [BsonElement("logradouro")]
        public string Logradouro { get; set; }

        [JsonProperty("complemento")]
        [BsonElement("complemento")]
        public string Complemento { get; set; }

        [JsonProperty("bairro")]
        [BsonElement("bairro")]
        public string Bairro { get; set; }

        [JsonProperty("localidade")]
        [BsonElement("localidade")]
        public string Localidade { get; set; }

        [JsonProperty("uf")]
        [BsonElement("uf")]
        public string Uf { get; set; }

        [JsonProperty("ibge")]
        [BsonElement("ibge")]
        public string Ibge { get; set; }

        [BsonElement("gia")]
        [JsonProperty("gia")]
        public string Gia { get; set; }

        [JsonProperty("ddd")]
        [BsonElement("ddd")]
        public string Ddd { get; set; }

        [BsonElement("siafi")]
        [JsonProperty("siafi")]
        public string Siafi { get; set; }
    }
}
