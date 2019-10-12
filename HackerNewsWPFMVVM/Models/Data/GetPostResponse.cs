using System.Collections.Generic;

namespace HackerNewsWPFMVVM
{
    public class GetPostResponse
    {
        public List<StoryModel> StoriesCollection { get; set; }
        public int NextItem { get; set; }
    }
}
