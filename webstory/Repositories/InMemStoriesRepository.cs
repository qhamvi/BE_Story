using System;
using System.Collections.Generic;
using System.Linq;
using webstory.Entities;
namespace webstory.Repositories 
{
    public class InMemStoriesRepository : SStoriesRepository
    {
        private static List<Story> stories = new()
        {
            new Story
            {
                id = Guid.NewGuid(),
                titleStory = "Cau truyen1",
                author = "vivi",
                collector = "vi22",
                topic = new String[] { "Hello", "Xin chào", "Hula" },
                complete = false,
                createDate = DateTimeOffset.UtcNow,
                publishDate = DateTimeOffset.UtcNow,
                summary = "Tom tat cua truyen 1 la ......",
                listChap = new String[] { "idChap1", "idChap2" },
                idCom = new String[] { "idCom1", "idCom2" }
            },

            new Story
            {
                id = Guid.NewGuid(),
                titleStory = "Cau truyen2",
                author = "vivi",
                collector = "vi22",
                topic = new String[] { "Hello", "Xin chào", "Hula" },
                complete = false,
                createDate = DateTimeOffset.UtcNow,
                publishDate = DateTimeOffset.UtcNow,
                summary = "Tom tat cua truyen 1 la ......",
                listChap = new String[] { "idChap1", "idChap2" },
                idCom = new String[] { "idCom1", "idCom2" }
            },

            new Story
            {
                id = Guid.NewGuid(),
                titleStory = "Cau truyen3",
                author = "vivi",
                collector = "vi22",
                topic = new String[] { "Hello", "Xin chào", "Hula" },
                complete = false,
                createDate = DateTimeOffset.UtcNow,
                publishDate = DateTimeOffset.UtcNow,
                summary = "Tom tat cua truyen 1 la ......",
                listChap = new String[] { "idChap1", "idChap2" },
                idCom = new String[] { "idCom1", "idCom2" }
            }
        };
        public IEnumerable<Story> GetStories()
        {
            return stories;
        }
        public Story GetStory(Guid idStory)
        {
            return stories.Where(story => story.id == idStory).SingleOrDefault();
        }
        public void CreateStory(Story story)
        {
            stories.Add(story);

        }
        public void UpdateStory(Story story)
        {
            var index = stories.FindIndex(existingStory => existingStory.id == story.id);
            stories[index] = story;
        }
        public void DeleteStory(Guid idStory)
        {
            var index = stories.FindIndex(existingStory => existingStory.id == idStory);
            stories.RemoveAt(index);
        }
    }
}