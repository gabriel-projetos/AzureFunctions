using Api.Service.CepsMongoDb.Models;
using Microsoft.Win32;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;

namespace Api.Service.CepsMongoDb.Service
{
    //https://levelup.gitconnected.com/azure-functions-and-mongodb-f0abffdd574b
    //https://github.com/iamNoah1/bookreading-api
    public class CepDbContext
    {
        //FindAll Retorna todos os registros
        //SetSortOrder    Consulta em ordem de classificação
        //Insert  Adiciona um novo registro
        //FindOneById Encontra um registro com base no ObjectId
        //Save Atualiza o registro
        //Remove Remove um registro
        
        virtual public async Task AddAddressCep(CepModel cepModel)
        {
            await Collection().InsertOneAsync(cepModel);
        }

        public async Task<List<CepModel>> GetAllCepReadingEntries()
        {
            return await Collection().Find(_ => true).ToListAsync();
        }

        public async Task<CepModel> GetAddressCep(string cep)
        {
            return await Collection().Find(x => x.Cep == cep).FirstOrDefaultAsync();
        }

        public async Task DeleteCep(string id)
        {
            await Collection().DeleteOneAsync(cepReaning => cepReaning.Id == id);
        }

        public async Task UpdateCep(CepModel cepModel)
        {
            await Collection().ReplaceOneAsync(x => x.Id == cepModel.Id, cepModel);
        }

        private IMongoCollection<CepModel> Collection()
        {
            string connectionString = Environment.GetEnvironmentVariable("MONGO_DB_CONNECTION_STRING");
            MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl(connectionString));
            settings.SslSettings = new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };
            var mongoClient = new MongoClient(settings);

            var db = mongoClient.GetDatabase("ClusterDev");
            return db.GetCollection<CepModel>("cepreadings");
        }
    }
}
