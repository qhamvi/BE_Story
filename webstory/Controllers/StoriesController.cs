using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using webstory.Dtos;
using webstory.Entities;
using webstory.Repositories;

namespace webstory.Controllers 
{
    [ApiController]
    [Route("stories")]
    public class StoriesController : ControllerBase
    {
        private readonly SStoriesRepository Story_Repository ;
        public StoriesController(SStoriesRepository repository)
        {
            this.Story_Repository = repository;
        }

        //GET /stories 
        [HttpGet]
        public IEnumerable<StoryDto> GetStories()
        {
            var stories = Story_Repository.GetStories().Select(story => story.AsStoryDto());
            return stories ;
        }

        //GET /stories 
        [HttpGet("{idStory}")]
        public ActionResult<StoryDto> GetStory(Guid idStory)
        {
            var story = Story_Repository.GetStory(idStory) ;
            if (story is null)
            {
                return NotFound();
            }
            return story.AsStoryDto() ;
        }

        //POST /stories 
        [HttpPost]
        public ActionResult<StoryDto> CreateStoryDto(CreateStoryDto storyDto)
        {
            Story story = new Story{
                id = Guid.NewGuid(),
                titleStory = storyDto.titleStory,
                author = storyDto.author,
                collector = storyDto.author,
                topic = storyDto.topic,
                complete = storyDto.complete,
                createDate = DateTimeOffset.UtcNow,
                publishDate = DateTimeOffset.UtcNow,
                summary = storyDto.summary,
                listChap = storyDto.listChap,
                numberChap = storyDto.listChap.Length,
                idCom = storyDto.idCom
            };
            Story_Repository.CreateStory(story);
            return CreatedAtAction(nameof(GetStory), new {idStory = story.id},story.AsStoryDto());
        }

        //PUT /stories/{idStory}
        [HttpPut("{idStory}")]
        public ActionResult<StoryDto> UpdateStory(Guid idStory, UpdateStoryDto storyDto)
        {
            var existingStory = Story_Repository.GetStory(idStory);
            if (existingStory is null)
            {
                return NotFound();
            }
            Story updateStory = existingStory with {
               titleStory = storyDto.titleStory,
                author = storyDto.author,
                collector = storyDto.author,
                topic = storyDto.topic,
                complete = storyDto.complete,
                // createDate = DateTimeOffset.UtcNow,
                publishDate = DateTimeOffset.UtcNow,
                summary = storyDto.summary,
                listChap = storyDto.listChap,
                numberChap = storyDto.listChap.Length,
                idCom = storyDto.idCom
            };
            Story_Repository.UpdateStory(updateStory);
            return NoContent();
        }
        
        //DELETE /stories/ {idStory}
        [HttpDelete("{idStory}")]
        public ActionResult DeleteStory(Guid idStory)
        {
            var existingStory = Story_Repository.GetStory(idStory);
            if (existingStory is null)
            {
                return NotFound() ;
            }
            Story_Repository.DeleteStory(idStory);
            return NoContent();
        }
    }
}