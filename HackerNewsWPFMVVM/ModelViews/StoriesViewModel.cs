using HackerNewsWPFMVVM.Helpers;
using HackerNewsWPFMVVM.Models.Api;
using HackerNewsWPFMVVM.Models.Data;
using HackerNewsWPFMVVM.ModelViews.Commands;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

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

        HackerNewsEndPoint EndPoint;
        public GetStoriesCommand GetStoriesCommand { get; set; }
        public ChangeContextCommand ChangeContextCommand { get; set; }
        public GoToUrlCommand GoToUrlCommand { get; set; }

        public List<string> MenuItems { get; set; }

        private bool _IsLoading;
        public bool IsLoading
        {
            get
            {
                return _IsLoading;
            }
            set
            {
                _IsLoading = value;
                RaisePropertyChanged(nameof(IsLoading));
                CommandManager.InvalidateRequerySuggested();
            }
        }


        public StoriesViewModel()
        {
            EndPoint = Singleton.EndPoint;

            MenuItems = new List<string>();
            MenuItems.Add("Best");
            MenuItems.Add("Top");
            MenuItems.Add("New");
            MenuItems.Add("Ask");

            this.GetStoriesCommand = new GetStoriesCommand(this);
            this.ChangeContextCommand = new ChangeContextCommand(this);
            this.GoToUrlCommand = new GoToUrlCommand(this);

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
            IsLoading = true;
            StoryType = storyType;

            if (CheckCurrentListName(storyType) && storyType != "Next")
            {
                StoryItemApiName = storyType.ToLower() + "stories";
                //OnPropertyChanged("StoryItemApiName");
                NextItem = 0;
                Clear();
            }

            GetStoriesResponse result = await EndPoint.GetStories(StoryItemApiName, Increment, NextItem);

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

            IsLoading = false;
        }

        public bool CheckCurrentListName(string parameter)
        {
            if (IsLoading == true && parameter == "Next")
                return false;

            if (IsLoading == false && parameter == "Next")
                return true;

            if (NextItem < 0 && parameter == "Next")
                return false;

            if (parameter.ToUpper() + "STORIES" == StoryItemApiName.ToUpper())
                return false;

            return true;
        }

        public void ChangeContext(int storyId)
        {
            ((MainWindow)Application.Current.MainWindow).StoryId = storyId;
            ((MainWindow)Application.Current.MainWindow).DataContext = new CommentsViewModel();
        }

        public void GoToUrl(string url)
        {
            Browser.Open(url);
        }

        public void RaisePropertyChanged(string s)
        {
            OnPropertyChanged(new PropertyChangedEventArgs(s));
        }
    }
}
