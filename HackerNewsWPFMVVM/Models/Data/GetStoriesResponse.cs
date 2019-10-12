using System.Collections.Generic;

namespace HackerNewsWPFMVVM.Models.Data
{
    public class GetStoriesResponse
    {
        public List<StoryModel> StoriesCollection { get; set; }
        public int NextItem { get; set; }
    }
}
