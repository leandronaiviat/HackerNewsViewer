using HackerNewsWPFMVVM.Models.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HackerNewsWPFMVVM.Models.Api
{
    public class HackerNewsEndPoint
    {
        private const string BaseStoryUrl = "https://hacker-news.firebaseio.com/v0/";
        private const string BaseItemUrl = "https://hacker-news.firebaseio.com/v0/item/";

        public HackerNewsEndPoint() { }

        public async Task<GetStoriesResponse> GetStories(string storyType, int count, int id = 0,  string order = "asc")
        {
            string url = BaseStoryUrl + storyType;

            var resultIds = await HackerNewsApi.ApiHandler<List<int>>(url);
            
            int index = 0;

            if (id != 0)
            {
                //chequear si el id existe en la lista
                index = resultIds.FindIndex(a => a == id);
                
                if(order == "desc")
                {
                    index -= count;
                }
            }

            List<int> resultRange = resultIds.GetRange(index, count);

            List<StoryModel> storiesCollection = new List<StoryModel>();

            foreach (var item in resultRange)
            {
                url = BaseItemUrl + item.ToString();
                var result = await HackerNewsApi.ApiHandler<StoryModel>(url);
                storiesCollection.Add(result);
            }

            var nextItem = resultIds.FindIndex(a => a == resultRange.Last()) + 1;

            return new GetStoriesResponse
            {
                StoriesCollection = storiesCollection,
                NextItem = resultIds[nextItem]
            };
        }

        public async Task<List<CommentModel>> GetComments(StoryModel parent)
        {
            string url = BaseItemUrl;

            List<CommentModel> commentsCollection = new List<CommentModel>();

            foreach (var item in parent.Kids)
            {
                var result = await HackerNewsApi.ApiHandler<CommentModel>(url + item.ToString());
                commentsCollection.Add(result);
            }

            return commentsCollection;
        }
    }
}
