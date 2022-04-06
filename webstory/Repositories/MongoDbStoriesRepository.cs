using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;
using webstory.Entities;

namespace  webstory.Repositories
{
    public class MongoDbStoriesRepository : SStoriesRepository
    {
        private const string databaName= "webstory" ;
        private const string CollectionName = "stories" ;

        private readonly IMongoCollection<Story> storiesCollection ;
        private readonly FilterDefinitionBuilder<Story> filterBuilder = Builders<Story>.Filter;

        public MongoDbStoriesRepository(IMongoClient mongoClient)
        {
            IMongoDatabase database = mongoClient.GetDatabase(databaName);
            storiesCollection = database.GetCollection<Story>(CollectionName);
        }

        public void CreateStory(Story story)
        {
            storiesCollection.InsertOne(story);
        }

        public void DeleteStory(Guid idStory)
        {
            var filter = filterBuilder.Eq(story => story.id, idStory);
            storiesCollection.DeleteOne(filter);
        }

        public IEnumerable<Story> GetStories()
        {
            return storiesCollection.Find(new BsonDocument()).ToList();
        }

        public Story GetStory(Guid idStory)
        {
            var filter = filterBuilder.Eq(story => story.id, idStory);
            return storiesCollection.Find(filter).SingleOrDefault();
        }

        public void UpdateStory(Story story)
        {
            var filter = filterBuilder.Eq(existingStory => existingStory.id, story.id) ;
            storiesCollection.ReplaceOne(filter, story);
        }
    }

}