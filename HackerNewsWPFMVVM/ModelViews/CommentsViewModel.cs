using HackerNewsWPFMVVM.Models.Api;
using HackerNewsWPFMVVM.Models.Data;
using HackerNewsWPFMVVM.ModelViews.Commands;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;

namespace HackerNewsWPFMVVM.ModelViews
{
    public class CommentsViewModel : ObservableCollection<CommentModel>
    {
        HackerNewsEndPoint EndPoint = new HackerNewsEndPoint();
        public GetCommentsCommand GetCommentsCommand { get; set; }

        public List<string> MenuItems { get; set; }

        public CommentsViewModel()
        {
            MenuItems = new List<string>();
            MenuItems.Add("Return");

            this.GetCommentsCommand = new GetCommentsCommand(this);

            GetComments(8863);

            if (DesignerProperties.GetIsInDesignMode(new DependencyObject()))
            {
                Add(new CommentModel { By = "me", Time = 1000, Text = "Pollo" });
                Add(new CommentModel { By = "me", Time = 1000, Text = "Empanadas" });
                Add(new CommentModel { By = "me", Time = 1000, Text = "Chipas" });
            }
        }

        public async void GetComments(int parentId)
        {
            var result = await EndPoint.GetComments(parentId);

            foreach (var item in result)
            {
                Add(item);
            }
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