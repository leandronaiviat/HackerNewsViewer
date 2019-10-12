using System;
using System.Windows.Input;

namespace HackerNewsWPFMVVM.ModelViews.Commands
{
    public class GetStoriesCommand : ICommand
    {
        public BaseViewModel ViewModel { get; set; }

        public GetStoriesCommand(BaseViewModel viewModel)
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
            this.ViewModel.GetStories();
        }
    }
}
