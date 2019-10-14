using HackerNewsWPFMVVM.Models.Api;
using HackerNewsWPFMVVM.Models.Data;
using HackerNewsWPFMVVM.ModelViews.Commands;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;

namespace HackerNewsWPFMVVM.ModelViews
{
    public class StoriesViewModel : ObservableCollection<StoryModel>
    {
        private string StoryItemApiName = "";
        private int Increment = 10;
        //private int Id = 0;
        //private string Order = "asc";
        private int NextItem = 0;
        private string StoryType;

        HackerNewsEndPoint EndPoint = new HackerNewsEndPoint();
        public GetStoriesCommand GetStoriesCommand { get; set; }

        public StoriesViewModel()
        {
            this.GetStoriesCommand = new GetStoriesCommand(this);

            GetStories("top");

            if (DesignerProperties.GetIsInDesignMode(new DependencyObject()))
            {
                Add(new StoryModel { By = "me", Score = 1000, Title = "Pollo" });
                Add(new StoryModel { By = "me", Score = 1000, Title = "Empanadas" });
                Add(new StoryModel { By = "me", Score = 1000, Title = "Chipas" });
            }
        }

        public async void GetStories(string storyType)
        {
            StoryType = storyType;

            if (CheckCurrentListName(storyType) && storyType != "Next")
            {
                StoryItemApiName = storyType.ToLower() + "stories";
                OnPropertyChanged("StoryItemApiName");
                NextItem = 0;
                Clear();
            }

            var result = await EndPoint.GetStories(StoryItemApiName, Increment, NextItem);

            //result.ForEach(x => Add(x));

            if (StoryType == storyType)
            {
                NextItem = result.NextItem;

                if (NextItem < 0)
                {
                    GetStoriesCommand.RaiseCanExecuteChanged();
                }

                foreach (var item in result.StoriesCollection)
                {
                    Add(item);
                }
            }
        }

        public bool CheckCurrentListName(string parameter)
        {
            if (NextItem < 0 && parameter == "Next")
                return false;

            if (parameter.ToUpper() + "STORIES" == StoryItemApiName.ToUpper())
                return false;

            return true;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        // CommentViewModel : ObservableCollection<List<CommentModel>> OR ObservableCollection<ObservableCollection<CommentModel>>
    }
}
