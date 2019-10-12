using HackerNewsWPFMVVM.Models.Data;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HackerNewsWPFMVVM.Models.Api
{
    public class HackerNewsEndPoint
    {
        private const string BaseStoryUrl = "https://hacker-news.firebaseio.com/v0/";
        private const string BaseItemUrl = "https://hacker-news.firebaseio.com/v0/item/";
        private string CurrentStoryType = "";
        private List<int> CurrentCollectionIds;

        private HackerNewsCaching Cache = new HackerNewsCaching(new MemoryCache(new MemoryCacheOptions()));

        public HackerNewsEndPoint() { }

        public async Task<GetStoriesResponse> GetStories(string storyType, int count, int id = 0, string order = "asc")
        {
            if(CurrentStoryType != storyType)
            {
                CurrentStoryType = storyType;
                string url = BaseStoryUrl + CurrentStoryType;
                CurrentCollectionIds = await HackerNewsApi.ApiHandler<List<int>>(url);
            }

            int index = 0;

            if (id != 0)
            {
                //chequear si el id existe en la lista
                index = CurrentCollectionIds.FindIndex(a => a == id);

                if (order == "desc")
                {
                    index -= count;
                }
            }

            List<int> resultRange = CurrentCollectionIds.GetRange(index, count);

            List<StoryModel> storiesCollection = new List<StoryModel>();

            foreach (var item in resultRange)
            {
                StoryModel result = await GetFromCacheOrApi(item);
                storiesCollection.Add(result);
            }

            var nextItem = CurrentCollectionIds.FindIndex(a => a == resultRange.Last()) + 1;

            return new GetStoriesResponse
            {
                StoriesCollection = storiesCollection,
                NextItem = CurrentCollectionIds[nextItem]
            };
        }

        private async Task<StoryModel> GetFromCacheOrApi(int item)
        {
            StoryModel isCached = Cache.GetItem(item);
            StoryModel result;

            if (isCached != null)
            {
                result = isCached;
            }
            else
            {
                string url = BaseItemUrl + item.ToString();
                result = await HackerNewsApi.ApiHandler<StoryModel>(url);
                Cache.AddItem(result);
            }

            return result;

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
