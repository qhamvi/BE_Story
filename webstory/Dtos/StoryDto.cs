using System;

namespace webstory.Entities
{
    public record StoryDto
    {
         public Guid id {get; init;}

        public string titleStory {get; init;}

        public string author {get; init;}

        public string collector {get; init;}
        public string[] topic {get; init;}
        public bool complete {get; init;}
        
        public DateTimeOffset createDate {get; init;}

        public DateTimeOffset publishDate {get; init;}
        
        public int numberChap {get; init; } 
        public string[] listChap {get; init;}
        public string summary {get; init;}

        public string[] idCom {get; init;}
    }
}