using System;

namespace webstory.Dtos
{
    public record UpdateChapterDto
    {

        public string titleChap {get; init;}

        public string idStory {get; init;}

        public string collector {get; init;}
                
        public string content {get; init;}

        
    }
}