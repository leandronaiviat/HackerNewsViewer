using System;
using System.Windows.Input;

namespace HackerNewsWPFMVVM.ModelViews.Commands
{
    public class GetStoriesCommand : ICommand
    {
        private StoriesViewModel StoriesViewModel { get; set; }

        public GetStoriesCommand(StoriesViewModel storiesViewModel)
        {
            StoriesViewModel = storiesViewModel;
        }

        /// <summary>
        /// ICommand Interface Implemantation
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void RaiseCanExecuteChanged()
        {
            CommandManager.InvalidateRequerySuggested();
        }

        public void Execute(object parameter)
        {
            StoriesViewModel.GetStories(parameter as String);
        }

        public bool CanExecute(object parameter)
        {
            return StoriesViewModel.CheckCurrentListName(parameter as String);
        }
    }
}
