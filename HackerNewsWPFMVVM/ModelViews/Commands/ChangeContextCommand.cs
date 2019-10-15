using HackerNewsWPFMVVM.Models.Data;
using System;
using System.Windows.Input;

namespace HackerNewsWPFMVVM.ModelViews.Commands
{
    public class ChangeContextCommand : ICommand
    {
        private StoriesViewModel StoriesViewModel { get; set; }

        public ChangeContextCommand(StoriesViewModel storiesViewModel)
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
            StoriesViewModel.ChangeContext((int)parameter);
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }
    }
}
