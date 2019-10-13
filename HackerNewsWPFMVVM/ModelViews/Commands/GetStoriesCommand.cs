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
            this.ViewModel.GetStories(parameter as String);
        }

        public bool CanExecute(object parameter)
        {
            return this.ViewModel.CheckCurrentListName(parameter as String);
        }
    }
}
