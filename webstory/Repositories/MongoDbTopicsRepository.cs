using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using webstory.Entities;

namespace webstory.Repositories
{
    public class MongoDbTopicsRepository : TTopicsRepository
    {
        private const string databaseName = "webstory";
        private const string collectionName = "topics" ;
        private readonly IMongoCollection<Topic> topicsCollection;

        private readonly FilterDefinitionBuilder<Topic> filterBuilder = Builders<Topic>.Filter;
        public MongoDbTopicsRepository(IMongoClient mongoClient)
        {
            IMongoDatabase database = mongoClient.GetDatabase(databaseName);
            topicsCollection = database.GetCollection<Topic>(collectionName);
        }

        public async Task CreateTopicAsync(Topic topic)
        {
            await topicsCollection.InsertOneAsync(topic);
        }

        public async Task DeleteTopicAsync(Guid idTopic)
        {
            var filter = filterBuilder.Eq(topic => topic.id, idTopic);
            await topicsCollection.DeleteOneAsync(filter);
        }

        public async Task<Topic> GetTopicAsync(Guid idTopic)
        {
            var filter = filterBuilder.Eq(topic => topic.id, idTopic);
            return await topicsCollection.Find(filter).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<Topic>> GetTopicsAsync()
        {
            return await topicsCollection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task UpdateTopicAsync(Topic topic)
        {
            var filter = filterBuilder.Eq(existingTopic => existingTopic.id ,topic.id);
            await topicsCollection.ReplaceOneAsync(filter, topic);
        }
    }
}