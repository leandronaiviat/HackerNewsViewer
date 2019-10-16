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

        public HackerNewsEndPoint() {
            CurrentCollectionIds = new List<int>();
        }

        public async Task<GetStoriesResponse> GetStories(string storyType, int count, int id = 0, string order = "asc")
        {
            if (CurrentStoryType != storyType)
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

            if (index + count > CurrentCollectionIds.Count)
            {
                count = CurrentCollectionIds.Count - index;
            }

            List<int> resultRange = CurrentCollectionIds.GetRange(index, count);

            List<StoryModel> storiesCollection = new List<StoryModel>();

            foreach (var item in resultRange)
            {
                StoryModel result = await GetFromCacheOrApi(item, "story") as StoryModel;
                storiesCollection.Add(result);
            }

            return new GetStoriesResponse
            {
                StoriesCollection = storiesCollection,
                NextItem = CheckIfNextItem(resultRange)
            };
        }

        private int CheckIfNextItem(List<int> resultRange)
        {
            int nextItem = CurrentCollectionIds.FindIndex(a => a == resultRange.Last()) + 1;

            if (nextItem >= CurrentCollectionIds.Count)
            {
                return -1;
            }
            else
            {
                return CurrentCollectionIds[nextItem];
            }
        }

        private async Task<IDataModel> GetFromCacheOrApi(int item, string dataModelType)
        {
            IDataModel isCached = Cache.GetItem(item);
            IDataModel result;

            if (isCached != null)
            {
                result = isCached;
            }
            else
            {
                string url = BaseItemUrl + item.ToString();
                if (dataModelType == "story")
                {
                    result = await HackerNewsApi.ApiHandler<StoryModel>(url);
                }
                else
                {
                    result = await HackerNewsApi.ApiHandler<CommentModel>(url);
                }
                Cache.AddItem(result);
            }

            return result;
        }

        public async Task<List<CommentModel>> GetComments(int parentId, string dataModelType)
        {
            List<CommentModel> commentsCollection = new List<CommentModel>();

            IDataModel parent;

            if(dataModelType == "story")
            {
                parent = await GetFromCacheOrApi(parentId, "story") as StoryModel;

            }
            else
            {
                parent = await GetFromCacheOrApi(parentId, "comment") as CommentModel;
            }


            foreach (var item in parent.Kids)
            {
                CommentModel result = await GetFromCacheOrApi(item, "comment") as CommentModel;
                commentsCollection.Add(result);
            }

            return commentsCollection;
        }
    }
}
