using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webstory.Entities;

namespace webstory.Repositories
{

    public class InMemTopicsRepository : TTopicsRepository
    {
        private static readonly string[] Summaries = new[]
    {
        "Helo", "VD", "Haloo"
    };
        private readonly List<Topic> topics = new()
        {
            // new Topic { id = Guid.NewGuid(), nameTopic=Summaries },

            new Topic { id = Guid.NewGuid(), nameTopic = new string[] { "Hello", "Xin chào", "Hula" } },
            new Topic { id = Guid.NewGuid(), nameTopic = new string[] { "Bye", "Tạm biệt", "baibai" } },
            new Topic { id = Guid.NewGuid(), nameTopic = new string[] { "Class", "Courses", "Lớp" } }

            // new Topic { id = Guid.NewGuid(), nameTopic = { "Class", "Courses", "Lớp" } }, - list ERROR List<string>
        };


        public async Task<IEnumerable<Topic>> GetTopicsAsync()
        {
            return await Task.FromResult(topics);
        }
        public async Task<Topic> GetTopicAsync(Guid idTopic)
        {
            var topic = topics.Where(topic => topic.id == idTopic).SingleOrDefault();
            return await Task.FromResult(topic);
        }

        public async Task CreateTopicAsync(Topic topic)
        {
            topics.Add(topic);
            await Task.CompletedTask;
        }

        public async Task UpdateTopicAsync(Topic topic)
        {
            var index = topics.FindIndex(existingTopic => existingTopic.id == topic.id);
            topics[index] = topic;
            await Task.CompletedTask;
        }

        public async Task DeleteTopicAsync(Guid idTopic)
        {
            var index = topics.FindIndex(existingTopic => existingTopic.id == idTopic);
            topics.RemoveAt(index);
            await Task.CompletedTask;
        }
    }
}