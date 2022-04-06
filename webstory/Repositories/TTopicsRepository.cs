using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using webstory.Entities;

namespace webstory.Repositories
{
    public interface TTopicsRepository
    {
        Task<Topic> GetTopicAsync(Guid idTopic);
        Task<IEnumerable<Topic>> GetTopicsAsync();

        Task CreateTopicAsync(Topic topic);
        Task UpdateTopicAsync(Topic topic);

        Task DeleteTopicAsync(Guid idTopic);
    }
}