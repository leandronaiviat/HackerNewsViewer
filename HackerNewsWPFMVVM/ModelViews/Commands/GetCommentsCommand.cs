using System;
using System.Windows.Input;

namespace HackerNewsWPFMVVM.ModelViews.Commands
{
    public class GetCommentsCommand : ICommand
    {
        private CommentsViewModel CommentsViewModel { get; set; }

        public GetCommentsCommand(CommentsViewModel commentsViewModel)
        {
            CommentsViewModel = commentsViewModel;
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
            if (parameter as String == "Back")
            {
                CommentsViewModel.ChangeContext();
            }
            else
            {
                CommentsViewModel.GetMoreComments((int)parameter);
            }
        }

        public bool CanExecute(object parameter)
        {
            return true;
            //return CommentsViewModel.CheckCurrentListName(parameter as String);
        }
    }
}
