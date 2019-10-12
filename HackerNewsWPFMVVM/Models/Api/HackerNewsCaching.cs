using HackerNewsWPFMVVM.Models.Data;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;

namespace HackerNewsWPFMVVM.Models.Api
{
    public class HackerNewsCaching
    {
        private IMemoryCache _cache;

        public HackerNewsCaching(IMemoryCache Cache)
        {
            _cache = Cache;
        }

        public void AddItem(StoryModel model)
        {
            _cache.Set<StoryModel>(model.Id.ToString(), model);
        }

        public StoryModel GetItem(int Id)
        {
            StoryModel result;

            bool sucess = _cache.TryGetValue(Id.ToString(), out result);

            if (sucess)
            {
                return result;
            }
            else
            {
                return null;
            }
        }
    }

    //public void GetItems(List<int> collection)
    //{
    //    List<StoryModel> response = new List<StoryModel>();
    //    StoryModel result;

    //    foreach (var item in collection)
    //    {
    //        bool sucess = _cache.TryGetValue(item.ToString(), out result);

    //        if (sucess)
    //        {
    //            response.Add(result);
    //        }
    //        else
    //        {
    //            response.Add
    //        }

    //    }
    //}
}
}
