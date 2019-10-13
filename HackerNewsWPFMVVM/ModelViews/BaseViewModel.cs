using HackerNewsWPFMVVM.Models.Api;
using HackerNewsWPFMVVM.Models.Data;
using HackerNewsWPFMVVM.ModelViews.Commands;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;

namespace HackerNewsWPFMVVM.ModelViews
{
    public class BaseViewModel : ObservableCollection<StoryModel>
    {
        private string StoryType = "topstories";
        private int Increment = 10;
        //private int Id = 0;
        //private string Order = "asc";
        private int NextItem = 0;

        HackerNewsEndPoint EndPoint = new HackerNewsEndPoint();

        public GetStoriesCommand GetStoriesCommand { get; set; }
        public List<string> MenuItems { get; set; }

        public BaseViewModel()
        {
            this.GetStoriesCommand = new GetStoriesCommand(this);

            MenuItems = new List<string>();
            MenuItems.Add("Best");
            MenuItems.Add("Top");
            MenuItems.Add("New");

            if (DesignerProperties.GetIsInDesignMode(new DependencyObject()))
            {
                Add(new StoryModel { By = "me", Score = 1000, Title = "Pollo" });
                Add(new StoryModel { By = "me", Score = 1000, Title = "Empanadas" });
                Add(new StoryModel { By = "me", Score = 1000, Title = "Chipas" });
            }
        }


        public async void GetStories(string storyType)
        {
            if (CheckCurrentListName(storyType))
            {
                StoryType = storyType.ToLower() + "stories";
                OnPropertyChanged("StoryType");
                NextItem = 0;
                Clear();
            }
            
            var result = await EndPoint.GetStories(StoryType, Increment, NextItem);

            //result.ForEach(x => Add(x));

            NextItem = result.NextItem;

            foreach (var item in result.StoriesCollection)
            {
                Add(item);
            }

        }

        // CommentViewModel : ObservableCollection<List<CommentModel>> OR ObservableCollection<ObservableCollection<CommentModel>>
    }
}
