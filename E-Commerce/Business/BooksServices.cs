using System;
using E_Commerce.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace E_Commerce.Business
{
    public class BooksServices
    {
        private readonly IMongoCollection<Books> collection;
        public BooksServices(IOptions<BooksDatabaseSettings> dbSettings) 
        {
            //Reads the server instance for running database operations. The constructor of this class is provided the MongoDB connection string
            var client = new MongoClient(dbSettings.Value.ConnectionString);
            var db = client.GetDatabase(dbSettings.Value.DatabaseName);
            collection = db.GetCollection<Books>(dbSettings.Value.BooksCollectionName);

        }
        public async Task<List<Books>> GetAsync() =>
            await collection.Find(_ => true).ToListAsync();

        public async Task<Books?> GetAsync(string id) =>
            await collection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Books newBooks) =>
            await collection.InsertOneAsync(newBooks);

        public async Task UpdateAsync(string id, Books updatedBooks) =>
            await collection.ReplaceOneAsync(x => x.Id == id, updatedBooks);

        public async Task RemoveAsync(string id) =>
            await collection.DeleteOneAsync(x => x.Id == id);

    }
}

