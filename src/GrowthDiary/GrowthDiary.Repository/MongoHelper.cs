using GrowthDiary.Model;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrowthDiary.Repository
{
    public class MongoHelper
    {
        private static IMongoDatabase database;
        public MongoHelper(IConfiguration configuration)
        {
            MongoClient mongoClient = new MongoClient(configuration["DB:ConnectionString"]);
            database = mongoClient.GetDatabase(configuration.GetSection("DB:Name").Value);
        }

        public static T Find<T>(FilterDefinition<T> filter = null, string collectionName = null)
        {
            return FindList<T>(filter,collectionName).FirstOrDefault();
        }
        public static List<T> FindList<T>(FilterDefinition<T> filter = null, string collectionName = null)
        {
            collectionName ??= typeof(T).Name;
            filter ??= new BsonDocument();
            var collection = database.GetCollection<T>(collectionName);
            return collection.Find(filter).ToList();
        }

        public static async Task<T> FindAsync<T>(FilterDefinition<T> filter = null, string collectionName = null)
        {
            var result = await FindListAsync<T>(filter,collectionName);
            return result.FirstOrDefault();
        }

        public static async Task<List<T>> FindListAsync<T>(FilterDefinition<T> filter = null, string collectionName = null)
        {
            collectionName ??= typeof(T).Name;
            filter ??= new BsonDocument();
            var collection = database.GetCollection<T>(collectionName);
            var result = await collection.FindAsync(filter);
            return result.ToList();
        }


        public static void InsertOne<T>(T model, string collectionName = null)
        {
            collectionName ??= typeof(T).Name;
            var collection = database.GetCollection<T>(collectionName);
            collection.InsertOne(model);
        }

        public static async Task InsertOneAsync<T>(T model, string collectionName = null)
        {
            collectionName ??= typeof(T).Name;
            var collection = database.GetCollection<T>(collectionName);
            await collection.InsertOneAsync(model);
        }

        public static int UpdateOne<T>(T model, string collectionName = null, params string[] fields) where T : BaseModel
        {
            var list = new List<UpdateDefinition<T>>();
            bool updateAll = false;
            if (null == fields || fields.Length == 0) updateAll = true;

            foreach (var item in model.GetType().GetProperties())
            {
                if (item.Name.ToLower().Equals("_id")) continue;
                if ((updateAll || fields.Contains(item.Name)))
                {
                    list.Add(Builders<T>.Update.Set(item.Name, item.GetValue(model)));
                }
            }

            var updateDefinition = Builders<T>.Update.Combine(list);

            return UpdateOne(model._id, updateDefinition, collectionName);
        }

        public static int UpdateOne<T>(string id, UpdateDefinition<T> updateDefinition, string collectionName = null) where T : BaseModel
        {
            collectionName ??= typeof(T).Name;
            var collection = database.GetCollection<T>(collectionName);

            var result = collection.UpdateOne(m => m._id == id, updateDefinition);

            if (result.ModifiedCount == 1)
            {
                return 0;
            }
            else
            {
                return -1;
            }
        }

        public static async Task<int> UpdateOneAsync<T>(T model, string collectionName = null, params string[] fields) where T : BaseModel
        {
            collectionName ??= typeof(T).Name;
            var collection = database.GetCollection<T>(collectionName);
            var list = new List<UpdateDefinition<T>>();
            bool updateAll = false;
            if (null == fields || fields.Length == 0) updateAll = true;

            foreach (var item in model.GetType().GetProperties())
            {
                if (item.Name.ToLower().Equals("_id")) continue;
                if (updateAll || fields.Contains(item.Name))
                {
                    list.Add(Builders<T>.Update.Set(item.Name, item.GetValue(model)));
                }
            }

            var updatefilter = Builders<T>.Update.Combine(list);
            var result = await collection.UpdateOneAsync(m => m._id == model._id, updatefilter);

            if (result.ModifiedCount == 1)
            {
                return 0;
            }
            else
            {
                return -1;
            }
        }

        public static int ReplaceOne<T>(T model, string collectionName = null) where T : BaseModel
        {
            collectionName ??= typeof(T).Name;
            var collection = database.GetCollection<T>(collectionName);
            var result = collection.ReplaceOne(m => m._id == model._id, model);

            if (result.ModifiedCount == 1)
            {
                return 0;
            }
            else
            {
                return -1;
            }
        }

        public static async Task<int> ReplaceOneAsync<T>(T model, string collectionName = null) where T : BaseModel
        {
            collectionName ??= typeof(T).Name;
            var collection = database.GetCollection<T>(collectionName);
            var result = await collection.ReplaceOneAsync(m => m._id == model._id, model);

            if (result.ModifiedCount == 1)
            {
                return 0;
            }
            else
            {
                return -1;
            }
        }
    }
}
