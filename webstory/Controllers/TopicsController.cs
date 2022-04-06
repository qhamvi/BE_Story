using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using webstory.Dtos;
using webstory.Entities;
using webstory.Repositories;

namespace webstory.Controllers
{
    [ApiController]
    [Route("topics")]
    public class TopicsController : ControllerBase
    {
        private readonly TTopicsRepository Topic_Repository;
        public TopicsController(TTopicsRepository TRepository)
        
        {
            this.Topic_Repository = TRepository ;
        }
        
        //GET /topics
        [HttpGet]
        public async Task<IEnumerable<TopicDto>> GetTopicsAsync()
        {
            var topics = (await Topic_Repository.GetTopicsAsync())
                     .Select( topic => topic.AsTopicDto());
            return topics ;
        }
        //GET /topics/{id}
        [HttpGet("{idTopic}")]
        public async Task<ActionResult<TopicDto>> GetTopicAsync(Guid idTopic)
        {
            var topic = await Topic_Repository.GetTopicAsync(idTopic);
            if(topic is null)
            {
                return NotFound();
            }
            return topic.AsTopicDto();
        }
        //POST /topics
        [HttpPost]
        public async Task<ActionResult<TopicDto>> CreateTopicAsync(CreateTopicDto topicDto)
        {
            Topic topic = new(){
                id = Guid.NewGuid(),
                nameTopic = topicDto.nameTopic
            };
            await Topic_Repository.CreateTopicAsync(topic);
            return CreatedAtAction(nameof(GetTopicAsync), new {idTopic = topic.id}, topic.AsTopicDto());
        }
        //PUT /topics
        [HttpPut("{idTopic}")]
        public async Task<ActionResult> UpdateTopicAsync(Guid idTopic, UpdateTopicDto topicDto)
        {
            var existingTopic = await Topic_Repository.GetTopicAsync(idTopic);
            if (existingTopic is null)
            {
                return NotFound();
            }
            Topic updateTopic = existingTopic with
            {
                nameTopic = topicDto.nameTopic
            };
            await Topic_Repository.UpdateTopicAsync(updateTopic);
            return NoContent();
        }
        //DELETE /topics/{idTopic}
        [HttpDelete("{idTopic}")]
        public async Task<ActionResult> DeleteTopic (Guid idTopic)
        {
            var existingTopic = await Topic_Repository.GetTopicAsync(idTopic);
            if( existingTopic is null)
            {
                return NotFound();
            }
            await Topic_Repository.DeleteTopicAsync(idTopic);
            return NoContent();
        }

    }
}