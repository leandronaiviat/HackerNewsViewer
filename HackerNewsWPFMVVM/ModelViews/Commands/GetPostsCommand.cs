using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace HackerNewsWPFMVVM
{
    public class GetPostsCommand : ICommand
    {
        public BaseViewModel ViewModel { get; set; }

        public GetPostsCommand(BaseViewModel viewModel)
        {
            this.ViewModel = viewModel;
        }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            this.ViewModel.GetPosts();
        }
    }
}
